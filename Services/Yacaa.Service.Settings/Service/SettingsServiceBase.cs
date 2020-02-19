using System;
using System.IO;
using Newtonsoft.Json;
using Yacaa.Service.Settings.Configuration;
using Yacaa.Service.Settings.Enum;
using Yacaa.Service.Settings.Serialization;

namespace Yacaa.Service.Settings.Service
{
    public abstract partial class SettingsServiceBase
    {
        private readonly SettingsConfiguration _settingsConfiguration;
        
        [JsonIgnore]
        public bool IsSaved { get; set; }
        
        [JsonIgnore]
        public string FullDirectoryPath => Path.Combine(
            _settingsConfiguration.StorageSpace.GetDirectoryPath(),
            _settingsConfiguration.SubDirectoryPath);
        
        [JsonIgnore]
        public string FullFilePath => Path.Combine(
            FullDirectoryPath,
            _settingsConfiguration.Filename);

        protected SettingsServiceBase(SettingsConfiguration settingsConfiguration)
        {
            _settingsConfiguration = settingsConfiguration;
            
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != nameof(IsSaved))
                    IsSaved = false;
            };
        }
        
        public virtual void CopyFrom(SettingsServiceBase reference)
        {
            if (reference == null)
                throw new ArgumentNullException(nameof(reference));

            var serialized = Serializer.Serialize(reference);
            Serializer.Populate(serialized, this);

            IsSaved = reference.IsSaved;
        }
        
        public virtual void Save()
        {
            if (!Directory.Exists(FullDirectoryPath))
                Directory.CreateDirectory(FullDirectoryPath);
            
            File.WriteAllText(FullFilePath, Serializer.Serialize(this));

            IsSaved = true;
        }
        
        public virtual void Load()
        {
            if (!File.Exists(FullFilePath)) return;
            
            Serializer.Populate(File.ReadAllText(FullFilePath), this);

            IsSaved = true;
        }
    }
}