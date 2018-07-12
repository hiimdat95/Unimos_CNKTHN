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
    public partial class frmDanhSachHocBong_ChamCong : frmBase
    {
        private cBTC_DanhSachHocBong oBTC_DanhSachHocBong;
        private TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo;
        private cBTC_DanhSachHocBong_ChiTiet oBTC_DanhSachHocBong_ChiTiet;
        private TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien, dtThang;
        private bool Loaded = false;

        public frmDanhSachHocBong_ChamCong()
        {
            InitializeComponent();
            
            pTC_DanhSachHocBongInfo = new TC_DanhSachHocBongInfo();
            oBTC_DanhSachHocBong = new cBTC_DanhSachHocBong();
            oBTC_DanhSachHocBong_ChiTiet = new cBTC_DanhSachHocBong_ChiTiet();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmDanhSachHocBong_ChamCong_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                if (pDM_LopInfo.DM_LopID > 0)
                    grcLop.Visible = false;
                else
                    grcLop.Visible = true;

                dtThang = oBTC_DanhSachHocBong.GetThangInSinhVien(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, Program.NamHoc);
                cmbThang.Properties.DataSource = dtThang;
                if (dtThang.Rows.Count > 0)
                    cmbThang.ItemIndex = 0;
                Loaded = false;
                cmbThang_EditValueChanged(null, null);
            }
            else
            {
                cmbThang.Properties.DataSource = null;
                grdHocBong.DataSource = null;
            }
        }

        private void cmbThang_EditValueChanged(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                if (cmbThang.EditValue != null)
                {
                    dtSinhVien = oBTC_DanhSachHocBong.GetInSinhVienByKyTruoc(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, Program.NamHoc, int.Parse(cmbThang.EditValue.ToString()));
                    string HoDem = "";
                    foreach (DataRow dr in dtSinhVien.Rows)
                    {
                        dr["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                        dr["HoVa"] = HoDem;
                    }
                    grdHocBong.DataSource = dtSinhVien;
                    dtSinhVien.AcceptChanges();
                }
                else
                    grdHocBong.DataSource = null;

                Loaded = true;
            }
        }

        private void grvHocBong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvHocBong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string FieldChange = e.Column.FieldName;
            DataRow dr = grvHocBong.GetDataRow(e.RowHandle);
            if (FieldChange == "SoNgayThieuCong")
            {
                dr["SoTienThieuCong"] = double.Parse("0" + dr["SoNgayThieuCong"]) * double.Parse("0" + txtSoTienNgay.Text);
            }
            dr["SoTienConLai"] = double.Parse(dr["SoTien"].ToString()) - double.Parse("0" + dr["SoTienThieuCong"].ToString());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(dtSinhVien==null||dtSinhVien.Rows.Count<=0)
                return;
            DataTable dtChange = dtSinhVien.GetChanges();
            if (dtChange == null)
                return;
            foreach (DataRow dr in dtChange.Rows)
            {
                try
                {
                    pTC_DanhSachHocBong_ChiTietInfo = new TC_DanhSachHocBong_ChiTietInfo();
                    pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID = int.Parse(dr["TC_DanhSachHocBong_ChiTietID"].ToString());
                    if ("" + dr["SoNgayThieuCong"] != "")
                        pTC_DanhSachHocBong_ChiTietInfo.SoNgayThieuCong = int.Parse(dr["SoNgayThieuCong"].ToString());
                    if ("" + dr["SoTienThieuCong"] != "")
                        pTC_DanhSachHocBong_ChiTietInfo.SoTienThieuCong = int.Parse(dr["SoTienThieuCong"].ToString());
                    pTC_DanhSachHocBong_ChiTietInfo.GhiChu = "" + dr["GhiChu"];
                    oBTC_DanhSachHocBong_ChiTiet.UpdateThieuCong(pTC_DanhSachHocBong_ChiTietInfo);
                }
                catch
                { }
            }
            LuuThanhCong();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvHocBong_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (grvHocBong.FocusedColumn.FieldName == "SoNgayThieuCong" || grvHocBong.FocusedColumn.FieldName == "SoTienThieuCong")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Trim() == "")
                    {
                        e.Value = null;
                        e.Valid = true;
                    }
                    else
                    {
                        double result;
                        if (double.TryParse(e.Value.ToString(), out result))
                        {
                            if (result < 0)
                            {
                                e.Valid = false;
                                e.ErrorText = "Dữ liệu nhập vào phải dương.";
                            }
                        }
                        else
                        {
                            e.Valid = false;
                            e.ErrorText = "Dữ liệu điểm nhập vào phải là kiểu số.";
                        }
                    }
                }
            }
            else
                e.Valid = true;
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            dlgLopFilter dlg = new dlgLopFilter();
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                DM_LopInfo pDM_LopFilterInfo = dlg.pDM_LopInfo;
                DataTable dtMain = oBTC_DanhSachHocBong.GetInSinhVienByKyTruoc(pDM_LopFilterInfo, Program.IDNamHoc, 
                    Program.HocKy, Program.NamHoc, int.Parse(cmbThang.Text));
                if (dtMain.Rows.Count > 0)
                {
                    dtMain.Columns.Add("Thang", typeof(string));
                    dtMain.Columns.Add("TenNam", typeof(string));
                    dtMain.Columns.Add("HeTrinhDo", typeof(string));
                    dtMain.Columns.Add("TongTienBangChu", typeof(string));
                    dtMain.Rows[0]["Thang"] = cmbThang.Text;
                    if (7 <= int.Parse(cmbThang.Text) && int.Parse(cmbThang.Text) <= 12)
                        dtMain.Rows[0]["TenNam"] = Program.NamHoc.Substring(0, 4);
                    else
                        dtMain.Rows[0]["TenNam"] = Program.NamHoc.Substring(5);
                    double SoTien = double.Parse(dtMain.Compute("Sum(SoTienConLai)", "").ToString());
                    Lib.clsStringHelper cls = new Lib.clsStringHelper();
                    dtMain.Rows[dtMain.Rows.Count - 1]["TongTienBangChu"] = cls.ReadMoney(SoTien);

                    dtMain.Rows[0]["HeTrinhDo"] = dlg.HeTrinhDo;
                    frmReport frm = new frmReport(dtMain, dtMain, "rDanhSachHocBong_ChiTiet", "rDanhSachHocBong_BangKe", new string[] { "Subreport1" });
                    frm.ShowDialog();
                }
                else
                    ThongBao("Không có dữ liệu để in báo cáo!");
            }
        }
    }
}