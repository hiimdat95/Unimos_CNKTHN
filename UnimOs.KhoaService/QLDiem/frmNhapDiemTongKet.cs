using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraGrid.Views.Base;

namespace UnimOs.Khoa 
{
    public partial class frmNhapDiemTongKet : frmBase
    {
        private cBwsDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBwsXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBwsKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBwsKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private cBwsKQHT_DaChuyenDiem oBKQHT_DaChuyenDiem;
        private DataTable dtMonHoc, dtSinhVien, dtXLMonHoc;
        private DataRow drMonHoc;
        private int IDDM_MonHoc, IDXL_MonHocTrongKy;
        private bool IsGiaoVuNhapDiem, IsLoadMonNhapDiem = false;

        public frmNhapDiemTongKet()
        {
            InitializeComponent();
            oBDM_Lop = new cBwsDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBXL_MonHocTrongKy = new cBwsXL_MonHocTrongKy();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemTongKetMon = new cBwsKQHT_DiemTongKetMon();
            oBKQHT_MonThiTotNghiep_Lop = new cBwsKQHT_MonThiTotNghiep_Lop();
            oBKQHT_DaChuyenDiem = new cBwsKQHT_DaChuyenDiem();
        }

        private void frmNhapDiemTongKet_Load(object sender, EventArgs e)
        {
            cBwsHT_ThamSoHeThong oBThamSo = new cBwsHT_ThamSoHeThong();
            IsGiaoVuNhapDiem = oBThamSo.GetGiaTriByMaThamSo("GiaoVuNhapDiem") == "1" ? true : false;
            if ((Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0 || Program.objUserCurrent.Username == "giaovu") && !IsGiaoVuNhapDiem)
            {
                grvDiem.OptionsBehavior.Editable = false;
                SetButton(false);
            }
            dtXLMonHoc = (new cBwsKQHT_XepLoaiMonHoc()).Get(new KQHT_XepLoaiMonHocInfo());
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            IsLoadMonNhapDiem = false;
            LoadMonHocNhapDiem();
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void SetButton(bool status)
        {
            btnCapNhat.Enabled = status;
            btnChuyenDiem.Enabled = status;
        }

        private void LoadMonHocNhapDiem()
        {
            if (Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0)
                dtMonHoc = oBXL_MonHocTrongKy.GetByLopKhoa(pDM_LopInfo.DM_LopID, Program.objUserCurrent.IDDM_Khoa_GiaoVu, Program.IDNamHoc, Program.HocKy);
            else
                dtMonHoc = oBXL_MonHocTrongKy.GetByIDGiaoVien(Program.objUserCurrent.NS_GiaoVienID, pDM_LopInfo.DM_LopID, Program.HocKy, Program.IDNamHoc);

            grdMonHoc.DataSource = dtMonHoc;
            IsLoadMonNhapDiem = true;
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
                pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = IDDM_MonHoc;
                pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                pKQHT_DiemTongKetMonInfo.LyDo = "";

                foreach (DataRow dr in dtTemp.Rows)
                {
                    try
                    {
                        pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        // Diem lan 1
                        if(!chkThiLan1.Checked)
                            if ("" + dr["Diem"] != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr["Diem"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = 1;
                                pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = oBKQHT_DiemTongKetMon.XepLoaiMonHoc(dtXLMonHoc, pKQHT_DiemTongKetMonInfo.Diem);
                                oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                            }
                        // Diem lan 2
                        if(!chkThiLan2.Checked)
                            if ("" + dr["DiemLan2"] != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr["DiemLan2"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = 2;
                                pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = oBKQHT_DiemTongKetMon.XepLoaiMonHoc(dtXLMonHoc, pKQHT_DiemTongKetMonInfo.Diem);
                                oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                            }
                    }
                    catch
                    {
                        // error
                    }
                }
                ThongBao("Cập nhật thành công!");
                LoadSinhVien();
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private void LoadSinhVien()
        {
            if (!chkNhapDiemLan2.Checked)
                dtSinhVien = oBKQHT_DiemTongKetMon.GetDanhSachNhapDiem(pDM_LopInfo.DM_LopID, IDDM_MonHoc,
                    IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy, 1);
            else
                dtSinhVien = oBKQHT_DiemTongKetMon.GetDanhSachNhapDiem(pDM_LopInfo.DM_LopID, IDDM_MonHoc,
                    IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy, 2);

            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
        }
        
        private void grvDiem_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString().Trim() == "")
                {
                    if ("" + grvDiem.GetDataRow(grvDiem.FocusedRowHandle)[grvDiem.FocusedColumn.FieldName] != "")
                    {
                        e.Valid = false;
                        e.ErrorText = "Nếu muốn xóa bạn phải bấm phím Delete.";
                    }
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
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                {
                    int[] RowIndex = grvDiem.GetSelectedRows();
                    for (int i = 0; i < RowIndex.Length; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn[] GridCols = grvDiem.GetSelectedCells(RowIndex[i]);
                        for (int j = 0; j < GridCols.Length; j++)
                        {
                            if (GridCols[j].Name == "grcDiemLan1" || GridCols[j].Name == "grcDiemLan2")
                            {
                                try
                                {
                                    oBKQHT_DiemTongKetMon.DeleteByIDMonHocTrongKy(int.Parse(grvDiem.GetDataRow(RowIndex[i])["SV_SinhVienID"].ToString()),
                                        IDXL_MonHocTrongKy, int.Parse(GridCols[j].Name.Substring(10)));
                                }
                                catch { }
                            }
                        }
                    }
                    LoadSinhVien();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.GetChanges() != null)
            {
                if (ThongBaoChon("Dữ liệu đã thay đổi. Bạn có thực sự muốn thoát không?") != DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        private void grvMonHoc_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (!IsLoadMonNhapDiem)
                return;
            //chkNhapDiemLan2.Checked = false;
            if (grvMonHoc.FocusedRowHandle >= 0)
            {
                drMonHoc = grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle);
                IDDM_MonHoc = int.Parse(drMonHoc["DM_MonHocID"].ToString());
                IDXL_MonHocTrongKy = int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString());
                DataTable dtDaChuyenDiem = oBKQHT_DaChuyenDiem.GetByIDMonHocTrongKy(IDXL_MonHocTrongKy);
                if (dtDaChuyenDiem.Rows.Count > 0)
                {
                    chkThiLan1.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThiL1"].ToString());
                    chkThiLan2.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThiL2"].ToString());
                }
                else
                {
                    chkThiLan1.Checked = false;
                    chkThiLan2.Checked = false;
                }
            }
            else
            {
                drMonHoc = null;
                IDDM_MonHoc = 0;
                IDXL_MonHocTrongKy = 0;
            }
            LoadSinhVien();
            //chkDiemThanhPhan_CheckedChanged(null, null);
        }

        private void chkNhapDiemLan2_CheckedChanged(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void chkThiLan1_CheckedChanged(object sender, EventArgs e)
        {
            grcDiemLan1.OptionsColumn.AllowEdit = !chkThiLan1.Checked;
        }

        private void chkThiLan2_CheckedChanged(object sender, EventArgs e)
        {
            grcDiemLan2.OptionsColumn.AllowEdit = !chkThiLan2.Checked;
        }

        private void btnChuyenDiem_Click(object sender, EventArgs e)
        {
            if ((!chkNhapDiemLan2.Checked && chkThiLan1.Checked) || (chkNhapDiemLan2.Checked && chkThiLan2.Checked))
            {
                ThongBao("Dữ liệu điểm đã được chuyển, bạn không thể chuyển tiếp.");
                return;
            }
            if (grvMonHoc.DataSource == null)
                return;
            if (dtSinhVien.GetChanges() != null)
            {
                btnCapNhat_Click(null, null);
            }

            KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo = new KQHT_DaChuyenDiemInfo();
            pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;

            if (!chkNhapDiemLan2.Checked)
            {
                pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = true;
                pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1 = Program.objUserCurrent.NS_GiaoVienID;
            }
            else
            {
                pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = true;
                pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2 = Program.objUserCurrent.NS_GiaoVienID;
            }
            try
            {
                oBKQHT_DaChuyenDiem.AddChuyen(pKQHT_DaChuyenDiemInfo);
                grvMonHoc_FocusedRowChanged(null, null);
                ThongBao("Đã chuyển điểm thành công.");
            }
            catch (Exception ex)
            {
                ThongBaoLoi("Có lỗi khi lưu:\n" + ex.Message);
            }
        }
    }
}