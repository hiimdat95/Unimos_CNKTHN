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
    public partial class frmCongThucDiemToanKhoa : frmBase
    {
        private KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo;
        private cBKQHT_CongThucDiemToanKhoa oBKQHT_CongThucDiemToanKhoa;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private DataTable dtThanhPhan, dtCongThuc;
        private int KQHT_CongThucDiemToanKhoaID = 0, SoSauDauPhay;
        private double Value;

        public frmCongThucDiemToanKhoa()
        {
            InitializeComponent();
            pKQHT_CongThucDiemToanKhoaInfo = new KQHT_CongThucDiemToanKhoaInfo();
            oBKQHT_CongThucDiemToanKhoa = new cBKQHT_CongThucDiemToanKhoa();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
        }

        private void frmCongThucDiemToanKhoa_Load(object sender, EventArgs e)
        {
            LoadCongThucDiem();
            LoadThanhPhan();
        }
        private void LoadThanhPhan()
        {
            dtThanhPhan = CreateTable();
            XuLyTable();
            grdThanhPhanDiem.DataSource = dtThanhPhan;
        }
        private void LoadCongThucDiem()
        {
            pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = 0;
            dtCongThuc = oBKQHT_CongThucDiemToanKhoa.Get(pKQHT_CongThucDiemToanKhoaInfo);
            cmbCongThuc.Properties.DataSource = dtCongThuc;
        }

        private void cmbCongThuc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCongThuc.EditValue != null)
            {
                KQHT_CongThucDiemToanKhoaID = int.Parse(cmbCongThuc.EditValue.ToString());
                txtTenCongThuc.Text = cmbCongThuc.Text;
                txtCongThuc.Text = cmbCongThuc.GetColumnValue("CongThuc").ToString();
                txtGhiChu.Text = cmbCongThuc.GetColumnValue("GhChu").ToString();
            }
            else
                ClearText();
        }
        private void ClearText()
        {
            txtCongThuc.Text = "";
            txtGhiChu.Text = "";
            txtTenCongThuc.Text = "";
            KQHT_CongThucDiemToanKhoaID = 0;
            txtTenCongThuc.Focus();
        }
        private bool CheckValid()
        {
            if (txtCongThuc.Text.Trim() == "")
            {
                ThongBao("Bạn chưa nhập công thức !");
                return false;
            }
            if (txtTenCongThuc.Text.Trim() == "")
            {
                ThongBao("Bạn chưa chọn môn học !");
                return false;
            }
            if (dtThanhPhan.Rows.Count <= 0)
            {
                ThongBao("Chưa có thành phần điểm nào, bạn chưa thể lập công thức điểm !");
                return false;
            }
            return true;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("KyHieu", typeof(string));
            dt.Columns.Add("TenThanhPhan", typeof(string));
            dt.Columns.Add("GiaTri", typeof(float));
            return dt;
        }
        private void XuLyTable()
        {

            DataTable dtData = oBKQHT_MonThiTotNghiep_Lop.GetAllMon(Program.IDNamHoc);
            DataRow drNew;

            try
            {
                // add DiemToanKhoa
                drNew = dtThanhPhan.NewRow();
                drNew["KyHieu"] = "TBTK";
                drNew["TenThanhPhan"] = "Điểm TB toàn khóa";
                drNew["GiaTri"] = 7;
                dtThanhPhan.Rows.Add(drNew);

                if (dtData != null)
                {
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        drNew = dtThanhPhan.NewRow();
                        drNew["KyHieu"] = dtData.Rows[i]["MaMonHoc"];
                        drNew["TenThanhPhan"] = dtData.Rows[i]["TenMonHoc"];
                        drNew["GiaTri"] = 7;
                        dtThanhPhan.Rows.Add(drNew);
                    }
                }
               
            }
            catch
            { }
        }

        private void grvThanhPhanDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
        private bool TestCongThuc()
        {
            try
            {
                MathParser parser = new MathParser();
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    parser.CreateVar(dr["KyHieu"].ToString(), double.Parse(dr["GiaTri"].ToString()), null);
                }
                string formula = null;
                formula = txtCongThuc.Text;
                parser.OptimizationOn = true;
                if (formula.IndexOf("R+(") == 0 | formula.IndexOf("R-(") == 0)
                {
                    SoSauDauPhay = int.Parse(formula.Substring(3, 1));
                    double tmp = 0;
                    if (formula.IndexOf("R+(") == 0)
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, true);
                    }
                    else
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, false);
                    }
                }
                else
                {
                    parser.Expression = formula;
                    parser.Parse();
                    Value = double.Parse(parser.Value.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (txtCongThuc.Text.Trim() == "")
            {
                ThongBao("Bạn chưa nhập công thức !");
                return;
            }
            if (dtThanhPhan.Rows.Count <= 0)
            {
                ThongBao("Chưa có thành phần điểm nào, bạn chưa thể lập công thức điểm !");
                return;
            }

            if (!TestCongThuc())
                ThongBao("Công thức sai hãy kiểm tra lại");
           
            else
                ThongBao("Công thức hợp lệ, kết quả trả về của phép kiểm tra: " + Value.ToString());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            string CongThuc = txtCongThuc.Text.Trim();
            if (!TestCongThuc())
            {
                ThongBao("Công thức sai hãy kiểm tra lại");
                return;
            }
         
           if (KQHT_CongThucDiemToanKhoaID >0)
            {
                pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = KQHT_CongThucDiemToanKhoaID;
                pKQHT_CongThucDiemToanKhoaInfo.CongThuc = CongThuc;
                pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem = txtTenCongThuc.Text.Trim();
                pKQHT_CongThucDiemToanKhoaInfo.GhChu = txtGhiChu.Text;
                oBKQHT_CongThucDiemToanKhoa.Update(pKQHT_CongThucDiemToanKhoaInfo);
                SuaThanhCong();
            }
         
        }

        private void btnTronTren_Click(object sender, EventArgs e)
        {
            txtCongThuc.Text = "R+(1)" + txtCongThuc.Text;
        }

        private void btnTronDuoi_Click(object sender, EventArgs e)
        {
            txtCongThuc.Text = "R-(1)" + txtCongThuc.Text;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            string CongThuc = txtCongThuc.Text.Trim();
            if (!TestCongThuc())
            {
                ThongBao("Công thức sai hãy kiểm tra lại");
                return;
            }

            if (KQHT_CongThucDiemToanKhoaID == 0)
            {
                pKQHT_CongThucDiemToanKhoaInfo.CongThuc = CongThuc;
                pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem = txtTenCongThuc.Text.Trim();
                pKQHT_CongThucDiemToanKhoaInfo.GhChu = txtGhiChu.Text;
                oBKQHT_CongThucDiemToanKhoa.Add(pKQHT_CongThucDiemToanKhoaInfo);
                ThemThanhCong();
                LoadCongThucDiem();
                ClearText();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                if (KQHT_CongThucDiemToanKhoaID > 0)
                {
                    try
                    {
                        pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = KQHT_CongThucDiemToanKhoaID;
                        oBKQHT_CongThucDiemToanKhoa.Delete(pKQHT_CongThucDiemToanKhoaInfo);
                        XoaThanhCong();
                    }
                    catch { XoaThatBai(); }
                }
                LoadThanhPhan();
                ClearText();
            }
        }

        private void cmbCongThuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbCongThuc.EditValue = null;
        }

    }
}