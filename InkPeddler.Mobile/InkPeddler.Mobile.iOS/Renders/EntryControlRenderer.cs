using InkPeddler.Mobile.iOS.Renders;
using InkPeddler.Mobile.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryControl), typeof(EntryControlRenderer))]
namespace InkPeddler.Mobile.iOS.Renders
{
    public class EntryControlRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}