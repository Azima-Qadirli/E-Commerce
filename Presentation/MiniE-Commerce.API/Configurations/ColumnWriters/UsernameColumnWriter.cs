using Serilog.Core;
using Serilog.Events;

namespace MiniE_Commerce.API.Configurations.ColumnWriters
{
    public class UsernameColumnWriter : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var (username, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "Username");
            if (value is null)
            {
                var getValue = propertyFactory.CreateProperty(username, value);
                logEvent.AddPropertyIfAbsent(getValue);
            }
        }
    }
}
