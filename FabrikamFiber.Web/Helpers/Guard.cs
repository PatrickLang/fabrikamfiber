namespace FabrikamFiber.Web.Helpers
{
    using System;

    public static class Guard
    {
        public static void ThrowIfNull(object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }

        public static void ThrowIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(name);
        }

        public static void ThrowIfLesserThanZero(int value, string name)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(name);
        }
    }
}