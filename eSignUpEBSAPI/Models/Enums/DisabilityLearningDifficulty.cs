using System;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (member name "CodeNN") with the numeric DB id as the value.
    /// Description attribute contains the friendly name.
    /// </summary>
    public enum DisabilityLearningDifficulty
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Asperger's syndrome")]
        Code15 = 12, // '15' -> 12

        [Description("Autism spectrum disorder")]
        Code14 = 11, // '14' -> 11

        [Description("Disability affecting mobility")]
        Code6 = 3, // '6' -> 3

        [Description("Down Syndrome")]
        Code18 = 22, // '18' -> 22

        [Description("Dyscalculia")]
        Code13 = 10, // '13' -> 10

        [Description("Dyslexia")]
        Code12 = 9, // '12' -> 9

        [Description("Hearing impairment")]
        Code5 = 2, // '5' -> 2

        [Description("Mental health difficulty")]
        Code9 = 6, // '9' -> 6

        [Description("Moderate learning difficulty")]
        Code10 = 7, // '10' -> 7

        [Description("Not provided")]
        Code99 = 21, // '99' -> 21

        [Description("Other disability")]
        Code97 = 19, // '97' -> 19

        [Description("Other learning difficulty")]
        Code96 = 18, // '96' -> 18

        [Description("Other medical condition (for example epilepsy, asthma, diabetes)")]
        Code95 = 17, // '95' -> 17

        [Description("Other physical disability")]
        Code93 = 15, // '93' -> 15

        [Description("Other specific learning difficulty (e.g. Dyspraxia)")]
        Code94 = 16, // '94' -> 16

        [Description("Prefer not to say")]
        Code98 = 20, // '98' -> 20

        [Description("Profound complex disabilities")]
        Code7 = 4, // '7' -> 4

        [Description("Severe learning difficulty")]
        Code11 = 8, // '11' -> 8

        [Description("Social and emotional difficulties")]
        Code8 = 5, // '8' -> 5

        [Description("Speech, Language and Communication Needs")]
        Code17 = 14, // '17' -> 14

        [Description("Temporary disability after illness (for example post-viral) or accident")]
        Code16 = 13, // '16' -> 13

        [Description("Vision impairment")]
        Code4 = 1 // '4' -> 1 (Visual impairment -> Vision impairment)
    }

    public static class DisabilityLearningDifficultyHelper
    {
        /// <summary>
        /// Return the numeric DB id for a source code (e.g. "15" or "Code15"), or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();

            // Accept plain numeric ("15") or "Code15" forms
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<DisabilityLearningDifficulty>(trimmed, true, out var val))
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
        /// Get the Description attribute (friendly name) for a DisabilityLearningDifficulty enum value.
        /// </summary>
        public static string? GetFriendlyName(this DisabilityLearningDifficulty value)
        {
            var fi = typeof(DisabilityLearningDifficulty).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a source code (returns null if unknown).
        /// Accepts "15" or "Code15" (case-insensitive).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var trimmed = code.Trim();
            if (int.TryParse(trimmed, out var numeric))
                trimmed = "Code" + numeric.ToString();

            if (Enum.TryParse<DisabilityLearningDifficulty>(trimmed, true, out var val))
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