using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the source code (enum member name) with the numeric DB id as the value.
    /// The Description attribute contains the friendly name.
    /// </summary>
    public enum EmergencyContactRelationship
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Work colleague")]
        ASS = 47,        // Assessor (Apprenticeships) -> Work colleague
        [Description("Partner")]
        BOY = 38,        // Boyfriend -> Partner
        [Description("Brother")]
        BRO = 26,        // Brother -> Brother
        [Description("Work colleague")]
        ORG = 47,        // Carer (Organization) -> Work colleague
        [Description("Carer")]
        CAR = 27,        // Carer (Person) -> Carer
        [Description("Work colleague")]
        CAS = 47,        // Case Worker -> Work colleague
        [Description("Daughter")]
        DAU = 29,        // Daughter -> Daughter
        [Description("Other")]
        EMR = 37,        // Emergency -> Other
        [Description("Work colleague")]
        EMP = 47,        // Employer -> Work colleague
        [Description("Other")]
        EXTFAM = 37,     // Extended family member -> Other
        [Description("Other")]
        FARM = 37,       // Family -> Other
        [Description("Father")]
        FAH = 30,        // Father -> Father
        [Description("Partner")]
        FIAN = 38,       // Fiance -> Partner
        [Description("Carer")]
        FCARE = 27,      // Foster Carer -> Carer
        [Description("Friend")]
        FRIE = 31,       // Friend -> Friend
        [Description("Partner")]
        GIRL = 38,       // Girlfriend -> Partner
        [Description("Grandparent")]
        GPAR = 32,       // Grand Parent -> Grandparent
        [Description("Other")]
        GUARD = 37,      // Guardian -> Other
        [Description("Other")]
        HOS = 37,        // Host -> Other
        [Description("Other")]
        HOST = 37,       // Host Parent -> Other
        [Description("Partner")]
        HUS = 38,        // Husband -> Partner
        [Description("Carer")]
        KEY = 27,        // Key Worker -> Carer
        [Description("Mother")]
        MOTH = 34,       // Mother -> Mother
        [Description("Other")]
        NEI = 37,        // Neighbour -> Other
        [Description("Niece")]
        NIE = 36,        // Niece -> Niece
        [Description("Other")]
        WWW = 37,        // Not Applicable -> Other
        [Description("Other")]
        ZZZ = 37,        // Not Stated (intentionally) -> Other
        [Description("Other")]
        OOO = 37,        // OASIS Data Conversion -> Other
        [Description("Other")]
        YYY = 37,        // Other (Not elsewhere classified) -> Other
        [Description("Other")]
        PAR = 37,        // Parent -> Other
        [Description("Partner")]
        PART = 38,       // Partner -> Partner
        [Description("Other")]
        SEL = 37,        // Self (independent) -> Other
        [Description("Other")]
        SIB = 37,        // Sibling -> Other
        [Description("Sister")]
        SIS = 39,        // Sister -> Sister
        [Description("Carer")]
        SOC = 27,        // Social Worker -> Carer
        [Description("Son")]
        SON = 40,        // Son -> Son
        [Description("Other")]
        SPAR = 37,       // Step Parent -> Other
        [Description("Other")]
        SSIB = 37,       // Step Sibling -> Other
        [Description("Carer")]
        SUP = 27,        // Support Worker -> Carer
        [Description("Other")]
        XXX = 37,        // Unknown/Not Provided -> Other
        [Description("Wife")]
        WIFE = 46        // Wife -> Wife
    }

    public static class EmergencyContactRelationshipHelper
    {
        /// <summary>
        /// Return the numeric DB id for a relationship code, or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            if (Enum.TryParse<EmergencyContactRelationship>(code.Trim(), true, out var val))
                return (int)val;

            return null;
        }

        /// <summary>
        /// Try get the numeric id for a relationship code.
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
        /// Get the Description attribute (friendly name) for an EmergencyContactRelationship enum value.
        /// </summary>
        public static string? GetFriendlyName(this EmergencyContactRelationship value)
        {
            var fi = typeof(EmergencyContactRelationship).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from a relationship code (returns null if unknown).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
            if (Enum.TryParse<EmergencyContactRelationship>(code.Trim(), true, out var val))
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