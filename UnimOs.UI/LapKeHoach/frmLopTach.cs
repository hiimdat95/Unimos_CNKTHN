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
    public partial class frmLopTach : frmBase
    {
        private cBXL_LopTachGop oBXL_LopTachGop;
        private XL_LopTachGopInfo pXL_LopTachGopInfo;
        private cBXL_GiaoVien_MonHoc oBXL_GiaoVien_MonHoc;
        private cBXL_LopTachGop_MonHoc oBXL_LopTachGop_MonHoc;
        private XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo;
        private DataTable dtLopTachGop, dtChiTiet, dtLopTach, dtMonHoc;
        private EDIT_MODE edit;
        private DataView dtview;

        public frmLopTach()
        {
            InitializeComponent();
            oBXL_LopTachGop = new cBXL_LopTachGop();
            oBXL_GiaoVien_MonHoc = new cBXL_GiaoVien_MonHoc();
            oBXL_LopTachGop_MonHoc = new cBXL_LopTachGop_MonHoc();
            pXL_LopTachGopInfo = new XL_LopTachGopInfo();
            pXL_LopTachGop_MonHocInfo = new XL_LopTachGop_MonHocInfo();
            panelTop.Visible = false;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            cmbKhoa_EditValueChanged(null, null);
            repositoryPhongHoc.DataSource = LoadPhongHoc();
            repositoryGiaoVien.DataSource = (new cBNS_GiaoVien()).Get_TKB(0);
        }

        private void frmLopTach_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtLopTachGop = oBXL_LopTachGop.GetByHocKyNamHoc(Program.HocKy, Program.IDNamHoc, true);
            dtLopTach = CreateTableLopTach();
            grdLopTach.DataSource = dtLopTach;
            if (dtLopTach.Rows.Count > 0)
                ShowBarButton(true);
            else
                ShowBarButton(false);
            
            cmbSoLop.SelectedIndex = 0;
        }

        private void ShowBarButton(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
            barThemMonHoc.Enabled = status;
        }

        // Table này chỉ lưu các XL_LopTachGopID có ParentID = 0
        private DataTable CreateTableLopTach()
        {
            DataTable dt = new DataTable();
            DataTable dtTemp = new DataTable();
            dt.Columns.Add("Chon", typeof(bool));
            //dt.Columns["Chon"].DefaultValue = false;
            dt.Columns.Add("LopGoc", typeof(string));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("SoLop", typeof(int));
            dt.Columns.Add("TenLopTach", typeof(string));
            dt.Columns.Add("IDXL_MonHocTrongKy", typeof(int));
            dt.Columns.Add("XL_LopTachGopID", typeof(int));
            dt.Columns.Add("DM_LopGopID", typeof(int));
            dt.Columns.Add("IDDM_MonHoc", typeof(int));
            dt.Columns.Add("XL_LopTachGopIDs", typeof(string));
            dt.Columns.Add("TenMonHocs", typeof(string));
            dt.Columns.Add("IDXL_MonHocTrongKys", typeof(string));
            dtTemp = dt.Copy();

            if (dtLopTachGop.Rows.Count > 0)
            {
                int SoLop = 0;
                string IDDM_LopGoc = dtLopTachGop.Rows[0]["IDDM_LopGoc"].ToString(), IDXL_MonHocTrongKy = dtLopTachGop.Rows[0]["XL_MonHocTrongKyID"].ToString();

                DataRow drNew = dt.NewRow();

                foreach (DataRow dr in dtLopTachGop.Rows)
                {
                    if (dr["IDDM_LopGoc"].ToString() == IDDM_LopGoc && dr["XL_MonHocTrongKyID"].ToString() == IDXL_MonHocTrongKy)
                    {
                        drNew["Chon"] = false;
                        drNew["LopGoc"] = dr["LopGoc"].ToString();
                        drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                        if (drNew["TenLopTach"].ToString() == "")
                            drNew["TenLopTach"] = dr["TenLopTachGop"].ToString();
                        else
                            drNew["TenLopTach"] = drNew["TenLopTach"] + ", " + dr["TenLopTachGop"].ToString();

                        if (drNew["XL_LopTachGopIDs"].ToString() == "")
                            drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopID"].ToString();
                        else
                            drNew["XL_LopTachGopIDs"] = drNew["XL_LopTachGopIDs"] + ", " + dr["XL_LopTachGopID"].ToString();

                        drNew["IDXL_MonHocTrongKy"] = dr["XL_MonHocTrongKyID"].ToString();
                        if (dr["ParentID"].ToString() == "0")
                            drNew["XL_LopTachGopID"] = dr["XL_LopTachGopID"].ToString();
                        drNew["DM_LopGopID"] = dr["IDDM_LopGoc"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                    else
                    {
                        drNew["SoLop"] = SoLop;
                        dt.Rows.Add(drNew);
                        SoLop = 0;
                        drNew = dt.NewRow();
                        IDDM_LopGoc = dr["IDDM_LopGoc"].ToString();
                        IDXL_MonHocTrongKy = dr["XL_MonHocTrongKyID"].ToString();
                        drNew["Chon"] = false;
                        drNew["LopGoc"] = dr["LopGoc"].ToString();
                        drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                        drNew["TenLopTach"] = dr["TenLopTachGop"].ToString();
                        drNew["XL_LopTachGopID"] = dr["XL_LopTachGopID"].ToString();
                        drNew["IDXL_MonHocTrongKy"] = dr["XL_MonHocTrongKyID"].ToString();
                        //if (dr["XL_LopTachGopIDs"].ToString() == "0")
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopID"].ToString();
                        drNew["DM_LopGopID"] = dr["IDDM_LopGoc"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                }
                drNew["SoLop"] = SoLop;
                dt.Rows.Add(drNew);
            }

            if (dt.Rows.Count > 0)
            {
                int SoLop = 0;
                string IDXL_LopTachGops = dt.Rows[0]["XL_LopTachGopIDs"].ToString();

                DataRow drNew = dtTemp.NewRow();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["XL_LopTachGopIDs"].ToString() == IDXL_LopTachGops )
                    {
                        drNew["Chon"] = false;
                        drNew["LopGoc"] = dr["LopGoc"].ToString();
                        drNew["TenLopTach"] = dr["TenLopTach"].ToString();
                        if (drNew["TenMonHocs"].ToString() == "")
                            drNew["TenMonHocs"] = dr["TenMonHoc"].ToString();
                        else
                            drNew["TenMonHocs"] = drNew["TenMonHocs"] + ", " + dr["TenMonHoc"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        if (drNew["IDXL_MonHocTrongKys"].ToString() == "")
                            drNew["IDXL_MonHocTrongKys"] = dr["IDXL_MonHocTrongKy"].ToString();
                        else
                            drNew["IDXL_MonHocTrongKys"] = drNew["IDXL_MonHocTrongKys"] + ", " + dr["IDXL_MonHocTrongKy"].ToString();
                        if (drNew["IDXL_MonHocTrongKy"].ToString() == "")
                             drNew["IDXL_MonHocTrongKy"] = dr["IDXL_MonHocTrongKy"].ToString();
                        drNew["XL_LopTachGopID"] = dr["XL_LopTachGopID"].ToString();
                        drNew["DM_LopGopID"] = dr["DM_LopGopID"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                    else
                    {
                        drNew["SoLop"] = SoLop;
                        dtTemp.Rows.Add(drNew);
                        drNew = dtTemp.NewRow();
                        IDXL_LopTachGops = dr["XL_LopTachGopIDs"].ToString();
                        drNew["Chon"] = false;
                        drNew["LopGoc"] = dr["LopGoc"].ToString();
                        drNew["TenMonHocs"] = dr["TenMonHoc"].ToString();
                        drNew["TenLopTach"] = dr["TenLopTach"].ToString();
                        drNew["XL_LopTachGopID"] = dr["XL_LopTachGopID"].ToString();
                        drNew["IDXL_MonHocTrongKys"] = dr["IDXL_MonHocTrongKy"].ToString();
                        drNew["IDXL_MonHocTrongKy"] = dr["IDXL_MonHocTrongKy"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        drNew["DM_LopGopID"] = dr["DM_LopGopID"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                }
                drNew["SoLop"] = SoLop;
                dtTemp.Rows.Add(drNew);
            }
            return dtTemp;
        }

        private DataTable CreateTableLopTachChiTiet()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDDM_Lop", typeof(int));
            dt.Columns.Add("TenLopTachGop", typeof(string));
            dt.Columns.Add("SoSinhVien", typeof(int));
            dt.Columns.Add("IDNS_GiaoVien", typeof(int));
            dt.Columns.Add("IDDM_PhongHoc", typeof(int));
            dt.Columns.Add("CaHoc", typeof(string));
            return dt;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (cmbLop.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbLop, "Bạn chưa chọn lớp.");
                if (CtrlErr == null) CtrlErr = cmbLop;
            }
            if (cmbMonHoc.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbMonHoc, "Bạn chưa chọn môn học.");
                if (CtrlErr == null) CtrlErr = cmbMonHoc;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void GetpLopTachGopInfo(DataRow dr)
        {
            pXL_LopTachGopInfo.IDDM_LopGoc = int.Parse(cmbLop.EditValue.ToString());
            pXL_LopTachGopInfo.IDDM_NamHoc = Program.IDNamHoc;
            pXL_LopTachGopInfo.HocKy = Program.HocKy;
            pXL_LopTachGopInfo.LopTach = true;
            pXL_LopTachGopInfo.TenLopTachGop = dr["TenLopTachGop"].ToString();
            pXL_LopTachGopInfo.SoSinhVien = int.Parse("0" + dr["SoSinhVien"]);
        }

        private void GetpLopTachMonHocInfo(DataRow dr)
        {
            pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.EditValue.ToString());
            pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien = ("" + dr["IDNS_GiaoVien"] == "" ? -1 : int.Parse(dr["IDNS_GiaoVien"].ToString()));
            pXL_LopTachGop_MonHocInfo.CaHoc = (dr["CaHoc"] == null ? -1 : (dr["CaHoc"].ToString() == "Sáng" ? 0 : (dr["CaHoc"].ToString() == "Chiều" ? 1 : 2)));
            pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc = ("" + dr["IDDM_PhongHoc"] == "" ? -1 : int.Parse(dr["IDDM_PhongHoc"].ToString()));
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControls();
            panelTop.Visible = true;
            edit = EDIT_MODE.THEM;
        }
      
        private void barThemMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmbLop.EditValue = int.Parse(grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["DM_LopGopID"].ToString());
           // cmbLop_EditValueChanged(null, null);
            dlgThemMonHoc_LopTach dlg = new dlgThemMonHoc_LopTach(grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["XL_LopTachGopIDs"].ToString(), int.Parse(cmbLop.EditValue.ToString()), int.Parse(grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["IDXL_MonHocTrongKy"].ToString()),"",false,"",0);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() != "")
            {
                // ghi log
                GhiLog("Thêm môn học vào các lớp tách '" + grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["TenLopTach"].ToString() + "'", "Thêm", this.Tag.ToString());
                frmLopTach_Load(null, null);
                ThemThanhCong();
            }
        }
        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvLopTach.FocusedRowHandle = -1;
            bool check = false;
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                try
                {
                    cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
                    for (int i = 0; i < dtLopTach.Rows.Count; i++)
                    {

                        string mXL_LopTachGopIDs = "", mIDXL_MonHocTrongKys = "";

                        if (bool.Parse(dtLopTach.Rows[i]["Chon"].ToString()) == true)
                        {
                            check = true;
                            mXL_LopTachGopIDs = dtLopTach.Rows[i]["XL_LopTachGopIDs"].ToString() + ",";
                            try
                            {
                                // delete lop tach gop
                                oBXL_LopTachGop.DeleteByLopGoc(mXL_LopTachGopIDs.Substring(0,mXL_LopTachGopIDs.Length - 1));

                                  // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                                mIDXL_MonHocTrongKys = dtLopTach.Rows[i]["IDXL_MonHocTrongKys"].ToString() + ",";
                                while ((mIDXL_MonHocTrongKys != "") && (mIDXL_MonHocTrongKys != ","))
                                {
                                    oBXL_MonHocTrongKy.UpdateTachGop(int.Parse(mIDXL_MonHocTrongKys.Substring(0, mIDXL_MonHocTrongKys.IndexOf(","))), false);
                                    mIDXL_MonHocTrongKys = mIDXL_MonHocTrongKys.Substring(mIDXL_MonHocTrongKys.IndexOf(",") + 1);
                                }
                                // ghi log
                                GhiLog("Xóa các lớp tách '" + dtLopTach.Rows[i]["TenLopTach"].ToString() + "' khỏi CSDL", "Xóa", this.Tag.ToString());
                              
                            }
                            catch
                            {
                                check = false;
                            }
                        }
                    }
                    if (check == true)
                    {
                        cmbLop_EditValueChanged(null, null);
                        frmLopTach_Load(null, null);
                    }
                   
                }
                catch
                {
                    XoaThatBai();
                }
                if (check == false)
                {
                    ThongBao("Bạn chưa chọn dữ liệu cần xóa!");
                }
            }
        }
        private void GetInfo()
        {
            DataTable dtTemp = dtLopTachGop.Copy();
            dtTemp.DefaultView.RowFilter = "IDDM_LopGoc =" + grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["DM_LopGopID"].ToString() + "and IDDM_MonHoc=" + grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["IDDM_MonHoc"].ToString();
            dtview = dtTemp.DefaultView;
            cmbKhoa.EditValue = int.Parse(dtview[0]["IDDM_Khoa"].ToString());
            cmbLop.EditValue = int.Parse(grvLopTach.GetDataRow(grvLopTach.FocusedRowHandle)["DM_LopGopID"].ToString());
            //cmbMonHoc.Properties.LookUpData.DataSource
            cmbMonHoc.EditValue = int.Parse(dtview[0]["XL_MonHocTrongKyID"].ToString());
            cmbMonHoc.Enabled = false;
            cmbKhoa.Enabled = false;
            cmbLop.Enabled = false;
            cmbSoLop.EditValue = dtTemp.DefaultView.Count;
           
            
        }
        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbLop.Properties.DataSource = LoadLopTheoKhoa(int.Parse(cmbKhoa.EditValue.ToString()));
                cmbLop.EditValue = 0;
                
            }
            else
                cmbLop.Properties.DataSource = LoadLopTheoKhoa(0);
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
           //cmbMonHoc.Properties.DataSource = cmbLop.EditValue == null ? null : MonHocTrongKy(int.Parse(cmbLop.EditValue.ToString()));
            if (cmbLop.EditValue != null)
            {
                dtMonHoc = MonHocTrongKyGetAll(int.Parse(cmbLop.EditValue.ToString()));
                if (edit == EDIT_MODE.THEM)
                {
                    dtMonHoc.DefaultView.RowFilter = "HocOLopTachGop = 0";
                }
                else
                    dtMonHoc.DefaultView.RowFilter = "";
                cmbMonHoc.Properties.DataSource = dtMonHoc.DefaultView;
            }
            else
            {
                cmbMonHoc.Properties.DataSource = null;
            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvChiTiet.DataRowCount > 0)
            {
                int TongSoSV = 0;
                string TenCacLopTach = "";
                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    TongSoSV += int.Parse(dtChiTiet.Rows[i]["SoSinhVien"].ToString());
                }
                if (TongSoSV == int.Parse(cmbLop.GetColumnValue("SoSinhVien").ToString()))
                {
                    if (edit == EDIT_MODE.THEM)
                    {
                        int ParentID = 0;
                        // kiem tra tong so sinh vien

                        for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                        {
                            GetpLopTachGopInfo(dtChiTiet.Rows[i]);
                            GetpLopTachMonHocInfo(dtChiTiet.Rows[i]);
                            if (i == 0)
                            {
                                pXL_LopTachGopInfo.ParentID = 0;
                                ParentID = oBXL_LopTachGop.Add(pXL_LopTachGopInfo);
                                TenCacLopTach += pXL_LopTachGopInfo.TenLopTachGop;
                                pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = ParentID;
                            }
                            else
                            {
                                pXL_LopTachGopInfo.ParentID = ParentID;
                                pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = oBXL_LopTachGop.Add(pXL_LopTachGopInfo);
                            }

                            oBXL_LopTachGop_MonHoc.Add(pXL_LopTachGop_MonHocInfo);
                        }

                        // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                        cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
                        oBXL_MonHocTrongKy.UpdateTachGop(pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy, true);

                        // ghi log
                        GhiLog("Thêm các lớp tách '" + TenCacLopTach + "' vào CSDL", "Thêm", this.Tag.ToString());

                        DataRow[] drMon = dtMonHoc.Select("XL_MonHocTrongKyID = " + cmbMonHoc.EditValue.ToString());
                        if (drMon.Length > 0)
                            drMon[0]["HocOLopTachGop"] = true;

                        frmLopTach_Load(null, null);
                    }
                    else
                    {

                        cmbMonHoc.Enabled = true;
                        cmbKhoa.Enabled = true;
                        cmbLop.Enabled = true;
                        SuaThanhCong();
                        ResetControls();
                    }
                }
                else
                {
                    ThongBaoLoi("Tổng sinh viên của các lớp tách không cân bằng!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            if (edit == EDIT_MODE.SUA)
            {
                cmbMonHoc.Enabled = true;
                cmbKhoa.Enabled = true;
                cmbLop.Enabled = true;
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            //if (cmbMonHoc.EditValue != null)
            //{
            //    repositoryGiaoVien.DataSource = oBXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(int.Parse(cmbMonHoc.EditValue.ToString()), "");
            //}
        }

        private void cmbSoLop_EditValueChanged(object sender, EventArgs e)
        {
            if ((cmbSoLop.Text != "0") && (cmbMonHoc.EditValue != null))
            {
                dtChiTiet = CreateTableLopTachChiTiet();
                try
                {
                    DataRow drNew;
                    if (edit == EDIT_MODE.THEM)
                    {
                        int SoSVTrungBinh = int.Parse(cmbLop.GetColumnValue("SoSinhVien").ToString()) / int.Parse(cmbSoLop.Text);
                        int SoSVLopDauTien = int.Parse(cmbLop.GetColumnValue("SoSinhVien").ToString()) - SoSVTrungBinh * (int.Parse(cmbSoLop.Text) - 1);
                        for (int i = 1; i <= int.Parse(cmbSoLop.Text); i++)
                        {
                            drNew = dtChiTiet.NewRow();
                            drNew["IDDM_Lop"] = 0;
                            drNew["TenLopTachGop"] = cmbLop.Text + "_" + cmbMonHoc.GetColumnValue("MaMonHoc").ToString() + "_" + i.ToString();
                            drNew["SoSinhVien"] = (i == 1 ? SoSVLopDauTien : SoSVTrungBinh);
                            drNew["CaHoc"] = "Sáng";
                            dtChiTiet.Rows.Add(drNew);
                        }
                    }
                    else
                    {
                        // get grvChiTiet
                        int SoSVTrungBinh = 0;
                        int SoSVLopDauTien = 0;
                        if (cmbSoLop.Text != dtview.Count.ToString())
                        {
                            SoSVTrungBinh = int.Parse(cmbLop.GetColumnValue("SoSinhVien").ToString()) / int.Parse(cmbSoLop.Text);
                            SoSVLopDauTien = int.Parse(cmbLop.GetColumnValue("SoSinhVien").ToString()) - SoSVTrungBinh * (int.Parse(cmbSoLop.Text) - 1);
                        }
                        
                        for (int i = 0; i < int.Parse(cmbSoLop.Text); i++)
                        {
                            drNew = dtChiTiet.NewRow();
                            drNew["IDDM_Lop"] = (int.Parse(cmbSoLop.Text) > dtview.Count ? dtview[0]["IDDM_LopGoc"].ToString() : dtview[i]["IDDM_LopGoc"].ToString());
                            drNew["TenLopTachGop"] = (i < dtview.Count ? dtview[i]["TenLopTachGop"].ToString() : (cmbLop.Text + "_" + cmbMonHoc.GetColumnValue("MaMonHoc").ToString() + "_" + (i+1).ToString()));
                            drNew["SoSinhVien"] = (SoSVLopDauTien == 0 ? dtview[i]["SoSinhVien"].ToString() : (i == 1 ? SoSVLopDauTien.ToString() : SoSVTrungBinh.ToString()));
                            drNew["IDNS_GiaoVien"] = (i >= dtview.Count ? 0 : dtview[i]["IDNS_GiaoVien"]); ;
                            drNew["IDDM_PhongHoc"] = (i >= dtview.Count ? 0 : dtview[i]["IDDM_PhongHoc"]); ;
                            drNew["CaHoc"] = (i >= dtview.Count ? "Sáng" : (dtview[i]["CaHoc"] == null ? "-1" : (dtview[i]["CaHoc"].ToString() == "0" ? "Sáng" : (dtview[i]["CaHoc"].ToString() == "1" ? "Chiều" : "2"))));
                            dtChiTiet.Rows.Add(drNew);
                        }                       
                        // if (cmbSoLop.EditValue.ToString() ==  
                    }
                    grdChiTiet.DataSource = dtChiTiet;
                }
                catch (Exception exp)
                {
                    ThongBao(exp.Message);
                }
            }
            else
                grdChiTiet.DataSource = null;
        }

        private void ResetControls()
        {
            cmbSoLop.SelectedIndex = 0;
            cmbKhoa.EditValue = 0;
            cmbLop.EditValue = 0;
            cmbMonHoc.EditValue = 0;
            grdChiTiet.DataSource = null;
        }
    }
}