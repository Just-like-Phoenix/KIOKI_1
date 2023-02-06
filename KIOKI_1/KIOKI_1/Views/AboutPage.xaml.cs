using KIOKI_1.Classes;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOKI_1.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            rbcrypt.IsChecked = true;
            crypt.Clicked += Crypt_Clicked;
        }

        private void Crypt_Clicked(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(key.Text,out tmp))
            {
                if (rbcrypt.IsChecked)
                {
                    answer.Text = Algs.hedgeEncrypt(msg.Text, tmp);
                }
                else if (!rbcrypt.IsChecked)
                {
                    answer.Text = Algs.hedgeDecrypt(msg.Text, tmp);
                }
            }
            else
            {
                DisplayAlert("Ошибка","Введен неверный ключ!","Ок");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            rbcrypt.IsChecked = true;
        }
    }
}