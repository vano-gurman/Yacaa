using Yacaa.Service.Settings.Enum;

namespace Yacaa.Service.Settings.Configuration
{
    public class SettingsConfiguration
    {
        public StorageSpace StorageSpace { get; }
        public string Filename { get; }
        public string SubDirectoryPath { get; }

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