using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using Flurl;
using Flurl.Http;
using SpotPrice.Model;
using SpotPrice.Request;
using SpotPrice.Request.Builder;
using SpotPrice.Error;

namespace SpotPrice
{
    public class SpotPriceService : ISpotPriceService
    {
        public const string BaseUrl = "https://api.spot-hinta.fi";

        public async Task<int> GetRankAsync()
        {
            return await ExecuteAsync(async () =>
            {
                var response = await BaseUrl
                    .AppendPathSegment("JustNowRank")
                    .GetStringAsync();

                return int.Parse(response);
            });
        }

        public async Task<IPriceModel> GetPriceAsync()
        {
            return await ExecuteAsync(async () =>
            {
                var response = await BaseUrl
                    .AppendPathSegment("JustNow")
                    .GetJsonAsync<PriceModel>();

                return response;
            });
        }

        public async Task<IList<IPriceModel>> GetPricesAsync(
            Action<IGetPricesRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    IGetPricesRequest, IGetPricesRequestBuilder>(
                        builder, new GetPricesRequestBuilder());
                var response = await BaseUrl
                    .AppendPathSegment(request.Path)
                    .GetJsonAsync<IList<PriceModel>>();

                return response.Cast<IPriceModel>().ToList();
            });
        }

        public async Task<IPricePeriodModel> GetCheapestPeriodAsync(
            Action<IGetCheapestPriceRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    IGetCheapestPriceRequest, IGetCheapestPriceRequestBuilder>(
                        builder, new GetCheapestPriceRequestBuilder());
                var response = await BaseUrl
                    .AppendPathSegment("CheapestPeriod")
                    .AppendPathSegment(request.Hours)
                    .GetJsonAsync<PricePeriodModel>();

                return response;
            });
        }

        public async Task<IList<ITemperatureModel>> GetTemperaturesAsync(
            Action<IGetTemperatureRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    IGetTemperatureRequest, IGetTemperatureRequestBuilder>(
                        builder, new GetTemperatureRequestBuilder());
                var response = await BaseUrl
                    .AppendPathSegment("PostalCodeTemperatures")
                    .AppendPathSegment(request.PostalCode)
                    .GetJsonAsync<IList<TemperatureModel>>();

                return response.Cast<ITemperatureModel>().ToList();
            });
        }

        public async Task<IPriceCheckModel> CheckPriceAsync(
            Action<ICheckPriceRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    ICheckPriceRequest, ICheckPriceRequestBuilder>(
                        builder, new CheckPriceRequestBuilder());

                IFlurlResponse response;
                if (request.HasRank && request.HasPrice)
                    response = await BaseUrl
                        .AppendPathSegment("JustNowRank")
                        .AppendPathSegment(request.Rank.Value)
                        .AppendPathSegment(request.Price.Value)
                        .SetQueryParam("boosterHours", string.Join(",", request.BoosterHours))
                        .AllowHttpStatus(HttpStatusCode.BadRequest)
                        .GetAsync();
                else if (request.HasRank)
                    response = await BaseUrl
                        .AppendPathSegment("JustNowRank")
                        .AppendPathSegment(request.Rank.Value)
                        .SetQueryParam("boosterHours", string.Join(",", request.BoosterHours))
                        .AllowHttpStatus(HttpStatusCode.BadRequest)
                        .GetAsync();
                else
                    response = await BaseUrl
                        .AppendPathSegment("JustNow")
                        .AppendPathSegment(request.Price.Value)
                        .AllowHttpStatus(HttpStatusCode.BadRequest)
                        .GetAsync();

                return new PriceCheckModel(
                    response.StatusCode == 200,
                    await response.GetStringAsync());
            });
        }

        public async Task<IPriceCheckModel> CheckPriceExtendedAsync(
            Action<ICheckPriceExtendedRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    ICheckPriceExtendedRequest, ICheckPriceExtendedRequestBuilder>(
                        builder, new CheckPriceExtendedRequestBuilder());
                var response = await BaseUrl
                        .AppendPathSegment("JustNowRankDynamic")
                        .SetQueryParam("rankAtZeroDegrees", request.RankAtZeroDegrees.Value)
                        .SetQueryParam("rankAdjusterPercentage", request.RankAdjusterPercentage.Value)
                        .SetQueryParam("minimumRank", request.MinimumRank.Value)
                        .SetQueryParam("priceAlwaysAllowed", request.PriceAlwaysAllowed.Value)
                        .SetQueryParam("postalCode", request.PostalCode)
                        .SetQueryParam("boosterHours", string.Join(",", request.BoosterHours))
                        .SetQueryParam("debugMode", request.DebugMode.ToString().ToLower())
                        .AllowHttpStatus(HttpStatusCode.BadRequest)
                        .GetAsync();

                return new PriceCheckModel(
                    response.StatusCode == 200,
                    await response.GetStringAsync());
            });
        }

        public async Task<bool> CheckCheapestPeriodAsync(
            Action<IGetCheapestPriceRequestBuilder> builder)
        {
            return await ExecuteAsync(async () =>
            {
                var request = Build<
                    IGetCheapestPriceRequest, IGetCheapestPriceRequestBuilder>(
                        builder, new GetCheapestPriceRequestBuilder());
                var response = await BaseUrl
                    .AppendPathSegment("CheapestPeriodTodayCheck")
                    .AppendPathSegment(request.Hours)
                    .SetQueryParam("boosterHours", string.Join(",", request.BoosterHours))
                    .AllowHttpStatus(HttpStatusCode.BadRequest)
                    .GetAsync();

                return response.StatusCode == 200;
            });
        }

        private TRequest Build<TRequest, TRequestBuilder>(
            Action<TRequestBuilder> builder, TRequestBuilder requestBuilder)
            where TRequestBuilder : IRequestBuilder<TRequest>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            try
            {
                builder(requestBuilder);
                return requestBuilder.Build();
            }
            catch (Exception exc)
            {
                throw new SpotPriceSystemException(
                    "Failed to build request", exc);
            }
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(
            Func<Task<TResponse>> action)
        {
            try
            {
                return await action();
            }
            catch (FlurlHttpException exc)
            {
                if (exc.StatusCode != null &&
                    exc.StatusCode == 404)
                    throw new SpotPriceNotFoundException(
                        "Data not found", exc);
                else if (exc.StatusCode != null &&
                    exc.StatusCode == 429)
                    throw new SpotPriceOverloadedException(
                        "Too many requests from this IP address", exc);
                else
                    throw new SpotPriceSystemException(
                        "Failed to fetch data", exc);
            }
        }
    }
}
