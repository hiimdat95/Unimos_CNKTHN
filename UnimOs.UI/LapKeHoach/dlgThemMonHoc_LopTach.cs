using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgThemMonHoc_LopTach : frmBase
    {
        private Hashtable htb = new Hashtable();
        cBXL_GiaoVien_MonHoc oBXL_GiaoVien_MonHoc;
        XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo;
        cBXL_LopTachGop_MonHoc oBXL_LopTachGop_MonHoc;
        cBXL_LopTachGop oBXL_LopTachGop;
        XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo;
        DataView dvClone;
        DataTable dtMonHoc, dtMonHocAll;
        int IDDM_Lop,IDXL_MonHocTrongKy, SoLop;
        string XL_LopTachGopIDs, IDXL_MonHocTrongKys,IDDM_Lops;
        bool CheckTach_Gop;
        string[] ArrayLop;

        public dlgThemMonHoc_LopTach(string mXL_LopTachGopIDs, int mIDDM_Lop, int mIDXL_MonHocTrongKy, string mIDXL_MonHocTrongKys, bool mCheckTach_Gop, string mIDDM_Lops, int mSoLop)
        {
            InitializeComponent();

            oBXL_GiaoVien_MonHoc = new cBXL_GiaoVien_MonHoc();
            oBXL_LopTachGop_MonHoc = new cBXL_LopTachGop_MonHoc();
            oBXL_LopTachGop = new cBXL_LopTachGop();
            pXL_GiaoVien_MonHocInfo = new XL_GiaoVien_MonHocInfo ();
            pXL_LopTachGop_MonHocInfo = new XL_LopTachGop_MonHocInfo();

            CheckTach_Gop = mCheckTach_Gop;
            XL_LopTachGopIDs = mXL_LopTachGopIDs;
            IDXL_MonHocTrongKy = mIDXL_MonHocTrongKy;
            IDXL_MonHocTrongKys = mIDXL_MonHocTrongKys;

            // them mon hoc - lop tach
            if (CheckTach_Gop == false)
            {
                dtMonHoc = MonHocTrongKyGetAll(mIDDM_Lop);
                   IDDM_Lop = mIDDM_Lop;
            }
            else
            { 
                // them mon hoc - lop gop
                dtMonHocAll = MonHocTrongKyGetByLopGop(mIDDM_Lops, mSoLop);
                Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();

                dtMonHoc = cls.SelectDistinct(dtMonHocAll, new string[] { "IDDM_MonHoc", "TenMonHoc", "MaMonHoc", "IDNS_GiaoVien", "IDDM_PhongHoc", "Cahocs","Chon"  });

                IDDM_Lops = mIDDM_Lops;
                char[] mChar = {','};
                ArrayLop = IDDM_Lops.Split(mChar);
                IDDM_Lop = int.Parse(XL_LopTachGopIDs.Substring(0,XL_LopTachGopIDs.IndexOf(",")));
                SoLop = mSoLop;
            }

            dtMonHoc.AcceptChanges();          
            repositoryPhongHoc.DataSource = LoadPhongHoc();
           
            this.Tag = "";
        }

        private void dlgThemMonHoc_LopTach_Load(object sender, EventArgs e)
        {
            grdMonHoc.DataSource = dtMonHoc;
            repositoryGiaoVien.DataSource = LoadGiaoVienMonLop();
            if (grvMonHoc.DataRowCount > 0)
            {
                btnCapNhat.Visible = true;
            }
            else
                btnCapNhat.Visible = false;
        }

        private DataTable LoadGiaoVienMonLop()
        {
            if (CheckTach_Gop == false)
            {
                return oBXL_GiaoVien_MonHoc.GetByMonLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            }
            else
                return oBXL_GiaoVien_MonHoc.GetByMonLop(0,Program.IDNamHoc, Program.HocKy);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            bool mStatus = false;
            DataTable dtTemp = dtMonHoc.GetChanges();
            DataRow[] drMon = dtMonHoc.Select("Chon=true");
            if (drMon.Length == 0)
            {
                if (ThongBaoChon("Bỏ hết môn học, thông tin lớp tách gộp sẽ bị mất. Bạn có chắc chắn chấp nhận?") == DialogResult.Yes)
                {
                    try
                    {
                        mStatus = true;
                        oBXL_LopTachGop.DeleteByLopGoc(XL_LopTachGopIDs.Substring(0,XL_LopTachGopIDs.Length - 1));
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
                else
                {
                    return;
                }
            }
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        mStatus = true;
                        if ((bool)(dr["Chon"]) == true)
                        {
                            try
                            {
                                if (CheckTach_Gop == false)
                                {
                                    // them mon hoc - lop tach
                                    oBXL_LopTachGop_MonHoc.AddMonHoc_ByLopTach(IDXL_MonHocTrongKy, IDDM_Lop, int.Parse(dr["XL_MonHocTrongKyID"].ToString()),
                                       ("" + dr["IDNS_GiaoVien"].ToString() == "" ? -1 : int.Parse(dr["IDNS_GiaoVien"].ToString())), ("" + dr["IDDM_PhongHoc"].ToString() == "" ? -1 : int.Parse(dr["IDDM_PhongHoc"].ToString())), (dr["CaHocs"].ToString() == "" ? -1 : (dr["CaHocs"].ToString() == "Sáng" ? 0 : (dr["CaHocs"].ToString() == "Chiều" ? 1 : 2))));
                                    // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                                    oBXL_MonHocTrongKy.UpdateTachGop(int.Parse(dr["XL_MonHocTrongKyID"].ToString()), true);
                                }
                                else
                                {
                                    // them mon hoc - lop gop     
                                    oBXL_LopTachGop_MonHoc.AddMonHoc_ByLopGop(XL_LopTachGopIDs + ",", int.Parse(dr["IDDM_MonHoc"].ToString()),
                                       ("" + dr["IDNS_GiaoVien"].ToString() == "" ? -1 : int.Parse(dr["IDNS_GiaoVien"].ToString())), ("" + dr["IDDM_PhongHoc"].ToString() == "" ? -1 : int.Parse(dr["IDDM_PhongHoc"].ToString())), (dr["CaHocs"].ToString() == "" ? -1 : (dr["CaHocs"].ToString() == "Sáng" ? 0 : (dr["CaHocs"].ToString() == "Chiều" ? 1 : 2))));
                                }

                            }
                            catch (Exception exp)
                            {
                                ThongBao(exp.Message);
                            }
                        }
                        else
                        {
                            if (CheckTach_Gop == false)
                            {
                                // Lop Tach
                                oBXL_LopTachGop_MonHoc.DeleteByLopTach(IDDM_Lop, int.Parse(dr["XL_MonHocTrongKyID"].ToString()));
                                // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                                oBXL_MonHocTrongKy.UpdateTachGop(int.Parse(dr["XL_MonHocTrongKyID"].ToString()), false);
                            }
                            else
                            {
                                for (int i = 0; i < ArrayLop.Length; i++)
                                {
                                    try
                                    {
                                        DataRow[] drArray = dtMonHocAll.Select("IDDM_Lop =" + ArrayLop[i] + "and IDDM_MonHoc" + dr["IDDM_MonHoc"]);
                                        oBXL_LopTachGop_MonHoc.DeleteByLopTach(int.Parse(ArrayLop[i]), int.Parse(drArray[0]["XL_MonHocTrongKyID"].ToString()));
                                        // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
                                        oBXL_MonHocTrongKy.UpdateTachGop(int.Parse(drArray[0]["XL_MonHocTrongKyID"].ToString()), false);
                                    }
                                    catch (Exception exp)
                                    {
                                        ThongBao(exp.Message);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            if (mStatus == true)
            {
                this.Tag = "1";
                this.Close();
            }
            else
                ThongBao("Bạn chưa thay đổi môn học nào");
        }

        private void grvMonHoc_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "IDNS_GiaoVien")
            {
                LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
                DataTable dtSource = edit.Properties.LookUpData.DataSource as DataTable;
                dvClone = new DataView(dtSource);

                string parameter = view.GetRowCellValue(view.FocusedRowHandle, "IDDM_MonHoc").ToString();

                dvClone.RowFilter = "IDDM_MonHoc = " + parameter;
                edit.Properties.LookUpData.DataSource = dvClone;
               
            }
        }

        private void grvMonHoc_HiddenEditor(object sender, EventArgs e)
        {
            if (dvClone != null)
            {
                dvClone.Dispose();
                dvClone = null;
            }
        }

    }
}