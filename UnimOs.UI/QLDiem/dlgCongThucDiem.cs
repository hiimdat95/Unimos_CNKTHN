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
    public partial class dlgCongThucDiem : frmBase
    {
        private DataTable dtThanhPhan, dtCongThuc, dtMonHoc;
        private DataRow drCongThuc;
        private int IDDM_Lop, SoSauDauPhay;
        private double Value;
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo;
        private cBKQHT_CongThucDiem_ThanhPhanDiem oBKQHT_CongThucDiem_ThanhPhanDiem;
        private KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo;
        private EDIT_MODE edit;
        private string ToanTu = "+-*/()";

        public dlgCongThucDiem(DataTable mdtCongThuc, DataRow mdrCongThuc, EDIT_MODE mEdit, int mIDDM_Lop)
        {
            InitializeComponent();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
            pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
            oBKQHT_CongThucDiem_ThanhPhanDiem = new cBKQHT_CongThucDiem_ThanhPhanDiem();
            pKQHT_CongThucDiem_ThanhPhanDiemInfo = new KQHT_CongThucDiem_ThanhPhanDiemInfo();
            dtCongThuc = mdtCongThuc;
            drCongThuc = mdrCongThuc;
            edit = mEdit;
            IDDM_Lop = mIDDM_Lop;
        }

        private void dlgCongThucDiem_Load(object sender, EventArgs e)
        {
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetLapCongThuc();
            grdThanhPhanDiem.DataSource = dtThanhPhan;
            if (edit == EDIT_MODE.THEM)
            {
                dtMonHoc = oBKQHT_CongThucDiem.GetMonChuaToChuc(IDDM_Lop, Program.IDNamHoc, Program.HocKy, 0);
                cmbMonHoc.Properties.DataSource = dtMonHoc;
            }
            else
            {
                oBKQHT_CongThucDiem.ToInfo(ref pKQHT_CongThucDiemInfo, drCongThuc);
                cmbMonHoc.Properties.DataSource = oBKQHT_CongThucDiem.GetMonChuaToChuc(IDDM_Lop, Program.IDNamHoc, Program.HocKy, pKQHT_CongThucDiemInfo.IDDM_MonHoc);
                cmbMonHoc.EditValue = pKQHT_CongThucDiemInfo.IDDM_MonHoc;
                txtCongThuc.Text = pKQHT_CongThucDiemInfo.CongThuc;
            }
        }

        private bool TestCongThuc()
        {
            try
            {
                MathParser parser = new MathParser();
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    parser.CreateVar(dr["KyHieu"].ToString(), double.Parse(dr["GiaTriKiemTra"].ToString()), null);
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

        private bool ThanhPhanChuaTrongCongThuc(string KyHieuThanhPhan, string CongThuc)
        {
            // Nếu trong công thức có chứa ký hiệu thì kiểm tra tiếp ký hiệu trước và sau nó
            string str;
            int idx = CongThuc.IndexOf(KyHieuThanhPhan);
            if (idx == 0)
            {
                if (CongThuc.Length == KyHieuThanhPhan.Length)
                    return true;
                else
                {
                    str = CongThuc.Substring(KyHieuThanhPhan.Length, 1);
                    if (ToanTu.IndexOf(str) >= 0)
                        return true;
                }
            }
            else if (idx + KyHieuThanhPhan.Length == CongThuc.Length)
            {
                str = CongThuc.Substring(idx - 1, 1);
                if (ToanTu.IndexOf(str) >= 0)
                    return true;
            }
            else if (idx > 0)
            {
                str = CongThuc.Substring(idx - 1, 1);
                string str1 = CongThuc.Substring(idx + KyHieuThanhPhan.Length, 1);
                if (ToanTu.IndexOf(str) >= 0 & ToanTu.IndexOf(str1) >= 0)
                    return true;
            }
            return false;
        }

        private bool CheckValid()
        {
            if (txtCongThuc.Text.Trim() == "")
            {
                ThongBao("Bạn chưa nhập công thức !");
                return false;
            }
            if (cmbMonHoc.EditValue == null)
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

        private void GetpCongThucDiemInfo()
        {
            pKQHT_CongThucDiemInfo.IDDM_Lop = IDDM_Lop;
            pKQHT_CongThucDiemInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
            pKQHT_CongThucDiemInfo.IDDM_NamHoc = Program.IDNamHoc;
            pKQHT_CongThucDiemInfo.HocKy = Program.HocKy;
            pKQHT_CongThucDiemInfo.CongThuc = txtCongThuc.Text.Trim();
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
            if (CongThuc.IndexOf("R+(") == 0 | CongThuc.IndexOf("R-(") == 0)
                CongThuc = CongThuc.Substring(5, CongThuc.Length - 5);
            if (edit == EDIT_MODE.THEM)
            {
                try
                {
                    GetpCongThucDiemInfo();

                    pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID = oBKQHT_CongThucDiem.Add(pKQHT_CongThucDiemInfo);
                    DataRow drNew = dtCongThuc.NewRow();
                    oBKQHT_CongThucDiem.ToDataRow(pKQHT_CongThucDiemInfo, ref drNew);
                    drNew["TenMonHoc"] = cmbMonHoc.Text;
                    dtCongThuc.Rows.Add(drNew);

                    pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem = pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID;
                    foreach (DataRow dr in dtThanhPhan.Rows)
                    {
                        if (ThanhPhanChuaTrongCongThuc(dr["KyHieu"].ToString(), CongThuc))
                        {
                            pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem = int.Parse(dr["KQHT_ThanhPhanDiemID"].ToString());
                            oBKQHT_CongThucDiem_ThanhPhanDiem.Add(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
                        }
                    }
                    txtCongThuc.Text = "";
                    DataRow[] arrDr = dtMonHoc.Select("IDDM_MonHoc = " + cmbMonHoc.EditValue);
                    dtMonHoc.Rows.Remove(arrDr[0]);
                    ThemThanhCong();
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (txtCongThuc.Text.Trim() != pKQHT_CongThucDiemInfo.CongThuc)
                    {

                        GetpCongThucDiemInfo();
                        oBKQHT_CongThucDiem.Update(pKQHT_CongThucDiemInfo);
                        DataTable dt = oBKQHT_CongThucDiem_ThanhPhanDiem.GetByCongThucDiem(pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID);

                        foreach (DataRow dr in dt.Rows)
                        {
                            if (ThanhPhanChuaTrongCongThuc(dr["KyHieu"].ToString(), CongThuc))
                                CongThuc = CongThuc.Replace(dr["KyHieu"].ToString(), "");
                            else
                            {
                                pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID = int.Parse(dr["KQHT_CongThucDiem_ThanhPhanDiemID"].ToString());
                                oBKQHT_CongThucDiem_ThanhPhanDiem.Delete(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
                            }
                        }
                        if (CongThuc.Length > 0)
                        {
                            pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem = pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID;
                            foreach (DataRow dr in dtThanhPhan.Rows)
                            {
                                if (ThanhPhanChuaTrongCongThuc(dr["KyHieu"].ToString(), CongThuc))
                                {
                                    pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem = int.Parse(dr["KQHT_ThanhPhanDiemID"].ToString());
                                    oBKQHT_CongThucDiem_ThanhPhanDiem.Add(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
                                }
                            }
                        }
                    }
                    drCongThuc["CongThuc"] = txtCongThuc.Text.Trim();
                    SuaThanhCong();
                    this.Close();
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }
    }
}