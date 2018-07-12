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
using DevExpress.XtraGrid.Views.Base;

namespace UnimOs.UI 
{
    public partial class frmNhapDiemTongKet : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private cBKQHT_DiemMonThiTotNghiep oBKQHT_DiemMonThiTotNghiep;
        private KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo;
        private DataTable dtMonKy, dtSinhVien, dtMonThiTotNghiep, dtXLMonHoc;
        private int IDDM_Lop = 0;

        public frmNhapDiemTongKet()
        {
            InitializeComponent();

            // Check quyền để cho phép hay không cho phép thực hiện thao tạc lưu dữ liệu
            SetQuyen(this, "" + this.Tag);

            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
            oBKQHT_DiemMonThiTotNghiep = new cBKQHT_DiemMonThiTotNghiep();

            dtXLMonHoc = (new cBKQHT_XepLoaiMonHoc()).Get(new KQHT_XepLoaiMonHocInfo());
        }

        private void frmNhapDiemTongKet_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                if (chkTotNghiep.Checked == false)
                    LoadMonKy();
                else
                    LoadMonThiTotNghiep();
            }
        }
        
        private void grvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
       
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                if (!chkTotNghiep.Checked)
                {
                    pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                    pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                    pKQHT_DiemTongKetMonInfo.LyDo = "";
                    pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString());

                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        try
                        {
                            pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            // Diem lan 1
                            if ("" + dr["Diem"] != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr["Diem"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = 1;
                                oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                            }
                            // Diem lan 2
                            if ("" + dr["DiemLan2"] != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr["DiemLan2"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = 2;
                                oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                            }
                        }
                        catch
                        {
                            // error
                        }
                    }
                }
                else
                {
                    //pKQHT_DiemMonThiTotNghiepInfo = new KQHT_DiemMonThiTotNghiepInfo();
                    //pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop = int.Parse(cmbMonHoc.GetColumnValue("KQHT_MonThiTotNghiep_LopID").ToString());
                    //foreach (DataRow dr in dtTemp.Rows)
                    //{
                    //    try
                    //    {
                    //        pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    //        // Diem lan 1
                    //        if ("" + dr["Diem"] != "")
                    //        {
                    //            pKQHT_DiemMonThiTotNghiepInfo.Diem = double.Parse(dr["Diem"].ToString());
                    //            pKQHT_DiemMonThiTotNghiepInfo.LanThi = 1;
                    //            pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai = XepLoaiMonHoc(pKQHT_DiemMonThiTotNghiepInfo.Diem);
                    //            oBKQHT_DiemMonThiTotNghiep.AddUpdate(pKQHT_DiemMonThiTotNghiepInfo);
                    //        }
                    //        // Diem lan 2
                    //        if ("" + dr["DiemLan2"] != "")
                    //        {
                    //            pKQHT_DiemMonThiTotNghiepInfo.Diem = double.Parse(dr["DiemLan2"].ToString());
                    //            pKQHT_DiemMonThiTotNghiepInfo.LanThi = 2;
                    //            pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai = XepLoaiMonHoc(pKQHT_DiemMonThiTotNghiepInfo.Diem);
                    //            oBKQHT_DiemMonThiTotNghiep.AddUpdate(pKQHT_DiemMonThiTotNghiepInfo);
                    //        }
                    //    }
                    //    catch
                    //    { }
                    //}
                    ThongBao("Để nhập điểm thi tốt nghiệp bạn dùng chức năng 'Tổng hợp xét duyết/Nhập điểm thi tốt nghiệp'");
                    return;
                }
                ThongBao("Cập nhật thành công!");
                LoadSinhVien();
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        public int XepLoaiMonHoc(double Diem)
        {
            foreach (DataRow dr in dtXLMonHoc.Rows)
            {
                if (Diem >= double.Parse("0" + dr["TuDiem"]))
                    return int.Parse(dr["KQHT_XepLoaiMonHocID"].ToString());
            }
            return 0;
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien();
            }
        }

        private void LoadSinhVien()
        {
            if (!chkTotNghiep.Checked)
            {
                if (cmbLanThi.EditValue.ToString() == "1")
                    dtSinhVien = oBKQHT_DiemTongKetMon.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc,
                                        Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()), 0);
                else if (rdgTuDanhSach.SelectedIndex == 0)
                    dtSinhVien = oBKQHT_DiemTongKetMon.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc,
                                       Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()), 0);
                else
                    dtSinhVien = oBKQHT_DiemTongKetMon.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc,
                                       Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()), 1);
            }
            else
                dtSinhVien = oBKQHT_DiemMonThiTotNghiep.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.GetColumnValue("KQHT_MonThiTotNghiep_LopID").ToString()), 1);

            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
        }
        
        private void LoadMonKy()
        {
            dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            cmbMonHoc.Properties.DataSource = dtMonKy;
            if ((dtMonKy != null) && (dtMonKy.Rows.Count > 0))
            {
                cmbMonHoc.ItemIndex = 0;
                LoadSinhVien();
            }
            else
            {
                cmbMonHoc.EditValue = null;
                if (dtSinhVien != null)
                {
                    dtSinhVien.Clear();
                }
            }
        }

        private void LoadMonThiTotNghiep()
        {
            dtMonThiTotNghiep = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_Lop);
            cmbMonHoc.Properties.DataSource = dtMonThiTotNghiep;
            if ((dtMonThiTotNghiep != null) && (dtMonThiTotNghiep.Rows.Count > 0))
            {
                cmbMonHoc.ItemIndex = 0;
                LoadSinhVien();
            }
            else
            {
                cmbMonHoc.EditValue = null;
                if (dtSinhVien != null)
                {
                    dtSinhVien.Clear();
                }
            }
        }

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanThi.SelectedIndex > 0)
                rdgTuDanhSach.Enabled = true;
            else
                rdgTuDanhSach.Enabled = false;
            LoadSinhVien();
        }

        private void chkTotNghiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotNghiep.Checked == true)
            {
                LoadMonThiTotNghiep();
            }
            else
            {
                LoadMonKy();
            }
        }

        private void rdgTuDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
           LoadSinhVien();
        }

        private void grvDiem_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
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
                    float diem;
                    if (float.TryParse(e.Value.ToString(), out diem))
                    {
                        if (diem < 0 || diem > 10)
                        {
                            e.Valid = false;
                            e.ErrorText = "Dữ liệu điểm nhập vào phải từ 0 đến 10.";
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

        private void grvDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnXoa_Click(null, null);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!chkTotNghiep.Checked)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                {
                    int[] RowIndex = grvDiem.GetSelectedRows();
                    long IDXL_MonHocTrongKy = long.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString());
                    for (int i = 0; i < RowIndex.Length; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn[] GridCols = grvDiem.GetSelectedCells(RowIndex[i]);
                        for (int j = 0; j < GridCols.Length; j++)
                        {
                            if (GridCols[j].Name == "grcDiemL1" || GridCols[j].Name == "grcDiemL2")
                            {
                                try
                                {
                                    oBKQHT_DiemTongKetMon.DeleteByIDMonHocTrongKy(int.Parse(grvDiem.GetDataRow(RowIndex[i])["SV_SinhVienID"].ToString()),
                                        IDXL_MonHocTrongKy, int.Parse(GridCols[j].Name.Substring(8)));
                                }
                                catch { }
                            }
                        }
                    }
                    LoadSinhVien();
                }
            }
        }

    }
}