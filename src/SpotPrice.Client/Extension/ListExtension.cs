using System.Collections.Generic;

namespace SpotPrice.Client.Extension
{
    internal static class ListExtension
    {
        public static void AddRange<T>(
            this IList<T> collection, IEnumerable<T> items)
        {
            if (collection is List<T> list)
            {
                list.AddRange(items);
            }
            else
            {
                foreach (var item in items)
                    collection.Add(item);
            }
        }
    }
}
