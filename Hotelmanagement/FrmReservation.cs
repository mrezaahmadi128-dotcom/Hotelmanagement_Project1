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
    public partial class FrmReservation : Form
    {
        private ReservationDto _reserv;
        ReservationService _service;
        public FrmReservation(ReservationService service)
        {
            InitializeComponent();
            _service = service;
            
        }

        public FrmReservation(ReservationDto reserv, ReservationService service)
        {
            InitializeComponent();
            _service = service;
            _reserv = reserv;
            dtpIn.Value = _reserv.CheckIn;
            dtpOut.Value = _reserv.CheckOut;
            lblTotalPrice.Text = _reserv.TotalPrice.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dateIn = dtpIn.Value.Date;
            DateTime dateOut = dtpOut.Value.Date;

            if (_reserv == null)
            {
                
                int guest = Convert.ToInt32(cbGuest.SelectedValue);
                int room = Convert.ToInt32(cbRoom.SelectedValue);
                var reserv = new ReservationDto(guest, room, dateIn, dateOut,0);
                OperationResult result = _service.AddReservation(reserv);
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
            else
            {
                int guest = Convert.ToInt32(cbGuest.SelectedValue);
                int room = Convert.ToInt32(cbRoom.SelectedValue);
                var reserv = new ReservationDto(_reserv.Id,guest, room, dateIn, dateOut, 0);
                var result = _service.UpdateReservation(reserv);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("رزرو ویرایش شد");
                this.Close();

            }
        }
        public void ReadData()
        {
            GuestService _guest = new GuestService();
            RoomService _room = new RoomService();
            var guest = _guest.GetGuests();
            var room = _room.GetRooms();
            cbRoom.DataSource = room.Data;
            cbRoom.DisplayMember = "Display";
            cbRoom.ValueMember = "Id";
            cbGuest.DataSource = guest.Data;
            cbGuest.DisplayMember = "Display";
            cbGuest.ValueMember = "Id";
        }
        private void FrmReservation_Load(object sender, EventArgs e)
        {
                ReadData();
            if(_reserv!=null)
            {
                cbGuest.SelectedValue = _reserv.GuestId;
                cbRoom.SelectedValue = _reserv.RoomId;
            }
        }
    }
}
