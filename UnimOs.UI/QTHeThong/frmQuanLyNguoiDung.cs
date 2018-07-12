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
using Lib;

namespace UnimOs.UI
{
    public partial class frmQuanLyNguoiDung : frmBase
    {
        private cBHT_ChucNang oBHT_ChucNang;
        private HT_ChucNangInfo pHT_ChucNangInfo;
        private DataTable dtNhom, dtGiaoVien, dtNguoiDung, dtChucNang;
        private cBNS_GiaoVien oBNS_GiaoVien;
        private HT_UserInfo pHT_UserInfo;
        private cBHT_User oBHT_User;
        private bool mUPDATE = false;
        private string TenDangNhap = "";
        private int Idx = -1, IDHT_UserGroup = 0;


        public frmQuanLyNguoiDung()
        {
            InitializeComponent();

            oBNS_GiaoVien = new cBNS_GiaoVien();

            pHT_UserInfo = new HT_UserInfo();
            oBHT_User = new cBHT_User();

            pHT_ChucNangInfo = new HT_ChucNangInfo();
            oBHT_ChucNang = new cBHT_ChucNang();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetData();
            ShowButton(false);
        }

        private void GetData()
        {
            dtNhom = LoadNhomNguoiDung();
            if (dtNhom != null)
            {
                cmbNhom.Properties.DataSource = dtNhom;
            }

            dtGiaoVien = oBNS_GiaoVien.GetByIDNS_DonVi(0);
            if (dtGiaoVien != null)
            {
                cmbGiaoVien.Properties.DataSource = dtGiaoVien;
            }

            pHT_UserInfo.HT_UserID = 0;
            dtNguoiDung = oBHT_User.Get(pHT_UserInfo);
            if (dtNguoiDung != null)
            {
                grdNguoiDung.DataSource = dtNguoiDung;
            }
        }


        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowButton(true);
            mUPDATE = true;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            ShowButton(true);
            mUPDATE = false;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvNguoiDung.FocusedRowHandle = -1;
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                DataTable dtTemp = dtNguoiDung.GetChanges();
                if (dtTemp != null)
                {
                    int mCheck = 0;
                    int mSoRows = dtNguoiDung.Rows.Count;
                    for (int i = 0; i < mSoRows; i++)
                    {
                        if ((bool)(dtNguoiDung.Rows[i]["Chon"]))
                        {
                            pHT_UserInfo.HT_UserID = int.Parse(dtNguoiDung.Rows[i]["HT_UserID"].ToString());
                            try
                            {
                                oBHT_User.Delete(pHT_UserInfo);
                                // ghi log
                                GhiLog("Xóa người dùng có tên đăng nhập là: '" + pHT_UserInfo.UserName + "' trong CSDL ", "Xóa", this.Tag.ToString());

                                mCheck = 1;
                                dtNguoiDung.Rows.Remove(dtNguoiDung.Rows[i]);
                                mSoRows = mSoRows - 1;
                                i = i - 1;
                            }
                            catch
                            {
                                mCheck = 2;
                            }
                        }
                    }
                    if (mCheck == 0)
                        ThongBao("Bạn phải chọn ít nhất 1 nhóm người dùng để xóa!");
                    else if (mCheck == 1)
                        XoaThanhCong();
                    else
                        XoaThatBai();
                }
                else
                    ThongBao("Bạn phải chọn ít nhất 1 nhóm người dùng để xóa!");
            }
        }
        private void menuGanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvNguoiDung.FocusedRowHandle >= 0)
            {
                dlgChucNang dlg = new dlgChucNang(int.Parse(grvNguoiDung.GetDataRow(grvNguoiDung.FocusedRowHandle)["HT_UserID"].ToString()), 0);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    GetNguoiDung_Quyen(pHT_UserInfo.HT_UserID);
                }
            }
        }

        private void menuXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnXoa_ItemClick(null, null);
        }

        private void menuSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnSua_ItemClick(null, null);
        }

        private void menuThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnThem_ItemClick(null, null);
        }
        private void cmbGiaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbGiaoVien.EditValue = null;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetInfo();
            TenDangNhap = pHT_UserInfo.UserName;
            if (!CheckValid()) return;
            try
            {
                if (mUPDATE == true)
                {
                    int idxNew = Idx;
                    // sua nguoi dung
                    oBHT_User.Update(pHT_UserInfo);
                    if (IDHT_UserGroup != pHT_UserInfo.IDHT_UserGroup && pHT_UserInfo.IDHT_UserGroup > 0)
                    {
                        if (ThongBaoChon("Bạn có muốn thêm quyền cho người dùng theo nhóm đã chọn!") == DialogResult.Yes)
                        {
                            try
                            {
                                oBHT_User.UpdateChucNang(pHT_UserInfo.HT_UserID, pHT_UserInfo.IDHT_UserGroup);
                            }
                            catch (Exception exp)
                            {
                                ThongBao(exp.Message);
                            }
                        }
                    }

                    DataRow[] arrDr = dtNguoiDung.Select(pHT_UserInfo.strHT_UserID + " = " + pHT_UserInfo.HT_UserID.ToString());
                    DataRow drNew = dtNguoiDung.NewRow();
                    oBHT_User.ToDataRow(pHT_UserInfo, ref drNew);
                    drNew["Chon"] = false;
                    dtNguoiDung.Rows.InsertAt(drNew, idxNew + 1);
                    dtNguoiDung.Rows.Remove(arrDr[0]);
                    grvNguoiDung.FocusedRowHandle = idxNew;
                    // ghi log
                    GhiLog("Sửa thông tin người dùng có tên đăng nhập là: '" + pHT_UserInfo.UserName + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
                else
                {
                    // them  nguoi dung
                    oBHT_User.Add(pHT_UserInfo);

                    DataRow drNew = dtNguoiDung.NewRow();
                    oBHT_User.ToDataRow(pHT_UserInfo, ref drNew);
                    drNew["Chon"] = false;
                    dtNguoiDung.Rows.Add(drNew);
                    // ghi log
                    GhiLog("Thêm người dùng có tên đăng nhập là: '" + pHT_UserInfo.UserName + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                    ClearText();
                }
            }
            catch (Exception exp)
            {
                ThongBao(exp.Message);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ShowButton(false);
        }

        private void GetNguoiDung_Quyen(int mHT_UserID)
        {
            dtChucNang = oBHT_ChucNang.GetIn_Tree(0, mHT_UserID);
            if (dtChucNang != null && dtChucNang.Rows.Count > 0)
            {
                trlChucNang.DataSource = dtChucNang;
                trlChucNang.RefreshDataSource();
                trlChucNang.ExpandAll();
            }
            else
            {
                trlChucNang.DataSource = null;
                trlChucNang.RefreshDataSource();
            }
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenDayDu.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenDayDu, "Tên đầy đủ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenDayDu;
            }
            if (txtMatKhau.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMatKhau, "Mật khẩu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMatKhau;
            }
            if (txtTenDangNhap.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenDangNhap, "Tên đăng nhập không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenDangNhap;
            }
            if (mUPDATE == true && txtTenDangNhap.Text.Trim() == TenDangNhap)
            {
                mUPDATE = true;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (grvNguoiDung.RowCount != 0)
                {
                    for (int i = 0; i < grvNguoiDung.DataRowCount; i++)
                    {
                        if (txtTenDangNhap.Text.Trim() == grvNguoiDung.GetDataRow(i)[pHT_UserInfo.strUserName].ToString())
                        {
                            if (CtrlErr == null) CtrlErr = txtTenDangNhap;
                            txtTenDangNhap.Text = "";
                            txtTenDangNhap.Focus();
                            ThongBao("Tên đăng nhập bạn nhập đã bị trùng!");
                            break;
                        }
                    }
                }
            }
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void ShowButton(bool mStatus)
        {
            btnCapNhat.Enabled = mStatus;
            btnHuy.Enabled = mStatus;
        }

        private void GetInfo()
        {
            pHT_UserInfo.IpAddress = txtIP.Text.Trim();
            pHT_UserInfo.MacAddress = txtMac.Text.Trim();
            pHT_UserInfo.UserName = txtTenDangNhap.Text.Trim();
            pHT_UserInfo.FullName = txtTenDayDu.Text.Trim();
            pHT_UserInfo.Password = Lib.clsAuthentication.Encrypt(txtMatKhau.Text.Trim());
            pHT_UserInfo.IDHT_UserGroup = (cmbNhom.EditValue == null ? -1 : int.Parse(cmbNhom.EditValue.ToString()));
            pHT_UserInfo.IDNS_GiaoVien = (cmbGiaoVien.EditValue == null ? -1 : int.Parse(cmbGiaoVien.EditValue.ToString()));
            pHT_UserInfo.Active = chkKichHoat.Checked;
        }

        private void GetInfo(DataRow dr)
        {
            pHT_UserInfo.HT_UserID = int.Parse(dr["HT_UserID"].ToString());
            pHT_UserInfo.IpAddress = dr["IpAddress"].ToString();
            pHT_UserInfo.MacAddress = dr["MacAddress"].ToString();
            pHT_UserInfo.UserName = dr["UserName"].ToString();
            pHT_UserInfo.FullName = dr["FullName"].ToString();
            pHT_UserInfo.Password = Lib.clsAuthentication.Decrypt(dr["Password"].ToString());
            IDHT_UserGroup = pHT_UserInfo.IDHT_UserGroup = (dr["IDHT_UserGroup"].ToString() == "" ? -1 : int.Parse(dr["IDHT_UserGroup"].ToString()));
            pHT_UserInfo.IDNS_GiaoVien = (dr["IDNS_GiaoVien"].ToString() == "" ? -1 : int.Parse(dr["IDNS_GiaoVien"].ToString()));
            pHT_UserInfo.Active = bool.Parse(dr["Active"].ToString());
        }

        private void grvNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNguoiDung.FocusedRowHandle >= 0)
            {
                Idx = grvNguoiDung.FocusedRowHandle;
                GetInfo(grvNguoiDung.GetDataRow(Idx));
                GetNguoiDung_Quyen(pHT_UserInfo.HT_UserID);
                SetText();

            }
        }
        private void SetText()
        {
            txtIP.Text = pHT_UserInfo.IpAddress;
            txtMac.Text = pHT_UserInfo.MacAddress;
            txtTenDangNhap.Text = pHT_UserInfo.UserName;
            txtTenDayDu.Text = pHT_UserInfo.FullName;
            txtMatKhau.Text = pHT_UserInfo.Password;
            cmbNhom.EditValue = pHT_UserInfo.IDHT_UserGroup;
            cmbGiaoVien.EditValue = pHT_UserInfo.IDNS_GiaoVien;
            chkKichHoat.Checked = (bool)(pHT_UserInfo.Active);
        }

        private void ClearText()
        {
            txtIP.Text = "";
            txtMac.Text = "";
            txtTenDangNhap.Text = "";
            txtTenDayDu.Text = "";
            txtMatKhau.Text = "";
            cmbNhom.EditValue = null;
            cmbGiaoVien.EditValue = null;
            chkKichHoat.Checked = false;
            txtTenDayDu.Focus();
        }

        private void grvNguoiDung_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdNguoiDung.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }

        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {
            if (trlChucNang.AllNodesCount > 0)
                trlChucNang.ExpandAll();
        }

        private void cmbNhom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNhom.EditValue = null;
        }

    }
}