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
        public event EventHandler DeleteTextChanged;
        RoomManager _roomManager;
        public FrmRooms(RoomManager manager)
        {
            InitializeComponent();
            _roomManager = manager;
            _roomManager.RoomAdded += RoomMnager_RoomAdded;
            _roomManager.RoomRemoved += Remove_Room;
            DeleteTextChanged += lable;
        }
        void RoomMnager_RoomAdded(object sender, EventArgs e)
        {
            LoadRooms();
        }
        void Remove_Room(object sender, EventArgs e)
        {
            LoadRooms();
            MessageBox.Show("!حذف انجام شد");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            var frm=new FrmRoom(_roomManager);
            frm.ShowDialog();
            
        }
        void lable(Object sender,EventArgs e)
        {
            
            if(txtDelete.TextLength>0)
            {
                label1.Visible = false;
            }
            else
                label1.Visible=true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (!CheckNumber(txtDelete.Text))
            {
                MessageBox.Show("شماره اتاق معبر نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Result result = _roomManager.RemoveRoom(int.Parse(txtDelete.Text));
            DialogResult res;
            res = MessageBox.Show(" آیا از حذف مطمئن هستید؟", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result.Success && DialogResult.Yes == res)
            {
                
                txtDelete.Clear();
                txtDelete.Focus();
                
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
            var manager = new RoomManager();

            if (!CheckNumber(txtEdite.Text))
            {
                MessageBox.Show("لطفاً برای ویرایش آیدی صحیح وارد کنید");
                return;
            }
            Room rom=manager.GetRoomById(int.Parse(txtEdite.Text));
            if (rom != null)
            {
                var frm = new FrmRoom(rom);
                frm.ShowDialog();
                LoadRooms();
            }
            else
            {
                MessageBox.Show("شماره اتاق وارد شده موجود نیست");
                txtEdite.Clear();
                txtEdite.Focus();
            }

        }
        public void LoadRooms()
        {
            
            List<Room> rooms = _roomManager.GetRooms();
            dgvRooms.DataSource = rooms;
        }
        private void FrmRooms_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            LoadRooms();
        }

        private void txtDelete_TextChanged(object sender, EventArgs e)
        {
            DeleteTextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtDelete_MouseEnter(object sender, EventArgs e)
        {
            txtDelete.Focus();
        }
    }
}
