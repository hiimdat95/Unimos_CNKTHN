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
    public partial class frmLapTaiKhoanGiaoVien : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private DataTable dtTree, dtGiaoVien;
        private bool Loaded = false;

        public frmLapTaiKhoanGiaoVien()
        {
            InitializeComponent();
            oBDonVi = new cBNS_DonVi();
            pDonViInfo = new NS_DonViInfo();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
        }

        private void frmLapTaiKhoanGiaoVien_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        public void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetForLapTaiKhoan(IDDonVi, chkChuaLapTaiKhoan.Checked);
            grdGiaoVien.DataSource = dtGiaoVien;
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();
        }

        private void trvDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
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

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckValid()
        {
            if (cmbMatKhau.SelectedIndex < 0 && txtMatKhau.Text == "")
                return false;
            return true;
        }

        private void btnLapTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
            {
                ThongBao("Bạn phải nhập mật khẩu mặc định cho Giáo viên.");
                return;
            }
            if (dtGiaoVien != null && dtGiaoVien.Rows.Count > 0)
            {
                Lib.clsVietToEn clsConvert = new Lib.clsVietToEn();
                Lib.clsStringHelper clsString=new Lib.clsStringHelper();

                /*
                if (cmbTenDangNhap.SelectedIndex == 0)
                {
                    string strTenVietTats = "";
                    // Tên đăng nhập là Tên viết tắt của GV
                    foreach (DataRow dr in dtGiaoVien.Rows)
                    {
                        strTenVietTats += clsString.FormatTenVietTat(dr["HoTen"].ToString()) + ";";
                    }
                    strTenVietTats = clsConvert.ConvertVietToEn(strTenVietTats.Remove(strTenVietTats.Length - 1)).ToLower();
                    string[] arrStr = strTenVietTats.Split(';');
                    for (int i = 0; i < dtGiaoVien.Rows.Count; i++)
                    {
                        dtGiaoVien.Rows[i]["Username"] = arrStr[i];
                        if (cmbMatKhau.SelectedIndex < 0)
                            dtGiaoVien.Rows[i]["Password"] = Lib.clsAuthentication.Encrypt(txtMatKhau.Text.Trim());
                        else
                            dtGiaoVien.Rows[i]["Password"] = Lib.clsAuthentication.Encrypt(dtGiaoVien.Rows[i]["MaGiaoVien"].ToString() + txtMatKhau.Text.Trim());
                    }
                }
                else
                {
                    foreach (DataRow dr in dtGiaoVien.Rows)
                    {
                        dr["Username"] = dr["MaGiaoVien"];
                        if (cmbMatKhau.SelectedIndex < 0)
                            dr["Password"] = Lib.clsAuthentication.Encrypt(txtMatKhau.Text.Trim());
                        else
                            dr["Password"] = Lib.clsAuthentication.Encrypt(dr["MaGiaoVien"].ToString() + txtMatKhau.Text.Trim());
                    }
                }
                */

                int selectedIndex = grvGiaoVien.GetSelectedRows()[0];
                string userName = "";

                if (cmbTenDangNhap.SelectedIndex == 0)
                {
                    // Tên đăng nhập là Tên viết tắt của GV
                    userName += clsString.FormatTenVietTat(dtGiaoVien.Rows[selectedIndex]["HoTen"].ToString());
                    userName = clsConvert.ConvertVietToEn(userName).ToLower();

                    grvGiaoVien.GetDataRow(selectedIndex)["Username"] = userName;
                }
                else
                {
                    grvGiaoVien.GetDataRow(selectedIndex)["Username"] = dtGiaoVien.Rows[selectedIndex]["MaGiaoVien"];
                }

                if (cmbMatKhau.SelectedIndex < 0)
                {
                    grvGiaoVien.GetDataRow(selectedIndex)["Password"] =
                        Lib.clsAuthentication.Encrypt(txtMatKhau.Text.Trim());
                }
                else
                {
                    grvGiaoVien.GetDataRow(selectedIndex)["Password"] =
                        Lib.clsAuthentication.Encrypt(dtGiaoVien.Rows[selectedIndex]["MaGiaoVien"].ToString() +
                                                      txtMatKhau.Text.Trim());
                }
            }
            else
                ThongBao("Chưa có giáo viên nào để lập mã.");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtGiaoVien == null)
            {
                ThongBao("Không có giáo viên nào để lưu.");
                return;
            }
            DataTable dtChange = dtGiaoVien.GetChanges();
            if (dtChange != null)
            {
                oBGiaoVien.UpdateTaiKhoan(ref dtGiaoVien);
                grdGiaoVien.RefreshDataSource();
                ThongBao("Cập nhật tài khoản giáo viên thành công.");
            }
            else
                ThongBao("Không có sự thay đổi về tài khoản giáo viên.");
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                try
                {
                    var cloneData = dtGiaoVien.Copy();
                    CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");

                    foreach (DataRow dr in cloneData.Rows)
                    {
                        if ("" + dr["Password"] != "")
                            dr["Password"] = Lib.clsAuthentication.Decrypt("" + dr["Password"]);
                    }

                    Lib.clsExportToWord cls = new Lib.clsExportToWord();
                    Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                    Microsoft.Office.Interop.Word.Document aDoc = null;

                    cls.InitWord(WordApp, ref aDoc, 12);
                    cls.AddText(aDoc, "Danh sách giảng viên được cấp quyền", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter, 16);

                    cls.AddText(aDoc, "\tĐơn vi: " + pDonViInfo.TenDonVi, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);

                    cls.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                    cls.AddTable(aDoc, cloneData, new string[] { "Mã giáo viên", "Họ và tên", "Ngày sinh", "Tên đăng nhập", "Mật khẩu" },
                        new string[] { "MaGiaoVien", "HoTen", "NgaySinh", "Username", "Password" });
                    WordApp.Visible = true;
                    CloseWaitDialog();
                }
                catch
                {
                    CloseWaitDialog();
                }
            }
            else
                ThongBao("Không có danh sách giảng viên.");
        }

        private void btnGiaoVuKhoa_Click(object sender, EventArgs e)
        {
            if (grvGiaoVien.FocusedRowHandle >= 0)
            {
                DataRow dr = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                int[] arrIDChecked = null;
                if ("" + dr["IDDM_Khoa_GiaoVu"] != "")
                {
                    arrIDChecked = new int[1];
                    arrIDChecked[0] = int.Parse(dr["IDDM_Khoa_GiaoVu"].ToString());
                }
                dlgChonKhoa dlg = new dlgChonKhoa(false, arrIDChecked);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    oBGiaoVien.UpdateIDDM_Khoa_GiaoVu(dlg.arrIDChecked[0], int.Parse(dr["NS_GiaoVienID"].ToString()));
                    trvDonVi_FocusedNodeChanged(null, null);
                }
            }
        }

        private void chkChuaLapTaiKhoan_CheckedChanged(object sender, EventArgs e)
        {
            trvDonVi_FocusedNodeChanged(null, null);
        }
    }
}