

namespace Unifrik.Common.Shared.Utils
{
    public static class DeliverySpecializations
    {
        private static readonly List<string> _specializations = new()
        {
            "Intercity Delivery",          // Between major cities in the same country
            "Intracity Delivery",          // Within the same city
            "Cross-border Delivery",       // Across African country borders
            "Rural Area Delivery",         // Hard-to-reach rural or semi-urban locations
            "Express Delivery",            // Fast-track delivery (same-day/next-day)
            "Bulk Cargo Handling",         // For large/heavy goods
            "Cold Chain Delivery",         // Perishables (e.g., food, medicine)
            "Last-Mile Delivery",          // Final leg to customer’s location
            "Scheduled Delivery",          // Delivery at a chosen date/time
            "Pickup & Drop-off Service"    // From vendor location to customer
        };

        public static IEnumerable<string> GetAll()
        {
            return _specializations.AsReadOnly();
        }
    }
}

