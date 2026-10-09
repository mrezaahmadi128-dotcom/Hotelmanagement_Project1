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
    public partial class FrmRoom : Form
    {
       
        private RoomService _manager;
        private RoomDto _room;
        public FrmRoom(RoomService manager)
        {
            InitializeComponent();
            _manager = manager;
            
        }
        public FrmRoom(RoomDto room,RoomService manager)
        {
            InitializeComponent();
            _manager=manager;
            _room = room;
            txtRoomNuber.Text=room.RoomNumber;
            txtCapacity.Text=room.Capacity.ToString();
            txtPrice.Text=room.Price.ToString();

        }
        //bool validateCapacity(Room room)
        //{
        //    if (room.Capacity > 0)
        //        return true;
        //    return false;
        //}
        private bool CheckNumber(string number)
        {
            int room;
            return int.TryParse(number, out room);
        }
        private bool CheckNumberForDecimal(string price)
        {
            decimal mablagh;
            return decimal.TryParse(price, out mablagh);

        }
        private bool ValidateInputs(string roomNumber,string price,string capaCity)
        {
            if (!CheckNumber(roomNumber))
            {
                MessageBox.Show("لطفا برای شماره اتاق عدد وارد کنید");
                txtRoomNuber.Focus();
                return false;
            }


            if (!CheckNumberForDecimal(price))
            {
                MessageBox.Show("لطفا برای مبلغ عدد وارد کنید");
                txtPrice.Focus();
                return false;
            }

            if (!CheckNumber(capaCity))
            {
                MessageBox.Show("لطفا برای ظرفیت عدد وارد کنید");
                txtCapacity.Focus();
                return false;
            }

            return true;
        }
        private bool DoCheck()
        {
           if( CheckNumber(txtRoomNuber.Text)&&
               CheckNumber(txtCapacity.Text) &&
               CheckNumberForDecimal(txtPrice.Text))       
            {
                return true;
            }
           return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            
            if (_room == null)
            {

                if (!DoCheck())
                    return;
                if (!ValidateInputs(txtRoomNuber.Text,txtPrice.Text,txtCapacity.Text))
                {
                    return;
                }
                int capacity=int.Parse(txtCapacity.Text);
                decimal price=decimal.Parse(txtPrice.Text);
                RoomDto room=new RoomDto(txtRoomNuber.Text, capacity,price);
                var result = _manager.AddRoom(room);
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
                if (!ValidateInputs(txtRoomNuber.Text,txtPrice.Text,txtCapacity.Text))
                {
                    return;
                }
                int capacity = int.Parse(txtCapacity.Text);
                decimal price = decimal.Parse(txtPrice.Text);
                OperationResult result =_manager.Update(_room.Id,txtRoomNuber.Text,capacity,price);
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

        private void FrmRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
