using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Instagram.ViewModels
{
    public class StoryViewModel : BaseViewModel
    {
        public string Image { get; set; }
        public string Nickname { get; set; }
        private bool _isReaded;
        public bool IsReaded
        {
            get { return _isReaded; }
            set
            {
                SetValue(ref _isReaded, value);
                OnPropertyChanged(nameof(Color));
            }
        }
        public Color Color
        {
            get { return IsReaded ? Color.Gray : Color.Red; }
        }

    }
}
