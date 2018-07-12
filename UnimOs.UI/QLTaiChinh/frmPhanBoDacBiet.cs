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
    public partial class frmPhanBoDacBiet : frmBase
    {
        private DataTable dtDoiTuong,dtDoiTuongPhanBo;
        private DataRow dr;
        private cBTC_PhanBoQuyHocBong oBTC_PhanBoQuyHocBong;
        private TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo;

        public frmPhanBoDacBiet( DataRow mdr,ref  DataTable mdtDoiTuong, double mSoTienDaPhanBo)
        {
            InitializeComponent();

            dr = mdr;
            dtDoiTuong = mdtDoiTuong;
            if (dr != null)
            {
                txtTenLoaiQuy.Text = dr["TenLoaiQuy"].ToString();
                txtSoTien.Text = double.Parse(dr["SoTien"].ToString()).ToString("N0");
            }
            txtSoTienDaPhanBo.Text = mSoTienDaPhanBo.ToString("N0");
            cmbDoiTuong.Properties.DataSource = dtDoiTuong;
          
            oBTC_PhanBoQuyHocBong = new cBTC_PhanBoQuyHocBong();
            pTC_PhanBoQuyHocBongInfo = new TC_PhanBoQuyHocBongInfo();
        }

        private void GetDoiTuongPhanBo()
        {
            dtDoiTuongPhanBo = oBTC_PhanBoQuyHocBong.GetByQuyHocBong(int.Parse(dr["TC_QuyHocBongID"].ToString()), Program.IDNamHoc, Program.HocKy,1);
            grdDoiTuong.DataSource = dtDoiTuongPhanBo;
            dtDoiTuongPhanBo.AcceptChanges();
        }

        private void frmPhanBoDacBiet_Load(object sender, EventArgs e)
        {
            if (dr != null)
            {
                GetDoiTuongPhanBo();
            }
        }

        private void txtSoTienDaPhanBo_EditValueChanged(object sender, EventArgs e)
        {
            txtSoTienConLai.Text = (double.Parse("0" + txtSoTien.Text.Replace(",", "")) - double.Parse("0" + txtSoTienDaPhanBo.Text.Replace(",", ""))).ToString("N0");
        }
       
        private void grvDoiTuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDoiTuong.RowCount > 0)
            {
                oBTC_PhanBoQuyHocBong.ToInfo( ref pTC_PhanBoQuyHocBongInfo, grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (grvDoiTuong.FocusedRowHandle >= 0)
            {
                if (int.Parse("0" + grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle)["TC_PhanBoQuyHocBongID"].ToString()) > 0)
                {
                    if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
                    {
                        try
                        {
                            pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID = int.Parse("0" + grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle)["TC_PhanBoQuyHocBongID"].ToString());
                            oBTC_PhanBoQuyHocBong.Delete(pTC_PhanBoQuyHocBongInfo);
                            ThongBao("Xóa thành công!");
                            GetDoiTuongPhanBo();
                        }
                        catch
                        {
                            ThongBao("Dữ liệu đang dùng không thể xóa!");
                        }
                    }
                }
                
            }
            else
                ThongBao("Bạn chưa chọn đối tượng cần xóa!");
            //if (dtDoiTuong != null && dtDoiTuong.Rows.Count > 0)
            //{
            //    double TongTien = 0;
            //    foreach (DataRow mdr in dtDoiTuong.Rows)
            //    {
            //        if (double.Parse("0" + mdr["SoTien"]) > 0 && int.Parse(dr["TC_QuyHocBongID"].ToString())>0)
            //        {
            //            pTC_PhanBoQuyHocBongInfo.HocKy = Program.HocKy;
            //            pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc = Program.IDNamHoc;
            //            pTC_PhanBoQuyHocBongInfo.IDDM_Khoa = int.Parse(mdr["DM_KhoaID"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.IDDM_Lop = int.Parse(mdr["DM_LopID"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.IDDM_Nganh = int.Parse(mdr["DM_NganhID"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc = int.Parse(mdr["DM_KhoaHocID"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong = int.Parse(dr["TC_QuyHocBongID"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.PhanDacBiet = true;
            //            pTC_PhanBoQuyHocBongInfo.SoSinhVien = int.Parse(mdr["SoSinhVien"].ToString());
            //            pTC_PhanBoQuyHocBongInfo.SoTien = double.Parse(mdr["SoTien"].ToString());
            //            oBTC_PhanBoQuyHocBong.Add(pTC_PhanBoQuyHocBongInfo);
            //            TongTien += pTC_PhanBoQuyHocBongInfo.SoTien;
            //        }
            //    }
            //    txtSoTienConLai.Text = (double.Parse(txtSoTienConLai.Text.Replace(",", "")) + TongTien).ToString("N0");
            //    ThongBao("Lưu thành công!");
            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (double.Parse("0" + txtNhapSoTien.Text.Trim()) > 0 && cmbDoiTuong.EditValue != null)
            {
                pTC_PhanBoQuyHocBongInfo.HocKy = Program.HocKy;
                pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc = Program.IDNamHoc;
                pTC_PhanBoQuyHocBongInfo.IDDM_Khoa = int.Parse(cmbDoiTuong.GetColumnValue("DM_KhoaID").ToString());
                pTC_PhanBoQuyHocBongInfo.IDDM_Lop = int.Parse(cmbDoiTuong.GetColumnValue("DM_LopID").ToString());
                pTC_PhanBoQuyHocBongInfo.IDDM_Nganh = int.Parse(cmbDoiTuong.GetColumnValue("DM_NganhID").ToString());
                pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc = int.Parse(cmbDoiTuong.GetColumnValue("DM_KhoaHocID").ToString());
                pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong = int.Parse(dr["TC_QuyHocBongID"].ToString());
                pTC_PhanBoQuyHocBongInfo.PhanDacBiet = true;
                pTC_PhanBoQuyHocBongInfo.SoSinhVien = int.Parse(cmbDoiTuong.GetColumnValue("SoSinhVien").ToString());
                pTC_PhanBoQuyHocBongInfo.SoTien = double.Parse("0" + txtNhapSoTien.Text.Trim());
                oBTC_PhanBoQuyHocBong.Add(pTC_PhanBoQuyHocBongInfo);
                txtSoTienDaPhanBo.Text = (double.Parse(txtSoTienDaPhanBo.Text.Replace(",", "")) + pTC_PhanBoQuyHocBongInfo.SoTien).ToString("N0");
                ThongBao("Thêm thành công!");
                GetDoiTuongPhanBo();
                txtNhapSoTien.Text = "";
            }
            else
                ThongBao("Bạn chưa chọn đầy đủ thông tin đối tượng và số tiền!");

          
        }
    }
}