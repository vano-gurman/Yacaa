using System.Security;
using Yacaa.Services.DataAccess;
using Yacaa.Services.Settings;
using Yacaa.Shared.Encryption;
using Yacaa.ViewModels.Base;

namespace Yacaa.ViewModels.Dialogs
{
    public class LoginDbDialogViewModel : DialogScreen
    {
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        #region Public properties

        public string Server
        {
            get => _settingsService.DbSettings.Server;
            set => _settingsService.DbSettings.Server = value;
        }
        public bool LocalDb
        {
            get => _settingsService.DbSettings.LocalDb;
            set => _settingsService.DbSettings.LocalDb = value;
        }
        public string Username
        {
            get => _settingsService.DbSettings.Username;
            set => _settingsService.DbSettings.Username = value;
        }
        public SecureString Password
        {
            get => _settingsService.DbSettings.PasswordKey.DecryptString();
            set => _settingsService.DbSettings.PasswordKey = value.EncryptString();
        }
        public bool TrustedConnection
        {
            get => _settingsService.DbSettings.TrustedConnection;
            set => _settingsService.DbSettings.TrustedConnection = value;
        }
        public string Database
        {
            get => _settingsService.DbSettings.Database;
            set => _settingsService.DbSettings.Database = value;
        }
        
        #endregion
        
        
        public LoginDbDialogViewModel(SettingsService settingsService, DataService dataService)
        {
            _settingsService = settingsService;
            _settingsService.Load();

            _dataService = dataService;
        }
        
        public void Save()
        {
            _settingsService.Save();
            _dataService.ValidateAndSetConnectionString(_settingsService.DbSettings.ConnectionString);
            Close(true);
        }

        public void Cancel()
        {
            _settingsService.Load();
            Close(false);
        }
    }
}