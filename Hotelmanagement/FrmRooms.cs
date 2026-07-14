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
    public partial class FrmRooms : Form
    {
        public FrmRooms()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomManager room=new RoomManager();
            var frm=new FrmRoom();
            frm.ShowDialog();
            dgvRooms.DataSource=room.GetRooms().ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var room = new RoomManager();
            int roomNumber;
            bool f = int.TryParse(txtDelete.Text, out roomNumber);
            if (!f)
            {
                MessageBox.Show("لطفا برای حذف شماره اتاق صحیح وارد کنید");
                return;
            }
            Result result = room.RemoveRoom(roomNumber);
            DialogResult res;
            res = MessageBox.Show(" آیا از حذف مطمئن هستید؟", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result.Success && DialogResult.Yes == res)
            {
                MessageBox.Show("!حذف انجام شد");
                txtDelete.Clear();
                txtDelete.Focus();
                dgvRooms.DataSource = room.GetRooms().ToList();
            }
            else
            {
                MessageBox.Show(result.Message,"خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


        }
        private bool CheckNumber(string number)
        {
            int roomNumber;
            bool check = int.TryParse(number, out roomNumber);
            if (check)
            {
                return true;
            }
            return false;
        }
        private void btnEdite_Click(object sender, EventArgs e)
        {
            var room = new RoomManager();

            if (!CheckNumber(txtEdite.Text))
            {
                MessageBox.Show("لطفاً برای ویرایش شماره اتاق صحیح وارد کنید");
                return;
            }
            Room rom=RoomManager.GetRoomByNuber(int.Parse(txtEdite.Text));
            if (rom != null)
            {
                var frm = new FrmRoom(rom);
                frm.ShowDialog();
                dgvRooms.DataSource = room.GetRooms().ToList();
            }
            else
            {
                MessageBox.Show("شماره اتاق وارد شده موجود نیست");
                txtEdite.Clear();
                txtEdite.Focus();
            }

        }
    }
}
