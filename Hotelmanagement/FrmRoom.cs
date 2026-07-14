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
            txtRoomNuber.Text=room.RoomNumber.ToString();
            txtCapacity.Text=room.Capacity.ToString();
            txtPrice.Text=room.Price.ToString();

        }
        private bool CheckNumber(string number)
        {
            int room;
            bool check=int.TryParse(number, out room);
            if(check)
            {
                return true;
            }
            return false;
        }
        private bool ValidateInputs()
        {
            if (!CheckNumber(txtRoomNuber.Text))
            {
                MessageBox.Show("لطفا برای شماره اتاق عدد وارد کنید");
                txtRoomNuber.Focus();
                return false;
            }


            if (!CheckNumber(txtPrice.Text))
            {
                MessageBox.Show("لطفا برای مبلغ عدد وارد کنید");
                txtPrice.Focus();
                return false;
            }

            if (!CheckNumber(txtCapacity.Text))
            {
                MessageBox.Show("لطفا برای ظرفیت عدد وارد کنید");
                txtCapacity.Focus();
                return false;
            }

            return true;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            int roomNumber = int.Parse(txtRoomNuber.Text);
            int capacity = int.Parse(txtCapacity.Text);
            int price = int.Parse(txtPrice.Text);
            var r = new RoomManager();
            if (_room == null)
            {

                if (!ValidateInputs())
                {
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
            else
            {
                if (!ValidateInputs())
                {
                    return;
                }
                Result result =_room.Update(roomNumber, capacity, price);
                if (result.Success)
                {
                    MessageBox.Show("ویرایش انجام شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }
    }
}
