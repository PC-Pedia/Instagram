using System;
using System.Collections.Generic;
using System.Text;

namespace Instagram.Models
{
    /// <summary>
    /// Story model for working with DB
    /// </summary>
    public class Story
    {
        public string Image { get; set; }
        public string Nickname { get; set; }
        public bool IsReaded { get; set; } = false;
    }
}
