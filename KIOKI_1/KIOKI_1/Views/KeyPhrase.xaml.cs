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
    public partial class KeyPhrase : ContentPage
    {
        public KeyPhrase()
        {
            InitializeComponent();

            crypt.Clicked += Crypt_Clicked;
        }

        private void Crypt_Clicked(object sender, EventArgs e)
        {
            if (rbcrypt.IsChecked)
            {
                answer.Text = Algs.KeyPhraseEncrypt(msg.Text, key.Text);
            }
            else if (!rbcrypt.IsChecked)
            {
                answer.Text = Algs.KeyPhraseDecrypt(msg.Text, key.Text);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            rbcrypt.IsChecked = true;
        }
    }
}