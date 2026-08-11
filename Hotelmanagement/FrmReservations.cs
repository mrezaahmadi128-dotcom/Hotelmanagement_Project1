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
            dgvReserv.DataSource=ReservationManager.GetReservation().ToList();
        }

        private void dgvReserv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
