using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;


namespace Unifrik.Infrastructure.Shared.Configuration
{
    public static class ConfigurationPlaceholderExtensions
    {
        /// <summary>
        /// Replaces ${ENV_VAR} placeholders in the configuration recursively.
        /// </summary>
        public static IConfiguration ReplacePlaceholders(this IConfiguration configuration)
        {
            if (configuration is IConfigurationRoot root)
            {
                foreach (var provider in root.Providers)
                {
                    ReplaceInProvider(provider);
                }
            }

            return configuration;
        }

        private static void ReplaceInProvider(IConfigurationProvider provider)
        {
            var keys = GetAllKeys(provider);
            foreach (var key in keys)
            {
                if (provider.TryGet(key, out var value) && value != null)
                {
                    var replaced = ReplaceEnvPlaceholders(value);
                    provider.Set(key, replaced);
                }
            }
        }

        private static IEnumerable<string> GetAllKeys(IConfigurationProvider provider)
        {
            var keys = new List<string>();
            provider.Load();
            provider.TryGet("", out _); // Prime the provider
            provider.GetChildKeys(Enumerable.Empty<string>(), null)
                    .ToList()
                    .ForEach(k => keys.Add(k));

            return keys;
        }

        private static string ReplaceEnvPlaceholders(string value)
        {
            return Regex.Replace(value, @"\$\{(?<var>[A-Z0-9_]+)\}", match =>
            {
                var envVar = match.Groups["var"].Value;
                var envValue = Environment.GetEnvironmentVariable(envVar);
                return !string.IsNullOrEmpty(envValue) ? envValue : match.Value;
            });
        }
    }
}


