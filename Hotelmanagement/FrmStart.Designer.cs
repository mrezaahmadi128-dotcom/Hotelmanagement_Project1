namespace Hotelmanagement
{
    partial class FrmStart
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
            this.btnViewGuest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewGuest
            // 
            this.btnViewGuest.Location = new System.Drawing.Point(678, 200);
            this.btnViewGuest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewGuest.Name = "btnViewGuest";
            this.btnViewGuest.Size = new System.Drawing.Size(136, 86);
            this.btnViewGuest.TabIndex = 0;
            this.btnViewGuest.Text = "ثبت مهمان";
            this.btnViewGuest.UseVisualStyleBackColor = true;
            this.btnViewGuest.Click += new System.EventHandler(this.btnViewGuest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 200);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 86);
            this.button2.TabIndex = 1;
            this.button2.Text = "ثبت اتاق";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 200);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 86);
            this.button3.TabIndex = 2;
            this.button3.Text = "ثبت کارمند";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 460);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnViewGuest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmStart";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewGuest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

