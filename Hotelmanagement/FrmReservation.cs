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
    public partial class FrmReservation : Form
    {
        private Reservation _reserv;
        public FrmReservation()
        {
            InitializeComponent();
        }
        public FrmReservation(Reservation reserv)
        {
            InitializeComponent();
            _reserv = reserv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dateIn = dtpIn.Value.Date;
            DateTime dateOut = dtpOut.Value.Date;

            if (_reserv == null)
            {
                Guest guest = (Guest)cbGuestId.SelectedItem;
                Room room = (Room)cbRoomNumber.SelectedItem;

                ReservationManager manager = new ReservationManager();
                var reserv = new Reservation(guest, room, dateIn, dateOut);
                Result result = manager.AddReserv(reserv);
                if (result.Success)
                {
                    MessageBox.Show("رزرو ثبت شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message,"خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void FrmReservation_Load(object sender, EventArgs e)
        {
            cbGuestId.DataSource = GuestManager.GetGuests();
            var roomManager = new RoomManager();
            cbRoomNumber.DataSource = roomManager.GetRooms();
            cbRoomNumber.DisplayMember = "RoomNumber";

        }
    }
}
