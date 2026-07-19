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
        public FrmGuests()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmGuest();
            frm.ShowDialog();
            dgvGuests.DataSource = GuestManager.GetGuest().ToList();
        }
        private bool CheckNumber(string number)
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
            var guest = new GuestManager();
            if (CheckNumber(txtDelete.Text))
            {
                Result result = guest.RemoveGuest(int.Parse(txtDelete.Text));
                DialogResult res;
                res = MessageBox.Show(" آیا از حذف مطمئن هستید؟", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result.Success && DialogResult.Yes == res)
                {
                    MessageBox.Show("حذف انجام شد");
                    txtDelete.Clear();
                    btnAdd.Focus();
                    dgvGuests.DataSource = GuestManager.GetGuest().ToList();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDelete.Clear();
                    txtDelete.Focus();
                }
            }
            else
                MessageBox.Show("آیدی را صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            if (CheckNumber(txtEdite.Text))
            {
                Guest guest = GuestManager.GetGuestById(int.Parse(txtEdite.Text));
                if (guest != null)
                {
                    var frm = new FrmGuest(guest);
                    frm.ShowDialog();
                    dgvGuests.DataSource = GuestManager.GetGuest().ToList();
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
    }
}
