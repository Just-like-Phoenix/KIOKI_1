using KIOKI_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOKI_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hedge : ContentPage
    {
        public Hedge()
        {
            InitializeComponent();
            rbcrypt.IsChecked = true;
            crypt.Clicked += Crypt_Clicked;
        }

        private void Crypt_Clicked(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(key.Text, out tmp))
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
                DisplayAlert("Ошибка", "Введен неверный ключ!", "Ок");
            }
        }
    }
}