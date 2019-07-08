using CarouselView.FormsPlugin.Abstractions;
using Instagram.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Instagram
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ViewModel = new MainPageViewModel(new PageService());
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.StoriesVm.SelectStoryCommand.Execute(e.SelectedItem);
        }

        public MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }

        private void CameraOpen(object sender, System.EventArgs e)
        {
            ViewModel.CameraOpenCommand.Execute(sender);
        }

        private void NewPage(object sender, System.EventArgs e)
        {
            ViewModel.NewPageCommand.Execute(((Image)sender).StyleId);
        }

        private void ShareMenu(object sender, System.EventArgs e)
        {
            ViewModel.PostsVm.OpenShareCommand.Execute(sender);
        }

        private void AddLike(object sender, System.EventArgs e)
        {
            var post = (PostViewModel)((Image)sender).BindingContext;
            ViewModel.PostsVm.AddLikeCommand.Execute(post);
        }

        private void AddBookmark(object sender, System.EventArgs e)
        {
            var post = (PostViewModel)((Image)sender).BindingContext;
            ViewModel.PostsVm.AddBookmarkCommand.Execute(post);
        }

        private void SharePost(object sender, System.EventArgs e)
        {
            ViewModel.PostsVm.ShareCommand.Execute(sender);
        }

        private void ViewComents(object sender, System.EventArgs e)
        {
            ViewModel.NewPageCommand.Execute(((Label)sender).StyleId);
        }

        private void ChangePosition(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            var post = (PostViewModel)((CarouselViewControl)sender).BindingContext;
            var count = post.Images.Count;
            var position = ((CarouselViewControl)sender).Position;
            string info = $"{position + 1}/{count}";
            post.Images[position].Position = info;
        }

        private void HomePage(object sender, System.EventArgs e)
        {
            ViewModel.HomePageCommand.Execute(sender);
        }
    }
}
