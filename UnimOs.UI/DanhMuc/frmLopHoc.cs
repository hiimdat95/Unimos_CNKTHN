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
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmLopHoc : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        public DM_LopInfo pDM_LopInfo;
        private DataTable dtLop;
        private bool UPDATE = true;
        private int idx;

        public frmLopHoc()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            LoadCombo();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            SetBarButton(false);
            SetButton(false);
            dtLop = oBDM_Lop.GetTree(Program.NamHoc);
            grdDSLop.DataSource = dtLop;
            lblSoLop.Text = "Hiện tại có " + dtLop.Rows.Count.ToString() + " lớp";
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            cmbKhoaHoc.Properties.DataSource = LoadKhoaHoc();
            cmbCoSo.Properties.DataSource = bLoadDiaDiem();
            // Ngành
            uccmbNganh.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNganh","Mã ngành"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNganh","Tên ngành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNganh_E","Name")}));
            uccmbNganh.cmb.Properties.DisplayMember = "TenNganh";
            uccmbNganh.cmb.Properties.ValueMember = "DM_NganhID";
            uccmbNganh.cmb.EditValueChanged += new EventHandler(cmbNganh_EditValueChanged);

            // Chuyên ngành
            uccmbChuyenNganh.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChuyenNganh","Mã chuyên ngành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChuyenNganh","Tên chuyên ngành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChuyenNganh_E","Name")}));
            uccmbChuyenNganh.cmb.Properties.DisplayMember = "TenChuyenNganh";
            uccmbChuyenNganh.cmb.Properties.ValueMember = "DM_ChuyenNganhID";

            // Trường liên kết
            uccmbTruongLienKet.cmb.Properties.DataSource = LoadTruongLienKet();
            uccmbTruongLienKet.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTruong","Mã trường"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTruong","Tên trường"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tinh","Tỉnh")}));
            uccmbTruongLienKet.cmb.Properties.DisplayMember = "TenTruong";
            uccmbTruongLienKet.cmb.Properties.ValueMember = "DM_TruongLienKetID";
        }

        private void SetText()
        {
            if (UPDATE)
            {
                txtTenLop.Text = pDM_LopInfo.TenLop;
                txtSoSV.Text = pDM_LopInfo.SoSinhVien.ToString();
                txtNienKhoa.Text = pDM_LopInfo.NienKhoa;
                cmbHe.EditValue = pDM_LopInfo.IDDM_He;
                cmbTrinhDo.EditValue = pDM_LopInfo.IDDM_TrinhDo;
                cmbKhoa.EditValue = pDM_LopInfo.IDDM_Khoa;
                cmbKhoaHoc.EditValue = pDM_LopInfo.IDDM_KhoaHoc;
                cmbCoSo.EditValue = pDM_LopInfo.IDDM_DiaDiem;
                uccmbNganh.cmb.EditValue = pDM_LopInfo.IDDM_Nganh;
                uccmbChuyenNganh.cmb.EditValue = pDM_LopInfo.IDDM_ChuyenNganh;
                uccmbTruongLienKet.cmb.EditValue = pDM_LopInfo.IDDM_TruongLienKet;
                chkXepLich.Checked = pDM_LopInfo.XepThoiKhoaBieu;
                dtpNgayVao.EditValue = pDM_LopInfo.NgayVao;
                dtpNgayRa.EditValue = pDM_LopInfo.NgayRa;
            }
            else
            {
                txtTenLop.Text = "";
                txtSoSV.Text = "";
                //txtNienKhoa.Text = "";
            }
            txtTenLop.Focus();
        }

        private void SetBarButton(bool Status)
        {
            barbtnSua.Enabled = Status;
            barbtnXoa.Enabled = Status;
        }

        private void SetButton(bool Status)
        {
            btnCapNhat.Enabled = Status;
            btnHuy.Enabled = Status;
        }

        private void GetpDM_LopInfo()
        {
            pDM_LopInfo.TenLop = txtTenLop.Text.Trim();
            pDM_LopInfo.NienKhoa = txtNienKhoa.Text.Trim();
            pDM_LopInfo.SoSinhVien = int.Parse(txtSoSV.Text.Trim());
            pDM_LopInfo.IDDM_KhoaHoc = int.Parse(cmbKhoaHoc.EditValue.ToString());
            pDM_LopInfo.IDDM_He = int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Khoa = int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = uccmbNganh.cmb.EditValue == null ? -1 : int.Parse(uccmbNganh.cmb.EditValue.ToString());
            pDM_LopInfo.IDDM_ChuyenNganh = uccmbChuyenNganh.cmb.EditValue == null ? -1 : int.Parse(uccmbChuyenNganh.cmb.EditValue.ToString());
            pDM_LopInfo.IDDM_TruongLienKet = uccmbTruongLienKet.cmb.EditValue == null ? -1 : int.Parse(uccmbTruongLienKet.cmb.EditValue.ToString());
            pDM_LopInfo.IDDM_DiaDiem = cmbCoSo.EditValue == null ? -1 : int.Parse(cmbCoSo.EditValue.ToString());
            pDM_LopInfo.XepThoiKhoaBieu = chkXepLich.Checked;
            if (dtpNgayVao.EditValue != null)
            {
                pDM_LopInfo.NgayVao = DateTime.Parse(dtpNgayVao.EditValue.ToString()).Date;
            }
          
            if (dtpNgayRa.EditValue != null)
            {
                pDM_LopInfo.NgayRa = DateTime.Parse(dtpNgayRa.EditValue.ToString()).Date;
            }
            pDM_LopInfo.KieuLopTachGop = -1;
        }

        private void GetpDM_LopInfo(DataRow dr)
        {
            pDM_LopInfo.DM_LopID = int.Parse(dr["DM_LopID"].ToString());
            pDM_LopInfo.TenLop = dr["TenLop"].ToString();
            pDM_LopInfo.NienKhoa = dr["NienKhoa"].ToString();
            pDM_LopInfo.SoSinhVien = int.Parse(dr["SoSinhVien"].ToString());
            pDM_LopInfo.IDDM_KhoaHoc = int.Parse(dr["IDDM_KhoaHoc"].ToString());
            pDM_LopInfo.IDDM_He = int.Parse(dr["IDDM_He"].ToString());
            pDM_LopInfo.IDDM_TrinhDo = int.Parse(dr["IDDM_TrinhDo"].ToString());
            pDM_LopInfo.IDDM_Khoa = int.Parse(dr["IDDM_Khoa"].ToString());
            pDM_LopInfo.IDDM_Nganh = int.Parse(dr["IDDM_Nganh"].ToString());
            pDM_LopInfo.IDDM_ChuyenNganh = int.Parse(dr["IDDM_ChuyenNganh"].ToString());
            pDM_LopInfo.IDDM_TruongLienKet = int.Parse(dr["IDDM_TruongLienKet"].ToString());
            pDM_LopInfo.XepThoiKhoaBieu = bool.Parse(dr["XepThoiKhoaBieu"].ToString());
            if ("" + dr[pDM_LopInfo.strIDDM_DiaDiem] != "")
                pDM_LopInfo.IDDM_DiaDiem = int.Parse(dr[pDM_LopInfo.strIDDM_DiaDiem].ToString());
            else
                pDM_LopInfo.IDDM_DiaDiem = -1;
            if (dr["NgayVao"] != null)
                pDM_LopInfo.NgayVao = DateTime.Parse(dr["NgayVao"].ToString()).Date;
            if (dr["NgayRa"] != null)
                pDM_LopInfo.NgayRa = DateTime.Parse(dr["NgayRa"].ToString()).Date;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenLop.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLop, "Tên lớp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLop;
            }
            if (txtNienKhoa.Text.Length != 9)
            {
                dxErrorProvider.SetError(txtNienKhoa, "Niên khóa không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNienKhoa;
            }
            if (cmbHe.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbHe, "Hệ đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbHe;
            }
            if (cmbTrinhDo.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbTrinhDo, "Trình độ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrinhDo;
            }
            if (cmbKhoa.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbKhoa, "Khoa không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbKhoa;
            }
            if (cmbCoSo.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbCoSo, "Bạn phải chọn cơ sở.");
                if (CtrlErr == null) CtrlErr = cmbCoSo;
            }
            if (cmbKhoaHoc.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbKhoaHoc, "Khóa học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbKhoaHoc;
            }
            if (txtSoSV.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoSV, "Số sinh viên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoSV;
            }   
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            uccmbNganh.cmb.Properties.DataSource = LoadNganhByIDKhoa(int.Parse(cmbKhoa.EditValue.ToString()));
        }

        void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            uccmbChuyenNganh.cmb.Properties.DataSource = LoadChuyenNganh(int.Parse(uccmbNganh.cmb.EditValue.ToString()));
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            GetpDM_LopInfo();
            DataRow drNew;
            if (UPDATE)
            {
                oBDM_Lop.Update(pDM_LopInfo);
                drNew = dtLop.NewRow();
                oBDM_Lop.ToDataRow(pDM_LopInfo, ref drNew);
                drNew["TenHe"] = cmbHe.Text;
                drNew["TenTrinhDo"] = cmbTrinhDo.Text;
                drNew["TenKhoa"] = cmbKhoa.Text;
                drNew["TenKhoaHoc"] = cmbKhoaHoc.Text;
                DataRow dr = grvDSLop.GetDataRow(grvDSLop.FocusedRowHandle);
                dtLop.Rows.InsertAt(drNew, grvDSLop.FocusedRowHandle + 1);
                dtLop.Rows.Remove(dr);
                // ghi log
                GhiLog("Sửa lớp học '" + pDM_LopInfo.TenLop + "' trong CSDL ", "Sửa", this.Tag.ToString());
                btnHuy_Click(null, null);
                grdDSLop.Enabled = true;
                SuaThanhCong();
            }
            else
            {
                pDM_LopInfo.DM_LopID = oBDM_Lop.Add(pDM_LopInfo);
                drNew = dtLop.NewRow();
                oBDM_Lop.ToDataRow(pDM_LopInfo, ref drNew);
                drNew["TenHe"] = cmbHe.Text;
                drNew["TenTrinhDo"] = cmbTrinhDo.Text;
                drNew["TenKhoa"] = cmbKhoa.Text;
                drNew["TenKhoaHoc"] = cmbKhoaHoc.Text;
                dtLop.Rows.Add(drNew);
                // ghi log
                GhiLog("Thêm lớp học '" + pDM_LopInfo.TenLop + "' vào CSDL ", "Thêm", this.Tag.ToString());
                SetText();
            }

            lblSoLop.Text = "Hiện tại có " + dtLop.Rows.Count.ToString() + " lớp";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButton(false);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UPDATE = false;
            SetButton(true);
            SetText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UPDATE = true;
            //SetText();
            SetButton(true);
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBDM_Lop.Delete(pDM_LopInfo);
                    // ghi log
                    GhiLog("Xóa lớp học '" + pDM_LopInfo.TenLop + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtLop.Rows.Remove(grvDSLop.GetDataRow(grvDSLop.FocusedRowHandle));
                    lblSoLop.Text = "Hiện tại có " + dtLop.Rows.Count.ToString() + " lớp";
                    XoaThanhCong();
                }
                catch(Exception ex)
                {
                    ThongBaoLoi("Dữ liệu đang dùng không thể xóa!\n" + ex.Message);
                }
            }
        }

        private void grvDSLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDSLop.DataRowCount > 0)
            {
                if (grvDSLop.FocusedRowHandle < 0)
                {
                    SetBarButton(false);
                }
                else
                {
                    SetBarButton(true);
                    idx = grvDSLop.FocusedRowHandle;
                    GetpDM_LopInfo(grvDSLop.GetDataRow(idx));
                    if (!btnCapNhat.Enabled)
                        SetText();
                }
            }
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            txtNienKhoa.Text = cmbKhoaHoc.GetColumnValue("NamVaoTruong").ToString() + "-" + cmbKhoaHoc.GetColumnValue("NamRaTruong").ToString();
            dtpNgayVao.EditValue = DateTime.Parse("10/8/" + cmbKhoaHoc.GetColumnValue("NamVaoTruong").ToString());
            
            dtpNgayRa.EditValue = DateTime.Parse("01/8/" + cmbKhoaHoc.GetColumnValue("NamRaTruong").ToString());
        }

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportToXls(grvDSLop);
        }
    }
}