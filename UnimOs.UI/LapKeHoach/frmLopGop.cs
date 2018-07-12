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
    public partial class frmLopGop : frmBase
    {
        private cBDM_He oBDM_He;
        private cBDM_TrinhDo oBDM_TrinhDo;
        private cBDM_Nganh oBDM_Nganh;
        private cBDM_KhoaHoc oBDM_KhoaHoc;
        private DM_HeInfo pDM_HeInfo;
        private DM_TrinhDoInfo pDM_TrinhDoInfo;
        private DM_NganhInfo pDM_NganhInfo;
        private DM_KhoaHocInfo pDM_KhoaHocInfo;
        private cBXL_LopTachGop oBXL_LopTachGop;
        private XL_LopTachGopInfo pXL_LopTachGopInfo;
        private DataTable dtLopGop, dtLopTachGop;
        public frmLopGop()
        {
            InitializeComponent();
            this.Tag = "";
            oBDM_He = new cBDM_He();
            oBDM_Nganh = new cBDM_Nganh();
            oBDM_TrinhDo = new cBDM_TrinhDo();
            oBDM_KhoaHoc = new cBDM_KhoaHoc();
            pDM_HeInfo = new DM_HeInfo();
            pDM_NganhInfo = new DM_NganhInfo();
            pDM_TrinhDoInfo = new DM_TrinhDoInfo();
            pDM_KhoaHocInfo = new DM_KhoaHocInfo();
            pXL_LopTachGopInfo = new XL_LopTachGopInfo();
            oBXL_LopTachGop = new cBXL_LopTachGop();

        }

        private void frmLopGop_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtLopTachGop = oBXL_LopTachGop.GetByHocKyNamHoc(Program.HocKy, Program.IDNamHoc, false);
            dtLopGop = CreateTableLopGop();
            grdLopGop.DataSource = dtLopGop;
            if (dtLopGop.Rows.Count > 0)
                ShowBarButton(true);
            else
                ShowBarButton(false);
            //LoadData();
        }

        // Table này chỉ lưu các XL_LopTachGopID có ParentID = 0
        private DataTable CreateTableLopGop()
        {
            DataTable dt = new DataTable();
            DataTable dtTemp = new DataTable();
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("TenLopTachGop", typeof(string));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("SoLopGop", typeof(int));
            dt.Columns.Add("TenCacLopGop", typeof(string));
            dt.Columns.Add("IDXL_MonHocTrongKy", typeof(int));
            dt.Columns.Add("IDDM_MonHoc", typeof(int));
            dt.Columns.Add("XL_LopTachGopIDs", typeof(string));
            dt.Columns.Add("TenMonHocs", typeof(string));
            dt.Columns.Add("IDXL_MonHocTrongKys", typeof(string));
            dt.Columns.Add("IDDM_LopGocs", typeof(string));
            dtTemp = dt.Copy();

            if (dtLopTachGop.Rows.Count > 0)
            {
                int SoLop = 0;
                string ParentID = dtLopTachGop.Rows[0]["XL_LopTachGopID"].ToString();

                DataRow drNew = dt.NewRow();              

                foreach (DataRow dr in dtLopTachGop.Rows)
                {

                    if (dr["ParentID"].ToString() == ParentID || (dr["XL_LopTachGopID"].ToString() == ParentID && SoLop == 0))
                    {
                        drNew["Chon"] = false;
                        drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                        drNew["TenLopTachGop"] = dr["TenLopTachGop"].ToString();
                        if (drNew["TenCacLopGop"].ToString() == "")
                            drNew["TenCacLopGop"] = dr["LopGoc"].ToString();
                        else
                            drNew["TenCacLopGop"] = drNew["TenCacLopGop"] + ", " + dr["LopGoc"].ToString();

                        if (drNew["IDDM_LopGocs"].ToString() == "")
                            drNew["IDDM_LopGocs"] = dr["IDDM_LopGoc"].ToString();
                        else
                            drNew["IDDM_LopGocs"] = drNew["IDDM_LopGocs"] + ", " + dr["IDDM_LopGoc"].ToString();

                        if (drNew["XL_LopTachGopIDs"].ToString() == "")
                            drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopID"].ToString();
                        else
                            drNew["XL_LopTachGopIDs"] = drNew["XL_LopTachGopIDs"] + ", " + dr["XL_LopTachGopID"].ToString();

                        if (drNew["IDXL_MonHocTrongKys"].ToString() == "")
                            drNew["IDXL_MonHocTrongKys"] = dr["XL_MonHocTrongKyID"].ToString();
                        else
                            drNew["IDXL_MonHocTrongKys"] = drNew["IDXL_MonHocTrongKys"] + ", " + dr["XL_MonHocTrongKyID"].ToString();

                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;

                    }
                    else
                    {
                        drNew["SoLopGop"] = SoLop;
                        dt.Rows.Add(drNew);
                        SoLop = 0;
                        drNew = dt.NewRow();
                        ParentID = dr["XL_LopTachGopID"].ToString();
                        drNew["Chon"] = false;
                        drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                        drNew["TenLopTachGop"] = dr["TenLopTachGop"].ToString();
                        drNew["TenCacLopGop"] = dr["LopGoc"].ToString();
                        drNew["IDDM_LopGocs"] = dr["IDDM_LopGoc"].ToString();
                        drNew["IDXL_MonHocTrongKys"] = dr["XL_MonHocTrongKyID"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopID"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                    
                }
                drNew["SoLopGop"] = SoLop;
                dt.Rows.Add(drNew);
               
            }

            if (dt.Rows.Count > 0)
            {
                int SoLop = 0;
                string IDXL_LopTachGops = dt.Rows[0]["XL_LopTachGopIDs"].ToString();

                DataRow drNew = dtTemp.NewRow();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["XL_LopTachGopIDs"].ToString() == IDXL_LopTachGops)
                    {
                        drNew["Chon"] = false;
                        drNew["TenLopTachGop"] = dr["TenLopTachGop"].ToString();
                        drNew["TenCacLopGop"] = dr["TenCacLopGop"].ToString();
                        if (drNew["TenMonHocs"].ToString() == "")
                            drNew["TenMonHocs"] = dr["TenMonHoc"].ToString();
                        else
                            drNew["TenMonHocs"] = drNew["TenMonHocs"] + ", " + dr["TenMonHoc"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        drNew["IDXL_MonHocTrongKys"] = dr["IDXL_MonHocTrongKys"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        drNew["IDDM_LopGocs"] = dr["IDDM_LopGocs"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        drNew["SoLopGop"] = dr["SoLopGop"];

                    }
                    else
                    {
                        drNew["SoLopGop"] = dr["SoLopGop"];
                        dtTemp.Rows.Add(drNew);
                        drNew = dtTemp.NewRow();
                        IDXL_LopTachGops = dr["XL_LopTachGopIDs"].ToString();
                        drNew["Chon"] = false;
                        drNew["TenLopTachGop"] = dr["TenLopTachGop"].ToString();
                        drNew["TenCacLopGop"] = dr["TenCacLopGop"].ToString();
                        drNew["TenMonHocs"] =  dr["TenMonHoc"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        drNew["IDXL_MonHocTrongKys"] = dr["IDXL_MonHocTrongKys"].ToString();
                        drNew["XL_LopTachGopIDs"] = dr["XL_LopTachGopIDs"].ToString();
                        drNew["IDDM_LopGocs"] = dr["IDDM_LopGocs"].ToString();
                        drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"].ToString();
                        SoLop++;
                    }
                }               
                dtTemp.Rows.Add(drNew);
            }
            return dtTemp;
        }
        private void ShowBarButton(bool status)
        {
            barThemMonHoc.Enabled = status;
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }
        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgThemLopGop dlg = new dlgThemLopGop();
            dlg.ShowDialog();
            if (dlg.Tag.ToString() != "")
            {
                frmLopGop_Load(null, null);
            }
        }
        private void barThemMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dlgThemMonHoc_LopTach dlg = new dlgThemMonHoc_LopTach(grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["XL_LopTachGopIDs"].ToString(), 0, 0, grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["IDXL_MonHocTrongKys"].ToString(), true, grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["IDDM_LopGocs"].ToString(), int.Parse(grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["SoLopGop"].ToString()));
            dlg.ShowDialog();
            if (dlg.Tag.ToString() != "")
            {
                // ghi log
                GhiLog("Thêm môn học vào lớp gộp '" + grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["TenLopTachGop"].ToString() + "'", "Thêm", this.Tag.ToString());
                frmLopGop_Load(null, null);
                ThemThanhCong();
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgSuaLopGop dlg = new dlgSuaLopGop(grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["XL_LopTachGopIDs"].ToString(), grvLopGop.GetDataRow(grvLopGop.FocusedRowHandle)["TenLopTachGop"].ToString());
            dlg.ShowDialog();
            if (dlg.Tag.ToString() != "")
            {
                frmLopGop_Load(null, null);
            }
        }
        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvLopGop.FocusedRowHandle = -1;
            bool check = false;
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                try
                {
                    cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
                    for (int i = 0; i < dtLopGop.Rows.Count; i++)
                    {

                        string mXL_LopTachGopIDs = "", mIDXL_MonHocTrongKys = "";

                        if (bool.Parse(dtLopGop.Rows[i]["Chon"].ToString()) == true)
                        {
                            check = true;
                            mXL_LopTachGopIDs = dtLopGop.Rows[i]["XL_LopTachGopIDs"].ToString() + ",";
                            try
                            {
                                // delete lop tach gop
                                oBXL_LopTachGop.DeleteByLopGoc(mXL_LopTachGopIDs.Substring(0, mXL_LopTachGopIDs.Length - 1));

                                // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                                mIDXL_MonHocTrongKys = dtLopGop.Rows[i]["IDXL_MonHocTrongKys"].ToString() + ",";
                                while ((mIDXL_MonHocTrongKys != "") && (mIDXL_MonHocTrongKys != ","))
                                {
                                    oBXL_MonHocTrongKy.UpdateTachGop(int.Parse(mIDXL_MonHocTrongKys.Substring(0, mIDXL_MonHocTrongKys.IndexOf(","))), false);
                                    mIDXL_MonHocTrongKys = mIDXL_MonHocTrongKys.Substring(mIDXL_MonHocTrongKys.IndexOf(",") + 1);
                                }
                                // ghi log
                                GhiLog("Xóa lớp gộp '" + dtLopGop.Rows[i]["TenLopTachGop"].ToString() + "' khỏi CSDL", "Xóa", this.Tag.ToString());

                            }
                            catch
                            {
                                check = false;
                            }
                        }
                    }
                    if (check == true)
                    {
                        frmLopGop_Load(null, null);
                     
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

       
    }
}