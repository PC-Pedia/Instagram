using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Instagram.ViewModels
{
    public class StoriesViewModel : BaseViewModel
    {
        public ObservableCollection<StoryViewModel> Stories { get; private set; }
        private StoryViewModel _selectedStory;
        private MainPageViewModel _mainPage;
        public ICommand SelectStoryCommand { get; private set; }
        public StoryViewModel SelectedStory
        {
            get { return _selectedStory; }
            set { SetValue(ref _selectedStory, value); }
        }

        public StoriesViewModel(MainPageViewModel mainPage)
        {
            _mainPage = mainPage;
            SelectStoryCommand = new Command<StoryViewModel>(vm => SelectStory(vm));
            Stories = new ObservableCollection<StoryViewModel>();
            Stories.Add(new StoryViewModel { Image = "instagramicon.png", Nickname = "New!" });
            Stories.Add(new StoryViewModel { Image = "http://lorempixel.com/output/people-q-c-640-480-2.jpg", Nickname = "First" });
            Stories.Add(new StoryViewModel { Image = "http://lorempixel.com/output/people-q-c-640-480-9.jpg", Nickname = "Second" });
            Stories.Add(new StoryViewModel { Image = "http://lorempixel.com/output/people-q-c-640-480-5.jpg", Nickname = "Third" });
            Stories.Add(new StoryViewModel { Image = "http://lorempixel.com/output/people-q-c-640-480-10.jpg", Nickname = "Fourth" });
            Stories.Add(new StoryViewModel { Image = "http://lorempixel.com/output/people-q-c-640-480-6.jpg", Nickname = "Fifth" });
        }

        private void SelectStory (StoryViewModel story)
        {
            if (story == null)
                return;
            if (story.Nickname == "New!")
                _mainPage.CameraOpenCommand.Execute(story);
            story.IsReaded = true;
            SelectedStory = null;
        }
    }
}
