using System;

namespace Yacaa.Service.Settings.Service
{
    public abstract partial class SettingsServiceBase : ICloneable
    {
        /// <summary>
        /// Performs a deep copy of this <see cref="SettingsManager"/> instance
        /// </summary>
        public object Clone()
        {
            var clone = (SettingsServiceBase) Activator.CreateInstance(GetType());
            clone.CopyFrom(this);
            return clone;
        }
    }
}