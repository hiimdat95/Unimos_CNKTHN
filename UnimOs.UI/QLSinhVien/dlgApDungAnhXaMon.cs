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
    public partial class dlgApDungAnhXaMon :frmBase
    {
        private DataRow dr;
        private cBSV_NhapHocLai oBSV_NhapHocLai;
        private SV_AnhXaMonInfo pSV_AnhXaMonInfo;
        private cBSV_AnhXaMon oBSV_AnhXaMon;
        private DataTable dtDaNhapHoc;

        public dlgApDungAnhXaMon(DataRow mdr)
        {
            InitializeComponent();
            oBSV_AnhXaMon = new cBSV_AnhXaMon();
            pSV_AnhXaMonInfo = new SV_AnhXaMonInfo();
            oBSV_NhapHocLai = new cBSV_NhapHocLai();
            dr = mdr;
        }

        private void dlgApDungAnhXaMon_Load(object sender, EventArgs e)
        {
            dtDaNhapHoc = oBSV_NhapHocLai.GetSinhVien(int.Parse(dr["IDDM_LopMoi"].ToString()));
            dtDaNhapHoc.DefaultView.RowFilter = "SV_SinhVienID not in (" + dr["SV_SinhVienID"].ToString() + ")";
            grdNhapHoc.DataSource = dtDaNhapHoc.DefaultView;
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            DataRow[] drTemp = dtDaNhapHoc.Select("Chon=1");
            if (drTemp.Length > 0)
            {
                if (ThongBaoChon("Bạn chắc chắn muốn thực hiện?") == DialogResult.Yes)
                { 
                    string ChuoiID="";
                    for (int i=0;i< drTemp.Length;i++)
                    {
                        ChuoiID += drTemp[i]["SV_SinhVienID"].ToString() + ",";
                    }
                    oBSV_AnhXaMon.ApDung(ChuoiID + "0", int.Parse(dr["SV_SinhVienID"].ToString()),int.Parse(dr["IDDM_LopMoi"].ToString()));
                    ThongBao("Áp dụng thành công!");
                    this.Close();
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}