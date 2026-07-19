using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagement
{
    public partial class FrmGuest : Form
    {
        private Guest _guest;
        public FrmGuest()
        {
            InitializeComponent();
        }
        public FrmGuest(Guest guest)
        {
            InitializeComponent();
            _guest = guest;
            txtFirst.Text=_guest.FirstName;
            txtlast.Text=_guest.LastName;
            txtNationalCode.Text=_guest.NationalCode;
            txtPhoneNumber.Text=_guest.MobileNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_guest == null)
            {
                var guest = new GuestManager();
                Guest gue = new Guest(txtFirst.Text, txtlast.Text, txtNationalCode.Text, txtPhoneNumber.Text);
                Result result = guest.AddGuest(gue);
                if (result.Success)
                {
                    MessageBox.Show("ثبت شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message);
                    return;
                }

            }
            else
            {
                Result ress = _guest.Update(txtFirst.Text, txtlast.Text, txtNationalCode.Text, txtPhoneNumber.Text);
                if (ress.Success)
                {
                    MessageBox.Show("ویرایش انجام شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ress.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
