using BL;
using Hotelmanagement.Properties;
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
    public partial class FrmReservations : Form
    {
        ReservationService _reservationService;
       
        public FrmReservations(ReservationService reservation)
        {
            InitializeComponent();
            _reservationService = reservation;
            _reservationService.Load+=LoadDataGrid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            var frm=new FrmReservation(_reservationService);
            frm.ShowDialog();
            LoadDataGrid();
        }

        private void dgvReserv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmReservations_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
           
        }
        public void LoadDataGrid()
        {
            var reservations = _reservationService.GetReservations();
            var upper = reservations.Data;
            var l=upper.GroupBy(t=>t.RoomId).ToArray();
            dgvReserv.DataSource = reservations.Data;
        }
        public OperationResult<int> CheckNumber(string number)
        {
            int num;
            if (int.TryParse(number, out num) && num > 0)
            {
                return OperationResult<int>.Ok(num);
            }
            return OperationResult<int>.Failed("آدیدی وارد شده معتبر نمی باشد");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var number=CheckNumber(txtDelete.Text);
            if(!number.Success)
            {
                MessageBox.Show(number.Message,"خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult res;
            res = MessageBox.Show("آیا از حذف مطمئن هستید؟","پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult.Yes == res)
            {
                var result = _reservationService.RemoveReservation(number.Data);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("حذف انجام شد", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                txtDelete.Clear();
            }
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            var reservId=CheckNumber(txtEdite.Text);
            if (!reservId.Success)
            {
                MessageBox.Show(reservId.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = _reservationService.GetReservationById(reservId.Data);
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frm=new FrmReservation(result.Data,_reservationService);
            frm.ShowDialog();
            LoadDataGrid();
            //var reserv=new ReservationDto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

      
            
        }
    }
}
