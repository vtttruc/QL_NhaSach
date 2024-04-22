using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace BaoCao_QuanLyNhaSach
{
    public partial class frmDoanhThu1 : Form
    {
        public frmDoanhThu1()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = InvoiceSaleBUS.GetStat();
            dtp_TuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtp_DenNgay.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = InvoiceSaleBUS.GetStat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = InvoiceSaleBUS.GetDayToDay(dtp_TuNgay.Value, dtp_DenNgay.Value);
            dgvTotal.DataSource = InvoiceSaleBUS.GetDoanhThuDayToDay(dtp_TuNgay.Value, dtp_DenNgay.Value);
            //if (txtYear.Text == "")
            //{
            //    if (txtMonth.Text == "")
            //    {
            //        if (txtDay.Text == "")
            //        {
            //            MessageBox.Show("Vui lòng nhập ngày, tháng, năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtDay.Focus();
            //        }
            //    }
            //}
            //else
            //{
            //    if (txtMonth.Text == "")
            //    {
            //        if (int.Parse(txtYear.Text) < 1900 || int.Parse(txtYear.Text) > DateTime.Now.Year)
            //        {
            //            MessageBox.Show("Năm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtYear.Focus();
            //        }
            //        else
            //        {
            //            dgvStatistics.DataSource = InvoiceSaleBUS.GetByYearEnH(txtYear.Text);
            //            dgvTotal.DataSource = InvoiceSaleBUS.GetDoanhThuYear(txtYear.Text);

            //        }
            //    }
            //    else
            //    {
            //        if (txtDay.Text == "")
            //        {
            //            if (InvoiceSaleDAO.CheckMonth(int.Parse(txtMonth.Text), int.Parse(txtYear.Text)))
            //            {
            //                dgvStatistics.DataSource = InvoiceSaleBUS.GetByMonthEnH(txtMonth.Text, txtYear.Text);
            //                dgvTotal.DataSource = InvoiceSaleBUS.GetDoanhThuMonth(txtMonth.Text, txtYear.Text);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Tháng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtMonth.Focus();
            //            }
            //        }
            //        else
            //        {
            //            int day = int.Parse(txtDay.Text);
            //            int month = int.Parse(txtMonth.Text);
            //            int year = int.Parse(txtYear.Text);

            //            if (InvoiceSaleDAO.CheckDate(day, month, year) == false)
            //            {
            //                MessageBox.Show("Ngày không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtDay.Focus();
            //                return;
            //            }
            //            // Gọi hàm GetByDayEnH() để tìm kiếm hóa đơn bán
            //            dgvStatistics.DataSource = InvoiceSaleBUS.GetByDayEnH(txtDay.Text, txtMonth.Text, txtYear.Text);
            //            dgvTotal.DataSource = InvoiceSaleBUS.GetDoanhThuDay(txtDay.Text, txtMonth.Text, txtYear.Text);
            //        }
            //    }
            //}
        }

        private void dtp_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if(dtp_TuNgay.Value > dtp_DenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtp_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_TuNgay.Value > dtp_DenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
