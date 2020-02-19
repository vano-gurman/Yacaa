using Yacaa.Services.Settings.Enum;

namespace Yacaa.Services.Settings.Configuration
{
    public class SettingsConfiguration
    {
        public StorageSpace StorageSpace { get; set; }
        public string Filename { get; set; }
        public string SubDirectoryPath { get; set; }

        public SettingsConfiguration(
            StorageSpace storageSpace = StorageSpace.ApplicationFolder,
            string subDirectoryPath = "",
            string filename = "Settings.json"
            )
        {
            StorageSpace = storageSpace;
            SubDirectoryPath = subDirectoryPath;
            Filename = filename;
        }
    }
}