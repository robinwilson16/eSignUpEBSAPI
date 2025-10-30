using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace eSignUpEBSAPI.Models.Enums
{
    /// <summary>
    /// Enum keyed by the ISO-style code (enum member name) with the numeric DB id as the value.
    /// Use the Description attribute for the human friendly name.
    /// </summary>
    public enum Country
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("Afghanistan")]
        AF = 30,
        [Description("Africa Not Otherwise Specified")]
        XQ = 31,
        [Description("Aland Islands")]
        AX = 32,
        [Description("Albania")]
        AL = 33,
        [Description("Algeria")]
        DZ = 34,
        [Description("American Samoa")]
        AS = 35,
        [Description("Andorra")]
        AD = 36,
        [Description("Angola")]
        AO = 37,
        [Description("Anguilla")]
        AI = 38,
        [Description("Antarctica And Oceania Not Otherwise Specified")]
        XX = 40,
        [Description("Antigua And Barbuda")]
        AG = 41,
        [Description("Argentina")]
        AR = 42,
        [Description("Armenia")]
        AM = 43,
        [Description("Aruba")]
        AW = 44,
        [Description("Asia (Except Middle East) Not Otherwise Specified")]
        XS = 45,
        [Description("Australia")]
        AU = 46,
        [Description("Austria")]
        AT = 47,
        [Description("Azerbaijan")]
        AZ = 48,
        [Description("Bahamas, The")]
        BS = 49,
        [Description("Bahrain")]
        BH = 50,
        [Description("Bangladesh")]
        BD = 51,
        [Description("Barbados")]
        BB = 52,
        [Description("Belarus")]
        BY = 53,
        [Description("Belgium")]
        BE = 54,
        [Description("Belize")]
        BZ = 55,
        [Description("Benin")]
        BJ = 56,
        [Description("Bermuda")]
        BM = 57,
        [Description("Bhutan")]
        BT = 58,
        [Description("Bolivia")]
        BO = 59,
        [Description("Bonaire, Sint Eustatius and Saba")]
        BQ = 60,
        [Description("Bosnia And Herzegovina")]
        BA = 61,
        [Description("Botswana")]
        BW = 62,
        [Description("Brazil")]
        BR = 64,
        [Description("British Virgin Islands")]
        VG = 66,
        [Description("Brunei")]
        BN = 67,
        [Description("Bulgaria")]
        BG = 68,
        [Description("Burkina")]
        BF = 69,
        [Description("Burma")]
        MM = 70,
        [Description("Burundi")]
        BI = 71,
        [Description("Cambodia")]
        KH = 72,
        [Description("Cameroon")]
        CM = 73,
        [Description("Canada")]
        CA = 74,
        [Description("Canary Islands")]
        IC = 75,
        [Description("Cape Verde")]
        CV = 76,
        [Description("Caribbean Not Otherwise Specified")]
        XW = 77,
        [Description("Cayman Islands")]
        KY = 78,
        [Description("Central African Republic")]
        CF = 79,
        [Description("Central America Not Otherwise Specified")]
        XU = 80,
        [Description("Chad")]
        TD = 81,
        [Description("Channel Islands Not Otherwise Specified")]
        XL = 83,
        [Description("Chile")]
        CL = 84,
        [Description("China")]
        CN = 85,
        [Description("Taiwan (China)")]
        TW = 86,
        [Description("Christmas Island")]
        CX = 87,
        [Description("Cocos (Keeling) Islands")]
        CC = 88,
        [Description("Colombia")]
        CO = 89,
        [Description("Comoros")]
        KM = 90,
        [Description("Congo")]
        CG = 91,
        [Description("Congo (Democratic Republic)")]
        CD = 92,
        [Description("Cook Islands")]
        CK = 93,
        [Description("Costa Rica")]
        CR = 94,
        [Description("Croatia")]
        HR = 95,
        [Description("Cuba")]
        CU = 96,
        [Description("Curacao")]
        CW = 97,
        [Description("Cyprus (European Union)")]
        XA = 99,
        [Description("Cyprus (Non-European Union)")]
        XB = 100,
        [Description("Cyprus Not Otherwise Specified")]
        XC = 101,
        [Description("Czech Republic")]
        CZ = 102,
        [Description("Denmark")]
        DK = 104,
        [Description("Djibouti")]
        DJ = 105,
        [Description("Dominica")]
        DM = 106,
        [Description("Dominican Republic")]
        DO = 107,
        [Description("East Timor")]
        TL = 108,
        [Description("Ecuador")]
        EC = 109,
        [Description("Egypt")]
        EG = 110,
        [Description("El Salvador")]
        SV = 111,
        [Description("England")]
        XF = 112,
        [Description("Equatorial Guinea")]
        GQ = 113,
        [Description("Eritrea")]
        ER = 114,
        [Description("Estonia")]
        EE = 115,
        [Description("Ethiopia")]
        ET = 116,
        [Description("Europe Not Otherwise Specified")]
        XP = 117,
        [Description("European Union Not Otherwise Specified")]
        EU = 118,
        [Description("Falkland Islands")]
        FK = 119,
        [Description("Faroe Islands")]
        FO = 120,
        [Description("Fiji")]
        FJ = 121,
        [Description("Finland")]
        FI = 122,
        [Description("France")]
        FR = 123,
        [Description("French Guiana")]
        GF = 124,
        [Description("French Polynesia")]
        PF = 125,
        [Description("Gabon")]
        GA = 127,
        [Description("Gambia, The")]
        GM = 128,
        [Description("Georgia")]
        GE = 129,
        [Description("Germany")]
        DE = 130,
        [Description("Ghana")]
        GH = 131,
        [Description("Gibraltar")]
        GI = 132,
        [Description("Greece")]
        GR = 133,
        [Description("Greenland")]
        GL = 134,
        [Description("Grenada")]
        GD = 135,
        [Description("Guadeloupe")]
        GP = 136,
        [Description("Guam")]
        GU = 137,
        [Description("Guatemala")]
        GT = 138,
        [Description("Guernsey")]
        GG = 139,
        [Description("Guinea")]
        GN = 140,
        [Description("Guinea-Bissau")]
        GW = 141,
        [Description("Guyana")]
        GY = 142,
        [Description("Haiti")]
        HT = 143,
        [Description("Honduras")]
        HN = 145,
        [Description("Hong Kong (Special Administrative Region of China)")]
        HK = 146,
        [Description("Hungary")]
        HU = 147,
        [Description("Iceland")]
        IS = 148,
        [Description("India")]
        IN = 149,
        [Description("Indonesia")]
        ID = 150,
        [Description("Iran")]
        IR = 151,
        [Description("Iraq")]
        IQ = 152,
        [Description("Ireland")]
        IE = 153,
        [Description("Isle Of Man")]
        IM = 154,
        [Description("Israel")]
        IL = 155,
        [Description("Italy")]
        IT = 156,
        [Description("Ivory Coast")]
        CI = 157,
        [Description("Jamaica")]
        JM = 158,
        [Description("Japan")]
        JP = 159,
        [Description("Jersey")]
        JE = 160,
        [Description("Jordan")]
        JO = 161,
        [Description("Kazakhstan")]
        KZ = 162,
        [Description("Kenya")]
        KE = 163,
        [Description("Kiribati")]
        KI = 164,
        [Description("Korea (North)")]
        KP = 165,
        [Description("Korea (South)")]
        KR = 166,
        [Description("Kosovo")]
        QO = 167,
        [Description("Kuwait")]
        KW = 168,
        [Description("Kyrgyzstan")]
        KG = 169,
        [Description("Laos")]
        LA = 170,
        [Description("Latvia")]
        LV = 171,
        [Description("Lebanon")]
        LB = 172,
        [Description("Lesotho")]
        LS = 173,
        [Description("Liberia")]
        LR = 174,
        [Description("Libya")]
        LY = 175,
        [Description("Liechtenstein")]
        LI = 176,
        [Description("Lithuania")]
        LT = 177,
        [Description("Luxembourg")]
        LU = 178,
        [Description("Macao")]
        MO = 179,
        [Description("Macedonia")]
        MK = 180,
        [Description("Madagascar")]
        MG = 181,
        [Description("Malawi")]
        MW = 182,
        [Description("Malaysia")]
        MY = 183,
        [Description("Maldives")]
        MV = 184,
        [Description("Mali")]
        ML = 185,
        [Description("Malta")]
        MT = 186,
        [Description("Marshall Islands")]
        MH = 187,
        [Description("Martinique")]
        MQ = 188,
        [Description("Mauritania")]
        MR = 189,
        [Description("Mauritius")]
        MU = 190,
        [Description("Mayotte")]
        YT = 191,
        [Description("Mexico")]
        MX = 192,
        [Description("Micronesia")]
        FM = 193,
        [Description("Middle East Not Otherwise Specified")]
        XR = 194,
        [Description("Moldova")]
        MD = 195,
        [Description("Monaco")]
        MC = 196,
        [Description("Mongolia")]
        MN = 197,
        [Description("Montenegro")]
        ME = 198,
        [Description("Montserrat")]
        MS = 199,
        [Description("Morocco")]
        MA = 200,
        [Description("Mozambique")]
        MZ = 201,
        [Description("Namibia")]
        NA = 202,
        [Description("Nauru")]
        NR = 203,
        [Description("Nepal")]
        NP = 204,
        [Description("Netherlands")]
        NL = 205,
        [Description("Netherlands Antilles")]
        AN = 206,
        [Description("New Caledonia")]
        NC = 207,
        [Description("New Zealand")]
        NZ = 208,
        [Description("Nicaragua")]
        NI = 209,
        [Description("Niger")]
        NE = 210,
        [Description("Nigeria")]
        NG = 211,
        [Description("Niue")]
        NU = 212,
        [Description("Norfolk Island")]
        NF = 213,
        [Description("North America Not Otherwise Specified")]
        XT = 214,
        [Description("Northern Ireland")]
        XG = 215,
        [Description("Northern Mariana Islands")]
        MP = 216,
        [Description("Norway")]
        NO = 217,
        [Description("Not Known")]
        ZZ = 218,
        [Description("Occupied Palestinian Territories")]
        PS = 219,
        [Description("Oman")]
        OM = 220,
        [Description("Pakistan")]
        PK = 221,
        [Description("Palau")]
        PW = 222,
        [Description("Panama")]
        PA = 223,
        [Description("Papua New Guinea")]
        PG = 224,
        [Description("Paraguay")]
        PY = 225,
        [Description("Peru")]
        PE = 226,
        [Description("Philippines")]
        PH = 227,
        [Description("Pitcairn, Henderson, Ducie And Oeno Islands")]
        PN = 228,
        [Description("Poland")]
        PL = 229,
        [Description("Portugal")]
        PT = 230,
        [Description("Puerto Rico")]
        PR = 231,
        [Description("Qatar")]
        QA = 232,
        [Description("Reunion")]
        RE = 233,
        [Description("Romania")]
        RO = 234,
        [Description("Russia")]
        RU = 235,
        [Description("Rwanda")]
        RW = 236,
        [Description("Samoa")]
        WS = 237,
        [Description("San Marino")]
        SM = 238,
        [Description("Sao Tome And Principe")]
        ST = 239,
        [Description("Saudi Arabia")]
        SA = 240,
        [Description("Scotland")]
        XH = 241,
        [Description("Senegal")]
        SN = 242,
        [Description("Serbia")]
        RS = 243,
        [Description("Seychelles")]
        SC = 245,
        [Description("Sierra Leone")]
        SL = 246,
        [Description("Singapore")]
        SG = 247,
        [Description("Sint Maarten (Dutch part)")]
        SX = 248,
        [Description("Slovakia")]
        SK = 249,
        [Description("Slovenia")]
        SI = 250,
        [Description("Solomon Islands")]
        SB = 251,
        [Description("Somalia")]
        SO = 252,
        [Description("South Africa")]
        ZA = 253,
        [Description("South America Not Otherwise Specified")]
        XV = 254,
        [Description("South Georgia And The South Sandwich Islands")]
        GS = 255,
        [Description("South Sudan")]
        SS = 256,
        [Description("Spain")]
        ES = 257,
        [Description("Sri Lanka")]
        LK = 260,
        [Description("St Barthelemy")]
        BL = 261,
        [Description("St Helena, Ascension and Tristan da Cunha")]
        SH = 262,
        [Description("St Kitts And Nevis")]
        KN = 263,
        [Description("St Lucia")]
        LC = 264,
        [Description("St Martin (French Part)")]
        MF = 265,
        [Description("St Pierre And Miquelon")]
        PM = 266,
        [Description("St Vincent And The Grenadines")]
        VC = 267,
        [Description("Sudan")]
        SD = 268,
        [Description("Surinam")]
        SR = 269,
        [Description("Svalbard And Jan Mayen")]
        SJ = 270,
        [Description("Swaziland")]
        SZ = 271,
        [Description("Sweden")]
        SE = 272,
        [Description("Switzerland")]
        CH = 273,
        [Description("Syria")]
        SY = 274,
        [Description("Tajikistan")]
        TJ = 275,
        [Description("Tanzania")]
        TZ = 276,
        [Description("Thailand")]
        TH = 277,
        [Description("Togo")]
        TG = 278,
        [Description("Tokelau")]
        TK = 279,
        [Description("Tonga")]
        TO = 280,
        [Description("Trinidad And Tobago")]
        TT = 281,
        [Description("Tunisia")]
        TN = 282,
        [Description("Turkey")]
        TR = 283,
        [Description("Turkmenistan")]
        TM = 284,
        [Description("Turks And Caicos Islands")]
        TC = 285,
        [Description("Tuvalu")]
        TV = 286,
        [Description("Uganda")]
        UG = 287,
        [Description("Ukraine")]
        UA = 288,
        [Description("United Arab Emirates")]
        AE = 290,
        [Description("United Kingdom Not Otherwise Specified")]
        XK = 292,
        [Description("United States")]
        US = 293,
        [Description("United States Virgin Islands")]
        VI = 295,
        [Description("Uruguay")]
        UY = 296,
        [Description("Uzbekistan")]
        UZ = 297,
        [Description("Vanuatu")]
        VU = 298,
        [Description("Vatican City")]
        VA = 299,
        [Description("Venezuela")]
        VE = 300,
        [Description("Vietnam")]
        VN = 301,
        [Description("Wales")]
        XI = 302,
        [Description("Wallis And Futuna")]
        WF = 303,
        [Description("Western Sahara")]
        EH = 305,
        [Description("Yemen")]
        YE = 306,
        [Description("Zambia")]
        ZM = 308,
        [Description("Zimbabwe")]
        ZW = 309
    }

    public static class CountryOfNationalityHelper
    {
        /// <summary>
        /// Return the numeric DB id for an ISO code, or null if unknown/blank.
        /// </summary>
        public static int? ToID(string? isoCode)
        {
            if (string.IsNullOrWhiteSpace(isoCode))
                return null;

            if (Enum.TryParse<Country>(isoCode.Trim(), true, out var val))
                return (int)val;

            return null;
        }

        /// <summary>
        /// Try get the numeric id for an ISO code.
        /// </summary>
        public static bool TryGetID(string? isoCode, out int id)
        {
            var val = ToID(isoCode);
            if (val.HasValue)
            {
                id = val.Value;
                return true;
            }
            id = default;
            return false;
        }

        /// <summary>
        /// Get the Description attribute (friendly name) for a CountryOfNationality enum value.
        /// </summary>
        public static string? GetFriendlyName(this Country value)
        {
            var fi = typeof(Country).GetField(value.ToString());
            if (fi == null) return null;
            var attr = fi.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }

        /// <summary>
        /// Get the friendly name from an ISO code (returns null if unknown).
        /// </summary>
        public static string? GetFriendlyNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
            if (Enum.TryParse<Country>(code.Trim(), true, out var val))
                return val.GetFriendlyName();
            return null;
        }
    }
}