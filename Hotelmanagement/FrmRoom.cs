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
    public partial class FrmRoom : Form
    {
        private Room _room;
        public FrmRoom()
        {
            InitializeComponent();
        }
        public FrmRoom(Room room)
        {
            InitializeComponent();
            _room = room;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var r = new RoomManager();
            if (_room == null)
            {
                int capacity,price,roomNumber;
                bool f = int.TryParse(txtCapacity.Text, out capacity);
                bool ff = int.TryParse(txtPrice.Text, out price);
                bool fff = int.TryParse(txtRoomNuber.Text, out roomNumber);
                if (!fff)
                {
                    MessageBox.Show("لطفا برای شماره اتاق عدد وارد کنید");
                    txtRoomNuber.Focus();
                    return;
                }
                if (!ff)
                {
                    MessageBox.Show("لطفا برای مبلغ عدد وارد کنید");
                    txtPrice.Focus();
                    return;
                }
                if (!f)
                { 
                    MessageBox.Show("لطفا برای ظرفیت عدد وارد کنید");
                    txtCapacity.Focus();
                    return;
                }


                Room room=new Room(roomNumber, capacity,price);
                Result result = r.AddRoom(room);
                if(result.Success)
                {
                    MessageBox.Show("ثبت شد");
                }
                else
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                foreach(var item in this.Controls)
                {
                    if(item is TextBox)
                    {
                        ((TextBox)item).Text = "";
                    }
                }

            }
        }
    }
}
