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
            this.btnReservation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewGuest
            // 
            this.btnViewGuest.Location = new System.Drawing.Point(737, 69);
            this.btnViewGuest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewGuest.Name = "btnViewGuest";
            this.btnViewGuest.Size = new System.Drawing.Size(122, 70);
            this.btnViewGuest.TabIndex = 0;
            this.btnViewGuest.Text = "ثبت مهمان";
            this.btnViewGuest.UseVisualStyleBackColor = true;
            this.btnViewGuest.Click += new System.EventHandler(this.btnViewGuest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 69);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 70);
            this.button2.TabIndex = 1;
            this.button2.Text = "ثبت اتاق";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(318, 69);
            this.btnReservation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(133, 70);
            this.btnReservation.TabIndex = 2;
            this.btnReservation.Text = "ثبت رزرو";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 70);
            this.button1.TabIndex = 3;
            this.button1.Text = "ثبت کارمند";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReservation);
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
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button button1;
    }
}

