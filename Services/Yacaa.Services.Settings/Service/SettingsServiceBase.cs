using System;
using System.IO;
using Newtonsoft.Json;
using Yacaa.Services.Settings.Configuration;
using Yacaa.Services.Settings.Enum;
using Yacaa.Services.Settings.Serialization;

namespace Yacaa.Services.Settings.Service
{
    public abstract partial class SettingsServiceBase
    {
        #region Private members
        private string FullDirectoryPath => Path.Combine(
            SettingsConfiguration.StorageSpace.GetDirectoryPath(),
            SettingsConfiguration.SubDirectoryPath);
        
        private string FullFilePath => Path.Combine(
            FullDirectoryPath,
            SettingsConfiguration.Filename);

        #endregion
        
        [JsonIgnore]
        public SettingsConfiguration SettingsConfiguration { get; }

        [JsonIgnore]
        public bool IsSaved { get; set; }

        protected SettingsServiceBase(SettingsConfiguration settingsConfiguration)
        {
            SettingsConfiguration = settingsConfiguration;
            
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != nameof(IsSaved))
                    IsSaved = false;
            };
        }
        
        public void CopyFrom(SettingsServiceBase reference)
        {
            if (reference == null)
                throw new ArgumentNullException(nameof(reference));

            var serialized = Serializer.Serialize(reference);
            Serializer.Populate(serialized, this);

            IsSaved = reference.IsSaved;
        }
        
        public void Save()
        {
            if (!Directory.Exists(FullDirectoryPath))
                Directory.CreateDirectory(FullDirectoryPath);
            
            File.WriteAllText(FullFilePath, Serializer.Serialize(this));

            IsSaved = true;
        }
        
        public void Load()
        {
            if (!File.Exists(FullFilePath)) return;
            
            Serializer.Populate(File.ReadAllText(FullFilePath), this);

            IsSaved = true;
        }
    }
}