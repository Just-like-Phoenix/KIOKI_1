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
    public partial class RotatingGrate : ContentPage
    {
        int rank = 4;

        public RotatingGrate()
        {
            InitializeComponent();
            grid = FillGrid(grid, rank);
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            int row = (sender as CustomButton).row;
            int column = (sender as CustomButton).column;

            bool isSetted = (sender as CustomButton).Text == "" ? false : true;

            (sender as CustomButton).Text = isSetted ? "" : "I";

            for (int i = 0; i < 3; i++)
            {
                int tmp = row;
                row = column;
                column = rank - tmp - 1;

                CustomButton btn = new CustomButton(row, column);
                btn.Clicked += Btn_Clicked;
                btn.Text = "";
                if (isSetted)
                {
                    btn.IsEnabled = true;
                    btn.BackgroundColor = Color.Blue;
                }
                else
                {
                    btn.IsEnabled = false;
                    btn.BackgroundColor = Color.Gray;
                }

                int index = (btn.row * rank) + btn.column;
                grid.Children.Remove(grid.Children.Single(x => (x as CustomButton).row == btn.row && (x as CustomButton).column == btn.column));
                grid.Children.Add(btn, btn.column, btn.row);
            }
        }

        private Grid FillGrid(Grid grid, int rank)
        {
            grid.RowDefinitions = new RowDefinitionCollection();
            grid.ColumnDefinitions = new ColumnDefinitionCollection();

            for (int i = 0; i < rank; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = 90});
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 90});
            }

            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    CustomButton tmp = new CustomButton(i, j);
                    tmp.BackgroundColor = Color.Blue;
                    tmp.Text = "";
                    tmp.Clicked += Btn_Clicked;
                    grid.Children.Add(tmp, j, i);
                }
            }

            return grid;
        }
    }
}