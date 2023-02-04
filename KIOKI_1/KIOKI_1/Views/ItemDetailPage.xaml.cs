using KIOKI_1.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KIOKI_1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}