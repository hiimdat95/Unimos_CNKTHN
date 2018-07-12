using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class dlgQuyetDinhTotNghiep : frmBase
    {
        private cBKQHT_QuyetDinhTotNghiep_SinhVien oBKQHT_QuyetDinhTotNghiep_SinhVien;
        private cBKQHT_QuyetDinhTotNghiep oBKQHT_QuyetDinhTotNghiep;
        private KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo;
        private KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien;
        private DataRow drQuyetDinh;
        private frmQuyetDinhTotNghiep frmQuyetDinh;
        private frmQuyetDinhTotNghiep_QCNghe frmQuyetDinh_QCNghe;

        public dlgQuyetDinhTotNghiep(frmQuyetDinhTotNghiep _frmQuyetDinh, DataRow _drQuyetDinh)
        {
            InitializeComponent();

            oBKQHT_QuyetDinhTotNghiep = new cBKQHT_QuyetDinhTotNghiep();
            oBKQHT_QuyetDinhTotNghiep_SinhVien = new cBKQHT_QuyetDinhTotNghiep_SinhVien();
            pKQHT_QuyetDinhTotNghiepInfo = new KQHT_QuyetDinhTotNghiepInfo();
            pKQHT_QuyetDinhTotNghiep_SinhVienInfo = new KQHT_QuyetDinhTotNghiep_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();

            frmQuyetDinh = _frmQuyetDinh;

            repositoryItemCmbXepLoaiTN.DataSource = (new cBKQHT_XepLoaiTotNghiep()).Get(new KQHT_XepLoaiTotNghiepInfo());

            drQuyetDinh = _drQuyetDinh;
            if (_drQuyetDinh != null && "" + _drQuyetDinh[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID] != "")
            {
                SetText();
            }
        }

        public dlgQuyetDinhTotNghiep(frmQuyetDinhTotNghiep_QCNghe _frmQuyetDinh, DataRow _drQuyetDinh)
        {
            InitializeComponent();

            oBKQHT_QuyetDinhTotNghiep = new cBKQHT_QuyetDinhTotNghiep();
            oBKQHT_QuyetDinhTotNghiep_SinhVien = new cBKQHT_QuyetDinhTotNghiep_SinhVien();
            pKQHT_QuyetDinhTotNghiepInfo = new KQHT_QuyetDinhTotNghiepInfo();
            pKQHT_QuyetDinhTotNghiep_SinhVienInfo = new KQHT_QuyetDinhTotNghiep_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();

            frmQuyetDinh_QCNghe = _frmQuyetDinh;

            repositoryItemCmbXepLoaiTN.DataSource = (new cBKQHT_XepLoaiTotNghiep()).Get(new KQHT_XepLoaiTotNghiepInfo());

            drQuyetDinh = _drQuyetDinh;
            if (_drQuyetDinh != null && "" + _drQuyetDinh[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID] != "")
            {
                SetText();
            }
        }

        private void dlgQuyetDinhTotNghiep_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                dtSinhVien = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetNotIn(pDM_LopInfo, Program.IDNamHoc);
                oBSV_SinhVien.TachCotHoVaTen(ref dtSinhVien);
                grdSinhVien.DataSource = dtSinhVien;
            }
        }

        private void SetText()
        {
            txtSoQuyetDinh.Text = drQuyetDinh["SoQuyetDinh"].ToString();
            dtpNgayQuyetDinh.EditValue = (DateTime)drQuyetDinh["NgayQuyetDinh"];
            txtNoiDung.Text = "" + drQuyetDinh["NoiDung"];
        }

        private void GetQuyetDinhInfo()
        {
            pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh = txtSoQuyetDinh.Text.Trim();
            pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh = (DateTime)dtpNgayQuyetDinh.EditValue;
            pKQHT_QuyetDinhTotNghiepInfo.NoiDung = txtNoiDung.Text.Trim();
            pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc = Program.IDNamHoc;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if (DxErrorProvider != null) DxErrorProvider.Dispose();
            if (txtSoQuyetDinh.Text == "")
            {
                DxErrorProvider.SetError(txtSoQuyetDinh, "Bạn phải nhập số quyết định.");
                if (CtrlErr == null)
                    CtrlErr = txtSoQuyetDinh;
            }
            if (dtpNgayQuyetDinh.Text == "")
            {
                DxErrorProvider.SetError(dtpNgayQuyetDinh, "Bạn phải chọn ngày quyết định.");
                if (CtrlErr == null)
                    CtrlErr = dtpNgayQuyetDinh;
            }
            if (dtSinhVien == null || dtSinhVien.Select("Chon = true").Length <= 0)
            {
                ThongBao("Bạn phải chọn sinh viên !");
                CtrlErr = grdSinhVien;
            }
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;

            GetQuyetDinhInfo();
            if (drQuyetDinh == null || "" + drQuyetDinh[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID] == "")
            {
                pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID = oBKQHT_QuyetDinhTotNghiep.Add(pKQHT_QuyetDinhTotNghiepInfo);
                oBKQHT_QuyetDinhTotNghiep.ToDataRow(pKQHT_QuyetDinhTotNghiepInfo, ref drQuyetDinh);
                if (frmQuyetDinh != null)
                    frmQuyetDinh.dtQuyetDinh.Rows.Add(drQuyetDinh);
                else
                    frmQuyetDinh_QCNghe.dtQuyetDinh.Rows.Add(drQuyetDinh);
            }
            else
            {
                pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID = int.Parse(drQuyetDinh[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID].ToString());
                oBKQHT_QuyetDinhTotNghiep.Update(pKQHT_QuyetDinhTotNghiepInfo);
                oBKQHT_QuyetDinhTotNghiep.ToDataRow(pKQHT_QuyetDinhTotNghiepInfo, ref drQuyetDinh);
            }

            DataRow[] arrDr = dtSinhVien.Select("Chon = true");
            pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep = pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID;
            bool addsv = false;
            foreach (DataRow dr in arrDr)
            {
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa = double.Parse("0" + dr["DiemTrungBinhChungToanKhoa"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep = double.Parse("0" + dr["DiemTrungBinhChungTotNghiep"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemXepLoaiTotNghiep = double.Parse("0" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemXepLoaiTotNghiep]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1 = double.Parse("0" + dr["DiemMonTotNghiep1"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2 = double.Parse("0" + dr["DiemMonTotNghiep2"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3 = double.Parse("0" + dr["DiemMonTotNghiep3"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4 = double.Parse("0" + dr["DiemMonTotNghiep4"]);
                pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep = int.Parse("0" + dr["IDKQHT_XepLoaiTotNghiep"]);

                oBKQHT_QuyetDinhTotNghiep_SinhVien.Add(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
                addsv = true;
            }
            if (addsv == true)
            {
                
                ThongBao("Đã thêm sinh viên vào quyết định");
            }
            if (frmQuyetDinh != null)
                frmQuyetDinh.grvQuyetDinh_FocusedRowChanged(null, null);
            else
                frmQuyetDinh_QCNghe.grvQuyetDinh_FocusedRowChanged(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgrvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void bgrvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(bgrvSinhVien, "Chon", e);
        }
    }
}