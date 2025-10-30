using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (member name) with the numeric DB id as the value.
    /// Description attribute contains the friendly name.
    /// Source codes that map to NULL in the SQL CASE (e.g. 'X', 'TFFB', 'TMMB') are not included.
    /// </summary>
    public enum GenderIdentity
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Female")]
        F = 1,

        [Description("GNC")]
        GNC = 4,

        [Description("Intersex")]
        IS = 3,

        [Description("Male")]
        M = 2,

        [Description("Non-binary")]
        NB = 5,

        [Description("Trans female (AMAB)")]
        TFMB = 7,

        [Description("Trans male (AFAB)")]
        TMFB = 6
    }

    public static class GenderIdentityHelper
    {
        /// <summary>
        /// Return the numeric DB id for a source code (e.g. "F" or "TFMB"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            if (Enum.TryParse<GenderIdentity>(trimmed, true, out var val))
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
        /// Get the Description attribute (friendly name) for a GenderIdentity enum value.
        /// </summary>
        public static string? GetFriendlyName(this GenderIdentity value)
        {
            var fi = typeof(GenderIdentity).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a source code (returns null if unknown).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            if (Enum.TryParse<GenderIdentity>(code.Trim(), true, out var val))
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