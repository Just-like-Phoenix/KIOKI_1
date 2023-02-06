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
    public partial class Decimation : ContentPage
    {
        public Decimation()
        {
            InitializeComponent();
            crypt.Clicked += Crypt_Clicked;
            generator.Clicked += Generator_Clicked;
        }

        private async void Generator_Clicked(object sender, EventArgs e)
        {
            int fkey = 0, skey = 0;

            await Task.Run(() => 
            {
                Random random = new Random();

                int iterations = random.Next(10, 250);

                for (int i = 2; i < iterations * 2; i++)
                {
                    for (int j = 2; j < iterations * 2; j++)
                    {
                        int gcd = Algs.GreatestCommonDivisor(i, j);
                        if (gcd == 1 && (i * j) % 32 == 1)
                        {
                            fkey = i;
                            skey = j;
                        }
                    }
                }
            });

            firstKey.Text = fkey.ToString();
            secondKey.Text = skey.ToString();
        }

        private void Crypt_Clicked(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(key.Text, out tmp) && Algs.GreatestCommonDivisor(32, int.Parse(key.Text)) == 1)
            {
                answer.Text = Algs.DecimationEncrypt(msg.Text, tmp);
            }
            else
            {
                DisplayAlert("Ошибка", "Введен неверный ключ!", "Ок");
            }
        }
    }
}