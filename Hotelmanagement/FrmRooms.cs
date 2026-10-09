using BL;
using Common.Constants;
using Hotelmanagement.Properties;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagement
{
    public partial class FrmRooms : Form
    {
        public event EventHandler DeleteTextChanged;
        RoomService _roomService;
        public FrmRooms(RoomService manager)
        {
            InitializeComponent();
            _roomService = manager;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            var frm=new FrmRoom(_roomService);
            frm.ShowDialog();
            LoadRooms();
            
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
                
                errorProvider1.SetError(txtDelete,Resources.IdError);
                
                //MessageBox.Show("", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
             DialogResult res;
             res = MessageBox.Show(Resources.DeleteMessage,Resources.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if ( DialogResult.Yes == res)
             {
                var result = _roomService.RemoveRoom(int.Parse(txtDelete.Text));
                if (result.Success)
                {

                    txtDelete.Clear();
                    txtDelete.Focus();
                    LoadRooms();
                }
                else
                {
                    MessageBox.Show(result.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
             
            
            }
        
        private bool CheckNumber(string number)
        {
            int result;
            return int.TryParse(number, out  result);
        }
        private void btnEdite_Click(object sender, EventArgs e)
        {
            

            if (!CheckNumber(txtEdite.Text))
            {
                MessageBox.Show(Resources.EditeError);
                return;
            }
            var result=_roomService.GetRoomById(int.Parse(txtEdite.Text));
            if (result.Success)
            {
                var frm = new FrmRoom(result.Data,_roomService);
                frm.ShowDialog();
                LoadRooms();
            }
            else
            {
                MessageBox.Show(Resources.Room_unavailable);
                txtEdite.Clear();
                txtEdite.Focus();
            }

        }
        public void LoadRooms()
        {
            
            var result = _roomService.GetRooms();
            var f=result.Data;
            
            if(result.Success)
            {
                dgvRooms.DataSource = result.Data;
            }
          // var prices=result.Data.Where(x=>x.Price> 1000000).Select(x=>x.RoomNumber).ToList();
        }
        private void FrmRooms_Load(object sender, EventArgs e)
        {
           
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

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture=new CultureInfo("en");
            btnEnglish.BackColor = Color.Red;
            btnPerLanguage.BackColor = Color.White;

        }

        private void btnPerLanguage_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa");
            btnPerLanguage.BackColor = Color.Red;
            btnEnglish.BackColor = Color.White;
        }
    }
}
