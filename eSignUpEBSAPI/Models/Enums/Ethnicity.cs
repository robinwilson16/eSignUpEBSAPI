using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (member name "CodeNN") with the numeric DB id as the value.
    /// Description attribute contains the friendly name.
    /// </summary>
    public enum Ethnicity
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Black/African/Caribbean - African")]
        Code44 = 15,
        [Description("Asian/Asian Black - Any other")]
        Code43 = 14,
        [Description("Black/African/Caribbean - Any other")]
        Code46 = 17,
        [Description("Other ethnic group - Any other")]
        Code98 = 19,
        [Description("Mixed/Multiple ethnic group - Any other")]
        Code38 = 9,
        [Description("White - Any other white background")]
        Code34 = 5,
        [Description("Other ethnic group - Arab")]
        Code47 = 18,
        [Description("Asian/Asian Black - Bangladeshi")]
        Code41 = 12,
        [Description("Black/African/Caribbean - Caribbean")]
        Code45 = 16,
        [Description("Asian/Asian Black - Chinese")]
        Code42 = 13,
        [Description("White - English/Welsh/Scottish/Northern Irish/British")]
        Code31 = 1,
        [Description("White - Gypsy or Irish Traveller")]
        Code33 = 3,
        [Description("Asian/Asian Black - Indian")]
        Code39 = 10,
        [Description("White - Irish")]
        Code32 = 2,
        [Description("Not Provided")]
        Code99 = 20,
        [Description("Asian/Asian Black - Pakistani")]
        Code40 = 11,
        // Codes 37,36,35 map to 5 (Any other white background)
        [Description("White - Any other white background")]
        Code37 = 5,
        [Description("White - Any other white background")]
        Code36 = 5,
        [Description("White - Any other white background")]
        Code35 = 5
    }

    public static class EthnicityHelper
    {
        /// <summary>
        /// Return the numeric DB id for a source code (e.g. "44" or "Code44"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            // If code is numeric like "44" convert to member name "Code44"
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<Ethnicity>(trimmed, true, out var val))
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
        /// Get the Description attribute (friendly name) for an Ethnicity enum value.
        /// </summary>
        public static string? GetFriendlyName(this Ethnicity value)
        {
            var fi = typeof(Ethnicity).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a source code (returns null if unknown).
        /// Accepts "44" or "Code44" or "Code44" case-insensitive.
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<Ethnicity>(trimmed, true, out var val))
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