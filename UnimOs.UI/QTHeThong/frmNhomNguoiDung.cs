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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Lib;

namespace UnimOs.UI
{
    public partial class frmNhomNguoiDung : frmBase
    {
        private cBHT_ChucNang oBHT_ChucNang;
        private HT_ChucNangInfo pHT_ChucNangInfo;
        private cBHT_UserGroup oBHT_UserGroup;
        private HT_UserGroupInfo pHT_UserGroupInfo;
        private bool mStatus = false;
        private DataTable dtNhom, dtChucNang;
        private int Idx;

        public frmNhomNguoiDung()
        {

            InitializeComponent();
            pHT_ChucNangInfo = new HT_ChucNangInfo();
            oBHT_ChucNang = new cBHT_ChucNang();
            oBHT_UserGroup = new cBHT_UserGroup();
            pHT_UserGroupInfo = new HT_UserGroupInfo();
        }

        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            pHT_UserGroupInfo.HT_UserGroupID = 0;

            dtNhom = oBHT_UserGroup.Get(pHT_UserGroupInfo);
            if (dtNhom != null)
            {
                grdNhomND.DataSource = dtNhom;
                dtNhom.AcceptChanges();
                if (dtNhom.Rows.Count > 0)
                {
                    GetNhomNguoiDung_Quyen(int.Parse(dtNhom.Rows[0]["HT_UserGroupID"].ToString()));
                }
            }
            ShowButton(false);
        }

        private void GetNhomNguoiDung_Quyen(int mHT_UserGroupID)
        {
            dtChucNang = oBHT_ChucNang.GetIn_Tree(mHT_UserGroupID, 0);
            if (dtChucNang != null)
            {
                trlChucNang.DataSource = dtChucNang;
                trlChucNang.ExpandAll();
            }
        }

        private void ShowButton(bool mStatus)
        {
            btnCapNhat.Enabled = mStatus;
            btnHuy.Enabled = mStatus;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                if (mStatus == true)
                {
                    int idxNew = Idx;
                    // sua nhom nguoi dung
                    pHT_UserGroupInfo.TenNhom = txtTenNhom.Text.Trim();
                    oBHT_UserGroup.Update(pHT_UserGroupInfo);

                    DataRow[] arrDr = dtNhom.Select(pHT_UserGroupInfo.strHT_UserGroupID + " = " + pHT_UserGroupInfo.HT_UserGroupID.ToString());
                    DataRow drNew = dtNhom.NewRow();
                    oBHT_UserGroup.ToDataRow(pHT_UserGroupInfo, ref drNew);
                    drNew["Chon"] = false;
                    dtNhom.Rows.InsertAt(drNew, idxNew + 1);
                    dtNhom.Rows.Remove(arrDr[0]);
                    grvNhomND.FocusedRowHandle = idxNew;
                    // ghi log
                    GhiLog("Sửa nhóm người dùng '" + pHT_UserGroupInfo.TenNhom + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                    txtTenNhom.Text = "";
                }
                else
                {
                    // them nhom nguoi dung
                    pHT_UserGroupInfo.TenNhom = txtTenNhom.Text.Trim();
                    oBHT_UserGroup.Add(pHT_UserGroupInfo);

                    DataRow drNew = dtNhom.NewRow();
                    oBHT_UserGroup.ToDataRow(pHT_UserGroupInfo, ref drNew);
                    drNew["Chon"] = false;
                    dtNhom.Rows.Add(drNew);
                    // ghi log
                    GhiLog("Thêm nhóm người dùng '" + pHT_UserGroupInfo.TenNhom + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                    txtTenNhom.Text = "";
                }
            }
            catch (Exception exp)
            {
                ThongBao(exp.Message);
            }
        }

        private void barbtnThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenNhom.Text = "";
            txtTenNhom.Focus();
            mStatus = false;
            ShowButton(true);
        }

        private void barbtnSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenNhom.Text = pHT_UserGroupInfo.TenNhom;
            mStatus = true;
            ShowButton(true);
        }

        private void barbtnXoaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvNhomND.FocusedRowHandle = -1;
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                DataTable dtTemp = dtNhom.GetChanges();
                if (dtTemp != null)
                {
                    int mCheck = 0;
                    int mSoRows = dtNhom.Rows.Count;
                    for (int i = 0; i < mSoRows; i++)
                    {
                        if ((bool)(dtNhom.Rows[i]["Chon"]))
                        {
                            pHT_UserGroupInfo.HT_UserGroupID = int.Parse(dtNhom.Rows[i]["HT_UserGroupID"].ToString());
                            try
                            {
                                oBHT_UserGroup.Delete(pHT_UserGroupInfo);
                                mCheck = 1;
                                dtNhom.Rows.Remove(dtNhom.Rows[i]);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ShowButton(false);
        }

        // xu ly chuot phai
        private void barbtnQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvNhomND.FocusedRowHandle >= 0)
            {
                dlgChucNang dlg = new dlgChucNang(0, int.Parse(grvNhomND.GetDataRow(grvNhomND.FocusedRowHandle)["HT_UserGroupID"].ToString()));
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    GetNhomNguoiDung_Quyen(pHT_UserGroupInfo.HT_UserGroupID);
                }
            }
        }

        private void barbtnThemNhomND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnThemNhom_ItemClick(null, null);
        }

        private void barbtnSuaNhomND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnSuaNhom_ItemClick(null, null);
        }

        private void barbtnXoaNhomND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnXoaNhom_ItemClick(null, null);
        }
        // xu ly chuot phai
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenNhom.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenNhom, "Tên nhóm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenNhom;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void grvNhomND_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNhomND.FocusedRowHandle >= 0)
            {
                Idx = grvNhomND.FocusedRowHandle;
                pHT_UserGroupInfo.HT_UserGroupID = int.Parse(grvNhomND.GetDataRow(grvNhomND.FocusedRowHandle)["HT_UserGroupID"].ToString());
                pHT_UserGroupInfo.TenNhom = grvNhomND.GetDataRow(grvNhomND.FocusedRowHandle)["TenNhom"].ToString();
                 GetNhomNguoiDung_Quyen(pHT_UserGroupInfo.HT_UserGroupID); 
            }
        }   
    
        private void grdNhomND_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdNhomND.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }
    }
}