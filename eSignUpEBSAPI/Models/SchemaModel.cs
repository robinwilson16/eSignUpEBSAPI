using Microsoft.EntityFrameworkCore;

namespace eSignUpEBSAPI.Models
{
    [Keyless]
    public class SchemaModel
    {
        public int? ColumnOrdinal { get; set; }
        public string? ColumnName { get; set; }
        public string? DataTypeName { get; set; }
        public string? DataType { get; set; }
    }
}
