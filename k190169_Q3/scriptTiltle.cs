using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace k190169_Q3
{
    public partial class scriptTiltle : UserControl
    {
        public scriptTiltle()
        {
            InitializeComponent();
        }

        #region Properties 


        private String _script;

        [Category("Custom Props")]
        public String ScriptTitle
        {
            get { return _script; }
            set { _script = value; Script.Text = value; }
        }

        #endregion


        private void Category_Click(object sender, EventArgs e)
        {

        }
    }
}
