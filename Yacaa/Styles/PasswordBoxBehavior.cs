using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace Yacaa.Styles
{
    public sealed class PasswordBoxBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LostKeyboardFocus += AssociatedObjectLostKeyboardFocus;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.LostKeyboardFocus -= AssociatedObjectLostKeyboardFocus;
            base.OnDetaching();
        }

        void AssociatedObjectLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var associatedPasswordBox = AssociatedObject as PasswordBox;
            if (associatedPasswordBox != null)
            {
                // Set your view-model's Password property here
            }
        }
    }
}