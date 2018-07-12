using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgDinhMuc : frmBase
    {
        private int SoThangChon = 0;
        private DataRow[] dr;
        public DataTable dtChiTiet;

        public dlgDinhMuc(DataRow[] mdr)
        {
            InitializeComponent();
            dr = mdr;
        }

        private void dlgDinhMuc_Load(object sender, EventArgs e)
        {

        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDSV_SinhVien", typeof(int));
            dt.Columns.Add("Thang", typeof(int));
            return dt;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            if (SoThangChon > 0)
            {
                dtChiTiet = CreateTable();
                DataRow drChiTiet;
                foreach (DataRow mdr in dr)
                {
                    if (chk1.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 1;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk2.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 2;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk3.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 3;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk4.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 4;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk5.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 5;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk6.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 6;
                        dtChiTiet.Rows.Add(drChiTiet);

                    }
                    if (chk7.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 7;
                        dtChiTiet.Rows.Add(drChiTiet);

                    }

                    if (chk8.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 8;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk9.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 9;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk10.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 10;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk11.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 11;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                    if (chk12.Checked == true)
                    {
                        drChiTiet = dtChiTiet.NewRow();
                        drChiTiet["IDSV_SinhVien"] = mdr["SV_SinhVienID"];
                        drChiTiet["Thang"] = 12;
                        dtChiTiet.Rows.Add(drChiTiet);
                    }
                }
                this.Tag = "1";
                this.Close();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 tháng!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Tag = "2";
            this.Close();
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk3.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk4.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk5.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk6.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk7.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk8.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk9.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk10_CheckedChanged(object sender, EventArgs e)
        {
            if (chk10.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk11_CheckedChanged(object sender, EventArgs e)
        {
            if (chk11.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk12.Checked == true)
                SoThangChon += 1;
            else
                SoThangChon -= 1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}