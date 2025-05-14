using Android.Content;
using InkPeddler.Mobile.Droid.Renders;
using InkPeddler.Mobile.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryControl), typeof(EntryControlRenderer))]
namespace InkPeddler.Mobile.Droid.Renders
{
    public class EntryControlRenderer : EntryRenderer
    {
        public EntryControlRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null;
                var lp = new MarginLayoutParams(Control.LayoutParameters);
                lp.SetMargins(0, 0, 0, 0);
                LayoutParameters = lp;
                Control.LayoutParameters = lp;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}