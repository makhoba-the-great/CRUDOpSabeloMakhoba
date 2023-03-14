namespace CRUDOpSabeloMakhoba
{
    partial class MainPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.btnReg = new System.Windows.Forms.Button();
            this.btnVw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.AccessibleName = "";
            this.btnReg.BackColor = System.Drawing.Color.Olive;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReg.ForeColor = System.Drawing.Color.Maroon;
            this.btnReg.Location = new System.Drawing.Point(297, 355);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(121, 46);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnVw
            // 
            this.btnVw.BackColor = System.Drawing.Color.ForestGreen;
            this.btnVw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVw.ForeColor = System.Drawing.Color.Yellow;
            this.btnVw.Location = new System.Drawing.Point(565, 355);
            this.btnVw.Name = "btnVw";
            this.btnVw.Size = new System.Drawing.Size(121, 46);
            this.btnVw.TabIndex = 1;
            this.btnVw.Text = "View";
            this.btnVw.UseVisualStyleBackColor = false;
            this.btnVw.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.btnVw);
            this.Controls.Add(this.btnReg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main-menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnVw;
    }
}

