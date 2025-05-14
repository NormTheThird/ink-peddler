using InkPeddler.Mobile.Extensions;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace InkPeddler.Mobile.ViewModels.Buttons
{
    public class ButtonModel : ExtendedBindableObject
    {
        public ButtonModel(string title, ICommand command, bool isVisible = true, bool isEnabled = true)
        {
            this.Text = title;
            this.Command = command;
            this.IsVisible = isVisible;
            this.IsEnabled = isEnabled;                
        }

        public ButtonModel(string text, Action action, bool isVisible = true, bool isEnabled = true)
        {
            this.Text = text;
            this.Command = new Command(action);
            this.IsVisible = isVisible;
            this.IsEnabled = isEnabled;
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private ICommand _command;
        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }
    }
}