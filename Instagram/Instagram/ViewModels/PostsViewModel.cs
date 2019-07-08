using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Instagram.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {
        public ObservableCollection<PostViewModel> Posts { get; private set; }
        public ICommand OpenShareCommand { get; private set; }
        public ICommand AddLikeCommand { get; private set; }
        public ICommand AddBookmarkCommand { get; private set; }
        public ICommand ShareCommand { get; private set; }

        public PostsViewModel()
        {
            Posts = new ObservableCollection<PostViewModel>();
            Seed();
            OpenShareCommand = new Command(OpenShare);
            AddLikeCommand = new Command<PostViewModel>(vm => AddLike(vm));
            AddBookmarkCommand = new Command<PostViewModel>(vm => AddBookmark(vm));
            ShareCommand = new Command(Share);
        }
        /// <summary>
        /// Open share menu
        /// </summary>
        private async void OpenShare()
        {
            await Application.Current.MainPage.DisplayActionSheet("", "Отменить", "Пожаловаться", "Отменить подписку на хэштег",
                "Копировать ссылку", "Поделиться", "Не показывать для этого хэштега");
        }
        /// <summary>
        /// Add new like to post
        /// </summary>
        /// <param name="post"></param>
        private void AddLike(PostViewModel post)
        {
            if (post == null)
                return;
            if (post.IsLiked == false)
            {
                post.IsLiked = true;
                post.LikesCount += 1;
            }
            else
            {
                post.IsLiked = false;
                post.LikesCount -= 1;
            }
        }
        /// <summary>
        /// Add bookmark to post
        /// </summary>
        /// <param name="post"></param>
        private void AddBookmark(PostViewModel post)
        {
            if (post == null)
                return;
            if (post.IsBookmark == false)
                post.IsBookmark = true;
            else
                post.IsBookmark = false;
        }
        /// <summary>
        /// Open share dialog
        /// </summary>
        private async void Share()
        {
            await Application.Current.MainPage.DisplayAlert("Share", "Are you want to share this on your page?", "Yes", "No");
        }
        /// <summary>
        /// Fill our posts
        /// </summary>
        private void Seed()
        {
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/people-q-c-640-480-2.jpg",
                Author = "First",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/sports-q-c-640-480-9.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/sports-q-c-640-480-7.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/sports-q-c-640-480-3.jpg" } },
                LikesCount = 11,
                Description = "Tokyo was selected as the host city during the 125th IOC Session in Buenos Aires, Argentina on 7 September 2013.[2] These Games will mark the return of the Summer Olympics to Tokyo for the first time since 1964, the first city in Asia to host the Olympics twice, and the fourth Olympics overall to be held in Japan, following the 1972 Winter Olympics in Sapporo and the 1998 Winter Olympics in Nagano. They will be the second of three consecutive Olympic Games to be held in East Asia, following the 2018 Winter Olympics in Pyeongchang, South Korea, and preceding the 2022 Winter Olympics in Beijing, China.",
                CommentCount = 12
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/people-q-c-640-480-1.jpg",
                Author = "Second",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/cats-q-c-640-480-9.jpg" }},
                LikesCount = 6,
                Description = "A cat has been returned to its owner in Southsea after ending up at an infants' school following a a two-week 'adventure'. Eleven-year-old Horace went missing ...",
                CommentCount = 1
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/business-q-c-640-480-9.jpg",
                Author = "Third",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/business-q-c-640-480-7.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/business-q-c-640-480-6.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/business-q-c-640-480-3.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/business-q-c-640-480-5.jpg" }},
                LikesCount = 34,
                Description = "BBC News. ... The German lender will exit the share trading business, much of which is in London and New York. 2h2 hours ago; Business.",
                CommentCount = 21
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/fashion-q-c-640-480-6.jpg",
                Author = "Fourth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/food-q-c-640-480-6.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/food-q-c-640-480-10.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/food-q-c-640-480-4.jpg" } },
                LikesCount = 14,
                Description = "All the latest news about Food from the BBC. ... One restaurant's simple approach to fighting food waste. With cowbells and chalkboard menus, this Toronto .",
                CommentCount = 6
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/nightlife-q-c-640-480-5.jpg",
                Author = "Fifth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/nightlife-q-c-640-480-5.jpg" }},
                LikesCount = 7,
                Description = "Nightclubs. 10:20, 25 MAY 2019. NightclubsBank holiday revellers kick off three-day weekend in style with wild party · Partygoers in Birmingham kicked off the .",
                CommentCount = 3
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/animals-q-c-640-480-7.jpg",
                Author = "Sixth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/animals-q-c-640-480-9.jpg" }},
                LikesCount = 27,
                Description = "Veterinary research and news on dogs as companions, canine health, wolf pack behavior and more. If it is news about dogs, you will find it here!",
                CommentCount = 13
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/city-q-c-640-480-8.jpg",
                Author = "Seventh",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/city-q-c-640-480-9.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/city-q-c-640-480-6.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/city-q-c-640-480-2.jpg" } },
                LikesCount = 14,
                Description = "Discover exciting world events, luxury travel deals, safety tips and more. View the latest international travel news and information at T+L.",
                CommentCount = 6
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/transport-q-c-640-480-6.jpg",
                Author = "Eighth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/transport-q-c-640-480-3.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/transport-q-c-640-480-8.jpg" },
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/transport-q-c-640-480-5.jpg" } },
                LikesCount = 54,
                Description = "Automotive News is the leading source of news about the global automotive industry.",
                CommentCount = 26
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/nature-q-c-640-480-5.jpg",
                Author = "Ninth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/nature-q-c-640-480-2.jpg" }},
                LikesCount = 27,
                Description = "Veterinary research and news on dogs as companions, canine health, wolf pack behavior and more. If it is news about dogs, you will find it here!",
                CommentCount = 13
            });
            Posts.Add(new PostViewModel
            {
                Avatar = "http://lorempixel.com/output/technics-q-c-640-480-2.jpg",
                Author = "Tenth",
                Location = "Somewhere",
                Images = new List<PostImageViewModel>() {
                     new PostImageViewModel{ImSource = "http://lorempixel.com/output/technics-q-c-640-480-6.jpg" }},
                LikesCount = 27,
                Description = "Veterinary research and news on dogs as companions, canine health, wolf pack behavior and more. If it is news about dogs, you will find it here!",
                CommentCount = 13
            });
        }
    }
}
