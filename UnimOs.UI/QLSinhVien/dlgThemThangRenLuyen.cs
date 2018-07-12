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
    public partial class dlgThemThangRenLuyen : frmBase
    {
        private cBSV_ThangRenLuyenTrongKy oBSV_ThangRenLuyenTrongKy;
        private SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo;
        private DataTable dtThang;

        public dlgThemThangRenLuyen(ref DataTable _dtThang)
        {
            InitializeComponent();

            oBSV_ThangRenLuyenTrongKy = new cBSV_ThangRenLuyenTrongKy();
            pSV_ThangRenLuyenTrongKyInfo = new SV_ThangRenLuyenTrongKyInfo();
            this.DialogResult = DialogResult.Cancel;
            dtThang = _dtThang;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtThang.Select("Thang = " + cmbThang.Text).Length > 0)
            {
                ThongBao("Tháng bạn chọn đã có trong kỳ này.");
                return;
            }
            pSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc = Program.IDNamHoc;
            pSV_ThangRenLuyenTrongKyInfo.HocKy = Program.HocKy;
            pSV_ThangRenLuyenTrongKyInfo.Thang = int.Parse(cmbThang.Text);
            pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID = oBSV_ThangRenLuyenTrongKy.Add(pSV_ThangRenLuyenTrongKyInfo);
            DataRow drNew = dtThang.NewRow();
            oBSV_ThangRenLuyenTrongKy.ToDataRow(pSV_ThangRenLuyenTrongKyInfo, ref drNew);
            dtThang.Rows.Add(drNew);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}