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
    public partial class frmMonHocTrongKy : frmBase
    {
        private cBwsDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBwsKQHT_ChuongTrinhDaoTao oBCTDT;
        private cBwsXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo;
        private DataTable dtMonKy, dtMonKhung;
        private int IDDM_Lop, HocKy, IDKQHT_ChuongTrinhDaoTao;
        public string[] ChuoiDM_LopID;

        public frmMonHocTrongKy()
        {
            InitializeComponent();
            IDKQHT_ChuongTrinhDaoTao = 0;
            oBDM_Lop = new cBwsDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBCTDT = new cBwsKQHT_ChuongTrinhDaoTao();
            oBXL_MonHocTrongKy = new cBwsXL_MonHocTrongKy();
            cmbHocKy.Properties.Items.Add(Program.HocKy);
            cmbNamHoc.Properties.Items.Add(Program.NamHoc);
            cmbNamHoc.SelectedIndex = 0;
            cmbHocKy.SelectedIndex = 0;
            repositoryThiMonKhung.DataSource = LoadHinhThucThi();
            repositoryThiMonKy.DataSource = LoadHinhThucThi();
        }

        private void frmMonHocTrongKy_Load(object sender, EventArgs e)
        {
            bar3.Visible = true;
            LoadTreeLop(uctrlLop);
            uctrlLop.chkExpandAll.Checked = true;
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                DataTable dtCTDT = oBDM_Lop.GetChuongTrinhDaoTao(IDDM_Lop);
                if (dtCTDT.Rows.Count > 0)
                    IDKQHT_ChuongTrinhDaoTao = int.Parse("0" + dtCTDT.Rows[0]["IDKQHT_ChuongTrinhDaoTao"]);
                else
                    IDKQHT_ChuongTrinhDaoTao = 0;
                if (IDKQHT_ChuongTrinhDaoTao != 0)
                {
                    FillKy(cmbKyKhung, int.Parse("0" + dtCTDT.Rows[0]["SoHocKy"]));
                    HocKy = GetKyThuFromHocKy(dtCTDT.Rows[0]["NienKhoa"].ToString());
                    cmbKyKhung.EditValue = HocKy;
                    if (cmbKyKhung.EditValue.ToString() == HocKy.ToString())
                        cmbKyKhung_SelectedValueChanged(null, null);

                    LoadMonKy(IDDM_Lop);
                }
                else if (pDM_LopInfo.DM_LopID > 0)
                {
                    grdMonKy.DataSource = null;
                    grdMonKhung.DataSource = null;
                    ThongBao("Lớp này chưa có chương trình đào tạo.");
                }
            }
        }

        private void LoadMonKhung(int IDKQHT_ChuongTrinhDaoTao, int HocKy)
        {
            dtMonKhung = oBCTDT.GetMonKhung(IDKQHT_ChuongTrinhDaoTao, IDDM_Lop, HocKy);
            grdMonKhung.DataSource = dtMonKhung;
        }

        private void LoadMonKy(int IDDM_Lop)
        {
            dtMonKy = oBXL_MonHocTrongKy.GetMonKy(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdMonKy.DataSource = dtMonKy;
            dtMonKy.AcceptChanges();

        }

        private void cmbKyKhung_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadMonKhung(IDKQHT_ChuongTrinhDaoTao, int.Parse(cmbKyKhung.EditValue.ToString()));
        }

        private void grvMonKhung_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvMonKhung, "Chon", e);
        }

        private void grvMonKy_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvMonKy, "Chon", e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (grvMonKhung.DataRowCount > 0)
            {
                bool chon = false;
                DataRow drNew, dr;
                for (int i = 0; i < dtMonKhung.Rows.Count; i++)
                {
                    dr = dtMonKhung.Rows[i];
                    if (bool.Parse(dr["Chon"].ToString()) == true)
                    {
                        chon = true;
                        drNew = dtMonKy.NewRow();
                        drNew["Chon"] = false;
                        drNew["MaMonHoc"] = dr["MaMonHoc"];
                        drNew["TenMonHoc"] = dr["TenMonHoc"];
                        drNew["SoHocTrinh"] = dr["SoHocTrinh"];
                        drNew["LyThuyet"] = dr["LyThuyet"];
                        drNew["ThucHanh"] = dr["ThucHanh"];
                        drNew["ChoPhepXepLich"] = dr["ChoPhepXepLich"];
                        drNew["IDDM_HinhThucThi"] = dr["IDDM_HinhThucThi"];
                        drNew["TinhDiemToanKhoa"] = dr["TinhDiemToanKhoa"];
                        drNew["IDKQHT_CTDT_ChiTiet"] = dr["KQHT_CTDT_ChiTietID"];
                        drNew["XL_MonHocTrongKyID"] = dr["XL_MonHocTrongKyID"];

                        dtMonKy.Rows.Add(drNew);
                        dtMonKhung.Rows.Remove(dr);
                        i--;
                    }
                }
                if (!chon)
                    ThongBao("Bạn chưa chọn môn nào.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvMonKy.DataRowCount > 0)
            {
                bool chon = false;
                DataRow drNew, dr;
                for (int i = 0; i < dtMonKy.Rows.Count; i++)
                {
                    dr = dtMonKy.Rows[i];

                    if (bool.Parse(dr["Chon"].ToString()) == true)
                    {
                        DataTable dbotong = oBDM_Lop.GetTongDiemThanhPhan(int.Parse("0" + dr["XL_MonHocTrongKyID"].ToString()));
                        if (dbotong.Rows.Count > 0 && int.Parse("0" + dbotong.Rows[0]["Tong"].ToString()) > 0)
                        {
                            ThongBao("Môn học đã có điểm bạn cần xóa điểm thành phần trước lúc xóa");
                        }
                        else
                        {
                            chon = true;
                            drNew = dtMonKhung.NewRow();
                            drNew["Chon"] = false;
                            drNew["MaMonHoc"] = dr["MaMonHoc"];
                            drNew["TenMonHoc"] = dr["TenMonHoc"];
                            drNew["SoHocTrinh"] = dr["SoHocTrinh"];
                            drNew["LyThuyet"] = dr["LyThuyet"];
                            drNew["ThucHanh"] = dr["ThucHanh"];
                            drNew["ChoPhepXepLich"] = dr["ChoPhepXepLich"];
                            drNew["IDDM_HinhThucThi"] = dr["IDDM_HinhThucThi"];
                            drNew["TinhDiemToanKhoa"] = dr["TinhDiemToanKhoa"];
                            drNew["KQHT_CTDT_ChiTietID"] = dr["IDKQHT_CTDT_ChiTiet"];
                            drNew["XL_MonHocTrongKyID"] = dr["XL_MonHocTrongKyID"];

                            dtMonKhung.Rows.Add(drNew);
                            dtMonKy.Rows.Remove(dr);
                            i--;
                        }
                    }
                    
                }
                if (!chon)
                    ThongBao("Bạn chưa chọn môn nào.");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Nếu MonKy có dữ liệu thì insert hoặc Update, nếu không có thì xóa hết.
            if (dtMonKy != null)
            {
                try
                {
                    if (dtMonKy.Rows.Count > 0)
                    {
                        string MonHocNotIn = "";
                        foreach (DataRow dr in dtMonKy.Rows)
                        {
                            pXL_MonHocTrongKyInfo = new XL_MonHocTrongKyInfo();
                            pXL_MonHocTrongKyInfo.IDDM_Lop = IDDM_Lop;
                            pXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet = int.Parse(dr["IDKQHT_CTDT_ChiTiet"].ToString());
                            pXL_MonHocTrongKyInfo.IDDM_NamHoc = Program.IDNamHoc;
                            pXL_MonHocTrongKyInfo.HocKy = Program.HocKy;
                            pXL_MonHocTrongKyInfo.IDDM_HinhThucThi = int.Parse(dr["IDDM_HinhThucThi"].ToString());
                            pXL_MonHocTrongKyInfo.SoHocTrinh = float.Parse("0" + dr["SoHocTrinh"]);
                            pXL_MonHocTrongKyInfo.LyThuyet = int.Parse("0" + dr["LyThuyet"]);
                            pXL_MonHocTrongKyInfo.ThucHanh = int.Parse("0" + dr["ThucHanh"]);
                            pXL_MonHocTrongKyInfo.SoTiet = pXL_MonHocTrongKyInfo.LyThuyet + pXL_MonHocTrongKyInfo.ThucHanh;
                            pXL_MonHocTrongKyInfo.ChoPhepXepLich = bool.Parse(dr["ChoPhepXepLich"].ToString());
                            pXL_MonHocTrongKyInfo.TinhDiemToanKhoa = bool.Parse(dr["TinhDiemToanKhoa"].ToString());
                            pXL_MonHocTrongKyInfo.HocOLopTachGop = false;

                            MonHocNotIn += pXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet.ToString() + ",";
                            if (int.Parse(dr["XL_MonHocTrongKyID"].ToString()) > 0)
                            {
                                pXL_MonHocTrongKyInfo.XL_MonHocTrongKyID = int.Parse(dr["XL_MonHocTrongKyID"].ToString());
                                oBXL_MonHocTrongKy.Update(pXL_MonHocTrongKyInfo);
                            }
                            else
                            {
                                dr["XL_MonHocTrongKyID"] = oBXL_MonHocTrongKy.Add(pXL_MonHocTrongKyInfo);
                            }
                        }
                        MonHocNotIn = MonHocNotIn.Substring(0, MonHocNotIn.Length - 1);

                        oBXL_MonHocTrongKy.DeleteMonHocNotIn(IDDM_Lop, Program.IDNamHoc, Program.HocKy, MonHocNotIn);
                    }
                    else
                    {
                        oBXL_MonHocTrongKy.DeleteByHocKyNamHoc(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
                    }
                    // ghi log
                    GhiLog("Cập nhật thay đổi môn học trong kỳ của lớp '" + pDM_LopInfo.TenLop + "'", "Cập nhật", this.Tag.ToString());
                    LoadMonKy(IDDM_Lop);
                    cmbKyKhung_SelectedValueChanged(null, null);
                    if (e != null)
                    {
                        ThongBao("Thay đổi thành công.");
                    }
                }
                catch
                {
                    ThongBaoLoi("Có thể một số môn học của lớp này đã phân công giáo viên.");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (IDDM_Lop > 0)
            {
                DataTable dtTemp = oBDM_Lop.GetTree(Program.NamHoc);
                dtTemp.DefaultView.RowFilter = "IDDM_KhoaHoc=" + pDM_LopInfo.IDDM_KhoaHoc.ToString() + "and IDKQHT_ChuongTrinhDaoTao =" + IDKQHT_ChuongTrinhDaoTao.ToString() + "and DM_LopID <>" + IDDM_Lop.ToString();
                dlgApDungChoCacLopKhac dlg = new dlgApDungChoCacLopKhac(dtTemp.DefaultView);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() != "")
                {
                    // xoa het cac mon hoc truoc khi insert
                    ChuoiDM_LopID = dlg.Tag.ToString().Substring(0, dlg.Tag.ToString().Length - 1).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (ChuoiDM_LopID != null)
                    {
                        bool status = true;
                        btnCapNhat_Click(null, null);
                        for (int i = 0; i < ChuoiDM_LopID.Length; i++)
                        {
                            try
                            {
                                oBXL_MonHocTrongKy.DeleteByHocKyNamHoc(int.Parse(ChuoiDM_LopID[i].ToString()), Program.IDNamHoc, Program.HocKy);
                                oBXL_MonHocTrongKy.ApDungCacLopKhac(IDDM_Lop,int.Parse(ChuoiDM_LopID[i].ToString()), Program.IDNamHoc, Program.HocKy);
                            }
                            catch
                            {
                                status = false;
                            }
                        }
                        if (status == true)
                        {
                            // ghi log
                            GhiLog("Áp dụng cho các lớp khác có môn học trong kỳ giống lớp '" + pDM_LopInfo.TenLop + "'", "Cập nhật", this.Tag.ToString());
                            ThongBao("Cập nhật thành công!");
                        }
                        else
                        {
                            ThongBao("Lỗi trong quá trình cập nhật!");
                        }
                    }
                }
            }
        }

        private void btnMonChuaToChuc_Click(object sender, EventArgs e)
        {
            dlgCacMonChuaToChuc dlg = new dlgCacMonChuaToChuc(IDKQHT_ChuongTrinhDaoTao, IDDM_Lop, HocKy);
            dlg.ShowDialog();
        }

        private void btnPhanBoChiTiet_Click(object sender, EventArgs e)
        {
            if (IDKQHT_ChuongTrinhDaoTao > 0)
            {
                Lib.clsExportToWord cls = new Lib.clsExportToWord();
                try
                {
                    DataTable dt = oBXL_MonHocTrongKy.GetMonKyToanKhoaByLop(IDDM_Lop);
                    if (dt.Rows.Count > 0)
                    {
                        CreateWaitDialog("Xuất dữ liệu", "Đang xuất dữ liệu ra file");
                        try
                        {
                            Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                            Microsoft.Office.Interop.Word.Document aDoc = null;
                            cls.InitWord(WordApp, ref aDoc, 13);

                            DataTable dtNamKy = new Lib.clsDataTableHelper().SelectDistinct(dt, new string[] { "TenNamHoc", "HocKy" });
                            foreach (DataRow dr in dtNamKy.Rows)
                            {
                                DataView dv = new DataView(dt);
                                dv.RowFilter = "TenNamHoc = '" + dr["TenNamHoc"] + "' And HocKy = " + dr["HocKy"];
                                cls.AddText(aDoc, "\tCác môn học trong học kỳ " + dr["HocKy"] + " năm học " + dr["TenNamHoc"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                                cls.AddTable(aDoc, dv.ToTable(), new string[] { "Tên môn học", "Số học trình", "Số tiết", "Lý thuyết", "Thực hành" },
                                    new string[] { "TenMonHoc", "SoHocTrinh", "SoTiet", "LyThuyet", "ThucHanh" });
                                cls.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            }
                            WordApp.Visible = true;
                            CloseWaitDialog();
                        }
                        catch (Exception ex)
                        {
                            CloseWaitDialog();
                            ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                            return;
                        }
                    }
                    else
                        ThongBao("Lớp này chưa được phân bổ các môn trong kỳ.");
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi xảy ra: " + ex.Message);
                }
            }
            else
                ThongBao("Lớp này chưa có chương trình đào tạo");
        }

        private void grvMonKhung_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}