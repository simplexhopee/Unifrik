


    namespace Unifrik.Common.Shared.Utils
    {
        public static class AllCountries
        {
            private static readonly Dictionary<string, List<string>> _regionCountries = new()
            {
                ["North Africa"] = new()
            {
                "Algeria", "Egypt", "Libya", "Mauritania", "Morocco", "Sudan", "Tunisia"
            },
                ["West Africa"] = new()
            {
                "Benin", "Burkina Faso", "Cabo Verde", "Côte d'Ivoire", "Gambia", "Ghana", "Guinea",
                "Guinea-Bissau", "Liberia", "Mali", "Niger", "Nigeria", "Senegal", "Sierra Leone", "Togo"
            },
                ["Central Africa"] = new()
            {
                "Angola", "Cameroon", "Central African Republic", "Chad", "Republic of the Congo",
                "Democratic Republic of the Congo", "Equatorial Guinea", "Gabon", "São Tomé and Príncipe"
            },
                ["East Africa"] = new()
            {
                "Burundi", "Comoros", "Djibouti", "Eritrea", "Ethiopia", "Kenya", "Madagascar",
                "Malawi", "Mauritius", "Mozambique", "Rwanda", "Seychelles", "Somalia", "South Sudan",
                "Tanzania", "Uganda", "Zambia", "Zimbabwe"
            },
                ["Southern Africa"] = new()
            {
                "Botswana", "Eswatini", "Lesotho", "Namibia", "South Africa"
            }
            };

            /// <summary>
            /// All countries in Africa (flat list).
            /// </summary>
            public static IEnumerable<string> GetAllCountries => _regionCountries
                .SelectMany(kv => kv.Value)
                .Distinct()
                .OrderBy(c => c);

            /// <summary>
            /// All regions.
            /// </summary>
            public static IEnumerable<string> GetAllRegions => _regionCountries.Keys.OrderBy(r => r);

            /// <summary>
            /// Get countries in a specific region.
            /// </summary>
            public static IEnumerable<string> GetCountriesByRegion(string region)
            {
                return _regionCountries.TryGetValue(region, out var countries)
                    ? countries.OrderBy(c => c)
                    : Enumerable.Empty<string>();
            }
        }
    }


