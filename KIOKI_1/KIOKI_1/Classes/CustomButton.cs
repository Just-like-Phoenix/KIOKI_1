using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KIOKI_1.Classes
{
    public class CustomButton : Button
    {
        public int row { get; }
        public int column { get; }

        public CustomButton(int row, int column) : base()
        {
            this.row = row;
            this.column = column;
        }
    }
}
