using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop;
using System.Reflection;

namespace UnimOs.UI
{
    public partial class frmNangBacChuyenNgach : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_SoQuyetDinh oBSoQuyetDinh;
        public NS_SoQuyetDinhInfo pSoQuyetDinhInfo;
        public cBNS_Luong oBLuong;
        public NS_LuongInfo pNS_LuongInfo;
        public cBNS_NhomNgach oBNS_NhomNgach;
        public NS_NhomNgachInfo pNS_NhomNgachInfo;
        private DataTable dtTree, dtGiaoVien, dtNgachCongChuc, dtNhomNgach, dtNangBacChuyenNgach;
        DataRow drGiaoVien;
        private bool Loaded = false, Them = false, Sua = false, ThemBoSung = false;
        private int idxGV;
        public int IDNS_NgachCongChuc;
        private int TrangThaiChonBac = -1;
        Lib.clsExportToWord clsWord = new Lib.clsExportToWord();

        public frmNangBacChuyenNgach()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBSoQuyetDinh = new cBNS_SoQuyetDinh();
            pSoQuyetDinhInfo = new NS_SoQuyetDinhInfo();
            oBLuong = new cBNS_Luong();
            pNS_LuongInfo = new NS_LuongInfo();
            oBNS_NhomNgach = new cBNS_NhomNgach();
            pNS_NhomNgachInfo = new NS_NhomNgachInfo();
            dtNangBacChuyenNgach = new DataTable();
            cmbBacLuong_SelectedIndexChanged(null, null);
            CreateTable();
        }

        private void CreateTable()
        {
            dtNangBacChuyenNgach = new DataTable();
            dtNangBacChuyenNgach.Columns.Add("NS_GiaoVienID", typeof(int));
            dtNangBacChuyenNgach.Columns.Add("MaGiaoVien", typeof(string));
            dtNangBacChuyenNgach.Columns.Add("HoTen", typeof(string));
            dtNangBacChuyenNgach.Columns.Add("IDNS_NgachCongChucCu", typeof(int));
            dtNangBacChuyenNgach.Columns.Add("MaNgachCongChucCu", typeof(string));
            dtNangBacChuyenNgach.Columns.Add("BacLuongCu", typeof(int));
            dtNangBacChuyenNgach.Columns.Add("HeSoLuongCu", typeof(double));
            dtNangBacChuyenNgach.Columns.Add("PhanTramHuongCu", typeof(double));
            dtNangBacChuyenNgach.Columns.Add("TuNgayCu", typeof(DateTime));
            dtNangBacChuyenNgach.Columns.Add("DenNgayCu", typeof(DateTime));
            dtNangBacChuyenNgach.Columns.Add("CongViecDamNhiem", typeof(string));
            dtNangBacChuyenNgach.Columns.Add("IDNS_NgachCongChuc", typeof(int));
            dtNangBacChuyenNgach.Columns.Add("MaNgachCongChuc", typeof(string));
            dtNangBacChuyenNgach.Columns.Add("BacLuong", typeof(int));
            dtNangBacChuyenNgach.Columns.Add("HeSoLuong", typeof(double));
            dtNangBacChuyenNgach.Columns.Add("PhanTramHuong", typeof(double));
            dtNangBacChuyenNgach.Columns.Add("TuNgay", typeof(DateTime));
            dtNangBacChuyenNgach.Columns.Add("DenNgay", typeof(DateTime));
            dtNangBacChuyenNgach.Columns.Add("LuongDenNgay", typeof(DateTime));
            dtNangBacChuyenNgach.Columns.Add("Chon", typeof(bool));
            dtNangBacChuyenNgach.Columns.Add("STT", typeof(int));
            if (dtNangBacChuyenNgach.Rows.Count > 0)
            {
                for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                {
                    dtNangBacChuyenNgach.Rows[i]["Chon"] = 0;
                }
            }
            dtNangBacChuyenNgach.AcceptChanges();
            grdNangBacChuyenNgach.DataSource = dtNangBacChuyenNgach;
        }

        private void frmQuaTrinhBoiDuong_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void LoadCombo()
        {
            dtNgachCongChuc = LoadNgachCongChuc();
            cmbNgachCongChuc.Properties.DataSource = dtNgachCongChuc;
            LoadSoQuyetDinh();
        }

        private void LoadSoQuyetDinh()
        {
            pSoQuyetDinhInfo.NS_SoQuyetDinhID = 0;
            cmbChonSoQuyetDinh.Properties.DataSource = oBSoQuyetDinh.Get(pSoQuyetDinhInfo);
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.NangBacChuyenNgach_GetByIDNS_DonVi(IDDonVi);
            dtGiaoVien.Columns.Add("Chon", typeof(bool));
            if (dtGiaoVien.Rows.Count > 0)
            {
                for (int i = 0; i < dtGiaoVien.Rows.Count; i++)
                {
                    dtGiaoVien.Rows[i]["Chon"] = 0;
                }
            }
            dtGiaoVien.AcceptChanges();
            grdGiaoVien.DataSource = dtGiaoVien;
            grvGiaoVien_FocusedRowChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();

        }

        private void trvDonVi_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
            }
        }

        private void cmbNgachCongChuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_NgachCongChuc frm = new frmDM_NgachCongChuc(null,this);
                frm.ShowDialog();
                if (IDNS_NgachCongChuc > 0)
                {
                    cmbNgachCongChuc.Properties.DataSource = LoadNgachCongChuc();
                    cmbNgachCongChuc.EditValue = IDNS_NgachCongChuc;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbNgachCongChuc.EditValue = null;
            }
        }

        private void cmbBacLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNgachCongChuc.EditValue != null)
            {
                TrangThaiChonBac = cmbBacLuong.SelectedIndex;
                switch (TrangThaiChonBac)
                {
                    case -1:
                        {
                            break;
                        }
                    case 0:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_1"].ToString();
                            break;
                        }
                    case 1:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_2"].ToString();
                            break;
                        }
                    case 2:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_3"].ToString();
                            break;
                        }
                    case 3:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_4"].ToString();
                            break;
                        }
                    case 4:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_5"].ToString();
                            break;
                        }
                    case 5:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_6"].ToString();
                            break;
                        }
                    case 6:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_7"].ToString();
                            break;
                        }
                    case 7:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_8"].ToString();
                            break;
                        }
                    case 8:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_9"].ToString();
                            break;
                        }
                    case 9:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_10"].ToString();
                            break;
                        }
                    case 10:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_11"].ToString();
                            break;
                        }
                    case 11:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_12"].ToString();
                            break;
                        }
                    case 12:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_13"].ToString();
                            break;
                        }
                    case 13:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_14"].ToString();
                            break;
                        }
                    case 14:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_15"].ToString();
                            break;
                        }
                    case 15:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_16"].ToString();
                            break;
                        }
                }
            }
        }

        private void cmbNgachCongChuc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNgachCongChuc.EditValue != null)
            {
                dtNhomNgach = oBNS_NhomNgach.GetBy_NS_NgachCongChucID(int.Parse(cmbNgachCongChuc.EditValue.ToString()));
            }
            cmbBacLuong_SelectedIndexChanged(null, null);
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayRaQuyetDinh.EditValue = null;
            txtCongViecDamNhiem.Text = "";
            cmbNgachCongChuc.EditValue = null;
            cmbBacLuong.SelectedIndex = -1;
            txtHeSoLuong.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            if (cmbNgachCongChuc.EditValue == null)
            {
                dxErrorProvider.SetError(cmbNgachCongChuc, "Ngạch công chức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbNgachCongChuc;
            }
            if (cmbBacLuong.SelectedIndex == -1)
            {
                dxErrorProvider.SetError(cmbBacLuong, "Bậc lương không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbBacLuong;
            }
            if (double.Parse("0" + txtHeSoLuong.Text) <= 0)
            {
                dxErrorProvider.SetError(txtHeSoLuong, "Hệ số lương phải lớn hơn 0.");
                if (CtrlErr == null) CtrlErr = txtHeSoLuong;
            }
            if (double.Parse("0" + txtPhanTramHuong.Text) <= 0)
            {
                dxErrorProvider.SetError(txtPhanTramHuong, "Phần trăm được hưởng phải lớn hơn 0.");
                if (CtrlErr == null) CtrlErr = txtPhanTramHuong;
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
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

        private void InsertTable()
        {
            if (dtGiaoVien.Rows.Count == 0)
            {
                ThongBaoLoi("Không có dữ liệu để thêm.");
            }
            else
            {
                DataRow[] arrDr1 = dtGiaoVien.Select("Chon = " + 1);
                if (arrDr1.Length == 0)
                {
                    ThongBaoLoi("Bạn chưa chọn cán bộ nào để nâng bậc - chuyển ngạch.");
                    return;
                }
                if (!Check_Valid()) return;
                string MaNgachCongChucMoi = "";
                DataRow[] arrDr2 = dtNgachCongChuc.Select("NS_NgachCongChucID = " + int.Parse("0" + cmbNgachCongChuc.EditValue));
                MaNgachCongChucMoi = arrDr2[0]["MaNgachCongChuc"].ToString();
                for (int i = 0; i < dtGiaoVien.Rows.Count; i++)
                {
                    DataRow[] arrDr3 = dtNangBacChuyenNgach.Select("NS_GiaoVienID = " + int.Parse("0" + dtGiaoVien.Rows[i]["NS_GiaoVienID"]));
                    if (arrDr3.Length == 0)
                    {
                        if (bool.Parse(dtGiaoVien.Rows[i]["Chon"].ToString()) == true)
                        {
                            DataRow dr = dtNangBacChuyenNgach.NewRow();
                            dr["NS_GiaoVienID"] = dtGiaoVien.Rows[i]["NS_GiaoVienID"];
                            dr["MaGiaoVien"] = dtGiaoVien.Rows[i]["MaGiaoVien"];
                            dr["HoTen"] = dtGiaoVien.Rows[i]["HoTen"];
                            if (Sua == false)
                            {
                                dr["IDNS_NgachCongChucCu"] = dtGiaoVien.Rows[i]["IDNS_NgachCongChuc"];
                                dr["MaNgachCongChucCu"] = dtGiaoVien.Rows[i]["MaNgachCongChuc"];
                                dr["BacLuongCu"] = dtGiaoVien.Rows[i]["BacLuong"];
                                dr["HeSoLuongCu"] = dtGiaoVien.Rows[i]["HeSoLuong"];
                                dr["PhanTramHuongCu"] = dtGiaoVien.Rows[i]["PhanTramHuong"];
                                dr["TuNgayCu"] = dtGiaoVien.Rows[i]["TuNgay"];
                                if ("" + dtGiaoVien.Rows[i]["DenNgay"] != "")
                                    if (DateTime.Parse(dtGiaoVien.Rows[i]["DenNgay"].ToString()) != DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null))
                                        dr["DenNgayCu"] = dtGiaoVien.Rows[i]["DenNgay"];
                            }
                            dr["CongViecDamNhiem"] = dtGiaoVien.Rows[i]["CongViecDamNhiem"];
                            dr["IDNS_NgachCongChuc"] = int.Parse("0" + cmbNgachCongChuc.EditValue);
                            dr["MaNgachCongChuc"] = MaNgachCongChucMoi;
                            dr["BacLuong"] = int.Parse(cmbBacLuong.SelectedIndex.ToString()) + 1;
                            dr["HeSoLuong"] = double.Parse("0" + txtHeSoLuong.Text);
                            dr["PhanTramHuong"] = double.Parse("0" + txtPhanTramHuong.Text);
                            if (dtpTuNgay.EditValue == null)
                            {
                                dr["TuNgay"] = DateTime.Parse("01/01/1900");
                            }
                            else
                            {
                                dr["TuNgay"] = DateTime.Parse(dtpTuNgay.EditValue.ToString());
                            }
                            if (dtpDenNgay.Checked == false)
                            {
                                dr["DenNgay"] = DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null);
                            }
                            else
                            {
                                dr["DenNgay"] = dtpDenNgay.Value;
                                dr["LuongDenNgay"] = dtpDenNgay.Value;
                            }
                            dr["Chon"] = false;
                            dtNangBacChuyenNgach.Rows.Add(dr);
                        }
                    }
                }
                if (dtGiaoVien.Rows.Count > 0)
                {
                    for (int j = 0; j < dtGiaoVien.Rows.Count; j++)
                    {
                        dtGiaoVien.Rows[j]["Chon"] = 0;
                    }
                }
                dtGiaoVien.AcceptChanges();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Sua == true)
            {
                CreateTable();
                Sua = false;            
            }
            InsertTable();
            Them = true;
            cmbChonSoQuyetDinh.EditValue = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc muốn xóa những cán bộ đã chọn trong quyết định nâng bậc - chuyển ngạch này.") == DialogResult.Yes)
            {
                if (Them == true)
                {
                    for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                    {
                        if (bool.Parse(dtNangBacChuyenNgach.Rows[i]["Chon"].ToString()) == true)
                        {
                            DataRow dr = dtNangBacChuyenNgach.Rows[i];
                            dtNangBacChuyenNgach.Rows.Remove(dr);
                            i = -1;
                        }
                    }
                }
                if (Sua == true)
                {
                    for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                    {
                        if (bool.Parse(dtNangBacChuyenNgach.Rows[i]["Chon"].ToString()) == true)
                        {
                            pNS_LuongInfo.NS_LuongID = int.Parse("0" + dtNangBacChuyenNgach.Rows[i]["NS_LuongID"]);
                            oBLuong.Delete(pNS_LuongInfo);
                            DataRow dr = dtNangBacChuyenNgach.Rows[i];
                            dtNangBacChuyenNgach.Rows.Remove(dr);
                            i = -1;
                        }
                    }
                }
            }
        }

        private NS_LuongInfo GetpLuong(DataRow dr, int IDNS_SoQuyetDinh)
        {
            pNS_LuongInfo.NS_LuongID = int.Parse("0" + dr["NS_LuongID"]);
            pNS_LuongInfo.IDNS_GiaoVien = int.Parse("0" + dr["NS_GiaoVienID"]);
            pNS_LuongInfo.IDNS_SoQuyetDinh = IDNS_SoQuyetDinh;
            pNS_LuongInfo.CongViecDamNhiem = txtCongViecDamNhiem.Text;
            pNS_LuongInfo.IDNS_NgachCongChuc = int.Parse("0" + cmbNgachCongChuc.EditValue);
            pNS_LuongInfo.BacLuong = int.Parse(cmbBacLuong.SelectedIndex.ToString()) + 1;
            pNS_LuongInfo.HeSoLuong = double.Parse("0" + txtHeSoLuong.Text);
            pNS_LuongInfo.PhanTramHuong = double.Parse("0" + txtPhanTramHuong.Text);
            if (dtpTuNgay.EditValue == null)
            {
                pNS_LuongInfo.TuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_LuongInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            if (dtpDenNgay.Checked == false)
            {
                pNS_LuongInfo.DenNgay = DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null);
            }
            else
            {
                pNS_LuongInfo.DenNgay = dtpDenNgay.Value;
            }
            return pNS_LuongInfo;
        }

        private NS_LuongInfo GetLuong(DataRow dr, int IDNS_SoQuyetDinh)
        {
            pNS_LuongInfo.IDNS_GiaoVien = int.Parse("0" + dr["NS_GiaoVienID"]);
            pNS_LuongInfo.IDNS_SoQuyetDinh = IDNS_SoQuyetDinh;
            pNS_LuongInfo.CongViecDamNhiem = "" + dr["CongViecDamNhiem"];
            pNS_LuongInfo.IDNS_NgachCongChuc = int.Parse(dr["IDNS_NgachCongChuc"].ToString());
            pNS_LuongInfo.BacLuong = int.Parse("0" + dr["BacLuong"].ToString());
            pNS_LuongInfo.HeSoLuong = double.Parse("0" + dr["HeSoLuong"].ToString());
            pNS_LuongInfo.PhanTramHuong = double.Parse("0" + dr["PhanTramHuong"].ToString());
            pNS_LuongInfo.TuNgay = DateTime.Parse(dr["TuNgay"].ToString());
            pNS_LuongInfo.DenNgay = DateTime.Parse(dr["DenNgay"].ToString());
            return pNS_LuongInfo;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            if (txtSoQuyetDinh.Text == "")
            {
                dxErrorProvider.SetError(txtSoQuyetDinh, "Số quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoQuyetDinh;
            }
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayRaQuyetDinh, "Ngày ra quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayRaQuyetDinh;
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

        private NS_SoQuyetDinhInfo GetpSoQuyetDinh()
        {
            pSoQuyetDinhInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                pSoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pSoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse(dtpNgayRaQuyetDinh.EditValue.ToString());
            }
            return pSoQuyetDinhInfo;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtNangBacChuyenNgach.Rows.Count == 0)
            {
                ThongBaoLoi("Không có dữ liệu để lưu.");
            }
            else
            {
                DataRow[] arrDr1 = dtNangBacChuyenNgach.Select("Chon = " + 1);
                if (arrDr1.Length == 0)
                {
                    ThongBaoLoi("Bạn chưa chọn cán bộ nào để nâng bậc - chuyển ngạch.");
                    return;
                }
                if (Them == true)
                {
                    if (!CheckValid()) return;
                    bool statusThem = false;
                    int IDNS_SoQuyetDinh = oBSoQuyetDinh.Add(GetpSoQuyetDinh());
                    for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                    {
                        if (bool.Parse(dtNangBacChuyenNgach.Rows[i]["Chon"].ToString()) == true)
                        {
                            oBLuong.Add(GetLuong(dtNangBacChuyenNgach.Rows[i], IDNS_SoQuyetDinh));
                            statusThem = true;
                        }
                    }
                    if (statusThem == true)
                    {
                        for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                        {
                            DataRow dr = dtNangBacChuyenNgach.Rows[i];
                            dtNangBacChuyenNgach.Rows.Remove(dr);
                            i = -1;
                        }
                        ThongBao("Lưu thông tin thành công.");
                    }
                    ClearText();
                    LoadSoQuyetDinh();
                    cmbChonSoQuyetDinh.EditValue = IDNS_SoQuyetDinh;
                }
                if (ThemBoSung == true)
                {
                    bool statusThemBoSung = false;
                    if (Sua == true)
                    {
                        DataTable dtbChanges = dtNangBacChuyenNgach.GetChanges();
                        if (dtbChanges == null)
                        {
                            return;
                        }
                        else
                        {
                            for (int i = 0; i < dtbChanges.Rows.Count; i++)
                            {
                                switch (dtbChanges.Rows[i].RowState)
                                {
                                    // Nếu là thêm mới
                                    case DataRowState.Added:
                                        if (bool.Parse(dtbChanges.Rows[i]["Chon"].ToString()) == true)
                                        {
                                            oBLuong.Add(GetLuong(dtbChanges.Rows[i], int.Parse("0" + cmbChonSoQuyetDinh.EditValue)));
                                            statusThemBoSung = true;
                                        }
                                        break;
                                }
                            }
                            if (statusThemBoSung == true)
                            {
                                ThongBao("Lưu thông tin thành công.");
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                        {
                            if (bool.Parse(dtNangBacChuyenNgach.Rows[i]["Chon"].ToString()) == true)
                            {
                                oBLuong.Add(GetLuong(dtNangBacChuyenNgach.Rows[i], int.Parse("0" + cmbChonSoQuyetDinh.EditValue)));
                                statusThemBoSung = true;
                            }
                        }
                        if (statusThemBoSung == true)
                        {
                            for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                            {
                                DataRow dr = dtNangBacChuyenNgach.Rows[i];
                                dtNangBacChuyenNgach.Rows.Remove(dr);
                                i = -1;
                            }
                            ThongBao("Lưu thông tin thành công.");
                        }
                    }
                    ClearText();
                }
                if (Sua == true && ThemBoSung == false)
                {
                    if (ThongBaoChon("Bạn có chắc muốn sửa những cán bộ đã chọn trong quyết định nâng bậc - chuyển ngạch này.") == DialogResult.Yes)
                    {
                        bool statusSua = false;
                        for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                        {
                            if (bool.Parse(dtNangBacChuyenNgach.Rows[i]["Chon"].ToString()) == true)
                            {
                                oBLuong.Update(GetpLuong(dtNangBacChuyenNgach.Rows[i], int.Parse("0" + cmbChonSoQuyetDinh.EditValue)));
                                statusSua = true;
                            }
                        }
                        if (statusSua == true)
                        {
                            ThongBao("Lưu thông tin thành công.");
                        }
                    }
                }
                Them = false;
                ThemBoSung = false;
                trvDonVi_FocusedNodeChanged(null, null);
                btnTimKiem_Click(null , null);
                dtNangBacChuyenNgach.AcceptChanges();
            }
        }

        private void grvGiaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvGiaoVien, "Chon", e);
        }

        private void grvNangBacChuyenNgach_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvNangBacChuyenNgach, "Chon", e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cmbChonSoQuyetDinh.EditValue != null)
            {
                dtNangBacChuyenNgach = oBLuong.GetBy_NS_SoQuyetDinhID(int.Parse("0" + cmbChonSoQuyetDinh.EditValue));
                dtNangBacChuyenNgach.Columns.Add("Chon", typeof(bool));
                dtNangBacChuyenNgach.Columns.Add("STT", typeof(int));
                for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                {
                    dtNangBacChuyenNgach.Rows[i]["Chon"] = 0;
                }
                grdNangBacChuyenNgach.DataSource = dtNangBacChuyenNgach;
                dtNangBacChuyenNgach.AcceptChanges();
            }
            Them = false;
            Sua = true;
        }

        private void btnInQuyetDinh_Click(object sender, EventArgs e)
        {
            if (dtNangBacChuyenNgach.Rows.Count > 0)
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
                    if(Them == true)
                        clsWord.AddText(aDoc, "QUYẾT ĐỊNH SỐ " + txtSoQuyetDinh.Text, 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                    if(Sua == true)
                        clsWord.AddText(aDoc, "QUYẾT ĐỊNH SỐ " + dtNangBacChuyenNgach.Rows[0]["SoQuyetDinh"], 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                    clsWord.AddText(aDoc, "Về việc nâng bậc lương - chuyển ngạch", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                    clsWord.AddText(aDoc, "đối với cán bộ công nhân viên chức", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);

                    // Noi dung trang
                    
                    // Insert qua trinh cong tac vao bang                    
                    clsWord.AddText(aDoc, "Điều 1. Nâng bậc lương, chuyển ngạch cho " + dtNangBacChuyenNgach.Rows.Count + " cán bộ, công nhân viên chức " + Program.TenTruong + "."
                                        , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    for (int i = 0; i < dtNangBacChuyenNgach.Rows.Count; i++)
                    {
                        dtNangBacChuyenNgach.Rows[i]["STT"] = i + 1;
                    }
                    clsWord.AddTable(aDoc, dtNangBacChuyenNgach, new string[] { "STT", "Họ và tên", "Mã ngạch", "Bậc lương", "Hệ số", "Mức hưởng(%)", "Từ ngày", "Đế ngày" },
                                                       new string[] { "STT", "HoTen", "MaNgachCongChuc", "BacLuong", "HeSoLuong", "PhanTramHuong", "TuNgay", "LuongDenNgay" });
                    clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    clsWord.AddText(aDoc, "Điều 2. Các ông (bà) Chánh Văn phòng, Vụ trưởng Vụ Tổ chức cán bộ, Vụ trưởng Vụ Kế hoạch - Tài chính, Hiệu trưởng " + Program.TenTruong + " và các ông, bà có tên trong danh sách tại Điều 1 chịu trách nhiệm thi hành Quyết định này./."
                                                     , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                    WordApp.Visible = true;
                    CloseWaitDialog();
                }
                catch (Exception ex)
                {
                    CloseWaitDialog();
                    ThongBaoLoi("Đang xuất dữ liệu, lỗi khi tắt chức năng này. " + ex.Message);
                }
            }
        }

        private void btnXoaQuyetDinh_Click(object sender, EventArgs e)
        {
            if (cmbChonSoQuyetDinh.EditValue == null)
            {
                ThongBaoLoi("Chọn số quyết định để xóa.");
                cmbChonSoQuyetDinh.Focus();
                return;
            }
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    int NS_SoQuyetDinhID = int.Parse("0" + cmbChonSoQuyetDinh.EditValue);
                    oBLuong.Delete_NS_SoQuyetDinhID(NS_SoQuyetDinhID);
                    // ghi log
                    if (NS_SoQuyetDinhID != 0 && Loaded)
                    {
                        string SoQuyetDinh = cmbChonSoQuyetDinh.GetColumnValue("SoQuyetDinh") + "";
                        GhiLog("Xóa số quyết định nâng bậc chuyển ngạch'" + SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    }
                    LoadSoQuyetDinh();
                    btnTimKiem_Click(null, null);
                    trvDonVi_FocusedNodeChanged(null, null);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnThemBoSung_Click(object sender, EventArgs e)
        {
            if (cmbChonSoQuyetDinh.EditValue == null)
            {
                ThongBaoLoi("Chọn số quyết định để thêm.");
                cmbChonSoQuyetDinh.Focus();
                return;
            }
            if (Sua == true)
            {
                InsertTable();
            }
            else
            {
                CreateTable();
                InsertTable();
            }
            Them = false;
            ThemBoSung = true;
        }
    }
}