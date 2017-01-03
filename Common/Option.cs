using System;
using System.Collections.Generic;

namespace NullReferencesDemo.Common
{
    public class Option<T>: IEnumerable<T>
    {
        private T[] data;
        
        private Option(T[] data)
        {
            this.data = data;
        }

        public static Option<T> Create(T element)
        {
            return new Option<T>(new T[] { element });
        }

        public static Option<T> CreateEmpty()
        {
            return new Option<T>(new T[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.data).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
