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
        private RoomManager _manager;
        private Room _room;
        public FrmRoom(RoomManager manager)
        {
            InitializeComponent();
            _manager = manager;
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
        private void DoCheck()
        {
            CheckNumber(txtRoomNuber.Text);
            CheckNumber(txtCapacity.Text);
            CheckNumber(txtPrice.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            
            if (_room == null)
            {
                
                DoCheck();
                if (!ValidateInputs())
                {
                    return;
                }
                int capacity=int.Parse(txtCapacity.Text);
                decimal price=decimal.Parse(txtPrice.Text);
                Room room=new Room(txtRoomNuber.Text, capacity,price);
                Result result = _manager.AddRoom(room);
                if(result.Success)
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

                DoCheck();
                if (!ValidateInputs())
                {
                    return;
                }
                int capacity = int.Parse(txtCapacity.Text);
                decimal price = decimal.Parse(txtPrice.Text);
                Result result =_manager.Update(_room.Id,txtRoomNuber.Text,capacity,price);
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
