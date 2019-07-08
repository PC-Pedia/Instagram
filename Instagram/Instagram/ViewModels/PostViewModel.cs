using System;
using System.Collections.Generic;
using System.Text;

namespace Instagram.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public string Avatar { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public List<PostImageViewModel> Images { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        private bool _isLiked;
        private bool _isBookmark;
        private int _likesCount;

        public bool IsLiked
        {
            get { return _isLiked; }
            set
            {
                SetValue(ref _isLiked, value);
                OnPropertyChanged(nameof(Like));
            }
        }
        public bool IsBookmark
        {
            get { return _isBookmark; }
            set
            {
                SetValue(ref _isBookmark, value);
                OnPropertyChanged(nameof(Bookmark));
            }
        }
        public string Like
        {
            get { return IsLiked ? "likered.png" : "like.png"; }
        }

        public string Bookmark
        {
            get { return IsBookmark ? "bookmarkred.png" : "bookmark.png"; }
        }
        public int LikesCount
        {
            get { return _likesCount; }
            set
            {
                SetValue(ref _likesCount, value);
                OnPropertyChanged(nameof(LikesCount));
            }
        }
    }
}
