namespace Hotelmanagement
{
    partial class FrmReservations
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
            this.dgvReserv = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Guest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReserv
            // 
            this.dgvReserv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNumber,
            this.Id,
            this.CheckIn,
            this.CheckOut,
            this.Guest,
            this.Room});
            this.dgvReserv.Location = new System.Drawing.Point(146, 148);
            this.dgvReserv.Name = "dgvReserv";
            this.dgvReserv.RowHeadersWidth = 51;
            this.dgvReserv.RowTemplate.Height = 24;
            this.dgvReserv.Size = new System.Drawing.Size(601, 210);
            this.dgvReserv.TabIndex = 0;
            this.dgvReserv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReserv_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(146, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 44);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // RoomNumber
            // 
            this.RoomNumber.DataPropertyName = "RoomNumber";
            this.RoomNumber.HeaderText = "شماره اتاق";
            this.RoomNumber.MinimumWidth = 6;
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.Width = 125;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "آیدی مهمان";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // CheckIn
            // 
            this.CheckIn.DataPropertyName = "CheckIn";
            this.CheckIn.HeaderText = "تاریخ ورود";
            this.CheckIn.MinimumWidth = 6;
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.Width = 125;
            // 
            // CheckOut
            // 
            this.CheckOut.DataPropertyName = "CheckOut";
            this.CheckOut.HeaderText = "تاریخ خروج";
            this.CheckOut.MinimumWidth = 6;
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.Width = 150;
            // 
            // Guest
            // 
            this.Guest.DataPropertyName = "Guest";
            this.Guest.HeaderText = "Guest";
            this.Guest.MinimumWidth = 6;
            this.Guest.Name = "Guest";
            this.Guest.Visible = false;
            this.Guest.Width = 125;
            // 
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Room";
            this.Room.MinimumWidth = 6;
            this.Room.Name = "Room";
            this.Room.Visible = false;
            this.Room.Width = 125;
            // 
            // FrmReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 499);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvReserv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmReservations";
            this.Text = "FrmReservations";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReserv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
    }
}