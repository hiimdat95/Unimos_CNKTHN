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
    public partial class frmDM_QuyenHoaDon : frmBase
    {
        private int status;
        private cBTC_QuyenHoaDon oBTC_QuyenHoaDon;
        private TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo;
        private DataTable dtQuyenHoaDon, dtDaChon, dtChuaChon;
        private DataRow drQuyenHoaDon;
        private string strDelete = "", strAdd = "";

        public frmDM_QuyenHoaDon()
        {
            InitializeComponent();
            pTC_QuyenHoaDonInfo = new TC_QuyenHoaDonInfo();
            oBTC_QuyenHoaDon = new cBTC_QuyenHoaDon();
        }

        private void frmDM_QuyenHoaDon_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            cmbDiaDiem.Properties.DataSource = bLoadDiaDiem();
            GetQuyenHoaDon();
            if (dtQuyenHoaDon.Rows.Count > 0)
            {
                grvQuyenHoaDon.FocusedRowHandle = 0;
                grvQuyenHoaDon_FocusedRowChanged(null, null);
            }
        }

        private void GetQuyenHoaDon()
        {
            dtQuyenHoaDon = oBTC_QuyenHoaDon.GetByHocKy_NamHoc(Program.HocKy, Program.IDNamHoc);
            grdQuyenHoaDon.DataSource = dtQuyenHoaDon;

        }

        private void ClearText()
        {
            txtTenQuyenHoaDon.Text = "";
            txtTuSo.Text = "";
            txtSoHienTai.Text = "";
            strAdd = "";
            strDelete = "";
            txtTenQuyenHoaDon.Focus();
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbDiaDiem.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenQuyenHoaDon, "Tên quyển hóa đơn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuyenHoaDon;
            }
            if (txtTenQuyenHoaDon.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenQuyenHoaDon, "Tên quyển hóa đơn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuyenHoaDon;
            }
            if (txtTuSo.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTuSo, "Từ số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTuSo;
            }
            if (txtSoHienTai.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoHienTai, "Số hiện tại không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoHienTai;
            }

            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void SetInfo()
        {
            cmbDiaDiem.EditValue = pTC_QuyenHoaDonInfo.IDDM_DiaDiem;
            txtTenQuyenHoaDon.Text = pTC_QuyenHoaDonInfo.TenQuyenHoaDon;
            txtTuSo.Text = pTC_QuyenHoaDonInfo.TuSo;
            txtSoHienTai.Text = pTC_QuyenHoaDonInfo.SoHienTai;
        }

        private void GetTrinhDo()
        {
            if (status == 0)// thêm
            {
                dtDaChon = oBTC_QuyenHoaDon.GetTrinhDo(0, 0, Program.HocKy, Program.IDNamHoc);
                dtChuaChon = oBTC_QuyenHoaDon.GetTrinhDo(1, 0, Program.HocKy, Program.IDNamHoc);

            }
            else // sửa
            {
                dtDaChon = oBTC_QuyenHoaDon.GetTrinhDo(0, pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID, Program.HocKy, Program.IDNamHoc);
                dtChuaChon = oBTC_QuyenHoaDon.GetTrinhDo(1, pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID, Program.HocKy, Program.IDNamHoc);

            }
            grdChuaChon.DataSource = dtChuaChon;
            grdDaChon.DataSource = dtDaChon;
        }

        private void GetInfo()
        {
            pTC_QuyenHoaDonInfo.IDDM_DiaDiem = int.Parse(cmbDiaDiem.EditValue.ToString());
            pTC_QuyenHoaDonInfo.TenQuyenHoaDon = txtTenQuyenHoaDon.Text;
            pTC_QuyenHoaDonInfo.TuSo = txtTuSo.Text;
            pTC_QuyenHoaDonInfo.SoHienTai = txtSoHienTai.Text;
            pTC_QuyenHoaDonInfo.HocKy = Program.HocKy;
            pTC_QuyenHoaDonInfo.IDDM_NamHoc = Program.IDNamHoc;
        }


        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtTenQuyenHoaDon.Focus();
            status = 0;
            GetTrinhDo();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            SetInfo();
            GetTrinhDo();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                grvQuyenHoaDon_FocusedRowChanged(null, null);
                try
                {
                    oBTC_QuyenHoaDon.Delete(pTC_QuyenHoaDonInfo);
                    GetQuyenHoaDon();
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            cBTC_QuyenHoaDon_TrinhDo oBQuyenHoaDon_Trinhdo = new cBTC_QuyenHoaDon_TrinhDo();
            TC_QuyenHoaDon_TrinhDoInfo pQuyenHoaDon_TrinhDo = new TC_QuyenHoaDon_TrinhDoInfo();
            if (!Check_Valid()) return;
            try
            {
                GetInfo();

                string[] arrAdd = strAdd.Split(',');
                string[] arrDelete = strDelete.Split(',');

                if (status == 0)
                {
                    int mQuyenHoaDonID = oBTC_QuyenHoaDon.Add(pTC_QuyenHoaDonInfo);
                    drQuyenHoaDon = dtQuyenHoaDon.NewRow();
                    oBTC_QuyenHoaDon.ToDataRow(pTC_QuyenHoaDonInfo, ref drQuyenHoaDon);
                    drQuyenHoaDon["TC_QuyenHoaDonID"] = mQuyenHoaDonID;
                    dtQuyenHoaDon.Rows.Add(drQuyenHoaDon);
                    ThemThanhCong();
                    // Update Trinh Do
                    if (arrAdd.Length > 0)
                        for (int i = 0; i < arrAdd.Length - 1; i++)
                        {
                            if (arrAdd[i].ToString() != "")
                            {
                                pQuyenHoaDon_TrinhDo.IDDM_TrinhDo = int.Parse(arrAdd[i]);
                                pQuyenHoaDon_TrinhDo.IDTC_QuyenHoaDon = mQuyenHoaDonID;
                                oBQuyenHoaDon_Trinhdo.Add(pQuyenHoaDon_TrinhDo);
                            }
                        }
                    if (arrDelete.Length > 0)
                        for (int i = 0; i < arrDelete.Length - 1; i++)
                        {
                            if (arrDelete[i].ToString() != "")
                            {
                                pQuyenHoaDon_TrinhDo.TC_QuyenHoaDon_TrinhDoID = int.Parse(arrDelete[i]);
                                oBQuyenHoaDon_Trinhdo.Delete(pQuyenHoaDon_TrinhDo);
                            }
                        }
                    GetTrinhDo();
                }
                else
                {
                    oBTC_QuyenHoaDon.Update(pTC_QuyenHoaDonInfo);
                    drQuyenHoaDon[pTC_QuyenHoaDonInfo.strTuSo] = pTC_QuyenHoaDonInfo.TuSo;
                    drQuyenHoaDon[pTC_QuyenHoaDonInfo.strSoHienTai] = pTC_QuyenHoaDonInfo.SoHienTai;
                    drQuyenHoaDon[pTC_QuyenHoaDonInfo.strTenQuyenHoaDon] = pTC_QuyenHoaDonInfo.TenQuyenHoaDon;

                    // Update Trinh Do
                    for (int i = 0; i < arrAdd.Length - 1; i++)
                    {
                        if (arrAdd[i].ToString() != "")
                        {
                            pQuyenHoaDon_TrinhDo.IDDM_TrinhDo = int.Parse(arrAdd[i]);
                            pQuyenHoaDon_TrinhDo.IDTC_QuyenHoaDon = pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID;
                            oBQuyenHoaDon_Trinhdo.Add(pQuyenHoaDon_TrinhDo);
                        }
                    }
                    for (int i = 0; i < arrDelete.Length - 1; i++)
                    {
                        if (arrDelete[i].ToString() != "")
                        {
                            pQuyenHoaDon_TrinhDo.TC_QuyenHoaDon_TrinhDoID = int.Parse(arrDelete[i]);
                            oBQuyenHoaDon_Trinhdo.Delete(pQuyenHoaDon_TrinhDo);
                        }
                    }
                    SuaThanhCong();
                    panelTop.Visible = false;
                }

                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtChuaChon.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtChuaChon.Rows[i]["Chon"])
                {
                    dtChuaChon.Rows[i]["Chon"] = false;
                    strAdd += dtChuaChon.Rows[i]["DM_TrinhDoID"] + ",";
                    dtDaChon.ImportRow(dtChuaChon.Rows[i]);
                    dtChuaChon.Rows.Remove(dtChuaChon.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtDaChon.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtDaChon.Rows[i]["Chon"])
                {
                    dtDaChon.Rows[i]["Chon"] = false;
                    strDelete += dtChuaChon.Rows[i]["TC_QuyenHoaDon_TrinhDoID"] + ",";
                    dtChuaChon.ImportRow(dtDaChon.Rows[i]);
                    dtDaChon.Rows.Remove(dtDaChon.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void grvQuyenHoaDon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuyenHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuyenHoaDon.FocusedRowHandle >= 0)
            {
                drQuyenHoaDon = grvQuyenHoaDon.GetDataRow(grvQuyenHoaDon.FocusedRowHandle);
                oBTC_QuyenHoaDon.ToInfo(ref pTC_QuyenHoaDonInfo, drQuyenHoaDon);
            }
        }

    }
}