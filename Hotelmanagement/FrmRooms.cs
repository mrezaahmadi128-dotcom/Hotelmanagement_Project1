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
            var room=new RoomManager();
            int roomNumber;
            bool f=int.TryParse(txtDelete.Text, out roomNumber);
            if(!f)
            {
                MessageBox.Show("لطفا برای حذف شماره اتاق صحیح وارد کنید");
                return;
            }
            Result result=room.RemoveRoom(roomNumber);
            if(result.Success)
            {
                MessageBox.Show("حذف شد");
                txtDelete.Clear();
                txtDelete.Focus();
                dgvRooms.DataSource = room.GetRooms().ToList();
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }


        }
    }
}
