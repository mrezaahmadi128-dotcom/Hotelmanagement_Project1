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
    public partial class FrmReservations : Form
    {
        public FrmReservations()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            var frm=new FrmReservation();
            frm.ShowDialog();
            ReservationManager manager = new ReservationManager();
            List<Reservation> reservations = manager.GetReservations();
            dgvReserv.DataSource = reservations;


        }

        private void dgvReserv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmReservations_Load(object sender, EventArgs e)
        {
            ReservationManager manager=new ReservationManager();
            List<Reservation> reservations=manager.GetReservations();
            dgvReserv.DataSource = reservations;
        }
    }
}
