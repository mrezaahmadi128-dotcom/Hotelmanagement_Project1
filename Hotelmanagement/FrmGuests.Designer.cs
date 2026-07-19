namespace Hotelmanagement
{
    partial class FrmGuests
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
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDelete = new System.Windows.Forms.TextBox();
            this.btnEdite = new System.Windows.Forms.Button();
            this.txtEdite = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGuests
            // 
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.NationalCode,
            this.MobileNumber,
            this.Id,
            this.FirstName,
            this.LastName});
            this.dgvGuests.Location = new System.Drawing.Point(43, 99);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.RowTemplate.Height = 24;
            this.dgvGuests.Size = new System.Drawing.Size(584, 155);
            this.dgvGuests.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(43, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "نام و خانوادگی";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.Width = 125;
            // 
            // NationalCode
            // 
            this.NationalCode.DataPropertyName = "NationalCode";
            this.NationalCode.HeaderText = "کدملی";
            this.NationalCode.MinimumWidth = 6;
            this.NationalCode.Name = "NationalCode";
            this.NationalCode.Width = 125;
            // 
            // MobileNumber
            // 
            this.MobileNumber.DataPropertyName = "MobileNumber";
            this.MobileNumber.HeaderText = "شماره تلفن";
            this.MobileNumber.MinimumWidth = 6;
            this.MobileNumber.Name = "MobileNumber";
            this.MobileNumber.Width = 125;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "آیدی مهمان";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "نام";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.Visible = false;
            this.FirstName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "فامیلی";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.Visible = false;
            this.LastName.Width = 125;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(151, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDelete
            // 
            this.txtDelete.Location = new System.Drawing.Point(237, 59);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(148, 30);
            this.txtDelete.TabIndex = 3;
            // 
            // btnEdite
            // 
            this.btnEdite.Location = new System.Drawing.Point(538, 51);
            this.btnEdite.Name = "btnEdite";
            this.btnEdite.Size = new System.Drawing.Size(70, 38);
            this.btnEdite.TabIndex = 4;
            this.btnEdite.Text = "ویرایش";
            this.btnEdite.UseVisualStyleBackColor = true;
            this.btnEdite.Click += new System.EventHandler(this.btnEdite_Click);
            // 
            // txtEdite
            // 
            this.txtEdite.Location = new System.Drawing.Point(616, 55);
            this.txtEdite.Name = "txtEdite";
            this.txtEdite.Size = new System.Drawing.Size(148, 30);
            this.txtEdite.TabIndex = 5;
            // 
            // FrmGuests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 404);
            this.Controls.Add(this.txtEdite);
            this.Controls.Add(this.btnEdite);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvGuests);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmGuests";
            this.Text = "FrmGuests";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDelete;
        private System.Windows.Forms.Button btnEdite;
        private System.Windows.Forms.TextBox txtEdite;
    }
}