﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KIOKI_1.Classes
{
    class CustomButton : Button
    {
        public int row { get; }
        public int column { get; }
        public bool wasPressed { get; }

        public CustomButton(int row, int column) : base()
        {
            this.row = row;
            this.column = column;
        }
    }
}