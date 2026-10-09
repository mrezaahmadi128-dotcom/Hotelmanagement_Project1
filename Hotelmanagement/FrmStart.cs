using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            var guest = new GuestService();
            var frm=new FrmGuests(guest);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomService service = new RoomService();
            var frm=new FrmRooms(service);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var reserv = new ReservationService();
            var frm = new FrmReservations(reserv);
            frm.ShowDialog();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
           
           
            
        }
    }
}
