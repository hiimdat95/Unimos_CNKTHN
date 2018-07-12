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
using DevExpress.XtraTreeList;

namespace UnimOs.UI
{
    public partial class dlgThemChucNang : frmBase
    {
        private DataTable dtChucNang;
        private int HT_ChucNangID;
        private EDIT_MODE edit;
        private DataRow[] dr;
        private cBHT_ChucNang oBHT_ChucNang;
        private HT_ChucNangInfo pHT_ChucNangInfo;
        private TreeList trlChucNang;

        public dlgThemChucNang(TreeList mtrlChucNang, DataTable mdtChucNang, int mHT_ChucNangID, EDIT_MODE mEdit)
        {
            InitializeComponent();
            oBHT_ChucNang = new cBHT_ChucNang();
            pHT_ChucNangInfo = new HT_ChucNangInfo();
            trlChucNang = mtrlChucNang;
            dtChucNang = mdtChucNang;
            HT_ChucNangID = mHT_ChucNangID;
            edit = mEdit;
        }

        private void dlgThemChucNang_Load(object sender, EventArgs e)
        {
            LoadPhanHe();
            cmbKieuRibbon.Properties.DataSource = KieuRibbon();
            cmbParent.Properties.DataSource = dtChucNang;
            if (edit == EDIT_MODE.SUA)
                SetText();
            else
                if (HT_ChucNangID > 0 && dtChucNang.Rows.Count > 0)
                {
                    cmbParent.EditValue = HT_ChucNangID;
                    dr = dtChucNang.Select("HT_ChucNangID = " + HT_ChucNangID.ToString());
                    if (dr.Length > 0)
                        cmbPhanHe.EditValue = "" + dr[0]["IDHT_PhanHe"] == "" ? -1 : int.Parse(dr[0]["IDHT_PhanHe"].ToString());
                }
            txtTenChucNang.Focus();
        }

        private void LoadPhanHe()
        {
            cBHT_PhanHe oBHT_PhanHe = new cBHT_PhanHe();
            HT_PhanHeInfo pHT_PhanHeInfo = new HT_PhanHeInfo();
            pHT_PhanHeInfo.HT_PhanHeID = 0;
            DataTable dt = oBHT_PhanHe.Get(pHT_PhanHeInfo);
            cmbPhanHe.Properties.DataSource = dt;
            if (dt.Rows.Count > 0)
                cmbPhanHe.ItemIndex = 0;
        }

        private void SetText()
        {
            dr = dtChucNang.Select("HT_ChucNangID = " + HT_ChucNangID.ToString());
            if (dr.Length > 0)
            {
                pHT_ChucNangInfo.HT_ChucNangID = HT_ChucNangID;
                txtbarbutton.Text = dr[0]["barbtnName"].ToString();
                txtTenChucNang.Text = dr[0]["TenChucNang"].ToString();
                txtTenForm.Text = dr[0]["Tag"].ToString();
                mtxtMoTa.Text = dr[0]["MoTa"].ToString();
                cmbPhanHe.EditValue = "" + dr[0]["IDHT_PhanHe"] == "" ? -1 : int.Parse(dr[0]["IDHT_PhanHe"].ToString());
                cmbParent.EditValue = "" + dr[0]["ParentID"] == "" ? -1 : int.Parse(dr[0]["ParentID"].ToString());
                if ("" + dr[0]["KieuRibbon"] != "")
                    cmbKieuRibbon.EditValue = dr[0]["KieuRibbon"].ToString();
                txtbtnThem.Text = "" + dr[0]["btnThem"];
                txtbtnSua.Text = "" + dr[0]["btnSua"];
                txtbtnXoa.Text = "" + dr[0]["btnXoa"];
            }
        }

        private void GetText()
        {
            pHT_ChucNangInfo.TenChucNang = txtTenChucNang.Text.Trim();
            pHT_ChucNangInfo.Tag = txtTenForm.Text.Trim();
            pHT_ChucNangInfo.IDHT_PhanHe = int.Parse(cmbPhanHe.EditValue.ToString());
            pHT_ChucNangInfo.ParentID = cmbParent.EditValue.ToString() == "-1" ? 0 : int.Parse(cmbParent.EditValue.ToString());
            pHT_ChucNangInfo.MoTa = mtxtMoTa.Text.Trim();
            pHT_ChucNangInfo.barbtnName = txtbarbutton.Text.Trim();
            if (pHT_ChucNangInfo.ParentID == 0)
                pHT_ChucNangInfo.Level = 1;
            else
                pHT_ChucNangInfo.Level = int.Parse(cmbParent.GetColumnValue("Level").ToString()) + 1;
            pHT_ChucNangInfo.KieuRibbon = cmbKieuRibbon.ItemIndex > -1 ? cmbKieuRibbon.EditValue.ToString() : "";
            pHT_ChucNangInfo.btnThem = txtbtnThem.Text;
            pHT_ChucNangInfo.btnSua = txtbtnSua.Text;
            pHT_ChucNangInfo.btnXoa = txtbtnXoa.Text;
        }

        private void ClearText()
        {
            txtTenChucNang.Text = "";
            txtTenForm.Text = "";
            txtbarbutton.Text = "";
            txtTenChucNang.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenChucNang.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChucNang, "Tên chức năng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenChucNang;
            }
            if (cmbPhanHe.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbPhanHe, "Bạn chưa chọn phân hệ.");
                if (CtrlErr == null) CtrlErr = cmbPhanHe;
            }

            // Kiểm tra thông tin thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            //if (dr.Length > 0)
            //    oBHT_ChucNang.ToInfo(ref pHT_ChucNangInfo, dr[0]);
            GetText();
            
            if (edit == EDIT_MODE.THEM)
            {
                pHT_ChucNangInfo.HT_ChucNangID = oBHT_ChucNang.Add(pHT_ChucNangInfo);

                DataView dv = new DataView(dtChucNang);
                dv.Sort = "ID Desc";
                int ID = int.Parse(dv[0]["ID"].ToString()) + 1;

                DataRow drNew = dtChucNang.NewRow();
                oBHT_ChucNang.ToDataRow(pHT_ChucNangInfo, ref drNew);
                drNew["ID"] = ID;
                
                // Thêm phần tử với vào datatable
                // Nếu ParentID = 0
                if (pHT_ChucNangInfo.ParentID == 0)
                    drNew["ParentIDs"] = 0;
                else
                    drNew["ParentIDs"] = int.Parse(cmbParent.GetColumnValue("ID").ToString());

                dtChucNang.Rows.Add(drNew);

                dtChucNang.AcceptChanges();
                trlChucNang.RefreshDataSource();

                ClearText();
            }
            else
            {
                oBHT_ChucNang.Update(pHT_ChucNangInfo);
                if (cmbParent.ItemIndex == -1)
                    dr[0]["ParentIDs"] = 0;
                else
                    dr[0]["ParentIDs"] = int.Parse(cmbParent.GetColumnValue("ID").ToString());
                oBHT_ChucNang.ToDataRow(pHT_ChucNangInfo, ref dr[0]);
                dtChucNang.AcceptChanges();
                trlChucNang.RefreshDataSource();
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbParent.EditValue = -1;
        }
    }
}