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
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }

     
        private void btnViewGuest_Click(object sender, EventArgs e)
        {
            var frm=new FrmGuests();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm=new FrmRooms();
            frm.ShowDialog();
        }
    }
}
