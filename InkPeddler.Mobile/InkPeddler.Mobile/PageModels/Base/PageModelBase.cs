using InkPeddler.Mobile.Extensions;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public virtual Task InitializeAsync(object navigationData = null)
        {
            return Task.CompletedTask;
        }
    }
}