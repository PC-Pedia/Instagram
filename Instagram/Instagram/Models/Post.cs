using System;
using System.Collections.Generic;
using System.Text;

namespace Instagram.Models
{
    /// <summary>
    /// Post model for working with DB
    /// </summary>
    public class Post
    {
        public string Avatar { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public List<PostImage> Images { get; set; }
        public bool IsLiked { get; set; }
        public bool IsBookmark { get; set; }
        public int LikesCount { get; set; }
        public string Description { get; set; }
        public int CommentCoune { get; set; }
    }
}
