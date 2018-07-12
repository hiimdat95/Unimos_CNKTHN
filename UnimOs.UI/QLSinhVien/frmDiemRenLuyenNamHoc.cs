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
    public partial class frmDiemRenLuyenNamHoc : frmBase
    {
        private cBSV_DiemRenLuyen oBSV_DiemRenLuyen;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtDiemRenLuyen, dtXepLoaiRenLuyen;

        public frmDiemRenLuyenNamHoc()
        {
            InitializeComponent();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_DiemRenLuyen = new cBSV_DiemRenLuyen();
        }

        private void frmDiemRenLuyenNamHoc_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtXepLoaiRenLuyen = LoadXepLoaiRenLuyen();
            repositoryCmbXepLoaiKy.DataSource = dtXepLoaiRenLuyen;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            LoadDiemRenLuyen();
        }

        private void LoadDiemRenLuyen()
        {
            dtDiemRenLuyen = oBSV_DiemRenLuyen.GetByLop(pDM_LopInfo.DM_LopID, Program.IDNamHoc);
            if (!dtDiemRenLuyen.Columns.Contains("HoVa"))
                dtDiemRenLuyen.Columns.Add("HoVa", typeof(string));
            if (!dtDiemRenLuyen.Columns.Contains("TenSV"))
                dtDiemRenLuyen.Columns.Add("TenSV", typeof(string));
            string Ho_Dem = "";
            foreach (DataRow dr in dtDiemRenLuyen.Rows)
            {
                dr["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref Ho_Dem);
                dr["HoVa"] = Ho_Dem;
            }
            grdDiemRenLuyen.DataSource = dtDiemRenLuyen;
            dtDiemRenLuyen.AcceptChanges();
        }

        private void bgrvDiemRenLuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtDiemRenLuyen == null)
                return;
            DataTable dtChange = dtDiemRenLuyen.GetChanges();
            if (dtChange != null)
            {
                foreach (DataRow dr in dtChange.Rows)
                {
                    oBSV_DiemRenLuyen.UpdateChange(int.Parse(dr["SV_SinhVienID"].ToString()), Program.IDNamHoc, 3,
                        "" + dr["SoDiemCaNam"] == "" ? -1 : double.Parse(dr["SoDiemCaNam"].ToString()),
                        "" + dr["IDDM_XepLoaiRenLuyenCaNam"] == "" ? 0 : int.Parse(dr["IDDM_XepLoaiRenLuyenCaNam"].ToString()), "" + dr["NhanXetCaNam"]);
                }
            }

            LuuThanhCong();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(bgrvDiemRenLuyen);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtDiemRenLuyen.GetChanges() != null)
            {
                if (ThongBaoChon("Dữ liệu đã thay đổi. Bạn có thực sự muốn thoát không ?") != DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        private void repositoryCmbXepLoaiKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (bgrvDiemRenLuyen.FocusedColumn == grcXepLoaiCaNam)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    (bgrvDiemRenLuyen.ActiveEditor as LookUpEdit).ClosePopup();
                    (bgrvDiemRenLuyen.ActiveEditor as BaseEdit).EditValue = null;
                }
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            double Diem;
            foreach(DataRow dr in dtDiemRenLuyen.Rows)
            {
                Diem = Math.Round((double.Parse("0" + dr["SoDiemKy1"]) + 2 * (double.Parse("0" + dr["SoDiemKy2"]))) / 3, 0, MidpointRounding.AwayFromZero);
                dr["SoDiemCaNam"] = Diem;

                for (int j = 0; j < dtXepLoaiRenLuyen.Rows.Count; j++)
                {
                    if (Diem >= double.Parse(dtXepLoaiRenLuyen.Rows[j]["TuDiem"].ToString()))
                    {
                        dr["IDDM_XepLoaiRenLuyenCaNam"] = dtXepLoaiRenLuyen.Rows[j]["DM_XepLoaiRenLuyenID"];
                        break;
                    }
                }
            }
            ThongBao("Tổng hợp thành công.");
        }
    }
}