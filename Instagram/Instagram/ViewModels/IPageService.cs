using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Instagram.ViewModels
{
    /// <summary>
    /// Interface for navigation
    /// </summary>
    public interface IPageService
    {
        Task PushAsync(Page page);
    }
}
