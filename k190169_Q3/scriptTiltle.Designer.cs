
namespace k190169_Q3
{
    partial class scriptTiltle
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
            this.Script = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Script
            // 
            this.Script.Location = new System.Drawing.Point(22, 23);
            this.Script.Name = "Script";
            this.Script.Size = new System.Drawing.Size(292, 61);
            this.Script.TabIndex = 1;
            this.Script.Text = "Script";
            this.Script.Click += new System.EventHandler(this.Category_Click);
            // 
            // scriptTiltle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Script);
            this.Name = "scriptTiltle";
            this.Size = new System.Drawing.Size(341, 105);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Script;
    }
}
