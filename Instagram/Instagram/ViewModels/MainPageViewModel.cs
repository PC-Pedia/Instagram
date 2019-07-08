using Plugin.Media;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Instagram.ViewModels
{
    public class MainPageViewModel
    {
        public StoriesViewModel StoriesVm { get; private set; }
        public PostsViewModel PostsVm { get; private set; }
        public ICommand CameraOpenCommand { get; private set; }
        public ICommand NewPageCommand { get; private set; }
        public ICommand HomePageCommand { get; private set; }
        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            CameraOpenCommand = new Command(CameraOpen);
            HomePageCommand = new Command(HomePage);
            NewPageCommand = new Command<string>(np => NewPage(np));
            StoriesVm = new StoriesViewModel(this);
            PostsVm = new PostsViewModel();
        }
        /// <summary>
        /// Open Camera on device
        /// </summary>
        private async void CameraOpen()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");
        }
        /// <summary>
        /// go to new navigation page
        /// </summary>
        /// <param name="title">title of new page</param>
        private async void NewPage(string title)
        {
            Page page = new Page(){ Title = title };
            await _pageService.PushAsync(page);
        }
        /// <summary>
        /// Refresh home page
        /// </summary>
        private async void HomePage()
        {
            Page page = new MainPage();
            await _pageService.PushAsync(page);
        }
    }
}
