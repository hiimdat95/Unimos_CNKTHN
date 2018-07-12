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
    public partial class frmNhapHocLai : frmBase
    {
      
        private cBDM_Lop oBDM_Lop;
        private cBSV_NhapHocLai oBSV_NhapHocLai;
        private SV_NhapHocLaiInfo pSV_NhapHocLaiInfo;
        private DataTable dtChuaNhapHoc, dtDaNhapHoc;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataRow drNhapHoc;
        private int IDDM_Lop;

        public frmNhapHocLai()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_NhapHocLai = new cBSV_NhapHocLai();
            pSV_NhapHocLaiInfo = new SV_NhapHocLaiInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
        }
        private void frmNhapHocLai_Load(object sender, EventArgs e)
        {
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(new DM_LopInfo(), Program.NamHoc);
            repositoryTrangThai.DataSource = oBSV_SinhVien.CreateTableTrangThai();
            dtChuaNhapHoc = oBSV_NhapHocLai.GetSinhVien_ChuaNhapHoc();
            grdDanhSach.DataSource = dtChuaNhapHoc;
        }
        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                IDDM_Lop = int.Parse(cmbLop.EditValue.ToString());
                dtDaNhapHoc = oBSV_NhapHocLai.GetSinhVien(IDDM_Lop);
                grdNhapHoc.DataSource = dtDaNhapHoc;
            }
        }
        private void grvNhapHoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdNhapHoc.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }
        private void grvNhapHoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtChuaNhapHoc.Rows.Count;
            if (cmbLop.EditValue != null)
            {
                DataRow[] dr = dtChuaNhapHoc.Select("Chon=1");
                if (dr.Length > 0)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if ((bool)dtChuaNhapHoc.Rows[i]["Chon"])
                        {
                            dtChuaNhapHoc.Rows[i]["Chon"] = false;
                            dtChuaNhapHoc.Rows[i]["IDDM_LopMoi"] = IDDM_Lop;
                            dtChuaNhapHoc.Rows[i]["TenNamHoc"] = Program.NamHoc;
                            // add
                            pSV_NhapHocLaiInfo.HocKy = Program.HocKy;
                            pSV_NhapHocLaiInfo.IDDM_LopCu = int.Parse(dtChuaNhapHoc.Rows[i]["IDDM_LopCu"].ToString());
                            pSV_NhapHocLaiInfo.IDDM_LopMoi = IDDM_Lop;
                            pSV_NhapHocLaiInfo.IDDM_NamHoc = Program.IDNamHoc;
                            pSV_NhapHocLaiInfo.IDSV_SinhVien = int.Parse(dtChuaNhapHoc.Rows[i]["SV_SinhVienID"].ToString());
                            dtChuaNhapHoc.Rows[i]["SV_NhapHocLaiID"] = oBSV_NhapHocLai.Add(pSV_NhapHocLaiInfo);
                            //
                            dtDaNhapHoc.ImportRow(dtChuaNhapHoc.Rows[i]);
                            dtChuaNhapHoc.Rows.Remove(dtChuaNhapHoc.Rows[i]);
                            Count = Count - 1;
                            i = i - 1;
                        }
                    }
                }
                else
                    ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
            }
            else
                ThongBao("Bạn chưa chọn lớp nhập học lại!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtDaNhapHoc.Rows.Count;
            DataRow[] dr = dtDaNhapHoc.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                    {
                        if ((bool)dtDaNhapHoc.Rows[i]["Chon"])
                        {
                            dtDaNhapHoc.Rows[i]["Chon"] = false;
                            try
                            {
                                pSV_NhapHocLaiInfo.SV_NhapHocLaiID = int.Parse(dtDaNhapHoc.Rows[i]["SV_NhapHocLaiID"].ToString());
                                oBSV_NhapHocLai.Delete(pSV_NhapHocLaiInfo);

                            }
                            catch { }
                            dtChuaNhapHoc.ImportRow(dtDaNhapHoc.Rows[i]);
                            dtDaNhapHoc.Rows.Remove(dtDaNhapHoc.Rows[i]);
                            Count = Count - 1;
                            i = i - 1;
                        }
                    }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void barbtnAnhXaMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgAnhXaMonHoc dlg = new dlgAnhXaMonHoc(drNhapHoc, cmbLop.Text);
            dlg.ShowDialog();
        }

        private void grvNhapHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNhapHoc.FocusedRowHandle >= 0)
            {
                drNhapHoc = grvNhapHoc.GetDataRow(grvNhapHoc.FocusedRowHandle);
            }
        }

    }
}