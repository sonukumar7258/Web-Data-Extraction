
namespace k190169_Q3
{
    partial class Price
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScriptPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScriptPrice
            // 
            this.ScriptPrice.Location = new System.Drawing.Point(12, 16);
            this.ScriptPrice.Name = "ScriptPrice";
            this.ScriptPrice.Size = new System.Drawing.Size(292, 61);
            this.ScriptPrice.TabIndex = 2;
            this.ScriptPrice.Text = "price";
            // 
            // Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScriptPrice);
            this.Name = "Price";
            this.Size = new System.Drawing.Size(321, 110);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ScriptPrice;
    }
}
