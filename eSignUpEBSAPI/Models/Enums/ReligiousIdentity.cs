using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (member name "CodeNN") with the numeric DB id as the value.
    /// Description attribute contains the friendly name.
    /// Note: source code '99' maps to NULL in SQL and is therefore not included here.
    /// </summary>
    public enum ReligiousIdentity
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("No religion")]
        Code01 = 11,   // '01' => 11

        [Description("Buddhist")]
        Code02 = 3,    // '02' => 3

        [Description("Other")]
        Code05 = 10,   // '05' => 10 (Roman Catholic -> Other)
        [Description("Other")]
        Code06 = 10,   // '06' => 10 (Presbyterian Church in Ireland -> Other)
        [Description("Other")]
        Code07 = 10,   // '07' => 10 (Church of Ireland -> Other)
        [Description("Other")]
        Code08 = 10,   // '08' => 10 (Methodist -> Other)

        [Description("Christian")]
        Code09 = 1,    // '09' => 1 (Other Christian -> Christian)

        [Description("Hindu")]
        Code10 = 5,    // '10' => 5

        [Description("Jewish")]
        Code11 = 2,    // '11' => 2

        [Description("Muslim")]
        Code12 = 4,    // '12' => 4

        [Description("Sikh")]
        Code13 = 6,    // '13' => 6

        [Description("Other")]
        Code80 = 10,   // '80' => 10 (Other Religion -> Other)

        [Description("Prefer not to say")]
        Code98 = 7     // '98' => 7
    }

    public static class ReligiousIdentityHelper
    {
        /// <summary>
        /// Return the numeric DB id for a source code (e.g. "01" or "Code01"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            // Accept plain numeric ("01") or "Code01" forms
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString("D2");

            if (Enum.TryParse<ReligiousIdentity>(trimmed, true, out var val))
                return (int)val;

            return null;
        }

        /// <summary>
        /// Try get the numeric id for a source code.
        /// </summary>
        public static bool TryGetID(string? code, out int id)
        {
            var val = ToID(code);
            if (val.HasValue)
            {
                id = val.Value;
                return true;
            }
            id = default;
            return false;
        }

        /// <summary>
        /// Get the Description attribute (friendly name) for a ReligiousIdentity enum value.
        /// </summary>
        public static string? GetFriendlyName(this ReligiousIdentity value)
        {
            var fi = typeof(ReligiousIdentity).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a source code (returns null if unknown).
        /// Accepts "01" or "Code01" (case-insensitive).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString("D2");

            if (Enum.TryParse<ReligiousIdentity>(trimmed, true, out var val))
                return val.GetFriendlyName();

            return null;
        }

        /// <summary>
        /// Convenience: map code to tuple (id, friendlyName). id will be null for unknown code.
        /// </summary>
        public static (int? id, string? friendlyName) Map(string? code)
        {
            return (ToID(code), GetFriendlyNameFromCode(code));
        }
    }
}