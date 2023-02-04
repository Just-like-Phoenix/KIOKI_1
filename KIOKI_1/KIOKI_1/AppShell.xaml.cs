using KIOKI_1.ViewModels;
using KIOKI_1.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KIOKI_1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
