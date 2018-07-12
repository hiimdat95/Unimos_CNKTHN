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
    public partial class dlgAnhXaMonHoc :frmBase
    {
        private DataRow dr;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private SV_AnhXaMonInfo pSV_AnhXaMonInfo;
        private cBSV_AnhXaMon oBSV_AnhXaMon;
        private DataTable dtMonCu, dtMonMoi,dtAnhXaMonHoc;
        private int IDDM_LopCu, IDDM_LopMoi, IDSV_SinhVien;

        public dlgAnhXaMonHoc(DataRow mdr, string TenLopMoi)
        {
            InitializeComponent();
            dr = mdr;
            txtTenLopMoi.Text = TenLopMoi;
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBSV_AnhXaMon = new cBSV_AnhXaMon();
            pSV_AnhXaMonInfo = new SV_AnhXaMonInfo();
        }

        private void dlgAnhXaMonHoc_Load(object sender, EventArgs e)
        {
            txtMaSinhVien.Text = dr["MaSinhVien"].ToString();
            txtTenSinhVien.Text = dr["HoVaTen"].ToString();
            txtTenLopCu.Text = dr["TenLop"].ToString();
            IDDM_LopCu = int.Parse(dr["IDDM_LopCu"].ToString());
            IDDM_LopMoi = int.Parse(dr["IDDM_LopMoi"].ToString());
            IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
            LoadData();
        }
        private void LoadData()
        {
            // get mon lop moi
            dtMonMoi = oBSV_AnhXaMon.GetMonLopMoi(IDSV_SinhVien,IDDM_LopMoi);
            grdMonMoi.DataSource = dtMonMoi;
            dtMonCu = oBSV_AnhXaMon.GetMonLopCu(IDSV_SinhVien, IDDM_LopCu);
            grdMonCu.DataSource = dtMonCu;
            LoadAnhXaMonHoc();
        }

        private DataTable CreateTableMonHoc()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("SV_AnhXaMonID", typeof(int));
            dt.Columns.Add("TenMonHocMoi", typeof(string));
            dt.Columns.Add("TenMonHocCu", typeof(string));
            dt.Columns.Add("SoHTCu", typeof(int));
            dt.Columns.Add("SoHTMoi", typeof(int));
            dt.Columns.Add("HocKyCu", typeof(int));
            dt.Columns.Add("HocKyMoi", typeof(int));
            return dt;
        }

        private void LoadAnhXaMonHoc()
        {
            if (dtAnhXaMonHoc != null)
                dtAnhXaMonHoc.Clear();
            dtAnhXaMonHoc = CreateTableMonHoc();
            DataTable dtTemp = oBSV_AnhXaMon.GetChiTiet(IDSV_SinhVien,IDDM_LopMoi);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                DataRow drNew = dtAnhXaMonHoc.NewRow();
                DataRow[] drAnhXa;
                int intSV_AnhXaMonID = int.Parse(dtTemp.Rows[0]["SV_AnhXaMonID"].ToString());
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (intSV_AnhXaMonID != int.Parse(dtTemp.Rows[i]["SV_AnhXaMonID"].ToString()) || i == 0)
                    {
                        drAnhXa = dtTemp.Select("SV_AnhXaMonID=" + dtTemp.Rows[i]["SV_AnhXaMonID"].ToString());
                        drNew["SV_AnhXaMonID"] = intSV_AnhXaMonID;
                        if (drAnhXa[0]["IDXL_MonHocTrongKyCu"].ToString() != "0")
                        {
                            drNew["Chon"] = false;
                            drNew["SoHTCu"] = drAnhXa[0]["SoHTCu"];
                            drNew["SoHTMoi"] = drAnhXa[1]["SoHTMoi"];
                            drNew["TenMonHocCu"] = drAnhXa[0]["TenMonHocCu"].ToString();
                            drNew["TenMonHocMoi"] = drAnhXa[1]["TenMonHocMoi"].ToString();
                            drNew["HocKyCu"] = drAnhXa[0]["HocKyCu"];
                            drNew["HocKyMoi"] = drAnhXa[1]["HocKyMoi"];
                        }
                        else
                        {
                            drNew["Chon"] = false;
                            drNew["SoHTCu"] = drAnhXa[1]["SoHTCu"];
                            drNew["SoHTMoi"] = drAnhXa[0]["SoHTMoi"];
                            drNew["TenMonHocCu"] = drAnhXa[1]["TenMonHocCu"].ToString();
                            drNew["TenMonHocMoi"] = drAnhXa[0]["TenMonHocMoi"].ToString();
                            drNew["HocKyCu"] = drAnhXa[1]["HocKyCu"];
                            drNew["HocKyMoi"] = drAnhXa[0]["HocKyMoi"];
                        }
                        dtAnhXaMonHoc.Rows.Add(drNew);
                        drNew = dtAnhXaMonHoc.NewRow();
                    }
                    intSV_AnhXaMonID = int.Parse(dtTemp.Rows[i]["SV_AnhXaMonID"].ToString());
                }
            }
            grdAnhXa.DataSource = dtAnhXaMonHoc;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow[] drMonCu = dtMonCu.Select("Chon=1");
            DataRow[] drMonMoi = dtMonMoi.Select("Chon=1");
            if (drMonCu.Length == 1 && drMonMoi.Length == 1)
            {
                pSV_AnhXaMonInfo.IDDM_Lop = IDDM_LopMoi;
                pSV_AnhXaMonInfo.IDSV_SinhVien = IDSV_SinhVien;
                pSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu = int.Parse(drMonCu[0]["XL_MonHocTrongKyID"].ToString());
                pSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi = int.Parse(drMonMoi[0]["XL_MonHocTrongKyID"].ToString());
                oBSV_AnhXaMon.Add(pSV_AnhXaMonInfo);
                LoadData();
                ThemThanhCong();
            }
            else
                ThongBao("Bạn phải chọn mỗi danh sách 1 môn!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow[] drAnhXa = dtAnhXaMonHoc.Select("Chon=1");
            if (drAnhXa.Length > 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    foreach (DataRow dr in drAnhXa)
                    {
                        try
                        {
                            pSV_AnhXaMonInfo.SV_AnhXaMonID = int.Parse(dr["SV_AnhXaMonID"].ToString());
                            oBSV_AnhXaMon.Delete(pSV_AnhXaMonInfo);
                        }
                        catch { }
                    }
                    XoaThanhCong();
                    LoadData();
                }
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (dtAnhXaMonHoc != null && dtAnhXaMonHoc.Rows.Count > 0)
            {
                dlgApDungAnhXaMon dlg = new dlgApDungAnhXaMon(dr);
                dlg.ShowDialog();
            }
            else
                ThongBao("Không có môn để áp dụng!");
        }
    }
}