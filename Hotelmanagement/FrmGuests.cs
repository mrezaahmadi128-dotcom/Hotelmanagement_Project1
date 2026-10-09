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
    public partial class FrmGuests : Form
    {
        GuestService _guestService;
        public FrmGuests(GuestService guest)
        {
            InitializeComponent();
            _guestService= guest;
        }
        private void LoadGuests()
        {
            //GuestManager manger = new GuestManager();

            var result = _guestService.GetGuests();
            if(result.Success)
            {
                dgvGuests.DataSource=result.Data;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmGuest(_guestService);
            frm.ShowDialog();
            LoadGuests();
        }
        public bool CheckNumber(string number)
        {
            int room;
            bool check = int.TryParse(number, out room);
            if (check)
            {
                return true;
            }
            return false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckNumber(txtDelete.Text))
            {
                MessageBox.Show("آیدی را صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDelete.Focus();
                return;
            }

            DialogResult res;
                res = MessageBox.Show(" آیا از حذف مطمئن هستید؟", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult.Yes != res)
                {
                return;
                }
           
            OperationResult result =_guestService.RemoveGuest(int.Parse(txtDelete.Text));
            if(result.Success)
            {
                MessageBox.Show("حذف انجام شد");
                txtDelete.Clear();
                btnAdd.Focus();
                LoadGuests();
            }
            else
            {
                MessageBox.Show(
            result.Message,
            "خطا",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

                txtDelete.Clear();
                txtDelete.Focus();
            }
                
                  
        
                
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            if (CheckNumber(txtEdite.Text))
            {
                
                var guest = _guestService.GetGuestById(int.Parse(txtEdite.Text));
                if (guest.Success)
                {
                    var frm = new FrmGuest(guest.Data,_guestService);
                    frm.ShowDialog();
                    LoadGuests();
                }
                else
                {
                    MessageBox.Show("آیدی وارد شده موجود نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEdite.Clear();
                    txtEdite.Focus();
                }
            }
            else
            {
                MessageBox.Show("آیدی را صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEdite.Focus();
            }
        }

        private void FrmGuests_Load(object sender, EventArgs e)
        {
            LoadGuests();
        }
    }
}
