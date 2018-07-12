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
    public partial class frmLop_MonThiTotNghiep : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtMon,dtMonDaChon;
        private KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private int IDDM_Lop = 0;

        public frmLop_MonThiTotNghiep()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
            pKQHT_MonThiTotNghiep_LopInfo = new KQHT_MonThiTotNghiep_LopInfo();
        }

        private void frmLop_MonThiTotNghiep_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }
        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            if (IDDM_Lop > 0)
            {
                LoadMon_Lop();
            }
            else
            {
                grdMonDaChon.DataSource = null;
                grdMon.DataSource = null;
            }
        }
        private void LoadMon_Lop()
        {
            dtMon = oBKQHT_MonThiTotNghiep_Lop.GetNotIn_Mon(IDDM_Lop);
            grdMon.DataSource = dtMon;
            dtMon.AcceptChanges();

            dtMonDaChon = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_Lop);
            grdMonDaChon.DataSource = dtMonDaChon;
            dtMonDaChon.AcceptChanges();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtMon.GetChanges();
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if ((bool)(dtTemp.Rows[i]["Chon"]) == true)
                    {
                        // add mon
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = IDDM_Lop;
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dtTemp.Rows[i]["DM_MonHocID"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = double.Parse("0" + dtTemp.Rows[i]["SoHocTrinh"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dtTemp.Rows[i]["TinhDiem"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_NamHoc = Program.IDNamHoc;
                        oBKQHT_MonThiTotNghiep_Lop.Add(pKQHT_MonThiTotNghiep_LopInfo);
                    }
                }
                LoadMon_Lop();
                ThongBao("Thêm môn thành công!");
            }
            else
                ThongBao("Bạn phải chọn ít nhất một môn học!");
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtMonDaChon.GetChanges();
            if (dtTemp != null)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if ((bool)(dtTemp.Rows[i]["Chon"]) == true)
                        {
                            try
                            {
                                //xoa 1 mon
                                pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID = int.Parse(dtTemp.Rows[i]["KQHT_MonThiTotNghiep_LopID"].ToString());
                                oBKQHT_MonThiTotNghiep_Lop.Delete(pKQHT_MonThiTotNghiep_LopInfo);
                            }
                            catch
                            { }
                        }
                    }
                    LoadMon_Lop();
                    ThongBao("Xóa môn thành công!");
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất một môn học!");
        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (dtMonDaChon.Rows.Count > 0)
            {
                dlgMonTotNghiep_ApDungLopKhac dlg = new dlgMonTotNghiep_ApDungLopKhac(pDM_LopInfo,dtMonDaChon);
                dlg.ShowDialog();
            }
            else
                ThongBao("Bạn chưa thêm môn học cho lớp này!");
        }

        private void grvMon_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvMon, "Chon", e);
        }

        private void grvMonDaChon_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvMonDaChon, "Chon", e);
        }
    }
}