using BL;
using Models;
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
        private GuestDto _guest;
        private GuestService _guestService;
        private int _id;
        public FrmGuest(GuestService service)
        {
            InitializeComponent();
            _guestService = service;
        }
        public FrmGuest(GuestDto guest,GuestService service)
        {
            InitializeComponent();
            _guestService = service;
            _id= guest.Id;
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
               
                GuestDto guest = new GuestDto(txtFirst.Text, txtlast.Text, txtNationalCode.Text, txtPhoneNumber.Text);
                OperationResult result = _guestService.AddGuest(guest);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                else
                {
                    MessageBox.Show("ثبت شد");
                    this.Close();
                    return;
                }


            }
            else
            {
                
                OperationResult ress = _guestService.UpdateGuest(_id,txtFirst.Text, txtlast.Text, txtNationalCode.Text, txtPhoneNumber.Text);
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
