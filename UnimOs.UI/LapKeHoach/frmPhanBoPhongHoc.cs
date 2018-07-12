using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmPhanBoPhongHoc : frmBase
    {
        cBDM_PhongHoc oBDM_PhongHoc;
        cBDM_Lop oBDM_Lop;
        cBXL_Tuan oBXL_Tuan;
        cBXL_KeHoachTruong oBXL_KeHoachToanTruong;
        DataTable dtTuan;
        private int IDDM_PhongHoc, rowIndex, SucChua;
        private string TenPhongHoc;
        DataTable dtLop;
        bool frmLoad = false;

        public frmPhanBoPhongHoc()
        {
            InitializeComponent();
            oBDM_PhongHoc = new cBDM_PhongHoc();
            oBDM_Lop = new cBDM_Lop();
            oBXL_Tuan= new cBXL_Tuan ();
            oBXL_KeHoachToanTruong = new cBXL_KeHoachTruong();
            txtNamHoc.Text = Program.NamHoc;
         // load combobox
            dtTuan = oBXL_Tuan.GetByHocKy_NamHoc(Program.IDNamHoc, Program.HocKy);
            cmbTuTuan.Properties.DataSource = dtTuan;           
            cmbDenTuan.Properties.DataSource = dtTuan;
        }
        private void LoadGrid()
        {

            dtLop = oBDM_Lop.GetPhanBoPhongHoc(Program.IDNamHoc, Program.NamHoc, Program.HocKy, int.Parse(rdCaHoc.EditValue.ToString()), 0,0);
            grdLop.DataSource = dtLop;

            grdPhongHoc.DataSource = oBDM_PhongHoc.Get_TKB();
        }
        private void frmPhanBoPhongHoc_Load(object sender, EventArgs e)
        {
            LoadGrid();
            frmLoad = true;
        }

        private void grdPhongHoc_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (IDDM_PhongHoc > 0)
                    {
                        grdPhongHoc.DoDragDrop(sender, DragDropEffects.Copy);
                    }
                }
            }

            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grdPhongHoc_DragOver(object sender, DragEventArgs e)
        {
            if (IDDM_PhongHoc > 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void grdLop_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                GridHitInfo hi = grvLop.CalcHitInfo(grdLop.PointToClient(new Point(e.X, e.Y)));
                if (hi.InRow)
                {
                    e.Effect = DragDropEffects.Copy;
                    rowIndex = hi.RowHandle;
                    long IDXL_TuTuan = 0, IDXL_DenTuan = 0;
                    if (rdApDung.EditValue.ToString() == "0")
                    {
                        // ap dung cho tat ca cac tuan
                        IDXL_TuTuan = long.Parse(dtTuan.Rows[0]["XL_TuanID"].ToString());
                        IDXL_DenTuan = long.Parse(dtTuan.Rows[dtTuan.Rows.Count - 1]["XL_TuanID"].ToString());
                    }
                    else
                    {
                        // ap dung cho cac tuan duoc chon
                        IDXL_TuTuan = cmbTuTuan.EditValue == null ? 0 : long.Parse(cmbTuTuan.EditValue.ToString());
                        IDXL_DenTuan = cmbDenTuan.EditValue == null ? long.Parse(dtTuan.Rows[dtTuan.Rows.Count - 1]["XL_TuanID"].ToString()) : long.Parse(cmbDenTuan.EditValue.ToString());
                    }
                  
                    if (dtLop.Rows[rowIndex]["TenPhongHoc"].ToString() != "")
                    {
                        if (ThongBaoChon("Bạn có muốn thay thế phòng học cũ?") != DialogResult.Yes)
                            return;
                    }
                    if (SucChua < int.Parse(dtLop.Rows[rowIndex]["SoSinhVien"].ToString()))
                    {
                        if (ThongBaoChon("Sức chứa của phòng học không đủ, Bạn vẫn muốn tiếp tục?") != DialogResult.Yes)
                            return;
                    }
                    // kiem tra tinh hop le cua phong hoc duoc chon
                    if (oBXL_KeHoachToanTruong.CheckAddPhongHoc(IDXL_TuTuan, IDXL_DenTuan, IDDM_PhongHoc, int.Parse(dtLop.Rows[rowIndex]["DM_LopID"].ToString()), int.Parse(rdCaHoc.EditValue.ToString())) != 0)
                    {
                        ThongBao("Phòng học đã được sử dụng!");
                        return;
                    }
                    oBXL_KeHoachToanTruong.UpdatePhongHoc(IDXL_TuTuan, IDXL_DenTuan, IDDM_PhongHoc, int.Parse(dtLop.Rows[rowIndex]["DM_LopID"].ToString()));
                    // ghi log
                    GhiLog("Thêm phòng học " + TenPhongHoc + " vào lớp " + dtLop.Rows[rowIndex]["TenLop"].ToString(), "Cập nhật", this.Tag.ToString());

                    dtLop.Rows[rowIndex]["IDDM_PhongHoc"] = IDDM_PhongHoc.ToString();
                    dtLop.Rows[rowIndex]["TenPhongHoc"] = TenPhongHoc;
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grdLop_DragOver(object sender, DragEventArgs e)
        {
            //Lấy thông tin hit
            GridHitInfo hi = grvLop.CalcHitInfo(grdLop.PointToClient(new Point(e.X, e.Y)));
            if (hi.InRow)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void grvPhongHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                // Nếu row đang focus là phong hoc thì cho phép kéo thả
                IDDM_PhongHoc = int.Parse(grvPhongHoc.GetDataRow(e.FocusedRowHandle)["DM_PhongHocID"].ToString());
                TenPhongHoc = grvPhongHoc.GetDataRow(e.FocusedRowHandle)["TenPhongHoc"].ToString();
                SucChua = int.Parse(grvPhongHoc.GetDataRow(e.FocusedRowHandle)["SucChua"].ToString());              
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void cmbTuTuan_EditValueChanged(object sender, EventArgs e)
        {
            if (frmLoad)
            {
                dtLop = oBDM_Lop.GetPhanBoPhongHoc(Program.IDNamHoc, Program.NamHoc, Program.HocKy, int.Parse(rdCaHoc.EditValue.ToString()), cmbTuTuan.EditValue == null ? 0 : int.Parse(cmbTuTuan.EditValue.ToString()), cmbDenTuan.EditValue == null ? 0 : int.Parse(cmbDenTuan.EditValue.ToString()));
                grdLop.DataSource = dtLop;
            }
        }

        private void cmbDenTuan_EditValueChanged(object sender, EventArgs e)
        {
            if (frmLoad)
            {
                dtLop = oBDM_Lop.GetPhanBoPhongHoc(Program.IDNamHoc, Program.NamHoc, Program.HocKy, int.Parse(rdCaHoc.EditValue.ToString()), cmbTuTuan.EditValue == null ? 0 : int.Parse(cmbTuTuan.EditValue.ToString()), cmbDenTuan.EditValue == null ? 0 : int.Parse(cmbDenTuan.EditValue.ToString()));
                grdLop.DataSource = dtLop;
            }
        }

        private void rdCaHoc_EditValueChanged(object sender, EventArgs e)
        {
            dtLop = oBDM_Lop.GetPhanBoPhongHoc(Program.IDNamHoc, Program.NamHoc, Program.HocKy, int.Parse(rdCaHoc.EditValue.ToString()), cmbTuTuan.EditValue == null ? 0 : int.Parse(cmbTuTuan.EditValue.ToString()), cmbDenTuan.EditValue == null ? 0 : int.Parse(cmbDenTuan.EditValue.ToString()));
            grdLop.DataSource = dtLop;
        }

        private void grvLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvLop.DataRowCount > 0 && grvLop.FocusedRowHandle >=0 )
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (grvLop.GetDataRow(grvLop.FocusedRowHandle)["TenPhongHoc"].ToString() != "")
                    {
                        if (ThongBaoChon("Bạn có chắc chắn muốn bỏ phòng khỏi lớp học?") != DialogResult.Yes)
                            return;
                    }
                    long IDXL_TuTuan = 0, IDXL_DenTuan = 0;
                    if (rdApDung.EditValue.ToString() == "0")
                    {
                        // ap dung cho tat ca cac tuan
                        IDXL_TuTuan = long.Parse(dtTuan.Rows[0]["XL_TuanID"].ToString());
                        IDXL_DenTuan = long.Parse(dtTuan.Rows[dtTuan.Rows.Count - 1]["XL_TuanID"].ToString());
                    }
                    else
                    {
                        // ap dung cho cac tuan duoc chon
                        IDXL_TuTuan = cmbTuTuan.EditValue == null ? 0 : long.Parse(cmbTuTuan.EditValue.ToString());
                        IDXL_DenTuan = cmbDenTuan.EditValue == null ? long.Parse(dtTuan.Rows[dtTuan.Rows.Count - 1]["XL_TuanID"].ToString()) : long.Parse(cmbDenTuan.EditValue.ToString());
                    }
                    oBXL_KeHoachToanTruong.UpdatePhongHoc(IDXL_TuTuan, IDXL_DenTuan, 0, int.Parse(grvLop.GetDataRow(grvLop.FocusedRowHandle)["DM_LopID"].ToString()));
                    // ghi log
                    GhiLog("Xóa phòng học " + grvLop.GetDataRow(grvLop.FocusedRowHandle)["TenPhongHoc"].ToString() + " ra khỏi lớp " + grvLop.GetDataRow(grvLop.FocusedRowHandle)["TenLop"].ToString(), "Xóa", this.Tag.ToString());
                    dtLop.Rows[grvLop.FocusedRowHandle]["IDDM_PhongHoc"] = "0";
                    dtLop.Rows[grvLop.FocusedRowHandle]["TenPhongHoc"] = "";
                }
            }
        }
    }
}