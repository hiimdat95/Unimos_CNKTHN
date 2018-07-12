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
    public partial class dlgThemLopGop : frmBase
    {
        DataTable dtLop;
        cBDM_Lop oBDM_Lop;
        cBXL_GiaoVien_MonHoc oBXL_GiaoVien_MonHoc;
        XL_LopTachGopInfo pXL_LopTachGopInfo;
        XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo;
        cBXL_LopTachGop oBXL_LopTachGop;
        cBXL_LopTachGop_MonHoc oBXL_LopTachGop_MonHoc;
        DataTable dtMonKy;
        int TongSoSV = 0;

        public dlgThemLopGop()
        {
            InitializeComponent();
            this.Tag = "";

        }

        private void dlgThemLopGop_Load(object sender, EventArgs e)
        {
            oBDM_Lop = new cBDM_Lop();
            oBXL_GiaoVien_MonHoc = new cBXL_GiaoVien_MonHoc();
            oBXL_LopTachGop = new cBXL_LopTachGop();
            oBXL_LopTachGop_MonHoc = new cBXL_LopTachGop_MonHoc();
            pXL_LopTachGop_MonHocInfo = new XL_LopTachGop_MonHocInfo();
            pXL_LopTachGopInfo = new XL_LopTachGopInfo();
            txtNamHoc.Text = Program.NamHoc;
            LoadData();
            repositoryPhongHoc.DataSource = LoadPhongHoc();
        }

        private void LoadData()
        { // do du lieu vao combobox
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoaHoc.Properties.DataSource = LoadKhoaHoc();
            cmbNganh.Properties.DataSource = LoadNganh();
            dtMonKy = MonHocTrongKy(0);
            Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();
            cmbMon.Properties.DataSource = cls.SelectDistinct(dtMonKy, new string[] { "IDDM_MonHoc", "TenMonHoc", "MaMonHoc" });

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            cmbTrinhDo.Properties.DataSource = cmbHe.EditValue == null ? LoadTrinhDo() : LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            GetLop();
        }

        private void cmbMon_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMon.EditValue != null)
            {

                repositoryGiaoVien.DataSource = oBXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(int.Parse(cmbMon.EditValue.ToString()), "");
            }
            GetLop();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenLopGop.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLopGop, "Tên lớp gộp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLopGop;
            }
            if (cmbMon.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbMon, "Bạn chưa chọn môn học.");
                if (CtrlErr == null) CtrlErr = cmbMon;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbHe.EditValue = null;
        }

        private void cmbTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbTrinhDo.EditValue = null;
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNganh.EditValue = null;
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbKhoaHoc.EditValue = null;
        }

        private void GetLop()
        {
            DM_LopInfo pDM_LopInfo = new DM_LopInfo();
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            dtLop = oBDM_Lop.GetLopGop(pDM_LopInfo, cmbMon.EditValue == null ? 0 : int.Parse(cmbMon.EditValue.ToString()), Program.NamHoc);
            if (dtLop != null)
            {
                grdLop.DataSource = dtLop;

            }
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            GetLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            GetLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            GetLop();
        }

        private void grvLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void GetpLopTachGopInfo(DataRow dr)
        {
            pXL_LopTachGopInfo.IDDM_LopGoc = int.Parse(dr["DM_LopID"].ToString());
            pXL_LopTachGopInfo.IDDM_NamHoc = Program.IDNamHoc;
            pXL_LopTachGopInfo.HocKy = Program.HocKy;
            pXL_LopTachGopInfo.LopTach = false;
            pXL_LopTachGopInfo.TenLopTachGop = txtTenLopGop.Text.Trim();
            pXL_LopTachGopInfo.SoSinhVien = TongSoSV;
        }

        private void GetpLopTachMonHocInfo(DataRow dr)
        {
            DataTable dtMonHocTrongKy = dtMonKy.Copy();
            dtMonHocTrongKy.DefaultView.RowFilter = "IDDM_Lop=" + dr["DM_LopID"].ToString() + "and IDDM_MonHoc=" + cmbMon.EditValue.ToString();
            if (dtMonHocTrongKy.DefaultView.Count > 0)
            {
                pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy = int.Parse(dtMonHocTrongKy.DefaultView[0]["XL_MonHocTrongKyID"].ToString());
            }
            pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien = ("" + dr["IDNS_GiaoVien"].ToString() == "" ? -1 : int.Parse(dr["IDNS_GiaoVien"].ToString()));
            pXL_LopTachGop_MonHocInfo.CaHoc = (dr["CaHoc"].ToString() == "" ? -1 : (dr["CaHoc"].ToString() == "Sáng" ? 0 : (dr["CaHoc"].ToString() == "Chiều" ? 1 : 2)));
            pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc = ("" + dr["IDDM_PhongHoc"].ToString() == "" ? -1 : int.Parse(dr["IDDM_PhongHoc"].ToString()));
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            if (grvLop.DataRowCount > 0)
            {
               
                int KiemTra = 0;
                for (int i = 0; i < grvLop.DataRowCount; i++)
                {
                    if ((bool)(grvLop.GetDataRow(i)["Chon"]) == true)
                    {
                        KiemTra += 1;
                        TongSoSV += int.Parse(grvLop.GetDataRow(i)["SoSinhVien"].ToString());
                    }
                }
                if (KiemTra < 2)
                {
                    ThongBao("Bạn phải chọn ít nhất 2 lớp cần gộp");
                }
                else
                {
                    cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
                    int ParentID = 0;
                    for (int i = 0; i < grvLop.DataRowCount; i++)
                    {
                        if ((bool)(grvLop.GetDataRow(i)["Chon"]) == true)
                        {
                            GetpLopTachGopInfo(grvLop.GetDataRow(i));
                            GetpLopTachMonHocInfo(grvLop.GetDataRow(i));
                            if (i == 0)
                            {
                                pXL_LopTachGopInfo.ParentID = 0;
                                ParentID = oBXL_LopTachGop.Add(pXL_LopTachGopInfo);

                                pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = ParentID;
                            }
                            else
                            {
                                pXL_LopTachGopInfo.ParentID = ParentID;
                                pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = oBXL_LopTachGop.Add(pXL_LopTachGopInfo);
                            }

                            oBXL_LopTachGop_MonHoc.Add(pXL_LopTachGop_MonHocInfo);
                            // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true                            
                            oBXL_MonHocTrongKy.UpdateTachGop(pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy, true);
                            // ghi log
                            GhiLog("Thêm lớp gộp '" + txtTenLopGop.Text.Trim() + "' vào CSDL", "Thêm", this.Tag.ToString());
                        }
                    }
                    this.Tag = "1";
                    this.Close();
                }
            }
        }
    }
}