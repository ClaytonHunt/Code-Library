using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CodeLibrary
{
    public class SingletonBase<T>
    {
        private static class SingletonHolder<T1>
        {
            internal static readonly T1 instance = (T1)typeof(T1)
                .GetConstructors(BindingFlags.Instance | 
                    BindingFlags.CreateInstance | 
                    BindingFlags.NonPublic)
                .SingleOrDefault()
                .Invoke(null);
            // Empty static constructor - forces laziness
            static SingletonHolder() { }
        }
        public static T Instance 
        { 
            get 
            { 
                return SingletonHolder<T>.instance; 
            } 
        }
    }
}
