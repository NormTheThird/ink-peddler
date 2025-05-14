using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InkPeddler.Mobile.Views.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableButton : Button
    {
        public BindableButton()
        {
            InitializeComponent();
        }
    }
}