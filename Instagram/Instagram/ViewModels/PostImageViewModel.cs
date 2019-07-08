using System;
using System.Collections.Generic;
using System.Text;

namespace Instagram.ViewModels
{
    public class PostImageViewModel : BaseViewModel
    {
        public string ImSource { get; set; }

        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                SetValue(ref _position, value);
                OnPropertyChanged(nameof(Position));
            }
        }
    }
}
