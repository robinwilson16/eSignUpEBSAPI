using Microsoft.EntityFrameworkCore;

namespace eSignUpEBSAPI.Models
{
    [Keyless]
    public class SettingsDatabase
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public bool? UseWindowsAuthentication { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
}
