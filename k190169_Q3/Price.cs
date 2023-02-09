using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace k190169_Q3
{
    public partial class Price : UserControl
    {
        public Price()
        {
            InitializeComponent();
        }

        #region Properties 


        private String _price;

        [Category("Custom Props")]
        public String price
        {
            get { return _price; }
            set { _price = value; ScriptPrice.Text = value; }
        }

        #endregion
    }
}
