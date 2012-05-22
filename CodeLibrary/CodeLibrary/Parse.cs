using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeLibrary
{
    public class Parse : SingletonBase<Parse>
    {
        private Parse() { }

        public T To<T>(object value) { return To<T>(value, default(T)); }

        public T To<T>(object value, T failValue)
        {
            try { return (T)Convert.ChangeType(value, typeof(T)); }
            catch { return failValue; }
        }
    }

    public static class ParseExtenstions
    {
        public static T To<T>(this object value)
        {
            return Parse.Instance.To<T>(value);
        }

        public static T To<T>(this object value, T failValue)
        {
            return Parse.Instance.To<T>(value, failValue);
        }
    }
}
