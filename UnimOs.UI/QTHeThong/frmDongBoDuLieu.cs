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
    public partial class frmDongBoDuLieu : frmBase
    {
        private cBHT_DongBo oBHT_DongBo;
        private HT_DongBoInfo pHT_DongBoInfo;
        private int SoThayDoi = 0;

        public frmDongBoDuLieu()
        {
            InitializeComponent();
            oBHT_DongBo = new cBHT_DongBo();
            pHT_DongBoInfo = new HT_DongBoInfo();
        }

        private void frmDongBoDuLieu_Load(object sender, EventArgs e)
        {
            DataTable dtDongBo = oBHT_DongBo.GetSoThayDoi();
            if (dtDongBo.Rows.Count > 0)
            {
                dtpTuNgay.EditValue = dtDongBo.Rows[0]["TuNgay"];
                dtpDenNgay.EditValue = dtDongBo.Rows[0]["DenNgay"];
                SoThayDoi = int.Parse(dtDongBo.Rows[0]["SoThayDoi"].ToString());
                lblSoThayDoi.Text = SoThayDoi.ToString();
                btnDongBo.Enabled = true;
                if (SoThayDoi == 0)
                    btnDongBo.Enabled = false;
            }
        }

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            try
            {
                CreateWaitDialog("Đang đồng bộ dữ liệu. Xin vui lòng chờ...", "Đồng bộ dữ liệu");
                string Host = Properties.Settings.Default.Host + "";
                string DatabaseName = Properties.Settings.Default.DatabaseName + "";
                string UserName = Properties.Settings.Default.UserName + "";
                string Password = Properties.Settings.Default.Password + "";
                if (Host != "" && DatabaseName != "" && UserName != "" && Password != "")
                {
                    // Lấy chuỗi kết nối đến DB máy chủ web trên host
                    string sqlConnection = "Data Source=" + Host + "; Initial Catalog=" + DatabaseName + "; User ID=" + UserName + "; Password=" + Password;
                    string Ac = oBHT_DongBo.ThucHienDongBo(sqlConnection);
                    CloseWaitDialog();
                    if (Ac == "TRUE")
                    {
                        frmDongBoDuLieu_Load(null, null);
                        ThongBao("Đồng bộ dữ liệu lên Website thành công!");
                    }
                    else
                        ThongBaoLoi("Có lỗi trong việc đồng bộ dữ liệu lên Website. Lỗi " + Ac);
                }
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}