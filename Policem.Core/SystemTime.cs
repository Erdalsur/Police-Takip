using System;

namespace Policem.Core
{
    public interface ISystemTimeProvider
    {
        DateTime Now { get; }

        DateTime Today { get; }

        DateTime MinValue { get; }
    }

    internal class DateTimeProvider : ISystemTimeProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Today;

        public DateTime MinValue => DateTime.MinValue;
    }

    public static class SystemTime
    {
        private static ISystemTimeProvider _provider;

        static SystemTime()
        {
            Reset();
        }

        public static void Reset()
        {
            _provider = new DateTimeProvider();
        }

        public static void SetProvider(ISystemTimeProvider provider)
        {
            _provider = provider;
        }

        public static DateTime Now => _provider.Now;

        public static DateTime Today => _provider.Today;

        public static DateTime MinValue => _provider.MinValue;
    }
}
