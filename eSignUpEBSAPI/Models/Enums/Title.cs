using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (enum member name) with the numeric DB id as the value.
    /// Description attribute contains the friendly display name.
    /// Source codes that map to NULL (e.g. 'MX') are not included.
    /// </summary>
    public enum Title
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Dr.")]
        DR = 4,

        [Description("Miss.")]
        MISS = 3,

        [Description("Mr.")]
        MR = 1,

        [Description("Mrs.")]
        MRS = 2,

        [Description("Ms.")]
        MS = 5
    }

    public static class TitleHelper
    {
        /// <summary>
        /// Return the numeric DB id for a title code (e.g. "MR"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            if (Enum.TryParse<Title>(code.Trim(), true, out var val))
                return (int)val;

            return null;
        }

        /// <summary>
        /// Try get the numeric id for a title code.
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
        /// Get the Description attribute (friendly name) for a Title enum value.
        /// </summary>
        public static string? GetFriendlyName(this Title value)
        {
            var fi = typeof(Title).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a title code (returns null if unknown).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
            if (Enum.TryParse<Title>(code.Trim(), true, out var val))
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