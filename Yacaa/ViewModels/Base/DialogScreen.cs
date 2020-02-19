using System;
using Stylet;

namespace Yacaa.ViewModels.Base
{
    public abstract class DialogScreen<T> : PropertyChangedBase
    {
        public T DialogResult { get; private set; }

        public event EventHandler? Closed;

        protected void Close(T dialogResult = default)
        {
            DialogResult = dialogResult;
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class DialogScreen : DialogScreen<bool?>
    {
    }
}