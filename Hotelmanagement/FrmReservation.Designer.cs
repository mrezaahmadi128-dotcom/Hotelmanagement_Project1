namespace Hotelmanagement
{
    partial class FrmReservation
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbreserv = new System.Windows.Forms.GroupBox();
            this.cbGuestId = new System.Windows.Forms.ComboBox();
            this.cbRoomNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpIn = new System.Windows.Forms.DateTimePicker();
            this.dtpOut = new System.Windows.Forms.DateTimePicker();
            this.gbreserv.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = ": آیدی مهمان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = ":شماره اتاق";
            // 
            // gbreserv
            // 
            this.gbreserv.BackColor = System.Drawing.Color.DimGray;
            this.gbreserv.Controls.Add(this.cbGuestId);
            this.gbreserv.Controls.Add(this.cbRoomNumber);
            this.gbreserv.Controls.Add(this.label4);
            this.gbreserv.Controls.Add(this.label3);
            this.gbreserv.Controls.Add(this.dtpIn);
            this.gbreserv.Controls.Add(this.dtpOut);
            this.gbreserv.Controls.Add(this.label1);
            this.gbreserv.Controls.Add(this.label2);
            this.gbreserv.Location = new System.Drawing.Point(12, 12);
            this.gbreserv.Name = "gbreserv";
            this.gbreserv.Size = new System.Drawing.Size(666, 205);
            this.gbreserv.TabIndex = 3;
            this.gbreserv.TabStop = false;
            this.gbreserv.Text = "ثبت رزرو";
            // 
            // cbGuestId
            // 
            this.cbGuestId.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbGuestId.FormattingEnabled = true;
            this.cbGuestId.Location = new System.Drawing.Point(36, 31);
            this.cbGuestId.Name = "cbGuestId";
            this.cbGuestId.Size = new System.Drawing.Size(195, 34);
            this.cbGuestId.TabIndex = 2;
            // 
            // cbRoomNumber
            // 
            this.cbRoomNumber.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbRoomNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbRoomNumber.FormattingEnabled = true;
            this.cbRoomNumber.Location = new System.Drawing.Point(375, 31);
            this.cbRoomNumber.Name = "cbRoomNumber";
            this.cbRoomNumber.Size = new System.Drawing.Size(182, 34);
            this.cbRoomNumber.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = ": تاریخ خروج";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = ": تاریخ ورود";
            // 
            // dtpIn
            // 
            this.dtpIn.Location = new System.Drawing.Point(356, 130);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(264, 32);
            this.dtpIn.TabIndex = 3;
            // 
            // dtpOut
            // 
            this.dtpOut.Location = new System.Drawing.Point(16, 130);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(264, 32);
            this.dtpOut.TabIndex = 4;
            // 
            // FrmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 325);
            this.Controls.Add(this.gbreserv);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmReservation";
            this.Text = "Hotel_Reserv";
            this.Load += new System.EventHandler(this.FrmReservation_Load);
            this.gbreserv.ResumeLayout(false);
            this.gbreserv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbreserv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpIn;
        private System.Windows.Forms.DateTimePicker dtpOut;
        private System.Windows.Forms.ComboBox cbGuestId;
        private System.Windows.Forms.ComboBox cbRoomNumber;
    }
}