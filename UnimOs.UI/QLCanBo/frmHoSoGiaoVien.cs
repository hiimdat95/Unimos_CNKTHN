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
using System.IO;
using Microsoft.Office.Interop;
using System.Reflection;

namespace UnimOs.UI
{
    public partial class frmHoSoGiaoVien : frmBase
    {
        private cBNS_GiaoVien oBNS_GiaoVien;
        private NS_GiaoVienInfo pNS_GiaoVienInfo;
        private cBNS_GiaoVien_ThongTin oBNS_GiaoVien_ThongTin;
        private NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo;
        private cBNS_GiaoVien_QuanHeGiaDinh oBNS_GiaoVien_QuanHeGiaDinh;
        private NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo;
        private cBNS_GiaoVien_NgoaiNgu oBNS_GiaoVien_NgoaiNgu;
        private NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNgu;
        private DataTable dtGiaoVien, dtHoSo, dtGiaoVien_QuanHeGiaDinh, dtGiaoVien_NgoaiNgu;
        private DataRow drGiaoVien, drHoSo, drGiaoVien_QuanHeGiaDinh, drGiaoVien_NgoaiNgu;
        public int IDDM_ChucDanh, IDDM_HocHam, IDDM_HocVi, IDDM_DanhHieu,
                   IDDM_TrinhDoQuanLyHanhChinhNhaNuoc, IDDM_TrinhDoChuyenMon, 
                   IDDM_TrinhDoLyLuan, IDDM_QuanHeGiaDinh, IDDM_NgoaiNgu;
        private EDIT_MODE edit;
        public frmDanhSachGiaoVien ofrmDanhSachGiaoVien;
        Lib.clsExportToWord clsWord = new Lib.clsExportToWord();

        public frmHoSoGiaoVien(DataTable _dtGiaoVien, ref DataRow _drGiaoVien, frmDanhSachGiaoVien _frmDanhSachGiaoVien)
        {
            InitializeComponent();
            oBNS_GiaoVien = new cBNS_GiaoVien();
            pNS_GiaoVienInfo = new NS_GiaoVienInfo();
            oBNS_GiaoVien_ThongTin = new cBNS_GiaoVien_ThongTin();
            pNS_GiaoVien_ThongTinInfo = new NS_GiaoVien_ThongTinInfo();
            oBNS_GiaoVien_QuanHeGiaDinh = new cBNS_GiaoVien_QuanHeGiaDinh();
            pNS_GiaoVien_QuanHeGiaDinhInfo = new NS_GiaoVien_QuanHeGiaDinhInfo();
            oBNS_GiaoVien_NgoaiNgu = new cBNS_GiaoVien_NgoaiNgu();
            pNS_GiaoVien_NgoaiNgu = new NS_GiaoVien_NgoaiNguInfo();
            dtGiaoVien = _dtGiaoVien;
            drGiaoVien = _drGiaoVien;
            ofrmDanhSachGiaoVien = _frmDanhSachGiaoVien;
            LoadDiaChi(ucNoiO);
            LoadDiaChi(ucThuongTru);
            SetControl(false);
            SetControlReadOnly(true);
            SetControlNgoaiNgu(true);
            SetButtonNgoaiNgu(false);
            btnLuu.Enabled = false;
            btnLuuNN.Enabled = false;
        }

        private void SetControlReadOnly(bool status)
        {
            cmbQuanHeGiaDinh.Properties.ReadOnly = status;
            txtHoVaTen.Properties.ReadOnly = status;
            txtNamSinh.Properties.ReadOnly = status;
            txtDiaChi.Properties.ReadOnly = status;
            txtNgheNghiep.Properties.ReadOnly = status;
            txtThongTinKhac.Properties.ReadOnly = status;
        }

        private void SetControlNgoaiNgu(bool mbool)
        {
            cmbNgoaiNgu.Properties.ReadOnly = mbool;
            txtTrinhDo.Properties.ReadOnly = mbool;
            txtSoChungChi.Properties.ReadOnly = mbool;
            dtpNgayCapCCNN.Properties.ReadOnly = mbool;
            txtNoiCap.Properties.ReadOnly = mbool;
        }

        private void picAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Pictures|*.bmp;*.gif;*.jpg;*.png|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNG|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = new Bitmap(dlg.FileName);
            }
        }

        private void LoadCombo()
        {
            cmbDonVi.Properties.DataSource = LoadDonVi();
            cmbDanToc.Properties.DataSource = LoadDanToc();
            cmbTonGiao.Properties.DataSource = LoadTonGiao();
            cmbChucDanh.Properties.DataSource = LoadChucDanh();
            cmbHocHam.Properties.DataSource = LoadHocHam();
            cmbHocVi.Properties.DataSource = LoadHocVi();
            cmbDanhHieu.Properties.DataSource = LoadDanhHieuDuocPhongTang();
            cmbTrinhDoQLHCNN.Properties.DataSource = LoadTrinhDoQuanLyHanhChinhNhaNuoc();
            cmbTrinhDoChuyenMon.Properties.DataSource = LoadTrinhDoChuyenMon();
            cmbTrinhDoLyLuan.Properties.DataSource = LoadTrinhDoLyLuan();
            cmbQuanHeGiaDinh.Properties.DataSource = LoadQuanHeGiaDinh();
            reposiQuanHeGiaDinh.DataSource = LoadQuanHeGiaDinh();
            cmbNgoaiNgu.Properties.DataSource = LoadNgoaiNgu();
            reposNgoaiNgu.DataSource = LoadNgoaiNgu();
            cmbTrangThaiGiaoVien.Properties.DataSource = LoadTrangThaiGiaoVien();
            DataTable dtTrinhDoNN_TH = bLoadTrinhDoNgoaiNgu_TinHoc();
            cmbTrinhDoTinHoc.Properties.DataSource = dtTrinhDoNN_TH;
            cmbTrinhDoNgoaiNgu.Properties.DataSource = dtTrinhDoNN_TH;
            repositoryIDTrinhDoNgoaiNgu.DataSource = dtTrinhDoNN_TH;
        }

        private void frmHoSoGiaoVien_Load(object sender, EventArgs e)
        {
            LoadCombo();
            dtHoSo = oBNS_GiaoVien.GetHoSo(int.Parse(drGiaoVien["NS_GiaoVienID"].ToString()));
            if (dtHoSo.Rows.Count > 0)
                drHoSo = dtHoSo.Rows[0];
            dataGiaoVien.DataSource = dtGiaoVien;
            SetText();
            dtGiaoVien_QuanHeGiaDinh = oBNS_GiaoVien_QuanHeGiaDinh.GetBy_IDNS_GiaoVien(int.Parse(drGiaoVien["NS_GiaoVienID"].ToString()));
            grdGiaoVien_QuanHeGiaDinh.DataSource = dtGiaoVien_QuanHeGiaDinh;
            dtGiaoVien_NgoaiNgu = oBNS_GiaoVien_NgoaiNgu.GetBy_IDNS_GiaoVien(int.Parse(drGiaoVien["NS_GiaoVienID"].ToString()));
            grdChungChiNgoaiNgu.DataSource = dtGiaoVien_NgoaiNgu;
        }

        private void SetText()
        {
            if ("" + drHoSo["Anh"] != "")
            {
                MemoryStream stream = new MemoryStream((byte[])drHoSo[pNS_GiaoVienInfo.strAnh]);
                picAnh.Image = Image.FromStream(stream);
            }
            cmbDonVi.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strIDNS_DonVi]);
            txtMaGiaoVien.Text = "" + drHoSo[pNS_GiaoVienInfo.strMaGiaoVien];
            txtHoTen.Text = drHoSo[pNS_GiaoVienInfo.strHoTen].ToString();
            if ("" + drHoSo[pNS_GiaoVienInfo.strNgaySinh] != "")
                dtpNgaySinh.EditValue = drHoSo[pNS_GiaoVienInfo.strNgaySinh];
            if ("" + drHoSo[pNS_GiaoVienInfo.strGioiTinh] != "")
                radioGioiTinh.EditValue = drHoSo[pNS_GiaoVienInfo.strGioiTinh];
            if (int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiO]) > 0)
                SetValueDiaChi(ucNoiO, int.Parse(drHoSo[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaNoiO].ToString()));
            ucNoiO.txtSoNha.Text = "" + drHoSo[pNS_GiaoVienInfo.strDiaChiNoiO];
            if (int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaThuongTru]) > 0)
                SetValueDiaChi(ucThuongTru, int.Parse(drHoSo[pNS_GiaoVienInfo.strIDDM_TinhHuyenXaThuongTru].ToString()));
            ucThuongTru.txtSoNha.Text = "" + drHoSo[pNS_GiaoVienInfo.strDiaChiThuongTru];
            cmbDanToc.EditValue = drHoSo[pNS_GiaoVienInfo.strIDDM_DanToc];
            cmbTonGiao.EditValue = drHoSo[pNS_GiaoVienInfo.strIDDM_TonGiao];
            txtDienThoai.Text = "" + drHoSo[pNS_GiaoVienInfo.strDienThoai];
            txtEmail.Text = "" + drHoSo[pNS_GiaoVienInfo.strEmail];
            txtSoCMND.Text = "" + drHoSo[pNS_GiaoVienInfo.strSoCMND];
            if ("" + drHoSo[pNS_GiaoVienInfo.strNgayCap] == "")
                dtpNgayCapCMCD.EditValue = null;
            else
            {
                dtpNgayCapCMCD.EditValue = drHoSo[pNS_GiaoVienInfo.strNgayCap];
            }
            cmbTrangThaiGiaoVien.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strTrangThaiGiaoVien].ToString());
            chkGiangDay.Checked = bool.Parse(drHoSo[pNS_GiaoVienInfo.strGiangDay].ToString());
            if (dtHoSo.DefaultView.Count > 0)
            {
                txtNgheNghiepTuyenDung.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strNgheNghiepTuyenDung].ToString();
                if ("" + drHoSo["NgayTuyenDung"] == "")
                {
                    dtpNgayTuyenDung.Checked = false;
                }
                else
                {
                    dtpNgayTuyenDung.Value = DateTime.Parse(drHoSo[pNS_GiaoVien_ThongTinInfo.strNgayTuyenDung].ToString());
                    dtpNgayTuyenDung.Checked = true;
                }
                chkGiaoVienChinhTri.Checked = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIsGiaoVienChinhTri] == "" ? false : 
                    bool.Parse(drHoSo[pNS_GiaoVien_ThongTinInfo.strIsGiaoVienChinhTri].ToString());
                txtSoTruongCongTac.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strSoTruongCongTac].ToString();
                txtTrinhDoPhoThong.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strTrinhDoPhoThong].ToString();
                cmbTrinhDoTinHoc.EditValue = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDTrinhDoTinHoc];
                txtTrinhDoTinHoc.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strTrinhDoTinHoc].ToString();
                cmbChucDanh.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_ChucDanh].ToString());
                cmbHocHam.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_HocHam].ToString());
                cmbHocVi.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_HocVi].ToString());
                cmbDanhHieu.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_DanhHieuDuocPhongTang].ToString());
                if ("" + drHoSo["NgayVaoDang"] == "")
                {
                    dtpNgayVaoDang.Checked = false;
                }
                else
                {
                    dtpNgayVaoDang.Value = DateTime.Parse(drHoSo[pNS_GiaoVien_ThongTinInfo.strNgayVaoDang].ToString());
                    dtpNgayVaoDang.Checked = true;
                }
                if ("" + drHoSo["NgayVaoDangChinhThuc"] == "")
                {
                    dtpNgayVaoDangChinhThuc.Checked = false;
                }
                else
                {
                    dtpNgayVaoDangChinhThuc.Value = DateTime.Parse(drHoSo[pNS_GiaoVien_ThongTinInfo.strNgayVaoDangChinhThuc].ToString());
                    dtpNgayVaoDangChinhThuc.Checked = true;
                }
                cmbTrinhDoQLHCNN.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_QuanLyHanhChinhNhaNuoc].ToString());
                cmbTrinhDoChuyenMon.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoChuyenMon].ToString());
                cmbTrinhDoLyLuan.EditValue = int.Parse("0" + drHoSo[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoLyLuan].ToString());
                txtTinhTrangSucKhoe.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strTinhTrangSucKhoe].ToString();
                txtSoSoBHXH.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strSoSoBaoHiemXaHoi].ToString();
                if ("" + drHoSo["ChieuCao"] == "" || double.Parse("0" + drHoSo["ChieuCao"].ToString()) == 0)
                    txtChieuCao.Text = null;
                else
                {
                    txtChieuCao.Text = drHoSo[pNS_GiaoVien_ThongTinInfo.strChieuCao].ToString();
                }
                if ("" + drHoSo["CanNang"] == "" || double.Parse("0" + drHoSo["CanNang"].ToString()) == 0)
                    txtCanNang.Text = null;
                else
                {
                    txtCanNang.Text = drHoSo[pNS_GiaoVien_ThongTinInfo.strCanNang].ToString();
                }
                txtNhomMau.Text = "" + drHoSo[pNS_GiaoVien_ThongTinInfo.strNhomMau].ToString();
            }
        }

        private void GetpGiaoVienInfo()
        {
            pNS_GiaoVienInfo.NS_GiaoVienID = int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_GiaoVienInfo.MaGiaoVien = txtMaGiaoVien.Text;
            pNS_GiaoVienInfo.HoTen = txtHoTen.Text;
            pNS_GiaoVienInfo.Ten = GetTen(txtHoTen.Text);
            if (dtpNgaySinh.EditValue == null)
            {
                pNS_GiaoVienInfo.NgaySinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_GiaoVienInfo.NgaySinh = DateTime.Parse(dtpNgaySinh.EditValue.ToString());
            }
            pNS_GiaoVienInfo.IDNS_DonVi = int.Parse("0" + cmbDonVi.EditValue);
            if (picAnh.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                picAnh.Image.Save(stream, picAnh.Image.RawFormat);
                byte[] img = stream.ToArray();
                pNS_GiaoVienInfo.Anh = img;
            }
            else
            {
                pNS_GiaoVienInfo.Anh = null;
            }
            pNS_GiaoVienInfo.DienThoai = txtDienThoai.Text;
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan = 0;
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh = 0;
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO = ucNoiO.returnID();
            pNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru = ucThuongTru.returnID();
            pNS_GiaoVienInfo.DiaChiNoiO = ucNoiO.txtSoNha.Text;
            pNS_GiaoVienInfo.DiaChiThuongTru = ucThuongTru.txtSoNha.Text;
            pNS_GiaoVienInfo.IDDM_DanToc = int.Parse("0" + cmbDanToc.EditValue);
            pNS_GiaoVienInfo.IDDM_TonGiao = int.Parse("0" + cmbTonGiao.EditValue);
            pNS_GiaoVienInfo.GioiTinh = bool.Parse(radioGioiTinh.EditValue.ToString());
            pNS_GiaoVienInfo.SoCMND = txtSoCMND.Text;
            if (dtpNgayCapCMCD.EditValue == null)
            {
                pNS_GiaoVienInfo.NgayCap = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_GiaoVienInfo.NgayCap = DateTime.Parse(dtpNgayCapCMCD.EditValue.ToString());
            }
            pNS_GiaoVienInfo.Email = txtEmail.Text;
            pNS_GiaoVienInfo.GiangDay = chkGiangDay.Checked;
            pNS_GiaoVienInfo.TrangThaiGiaoVien = int.Parse("0" + cmbTrangThaiGiaoVien.EditValue);
        }

        private void GetpGiaoVien_ThongTinInfo()
        {
            pNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien = int.Parse(drHoSo[pNS_GiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung = txtNgheNghiepTuyenDung.Text;
            pNS_GiaoVien_ThongTinInfo.NgayTuyenDung = dtpNgayTuyenDung.Checked == false ? DateTime.Parse("1/1/1900") : dtpNgayTuyenDung.Value;
            pNS_GiaoVien_ThongTinInfo.IsGiaoVienChinhTri = chkGiaoVienChinhTri.Checked;
            pNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh = int.Parse("0" + cmbChucDanh.EditValue);
            pNS_GiaoVien_ThongTinInfo.IDDM_HocHam = int.Parse("0" + cmbHocHam.EditValue);
            pNS_GiaoVien_ThongTinInfo.IDDM_HocVi = int.Parse("0" + cmbHocVi.EditValue);
            pNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong = txtTrinhDoPhoThong.Text;
            pNS_GiaoVien_ThongTinInfo.IDTrinhDoTinHoc = "" + cmbTrinhDoTinHoc.EditValue;
            pNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc = txtTrinhDoTinHoc.Text;
            pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon = int.Parse("0" + cmbTrinhDoChuyenMon.EditValue);
            pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan = int.Parse("0" + cmbTrinhDoLyLuan.EditValue);
            pNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc = int.Parse("0" + cmbTrinhDoQLHCNN.EditValue);
            pNS_GiaoVien_ThongTinInfo.NgayVaoDang = dtpNgayVaoDang.Checked == false ? DateTime.Parse("1/1/1900") : dtpNgayVaoDang.Value;
            pNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc = dtpNgayVaoDangChinhThuc.Checked == false ? DateTime.Parse("1/1/1900") : dtpNgayVaoDangChinhThuc.Value;
            pNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang = int.Parse("0" + cmbTrinhDoQLHCNN.EditValue);
            pNS_GiaoVien_ThongTinInfo.SoTruongCongTac = txtSoTruongCongTac.Text;
            pNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe = txtTinhTrangSucKhoe.Text;
            pNS_GiaoVien_ThongTinInfo.ChieuCao = double.Parse("0" + txtChieuCao.Text);
            pNS_GiaoVien_ThongTinInfo.CanNang = double.Parse("0" + txtCanNang.Text);
            pNS_GiaoVien_ThongTinInfo.NhomMau = txtNhomMau.Text;
            pNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi = txtSoSoBHXH.Text;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            if (cmbDonVi.EditValue == null)
            {
                dxErrorProvider.SetError(cmbDonVi, "Đơn vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbDonVi;
            }
            if (cmbTrangThaiGiaoVien.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrangThaiGiaoVien, "Trạng thái giáo viên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrangThaiGiaoVien;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            try
            {
                GetpGiaoVienInfo();
                oBNS_GiaoVien.Update(pNS_GiaoVienInfo);
                if ("" + drHoSo[pNS_GiaoVien_ThongTinInfo.strNS_GiaoVien_ThongTinID] != "")
                {
                    pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID = int.Parse(drHoSo[pNS_GiaoVien_ThongTinInfo.strNS_GiaoVien_ThongTinID].ToString());
                    GetpGiaoVien_ThongTinInfo();
                    oBNS_GiaoVien_ThongTin.Update(pNS_GiaoVien_ThongTinInfo);
                    ofrmDanhSachGiaoVien.LoadGiaoVien(int.Parse("0" + drHoSo[pNS_GiaoVienInfo.strIDNS_DonVi]));
                }
                else
                {
                    GetpGiaoVien_ThongTinInfo();
                    drHoSo[pNS_GiaoVien_ThongTinInfo.strNS_GiaoVien_ThongTinID] = oBNS_GiaoVien_ThongTin.Add(pNS_GiaoVien_ThongTinInfo);
                }
                SuaThanhCong();
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_ChucDanh frm = new frmDM_ChucDanh(this);
                frm.ShowDialog();
                if (IDDM_ChucDanh > 0)
                {
                    cmbChucDanh.Properties.DataSource = LoadChucDanh();
                    cmbChucDanh.EditValue = IDDM_ChucDanh;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbChucDanh.EditValue = null;
            }
        }

        private void cmbHocHam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_HocHam frm = new frmDM_HocHam(this);
                frm.ShowDialog();
                if (IDDM_HocHam > 0)
                {
                    cmbHocHam.Properties.DataSource = LoadHocHam();
                    cmbHocHam.EditValue = IDDM_HocHam;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbHocHam.EditValue = null;
            }
        }

        private void cmbDanhHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_DanhHieuDuocPhongTang frm = new frmDM_DanhHieuDuocPhongTang(this);
                frm.ShowDialog();
                if (IDDM_DanhHieu > 0)
                {
                    cmbDanhHieu.Properties.DataSource = LoadDanhHieuDuocPhongTang();
                    cmbDanhHieu.EditValue = IDDM_DanhHieu;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbDanhHieu.EditValue = null;
            }
        }

        private void cmbTrinhDoQLHCNN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_TrinhDoQuanLyHCNN frm = new frmDM_TrinhDoQuanLyHCNN(this);
                frm.ShowDialog();
                if (IDDM_TrinhDoQuanLyHanhChinhNhaNuoc > 0)
                {
                    cmbTrinhDoQLHCNN.Properties.DataSource = LoadTrinhDoQuanLyHanhChinhNhaNuoc();
                    cmbTrinhDoQLHCNN.EditValue = IDDM_TrinhDoQuanLyHanhChinhNhaNuoc;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbTrinhDoQLHCNN.EditValue = null;
            }
        }

        private void cmbTrinhDoChuyenMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_TrinhDoChuyenMon frm = new frmDM_TrinhDoChuyenMon(this);
                frm.ShowDialog();
                if (IDDM_TrinhDoChuyenMon > 0)
                {
                    cmbTrinhDoChuyenMon.Properties.DataSource = LoadTrinhDoChuyenMon();
                    cmbTrinhDoChuyenMon.EditValue = IDDM_TrinhDoChuyenMon;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbTrinhDoChuyenMon.EditValue = null;
            }
        }

        private void cmbTrinhDoLyLuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_TrinhDoLyLuan frm = new frmDM_TrinhDoLyLuan(this);
                frm.ShowDialog();
                if (IDDM_TrinhDoLyLuan > 0)
                {
                    cmbTrinhDoLyLuan.Properties.DataSource = LoadTrinhDoLyLuan();
                    cmbTrinhDoLyLuan.EditValue = IDDM_TrinhDoLyLuan;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbTrinhDoLyLuan.EditValue = null;
            }
        }

        private void cmbHocVi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_HocVi frm = new frmDM_HocVi(this);
                frm.ShowDialog();
                if (IDDM_HocVi > 0)
                {
                    cmbHocVi.Properties.DataSource = LoadHocVi();
                    cmbHocVi.EditValue = IDDM_HocVi;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbHocVi.EditValue = null;
            }
        }

        private void cmbQuanHeGiaDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_QuanHeGiaDinh frm = new frmDM_QuanHeGiaDinh(this);
                frm.ShowDialog();
                if (IDDM_QuanHeGiaDinh > 0)
                {
                    cmbQuanHeGiaDinh.Properties.DataSource = LoadQuanHeGiaDinh();
                    reposiQuanHeGiaDinh.DataSource = LoadQuanHeGiaDinh();
                    cmbQuanHeGiaDinh.EditValue = IDDM_QuanHeGiaDinh;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbQuanHeGiaDinh.EditValue = null;
            }
        }

        private void SetControl(bool status)
        {
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetButtonNgoaiNgu(bool status)
        {
            btnSuaNN.Enabled = status;
            btnXoaNN.Enabled = status;
        }

        private void ClearText()
        {
            txtHoVaTen.Text = "";
            txtNamSinh.Text = "";
            txtDiaChi.Text = "";
            cmbQuanHeGiaDinh.EditValue = null;
            txtNgheNghiep.Text = "";
            txtThongTinKhac.Text = "";
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtHoVaTen.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtHoVaTen, "Họ và tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHoVaTen;
            }
            if (cmbQuanHeGiaDinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbQuanHeGiaDinh, "Mỗi quan hệ gia đình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbQuanHeGiaDinh;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void SetValuesText()
        {
            txtHoVaTen.Text = pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen;
            txtNamSinh.Text = "" + pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh;
            txtDiaChi.Text = "" + pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan;
            cmbQuanHeGiaDinh.EditValue = int.Parse("0" + pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh);
            txtNgheNghiep.Text = "" + pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep;
            txtThongTinKhac.Text = "" + pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac;
            txtHoVaTen.Focus();
        }

        private void GetValuespInfo()
        {
            pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen = txtHoVaTen.Text;
            pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh = txtNamSinh.Text;
            pNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pNS_GiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse("0" + cmbQuanHeGiaDinh.EditValue);
            pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan = txtDiaChi.Text;
            pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan = 0;
            pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep = txtNgheNghiep.Text;
            pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac = txtThongTinKhac.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grdGiaoVien_QuanHeGiaDinh.Enabled = false;
            SetControlReadOnly(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grdGiaoVien_QuanHeGiaDinh.Enabled = false;
            SetControlReadOnly(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetValuesText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID = int.Parse(drGiaoVien_QuanHeGiaDinh[pNS_GiaoVien_QuanHeGiaDinhInfo.strNS_GiaoVien_QuanHeGiaDinhID].ToString());
                    oBNS_GiaoVien_QuanHeGiaDinh.Delete(pNS_GiaoVien_QuanHeGiaDinhInfo);
                    // ghi log
                    GhiLog("Xóa quan hệ gia đình giáo viên '" + pNS_GiaoVienInfo.HoTen + " người quan hệ " + pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen +"' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtGiaoVien_QuanHeGiaDinh.Rows.Remove(drGiaoVien_QuanHeGiaDinh);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                GetValuespInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID = oBNS_GiaoVien_QuanHeGiaDinh.Add(pNS_GiaoVien_QuanHeGiaDinhInfo);
                    GhiLog("Thêm quan hệ gia đình giáo viên '" + pNS_GiaoVienInfo.HoTen + " người quan hệ " + pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtGiaoVien_QuanHeGiaDinh.NewRow();
                    oBNS_GiaoVien_QuanHeGiaDinh.ToDataRow(pNS_GiaoVien_QuanHeGiaDinhInfo, ref drNew);
                    dtGiaoVien_QuanHeGiaDinh.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID = int.Parse(drGiaoVien_QuanHeGiaDinh[pNS_GiaoVien_QuanHeGiaDinhInfo.strNS_GiaoVien_QuanHeGiaDinhID].ToString());
                    oBNS_GiaoVien_QuanHeGiaDinh.Update(pNS_GiaoVien_QuanHeGiaDinhInfo);
                    GhiLog("Sửa quan hệ gia đình giáo viên '" + pNS_GiaoVienInfo.HoTen + " người quan hệ " + pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_GiaoVien_QuanHeGiaDinh.ToDataRow(pNS_GiaoVien_QuanHeGiaDinhInfo, ref drGiaoVien_QuanHeGiaDinh);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void grvGiaoVien_QuanHeGiaDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien_QuanHeGiaDinh.FocusedRowHandle >= 0)
            {
                drGiaoVien_QuanHeGiaDinh = grvGiaoVien_QuanHeGiaDinh.GetDataRow(grvGiaoVien_QuanHeGiaDinh.FocusedRowHandle);
                oBNS_GiaoVien_QuanHeGiaDinh.ToInfo(ref pNS_GiaoVien_QuanHeGiaDinhInfo, drGiaoVien_QuanHeGiaDinh);
                SetValuesText();
            }
            if (grvGiaoVien_QuanHeGiaDinh != null)
                if (grvGiaoVien_QuanHeGiaDinh.DataRowCount > 0 && grvGiaoVien_QuanHeGiaDinh.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drGiaoVien_QuanHeGiaDinh = grvGiaoVien_QuanHeGiaDinh.GetDataRow(grvGiaoVien_QuanHeGiaDinh.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drGiaoVien_QuanHeGiaDinh = null;
        }

        private void grvGiaoVien_QuanHeGiaDinh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdGiaoVien_QuanHeGiaDinh.Enabled = true;
            dxErrorProvider.ClearErrors();
            SetControlReadOnly(true);
            btnLuu.Enabled = false;
            grvGiaoVien_QuanHeGiaDinh_FocusedRowChanged(null, null);
        }

        private void cmbNgoaiNgu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_NgoaiNgu frm = new frmDM_NgoaiNgu(this);
                frm.ShowDialog();
                if (IDDM_NgoaiNgu > 0)
                {
                    cmbNgoaiNgu.Properties.DataSource = LoadNgoaiNgu();
                    reposNgoaiNgu.DataSource = LoadNgoaiNgu();
                    cmbNgoaiNgu.EditValue = IDDM_NgoaiNgu;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbNgoaiNgu.EditValue = null;
            }
        }

        private void ClearText_NgoaiNgu()
        {
            //cmbNgoaiNgu.EditValue = null;
            txtTrinhDo.Text = "";
            txtSoChungChi.Text = "";
            //dtpNgayCapCCNN.EditValue = null;
            txtNoiCap.Text = "";
        }

        private bool Check_Valid_NgoaiNgu()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbNgoaiNgu.EditValue == null)
            {
                dxErrorProvider.SetError(cmbNgoaiNgu, "Ngoại ngữ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbNgoaiNgu;
            }
            if (cmbTrinhDoNgoaiNgu.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrinhDoNgoaiNgu, "Trình độ ngoại ngữ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrinhDoNgoaiNgu;
            }
            if (txtTrinhDo.Text == "")
            {
                dxErrorProvider.SetError(txtTrinhDo, "Tên chứng chỉ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTrinhDo;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void SetText_NgoaiNgu()
        {
            cmbNgoaiNgu.EditValue = int.Parse("0" + pNS_GiaoVien_NgoaiNgu.IDDM_NgoaiNgu);
            cmbTrinhDoNgoaiNgu.EditValue = pNS_GiaoVien_NgoaiNgu.IDTrinhDo;
            txtTrinhDo.Text = "" + pNS_GiaoVien_NgoaiNgu.TrinhDo;
            txtSoChungChi.Text = "" + pNS_GiaoVien_NgoaiNgu.SoChungChi;
            if ("" + drGiaoVien_NgoaiNgu[pNS_GiaoVien_NgoaiNgu.strNgayCap] == "")
                dtpNgayCapCCNN.EditValue = null;
            else
            {
                dtpNgayCapCCNN.EditValue = DateTime.Parse(drGiaoVien_NgoaiNgu[pNS_GiaoVien_NgoaiNgu.strNgayCap].ToString());
            }
            txtNoiCap.Text = "" + pNS_GiaoVien_NgoaiNgu.NoiCap;
            cmbNgoaiNgu.Focus();
        }

        private void GepInfo_NgoaiNgu()
        {
            pNS_GiaoVien_NgoaiNgu.IDNS_GiaoVien = int.Parse(drGiaoVien[pNS_GiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_GiaoVien_NgoaiNgu.IDDM_NgoaiNgu = int.Parse("0" + cmbNgoaiNgu.EditValue);
            pNS_GiaoVien_NgoaiNgu.IDTrinhDo = cmbTrinhDoNgoaiNgu.EditValue.ToString();
            pNS_GiaoVien_NgoaiNgu.TrinhDo = txtTrinhDo.Text;
            pNS_GiaoVien_NgoaiNgu.SoChungChi = txtSoChungChi.Text;
            if (dtpNgayCapCCNN.EditValue == null)
            {
                pNS_GiaoVien_NgoaiNgu.NgayCap = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_GiaoVien_NgoaiNgu.NgayCap = DateTime.Parse(dtpNgayCapCCNN.EditValue.ToString());
            }
            pNS_GiaoVien_NgoaiNgu.NoiCap = txtNoiCap.Text;
        }

        private void btnThemNN_Click(object sender, EventArgs e)
        {
            grdChungChiNgoaiNgu.Enabled = false;
            SetControlNgoaiNgu(false);
            btnLuuNN.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText_NgoaiNgu();
        }

        private void btnSuaNN_Click(object sender, EventArgs e)
        {
            grdChungChiNgoaiNgu.Enabled = false;
            SetControlNgoaiNgu(false);
            btnLuuNN.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetText_NgoaiNgu();
        }

        private void btnXoaNN_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_GiaoVien_NgoaiNgu.NS_GiaoVien_NgoaiNguID = int.Parse(drGiaoVien_NgoaiNgu[pNS_GiaoVien_NgoaiNgu.strNS_GiaoVien_NgoaiNguID].ToString());
                    oBNS_GiaoVien_NgoaiNgu.Delete(pNS_GiaoVien_NgoaiNgu);
                    // ghi log
                    GhiLog("Xóa quan chứng chỉ ngoại ngữ giáo viên '" + pNS_GiaoVienInfo.HoTen + " số chứng chỉ " + pNS_GiaoVien_NgoaiNgu.SoChungChi + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtGiaoVien_NgoaiNgu.Rows.Remove(drGiaoVien_NgoaiNgu);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnLuuNN_Click(object sender, EventArgs e)
        {
            if (!Check_Valid_NgoaiNgu()) return;
            try
            {
                GepInfo_NgoaiNgu();
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_GiaoVien_NgoaiNgu.NS_GiaoVien_NgoaiNguID = oBNS_GiaoVien_NgoaiNgu.Add(pNS_GiaoVien_NgoaiNgu);
                    GhiLog("Thêm chứng chỉ ngoại ngữ giáo viên '" + pNS_GiaoVienInfo.HoTen + " số chứng chỉ " + pNS_GiaoVien_NgoaiNgu.SoChungChi + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtGiaoVien_NgoaiNgu.NewRow();
                    oBNS_GiaoVien_NgoaiNgu.ToDataRow(pNS_GiaoVien_NgoaiNgu, ref drNew);
                    if (pNS_GiaoVien_NgoaiNgu.NgayCap == DateTime.Parse("01/01/1900"))
                        drNew[pNS_GiaoVien_NgoaiNgu.strNgayCap] = DBNull.Value;
                    dtGiaoVien_NgoaiNgu.Rows.Add(drNew);
                    ClearText_NgoaiNgu();
                }
                else
                {
                    pNS_GiaoVien_NgoaiNgu.NS_GiaoVien_NgoaiNguID = int.Parse(drGiaoVien_NgoaiNgu[pNS_GiaoVien_NgoaiNgu.strNS_GiaoVien_NgoaiNguID].ToString());
                    oBNS_GiaoVien_NgoaiNgu.Update(pNS_GiaoVien_NgoaiNgu);
                    GhiLog("Sửa chứng chỉ ngoại ngữ giáo viên '" + pNS_GiaoVienInfo.HoTen + " số chứng chỉ " + pNS_GiaoVien_NgoaiNgu.SoChungChi + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_GiaoVien_NgoaiNgu.ToDataRow(pNS_GiaoVien_NgoaiNgu, ref drGiaoVien_NgoaiNgu);
                    if (pNS_GiaoVien_NgoaiNgu.NgayCap == DateTime.Parse("01/01/1900"))
                        drGiaoVien_NgoaiNgu[pNS_GiaoVien_NgoaiNgu.strNgayCap] = DBNull.Value;
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuyNN_Click(object sender, EventArgs e)
        {
            grdChungChiNgoaiNgu.Enabled = true;
            dxErrorProvider.ClearErrors();
            SetControlNgoaiNgu(true);
            btnLuuNN.Enabled = false;
            grvChungChiNgoaiNgu_FocusedRowChanged(null, null);
        }

        private void grvChungChiNgoaiNgu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvChungChiNgoaiNgu.FocusedRowHandle >= 0)
            {
                drGiaoVien_NgoaiNgu = grvChungChiNgoaiNgu.GetDataRow(grvChungChiNgoaiNgu.FocusedRowHandle);
                oBNS_GiaoVien_NgoaiNgu.ToInfo(ref pNS_GiaoVien_NgoaiNgu, drGiaoVien_NgoaiNgu);
                SetText_NgoaiNgu();
            }
            if (grvChungChiNgoaiNgu != null)
                if (grvChungChiNgoaiNgu.DataRowCount > 0 && grvChungChiNgoaiNgu.FocusedRowHandle >= 0)
                {
                    SetButtonNgoaiNgu(true);
                    drGiaoVien_NgoaiNgu = grvChungChiNgoaiNgu.GetDataRow(grvChungChiNgoaiNgu.FocusedRowHandle);
                    return;
                }
            SetButtonNgoaiNgu(false);
            drGiaoVien_NgoaiNgu = null;
        }

        private void grvChungChiNgoaiNgu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnInHoSo_Click(object sender, EventArgs e)
        {
            if (drGiaoVien["NS_GiaoVienID"] + "" != "")
            {
                int NS_GiaoVienID = int.Parse(drGiaoVien["NS_GiaoVienID"].ToString());
                DataTable dtSoYeuLyLich = oBNS_GiaoVien.Get_SoYeuLyLich(NS_GiaoVienID);
                if (dtSoYeuLyLich.Rows.Count > 0)
                {
                    CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                    try
                    {
                        // Khoi tao ban word.
                        Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                        Microsoft.Office.Interop.Word.Document aDoc = null;
                        clsWord.InitWord(WordApp, ref aDoc, 11);
                        // Insert du lieu vao ban word.
                        // Tieu de trang
                        clsWord.AddText(aDoc, "Mẫu 2a-BNV/2007", 0, 1, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                        clsWord.AddText(aDoc, "(ban hành kèm theo Quyết định số 06/2007/QĐ-BNV ngày 18/6/2007 của Bộ trưởng Bộ Nội vụ)", 0, 1, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                        clsWord.AddText(aDoc, "Cơ quan, đơn vị có thẩm quyền quản lý CBCC: " + Program.TenTruong + ", Số hiệu cán bộ, công chức: " + dtSoYeuLyLich.Rows[0]["MaGiaoVien"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "Cơ quan, đơn vị sử dụng CBCC: " + Program.TenTruong, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "SƠ YẾU LÝ LỊCH CÁN BỘ, CÔNG CHỨC", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                        // Noi dung trang
                        clsWord.AddText(aDoc, "\t\t\t1. Họ và tên khai sinh (viết chữ in hoa): " + dtSoYeuLyLich.Rows[0]["HoTen"].ToString().ToUpper(), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t\t2. Tên gọi khác : " + dtSoYeuLyLich.Rows[0]["Ten"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t\t3. Sinh ngày: " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Day.ToString()) +
                                                           " Tháng " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Month.ToString()) +
                                                           " năm " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Year.ToString()) +
                                                           ", Giới tính(nam, nữ): " + dtSoYeuLyLich.Rows[0]["TenGioiTinh"]
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t\t4. Nơi sinh: " + dtSoYeuLyLich.Rows[0]["DiaChiNoiO"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t\t5. Quê quán: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "6. Dân tộc: " + dtSoYeuLyLich.Rows[0]["TenDanToc"] + "\t\t" + "7. Tôn giáo: " + dtSoYeuLyLich.Rows[0]["TenTonGiao"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "8. Nơi đăng ký hộ khẩu thường trú: " + dtSoYeuLyLich.Rows[0]["DiaChiThuongTru"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Số nhà, đường phố, thành phố; xóm, thôn, xã, huyện, tỉnh)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "9. Nơi ở hiện nay: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Số nhà, đường phố, thành phố; xóm, thôn, xã, huyện, tỉnh)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "10. Nghề nghiệp khi được tuyển dụng: " + dtSoYeuLyLich.Rows[0]["NgheNghiepTuyenDung"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "11. Ngày tuyển dụng: " + ("" + dtSoYeuLyLich.Rows[0]["NgayTuyenDung"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayTuyenDung"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Cơ quan tuyển dụng: " + Program.TenTruong, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "12. Chức vụ (chức danh) hiện tại: " + dtSoYeuLyLich.Rows[0]["TenChucDanh"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Về chính quyền hoặc Đảng, đoàn thể, kể cả chức vụ kiêm nhiệm)" + dtSoYeuLyLich.Rows[0]["NgheNghiepTuyenDung"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "13. Công việc chính được giao: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "14. Ngạch công chức (viên chức): " + dtSoYeuLyLich.Rows[0]["TenNgachCongChuc"] + ", Mã ngạch: " + dtSoYeuLyLich.Rows[0]["MaNgachCongChuc"]
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "Bậc lương: " + dtSoYeuLyLich.Rows[0]["BacLuong"] + ", Hệ số: " + dtSoYeuLyLich.Rows[0]["HeSoLuong"] +
                                              ", Ngày hưởng: " + ("" + dtSoYeuLyLich.Rows[0]["TuNgay"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["TuNgay"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Phụ cấp chức vụ: " + dtSoYeuLyLich.Rows[0]["PhuCapChucVu"] + ", Phụ cấp khác: " + dtSoYeuLyLich.Rows[0]["PhuCapKhac"]
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "15.1. Trình độ giáo dục phổ thông (đã tốt nghiệp lớp mấy/ thuộc hệ nào): " + dtSoYeuLyLich.Rows[0]["TrinhDoPhoThong"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "15.2. Trình độ chuyên môn cao nhất: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoChuyenMon"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(TSKH, TS, Ths, cử nhân, kỹ sư, cao đẳng, trung cấp, sơ cấp; chuyên ngành)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "15.3. Lý luận chính trị: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoLyLuan"] + "\t\t" + "15.4. Quản lý nhà nước: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoQuanLyHanhChinhNhaNuoc"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Tên ngoại ngữ + Trình độ A, B, C, D,…)" + "\t\t" + "(Trình độ A, B, C,…)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "16. Ngày vào Đảng cộng sản Việt Nam: " + ("" + dtSoYeuLyLich.Rows[0]["NgayVaoDang"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayVaoDang"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Ngày chính thức: " + ("" + dtSoYeuLyLich.Rows[0]["NgayVaoDangChinhThuc"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayVaoDangChinhThuc"].ToString()).ToString("dd/MM/yyyy")), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "17. Ngày tham gia tổ chức chính trị - xã hội: " + ("" + dtSoYeuLyLich.Rows[0]["NgayThamGia"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayThamGia"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Tên tổ chức: " + dtSoYeuLyLich.Rows[0]["TenToChuc"] + ", Công việc: " + dtSoYeuLyLich.Rows[0]["CongViec"]
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Ngày tham gia tổ chức: Đoàn, Hội,…. Và làm việc gì trong tổ chức đó)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "18. Ngày nhập ngũ: " + ("" + dtSoYeuLyLich.Rows[0]["NgayNhapNgu"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayNhapNgu"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Ngày xuất ngũ: " + ("" + dtSoYeuLyLich.Rows[0]["NgayXuatNgu"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayXuatNgu"].ToString()).ToString("dd/MM/yyyy")) +
                                              ", Quân hàm cao nhất: " + dtSoYeuLyLich.Rows[0]["TenQuanHam"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "19. Danh hiệu được phong tặng cao nhất: " + dtSoYeuLyLich.Rows[0]["TenDanhHieuDuocPhongTang"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Anh hùng lao động, anh hùng lực lượng vũ trang; nhà giáo, thầy thuốc, nghệ sĩ nhân dân, ưu tú,…)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "20. Sở trường công tác: " + dtSoYeuLyLich.Rows[0]["SoTruongCongTac"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "21. Khen thưởng: " + dtSoYeuLyLich.Rows[0]["NoiDungKhenThuong"] + ", Năm: " + ("" + dtSoYeuLyLich.Rows[0]["NgayKhenThuong"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayKhenThuong"].ToString()).Year.ToString()) + "\t\t" +
                                              "22. Kỷ luật: " + dtSoYeuLyLich.Rows[0]["NoiDungKyLuat"] + ", Năm: " + ("" + dtSoYeuLyLich.Rows[0]["NgayKyLuat"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayKyLuat"].ToString()).Year.ToString()), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Hình thức cao nhất, năm nào)" + "\t" + "(Về đảng, chính quyền, đoàn thể hình thức cao nhất, năm nào)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "23. Tình trạng sức khỏe: " + dtSoYeuLyLich.Rows[0]["TinhTrangSucKhoe"] + ", Chiều cao: " + dtSoYeuLyLich.Rows[0]["ChieuCao"] + ", Cân nặng: " + dtSoYeuLyLich.Rows[0]["CanNang"] + " kg" + ", Nhóm máu: " + dtSoYeuLyLich.Rows[0]["NhomMau"]
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "24. Là thương binh hạng: " + "\t/\t" + ", Là con gia đình chính sách():", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "(Con thương binh, con liệt sĩ, người nhiễm chất độc da cam Dioxin)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "25. Số chứng minh nhân dân: " + dtSoYeuLyLich.Rows[0]["SoCMND"] +
                                              ", Ngày cấp: " + ("" + dtSoYeuLyLich.Rows[0]["NgayCap"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayCap"].ToString()).ToString("dd/MM/yyyy"))
                                            , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "26. Số sổ BHXH: " + dtSoYeuLyLich.Rows[0]["SoSoBaoHiemXaHoi"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        // Insert qua trinh boi duong vao bang                    
                        clsWord.AddText(aDoc, "27. Đào tạo, bồi dưỡng về chuyên môn, nghiệp vụ, lý luận chính trị, ngoại ngữ, tin học", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        DataTable dtBoiDuong = oBNS_GiaoVien.Get_QuaTrinhBoiDuong(NS_GiaoVienID);
                        clsWord.AddTable(aDoc, dtBoiDuong, new string[] { "Tên trường", "Chuyên ngành đào tạo", "Từ ngày", "Đến ngày", "Hình thức đào tạo", "Văn bằng chứng chỉ" },
                                                           new string[] { "NoiBoiDuong", "Ten", "TuNgay", "DenNgay", "TenHinhThucDaoTao", "TenXepLoaiChungChi" });
                        clsWord.AddText(aDoc, "Ghi chú: Hình thức đào tạo: chính quy, tại chức, chuyên tu, bồi dưỡng…………./ Văn bằng: TSKH, TS, Ths, Cử nhân, Kỹ sư, ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        // Insert qua trinh cong tac vao bang                    
                        clsWord.AddText(aDoc, "28. Tóm tắt quá trình công tác", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        DataTable dtCongTac = oBNS_GiaoVien.Get_QuaTrinhCongTac(NS_GiaoVienID);
                        clsWord.AddTable(aDoc, dtCongTac, new string[] { "Từ ngày", "Đến ngày", "Nội dung công tác", "Chức vụ đảm nhiệm", "Nơi công tác", "Tên nước" },
                                                           new string[] { "TuNgay", "DenNgay", "NoiDungCongTac", "ChucVuDamNhiem", "NoiCongTac", "TenNuoc" });
                        // Lịch sử bản thân
                        clsWord.AddText(aDoc, "29. Đặc điểm lịch sử bản thân", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "- Khai rõ: bị bắt, bị tù (từ ngày tháng năm nào đến ngày tháng năm nào, ở đâu), đã khai báo cho ai, những vấn đề gì? Bản thân có làm việc trong chế độ cũ (cơ quan, đơn vị nào, địa điểm, chức danh, chức vụ, thời gian làm việc…):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "- Thời gian hoặc có quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước ngoài (làm gì, tổ chức nào, đặt trụ sở ở đâu…?):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "- Có thân nhân (Cha, Mẹ, Vợ, chồng, con, anh chị em ruột) ở nước ngoài (làm gì, địa chỉ…):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        // Quan hệ gia đình
                        cBNS_GiaoVien_QuanHeGiaDinh oBNS_GiaVien_QuanHeGiaDinh = new cBNS_GiaoVien_QuanHeGiaDinh();
                        DataTable dtGiaDinh = oBNS_GiaVien_QuanHeGiaDinh.GetBy_IDNS_GiaoVien(NS_GiaoVienID);
                        clsWord.AddTable(aDoc, dtGiaDinh, new string[] { "Mỗi quan hệ", "Họ và tên", "Năm sinh", "Địa chỉ", "Nghề nghiệp", "Thông tin khác" },
                                                           new string[] { "TenMoiQuanHe", "HoVaTen", "NamSinh", "DiaChiQueQuan", "NgheNghiep", "ThongTinKhac" });
                        // Tieu de cuoi
                        clsWord.AddText(aDoc, "30. Nhận xét, đánh giá của cơ quan, đơn vị quản lý và sử dụng cán bộ công chức", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t\tNgười khai" + "\t\t\t" + "……., Ngày…… tháng…… năm 20….", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "Tôi xin cam đoan những lời khai trên đây là đúng sự thật" + "\t" + "Thủ trưởng cơ quan, đơn vị quản lý và sử dụng CBCC", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        clsWord.AddText(aDoc, "\t\t(Ký tên, ghi rõ họ tên)" + "\t\t\t\t" + "(Ký tên, đóng dấu)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                        WordApp.Visible = true;
                        CloseWaitDialog();
                        //ThongBao("Xuất dữ liệu ra word thành công.");
                    }
                    catch (Exception ex)
                    {
                        CloseWaitDialog();
                        ThongBaoLoi("Đang xuất dữ liệu, lỗi khi tắt chức năng này. " + ex.Message);
                    }
                }
            }
        }
    }
}