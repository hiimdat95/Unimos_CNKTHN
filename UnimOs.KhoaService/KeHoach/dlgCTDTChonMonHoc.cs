using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;

namespace UnimOs.Khoa
{
    public partial class dlgCTDTChonMonHoc : frmBase
    {
        private cBwsKQHT_MonHoc_CT_KhoiKienThuc oBKQHT_MonHoc_CT_KhoiKienThuc;
        private KQHT_MonHoc_CT_KhoiKienThucInfo pInfo;
        private DataTable dtMon, dtMonHoc;
        private bool ThemMon = false;

        public dlgCTDTChonMonHoc(int mIDKQHT_CT_KhoiKienThuc, string TenCTDT, ref DataTable _dtMonHoc)
        {
            InitializeComponent();
            dtMonHoc = _dtMonHoc;
            oBKQHT_MonHoc_CT_KhoiKienThuc = new cBwsKQHT_MonHoc_CT_KhoiKienThuc();
            pInfo = new KQHT_MonHoc_CT_KhoiKienThucInfo();
            pInfo.IDKQHT_CT_KhoiKienThuc = mIDKQHT_CT_KhoiKienThuc;
            lblCTDT.Text = TenCTDT.ToUpper();
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgCTDTChonMonHoc_Load(object sender, EventArgs e)
        {
            cBwsDM_MonHoc oBDM_MonHoc = new cBwsDM_MonHoc();
            dtMon = oBDM_MonHoc.GetNotInIDCTKhoiKienThuc(pInfo.IDKQHT_CT_KhoiKienThuc);
            grdMonHoc.DataSource = dtMon;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtChange = dtMon.GetChanges();
                if (dtChange != null)
                {
                    DataRow dr, drNew;
                    int count = dtChange.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        dr = dtChange.Rows[i];
                        if (bool.Parse(dr["Chon"].ToString()) == true)
                        {
                            pInfo.IDDM_MonHoc = int.Parse(dr["DM_MonHocID"].ToString());
                            pInfo.SoHocTrinh = float.Parse(dr["SoHocTrinh"].ToString());
                            pInfo.SoTiet = int.Parse(dr["SoTiet"].ToString());
                            pInfo.LyThuyet = int.Parse("0" + dr["LyThuyet"]);
                            pInfo.ThucHanh = int.Parse("0" + dr["ThucHanh"]);
                            pInfo.LoaiTietKhac1 = int.Parse("0" + dr["LoaiTietKhac1"]);
                            pInfo.LoaiTietKhac2 = int.Parse("0" + dr["LoaiTietKhac2"]);
                            pInfo.ChoPhepXepLich = bool.Parse(dr["ChoPhepXepLich"].ToString());
                            pInfo.IDDM_HinhThucThi = int.Parse(dr["IDDM_HinhThucThi"].ToString());
                            pInfo.TuChon = false;
                            pInfo.TinhDiemToanKhoa = bool.Parse(dr["TinhDiemToanKhoa"].ToString());

                            pInfo.KQHT_MonHoc_CT_KhoiKienThucID = oBKQHT_MonHoc_CT_KhoiKienThuc.Add(pInfo);

                            drNew = dtMonHoc.NewRow();
                            oBKQHT_MonHoc_CT_KhoiKienThuc.ToDataRow(pInfo, ref drNew);
                            drNew["Chon"] = false;
                            drNew["MaMonHoc"] = dr["MaMonHoc"];
                            drNew["TenMonHoc"] = dr["TenMonHoc"];
                            dtMonHoc.Rows.Add(drNew);

                            DataRow[] arrDr = dtMon.Select("DM_MonHocID = " + dr["DM_MonHocID"]);
                            dtMon.Rows.Remove(arrDr[0]);
                         }
                    }
                    ThemMon = true;
                }
                else
                    ThongBao("Bạn chưa chọn môn nào.");
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (ThemMon)
                this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}