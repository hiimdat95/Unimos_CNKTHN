using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class dlgChuyenLop_ChuyenDiem : frmBase
    {
        public int IDSV_SinhVien, IDDM_LopCu, IDDM_LopMoi;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private DataTable dtMonLopCu, dtMonLopMoi, dtAnhXa;

        public dlgChuyenLop_ChuyenDiem()
        {
            InitializeComponent();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
        }

        private void dlgChuyenLop_ChuyenDiem_Load(object sender, EventArgs e)
        {
            dtMonLopCu = oBXL_MonHocTrongKy.GetDiemMonByIDSV_SinhVienAndIDDM_Lop(IDSV_SinhVien, IDDM_LopCu);
            dtMonLopMoi = oBXL_MonHocTrongKy.GetDiemMonByIDSV_SinhVienAndIDDM_Lop(IDSV_SinhVien, IDDM_LopMoi);
            CreateTableAnhXa();

            grdMonLopCu.DataSource = dtMonLopCu;
            grdMonLopMoi.DataSource = dtMonLopMoi;
            bgrdAnhXa.DataSource = dtAnhXa;
        }

        private void CreateTableAnhXa()
        {
            dtAnhXa = new DataTable();
            dtAnhXa.Columns.Add("IDXL_MonHocTrongKy_Cu", typeof(int));
            dtAnhXa.Columns.Add("IDDM_MonHoc_Cu", typeof(int));
            dtAnhXa.Columns.Add("MaMonLopCu", typeof(string));
            dtAnhXa.Columns.Add("TenMonLopCu", typeof(string));
            dtAnhXa.Columns.Add("TenNamHoc_Cu", typeof(string));
            dtAnhXa.Columns.Add("IDDM_NamHoc_Cu", typeof(int));
            dtAnhXa.Columns.Add("IDKQHT_CTDT_ChiTiet_Cu", typeof(int));
            dtAnhXa.Columns.Add("HocKy_Cu", typeof(int));
            dtAnhXa.Columns.Add("Diem_Cu", typeof(float));

            dtAnhXa.Columns.Add("IDXL_MonHocTrongKy_Moi", typeof(int));
            dtAnhXa.Columns.Add("IDDM_MonHoc_Moi", typeof(int));
            dtAnhXa.Columns.Add("MaMonLopMoi", typeof(string));
            dtAnhXa.Columns.Add("TenMonLopMoi", typeof(string));
            dtAnhXa.Columns.Add("TenNamHoc_Moi", typeof(string));
            dtAnhXa.Columns.Add("IDDM_NamHoc_Moi", typeof(int));
            dtAnhXa.Columns.Add("IDKQHT_CTDT_ChiTiet_Moi", typeof(int));
            dtAnhXa.Columns.Add("HocKy_Moi", typeof(int));
            dtAnhXa.Columns.Add("Diem_Moi", typeof(float));
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            if (dtMonLopCu != null && dtMonLopMoi != null)
            {
                DataRow drNew, drCu, drMoi;
                // Chuyển các môn học có cùng thông tin sang
                for (int i = dtMonLopCu.Rows.Count - 1; i >= 0; i--)
                {
                    drCu = dtMonLopCu.Rows[i];
                    for (int j = dtMonLopMoi.Rows.Count - 1; j >= 0; j--)
                    {
                        drMoi = dtMonLopMoi.Rows[j];
                        if (("" + drCu["DM_MonHocID"] == "" + drMoi["DM_MonHocID"] && "" + drCu["TenNamHoc"] == "" + drMoi["TenNamHoc"]
                            && "" + drCu["HocKy"] == "" + drMoi["HocKy"]) || "" + drCu["KQHT_CTDT_ChiTietID"] == "" + drMoi["KQHT_CTDT_ChiTietID"])
                        {
                            drNew = dtAnhXa.NewRow();
                            drNew["IDXL_MonHocTrongKy_Cu"] = drCu["XL_MonHocTrongKyID"];
                            drNew["IDDM_MonHoc_Cu"] = drCu["DM_MonHocID"];
                            drNew["MaMonLopCu"] = drCu["MaMonHoc"];
                            drNew["TenMonLopCu"] = drCu["TenMonHoc"];
                            drNew["TenNamHoc_Cu"] = drCu["TenNamHoc"];
                            drNew["IDDM_NamHoc_Cu"] = drCu["IDDM_NamHoc"];
                            drNew["IDKQHT_CTDT_ChiTiet_Cu"] = drCu["KQHT_CTDT_ChiTietID"];
                            drNew["HocKy_Cu"] = drCu["HocKy"];
                            drNew["Diem_Cu"] = drCu["Diem"];

                            drNew["IDXL_MonHocTrongKy_Moi"] = drMoi["XL_MonHocTrongKyID"];
                            drNew["IDDM_MonHoc_Moi"] = drMoi["DM_MonHocID"];
                            drNew["MaMonLopMoi"] = drMoi["MaMonHoc"];
                            drNew["TenMonLopMoi"] = drMoi["TenMonHoc"];
                            drNew["TenNamHoc_Moi"] = drMoi["TenNamHoc"];
                            drNew["IDDM_NamHoc_Moi"] = drCu["IDDM_NamHoc"];
                            drNew["IDKQHT_CTDT_ChiTiet_Moi"] = drCu["KQHT_CTDT_ChiTietID"];
                            drNew["HocKy_Moi"] = drMoi["HocKy"];
                            drNew["Diem_Moi"] = drMoi["Diem"];

                            dtAnhXa.Rows.Add(drNew);

                            dtMonLopCu.Rows.Remove(drCu);
                            dtMonLopMoi.Rows.Remove(drMoi);
                            
                            break;
                        }
                    }
                }
            }
            else
                ThongBao("Phải có đầy đủ môn học của lớp cũ và lớp mới !");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtMonLopCu != null && dtMonLopMoi != null)
            {
                if (grvMonLopCu.FocusedRowHandle >= 0 && grvMonLopMoi.FocusedRowHandle >= 0)
                {
                    DataRow drNew, drCu, drMoi;

                    drCu = grvMonLopCu.GetDataRow(grvMonLopCu.FocusedRowHandle);
                    drMoi = grvMonLopMoi.GetDataRow(grvMonLopMoi.FocusedRowHandle);

                    drNew = dtAnhXa.NewRow();
                    drNew["IDXL_MonHocTrongKy_Cu"] = drCu["XL_MonHocTrongKyID"];
                    drNew["IDDM_MonHoc_Cu"] = drCu["DM_MonHocID"];
                    drNew["MaMonLopCu"] = drCu["MaMonHoc"];
                    drNew["TenMonLopCu"] = drCu["TenMonHoc"];
                    drNew["TenNamHoc_Cu"] = drCu["TenNamHoc"];
                    drNew["IDDM_NamHoc_Cu"] = drCu["IDDM_NamHoc"];
                    drNew["IDKQHT_CTDT_ChiTiet_Cu"] = drCu["KQHT_CTDT_ChiTietID"];
                    drNew["HocKy_Cu"] = drCu["HocKy"];
                    drNew["Diem_Cu"] = drCu["Diem"];

                    drNew["IDXL_MonHocTrongKy_Moi"] = drMoi["XL_MonHocTrongKyID"];
                    drNew["IDDM_MonHoc_Moi"] = drMoi["DM_MonHocID"];
                    drNew["MaMonLopMoi"] = drMoi["MaMonHoc"];
                    drNew["TenMonLopMoi"] = drMoi["TenMonHoc"];
                    drNew["TenNamHoc_Moi"] = drMoi["TenNamHoc"];
                    drNew["IDDM_NamHoc_Moi"] = drMoi["IDDM_NamHoc"];
                    drNew["IDKQHT_CTDT_ChiTiet_Moi"] = drMoi["KQHT_CTDT_ChiTietID"];
                    drNew["HocKy_Moi"] = drMoi["HocKy"];
                    drNew["Diem_Moi"] = drMoi["Diem"];

                    dtAnhXa.Rows.Add(drNew);

                    dtMonLopCu.Rows.Remove(drCu);
                    dtMonLopMoi.Rows.Remove(drMoi);
                }
                else
                    ThongBao("Bạn chưa chọn dòng dữ liệu nào !");
            }
            else
                ThongBao("Phải có đầy đủ môn học của lớp cũ và lớp mới !");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bgrvAnhXa.FocusedRowHandle >= 0)
            {
                DataRow dr, drCu, drMoi;
                dr = bgrvAnhXa.GetDataRow(bgrvAnhXa.FocusedRowHandle);

                drCu = dtMonLopCu.NewRow();
                drMoi = dtMonLopMoi.NewRow();

                drCu["XL_MonHocTrongKyID"] = dr["IDXL_MonHocTrongKy_Cu"];
                drCu["DM_MonHocID"] = dr["IDDM_MonHoc_Cu"];
                drCu["MaMonHoc"] = dr["MaMonLopCu"];
                drCu["TenMonHoc"] = dr["TenMonLopCu"];
                drCu["TenNamHoc"] = dr["TenNamHoc_Cu"];
                drCu["IDDM_NamHoc"] = dr["IDDM_NamHoc_Cu"];
                drCu["KQHT_CTDT_ChiTietID"] = dr["IDKQHT_CTDT_ChiTiet_Cu"];
                drCu["HocKy"] = dr["HocKy_Cu"];
                drCu["Diem"] = dr["Diem_Cu"];

                drMoi["XL_MonHocTrongKyID"] = dr["IDXL_MonHocTrongKy_Moi"];
                drMoi["DM_MonHocID"] = dr["IDDM_MonHoc_Moi"];
                drMoi["MaMonHoc"] = dr["MaMonLopMoi"];
                drMoi["TenMonHoc"] = dr["TenMonLopMoi"];
                drMoi["TenNamHoc"] = dr["TenNamHoc_Moi"];
                drMoi["IDDM_NamHoc"] = dr["IDDM_NamHoc_Moi"];
                drMoi["KQHT_CTDT_ChiTietID"] = dr["IDKQHT_CTDT_ChiTiet_Moi"];
                drMoi["HocKy"] = dr["HocKy_Moi"];
                drMoi["Diem"] = dr["Diem_Moi"];

                dtMonLopCu.Rows.Add(drCu);
                dtMonLopMoi.Rows.Add(drMoi);

                dtAnhXa.Rows.Remove(dr);
            }
            else
                ThongBao("Bạn chưa chọn dòng dữ liệu nào !");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChuyenDiem_Click(object sender, EventArgs e)
        {
            if (dtAnhXa.Rows.Count == 0)
            {
                ThongBao("Bạn chưa ánh xạ môn học nào !");
                return;
            }

            if (ThongBaoChon("Bạn có chắc chắn muốn chuyển điểm của sinh viên này không ?") == DialogResult.Yes)
            {
                CreateWaitDialog("Đang thực hiện chuyển điểm, xin vui lòng chờ.", "Chuyển điểm");
                foreach (DataRow dr in dtAnhXa.Rows)
                {
                    oBXL_MonHocTrongKy.ChuyenDiemByChuyenLop(IDSV_SinhVien, (int)dr["IDXL_MonHocTrongKy_Cu"], (int)dr["IDDM_MonHoc_Cu"],
                        (int)dr["IDXL_MonHocTrongKy_Moi"], (int)dr["IDDM_MonHoc_Moi"], (int)dr["IDDM_NamHoc_Moi"], (int)dr["HocKy_Moi"]);
                }
                CloseWaitDialog();
            }
        }
    }
}