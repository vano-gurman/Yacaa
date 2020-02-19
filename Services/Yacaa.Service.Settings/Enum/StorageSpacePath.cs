using System;

namespace Yacaa.Service.Settings.Enum
{
    public static class StorageSpacePath
    {
        public static string GetDirectoryPath(this StorageSpace storageSpace)
        {
            return storageSpace switch
            {
                StorageSpace.UserRoaming => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                StorageSpace.UserLocal => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                StorageSpace.ProgramData => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                StorageSpace.ApplicationFolder => AppDomain.CurrentDomain.BaseDirectory,
                _ => throw new ArgumentOutOfRangeException(nameof(storageSpace), storageSpace, null)
            };
        }
    }
}