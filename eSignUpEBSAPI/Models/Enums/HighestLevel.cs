using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (member name "CodeNN") with the numeric DB id as the value.
    /// Description attribute contains the friendly name.
    /// </summary>
    public enum HighestLevel
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Entry Level (Entry level award / essential skills)")]
        Code1 = 1,    // '1' -> 1

        [Description("Level 1 (GCSE grades 3-1; D-G; or fewer than 5 grades 9-4; Level 1 award)")]
        Code2 = 3,    // '2' -> 3

        [Description("Level 2 (At least 5 GCSE grades 9-4; Level 2 award; Int app)")]
        Code3 = 13,   // '3' -> 13

        [Description("Full level 2 (5 GCSEs 9-4; A*-C; Level 2 diploma; Intermediate apprenticeship)")]
        Code4 = 4,    // '4' -> 4

        [Description("Level 3 (A/AS-Level; Level 3 award; Advanced apprenticeship; T-Level)")]
        Code5 = 14,   // '5' -> 14

        [Description("Full level 3 (2 A-Levels; Level 3 diploma; Advanced apprenticeship)")]
        Code6 = 5,    // '6' -> 5

        [Description("Level 4 (HNC; Level 4 award; Higher apprenticeship)")]
        Code7 = 6,    // '7' -> 6

        [Description("Level 5 (HND; Foundation Degree; Level 5 award)")]
        Code8 = 7,    // '8' -> 7

        [Description("Level 6 (Degree; Level 6 award; Graduate certificate; Degree apprenticeship)")]
        Code9 = 8,    // '9' -> 8

        [Description("Level 7 and above (Masters degree; Postgraduate certificate; Level 7 award)")]
        Code10 = 9,   // '10' -> 9

        [Description("Other qualification, level not known")]
        Code97 = 10,  // '97' -> 10

        [Description("Not known")]
        Code98 = 11,  // '98' -> 11

        [Description("No qualifications")]
        Code99 = 12   // '99' -> 12
    }

    public static class HighestLevelHelper
    {
        /// <summary>
        /// Return the numeric DB id for a source code (e.g. "1" or "Code1"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            // Accept plain numeric ("1") or "Code1" forms
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<HighestLevel>(trimmed, true, out var val))
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
        /// Get the Description attribute (friendly name) for a HighestLevel enum value.
        /// </summary>
        public static string? GetFriendlyName(this HighestLevel value)
        {
            var fi = typeof(HighestLevel).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a source code (returns null if unknown).
        /// Accepts "1" or "Code1" (case-insensitive).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<HighestLevel>(trimmed, true, out var val))
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