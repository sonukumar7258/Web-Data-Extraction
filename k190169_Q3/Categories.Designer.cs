
namespace k190169_Q3
{
    partial class Categories
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
            this.Category = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Category
            // 
            this.Category.Location = new System.Drawing.Point(14, 19);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(292, 61);
            this.Category.TabIndex = 0;
            this.Category.Text = "Category";
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Category);
            this.Name = "Categories";
            this.Size = new System.Drawing.Size(322, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Category;
    }
}
