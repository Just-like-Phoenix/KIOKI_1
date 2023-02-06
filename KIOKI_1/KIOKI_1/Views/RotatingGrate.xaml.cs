using KIOKI_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOKI_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RotatingGrate : ContentPage
    {
        List<CustomButton> cells;
        int btnText;

        public RotatingGrate()
        {
            InitializeComponent();
            btnText = 1;
            cells = new List<CustomButton>();
            dimension.Text = stepper.Value.ToString();
            stepper.ValueChanged += Stepper_ValueChanged;
            crypt.Clicked += Crypt_Clicked;
            grid = FillGrid(grid, (int)stepper.Value);
        }

        private void Crypt_Clicked(object sender, EventArgs e)
        {
            if (cells.Count == (int)(stepper.Value * stepper.Value) / 4)
            {
                if (rbcrypt.IsChecked)
                {
                    answer.Text = Algs.RotatingGrateEncrypt(msg.Text, cells.ToArray());
                }
                else if (!rbcrypt.IsChecked)
                {
                    answer.Text = Algs.RotatingGrateDecrypt(msg.Text, cells.ToArray());
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Введен неверный ключ!", "Ок");
            }
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            dimension.Text = stepper.Value.ToString();
            cells.Clear();
            grid = FillGrid(grid, (int)stepper.Value);
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            int row = (sender as CustomButton).row;
            int column = (sender as CustomButton).column;

            bool isSetted = (sender as CustomButton).Text == "" ? false : true;

            if (isSetted)
            {
                cells.Remove(sender as CustomButton);
                (sender as CustomButton).Text = "";
                btnText--;
            }
            else
            {
                cells.Add(sender as CustomButton);
                (sender as CustomButton).Text = btnText.ToString();
                btnText++;
            }

            for (int i = 0; i < cells.Count; i++) cells[i].Text = (i + 1).ToString();

            for (int i = 0; i < 3; i++)
            {
                int tmp = row;
                row = column;
                column = (int)stepper.Value - tmp - 1;

                CustomButton btn = new CustomButton(row, column);
                btn.Clicked += Btn_Clicked;
                btn.Text = "";
                if (isSetted)
                {
                    btn.IsEnabled = true;
                    btn.Style = (Style)Application.Current.Resources["buttplug"];
                }
                else
                {
                    btn.IsEnabled = false;
                }

                int index = (btn.row * (int)stepper.Value) + btn.column;
                grid.Children.Remove(grid.Children.Single(x => (x as CustomButton).row == btn.row && (x as CustomButton).column == btn.column));
                grid.Children.Add(btn, btn.column, btn.row);
            }
        }

        private Grid FillGrid(Grid grid, int dimension)
        {
            grid.Children.Clear();

            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < dimension; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star});
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star});
            }

            for (int i = 0; i < (int)stepper.Value; i++)
            {
                for (int j = 0; j < (int)stepper.Value; j++)
                {
                    CustomButton tmp = new CustomButton(i, j);
                    tmp.Style = (Style)Application.Current.Resources["buttplug"];
                    
                    tmp.Text = "";
                    tmp.Clicked += Btn_Clicked;
                    grid.Children.Add(tmp, j, i);
                }
            }

            return grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            rbcrypt.IsChecked = true;
        }
    }
}