namespace ServisYonetimPanel.Core.Web.API.Values
{
    using System;

    public static class AppValues
    {
        private static Lazy<Guid> guid = new Lazy<Guid>(() => { return Guid.NewGuid(); });

        public static Guid ActivityId => guid.Value;
    }
}