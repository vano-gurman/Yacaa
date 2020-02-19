using Yacaa.Service.Settings.Configuration;
using Yacaa.Service.Settings.Models;
using Yacaa.Service.Settings.Service;

namespace Yacaa.Service.Settings
{
    public class SettingsService : SettingsServiceBase
    {
        public DbSettings DbSettings { get; } = new DbSettings();
        public UserSettings UserSettings { get; } = new UserSettings();
        public UserLayout UserLayout { get; } = new UserLayout();
        public SettingsService(SettingsConfiguration settingsConfiguration) : base(settingsConfiguration)
        {
        }
    }
}