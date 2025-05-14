using System.Threading.Tasks;
using Xamarin.Forms;

namespace InkPeddler.Mobile.Services
{
    public interface IPageService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        Task<Page> PopAsync();
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
    }

    public class PageService : IPageService
    {
        private Page MainPage { get => Application.Current.MainPage; }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }
    }
}