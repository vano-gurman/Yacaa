using System;

namespace Yacaa.Service.Settings.Service
{
    public class Stager<T> where T : SettingsServiceBase
    {
        /// <summary>
        /// Stable instance. All properties are up to date with the persistently stored version. Use only as read-only.
        /// </summary>
        public T Stable { get; }

        /// <summary>
        /// Dirty instance. Properties may be unsynchronized until they are saved to persistent storage.
        /// </summary>
        public T Dirty { get; }

        /// <summary>
        /// Create a stager for <see cref="SettingsServiceBase"/> by using the default constructor
        /// </summary>
        public Stager()
        {
            Stable = (T) Activator.CreateInstance(typeof (T));
            Dirty = (T) Activator.CreateInstance(typeof (T));
        }

        /// <summary>
        /// Creates a stager for given <see cref="SettingsServiceBase"/> instances
        /// </summary>
        public Stager(SettingsServiceBase current, SettingsServiceBase staging)
        {
            Stable = (T) current ?? throw new ArgumentNullException(nameof(current));
            Dirty = (T) staging ?? throw new ArgumentNullException(nameof(staging));
        }

        /// <summary>
        /// Saves the settings to file and synchronizes instances
        /// </summary>
        public virtual void Save()
        {
            Dirty.Save();
            Stable.CopyFrom(Dirty);
        }

        /// <summary>
        /// Loads settings from file and synchronizes instances
        /// </summary>
        public virtual void Load()
        {
            Dirty.Load();
            Stable.CopyFrom(Dirty);
        }

        /// <summary>
        /// Resets staging settings back to current
        /// </summary>
        public virtual void RevertStaging()
        {
            Dirty.CopyFrom(Stable);
        }
    }
}