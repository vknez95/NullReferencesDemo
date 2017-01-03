using System;
using System.Collections.Generic;

namespace NullReferencesDemo.Common
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);
        }

        public static IEnumerable<T> LazyDefaultIfEmpty<T>(this IEnumerable<T> source,
                                                           Func<T> defaultFactory)
        {
            bool isEmpty = true;
            
            foreach (T value in source)
            {
                yield return value;
                isEmpty = false;
            }

            if (isEmpty)
                yield return defaultFactory();

        }
    }
}
