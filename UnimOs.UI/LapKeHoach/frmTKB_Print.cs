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

namespace UnimOs.UI
{
    public partial class frmTKB_Print : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBXL_SuKienTKB oBXL_SuKienTKB;

        public frmTKB_Print()
        {
            InitializeComponent();

            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBXL_SuKienTKB = new cBXL_SuKienTKB();
        }

        private void frmTKB_Print_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);

            tabInTKB_SelectedPageChanged(null, null);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if(pDM_LopInfo.DM_LopID>0)
                webBrowserLop.DocumentText = GenHTML(pDM_LopInfo.DM_LopID);
        }

        private void tabInTKB_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (tabInTKB.SelectedTabPage.Name == "xtraTabLop")
                {
                    if (pDM_LopInfo.DM_LopID > 0)
                        webBrowserLop.DocumentText = GenHTML(pDM_LopInfo.DM_LopID);
                }
            }
            catch
            {
                return;
            }
        }

        private string GenHTML(int IDDM_Lop)
        {
            string Content = File.ReadAllText(Application.StartupPath + "\\Template\\Temp_TKB_Lop.txt");

            Content = Content.Replace("@HocKyNamHoc@", ("HỌC KỲ " + Program.HocKy.ToString() + " NĂM HỌC " + Program.NamHoc).ToUpper());
            Content = Content.Replace("@TenLop@", pDM_LopInfo.TenLop.Replace(":", "").ToUpper());

            DataSet ds = oBXL_SuKienTKB.Get_TKBByIDDM_Lop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);

            if (ds.Tables[1].Rows.Count == 0)
                return "";

            StringBuilder tblMonKy = new StringBuilder("<tr>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Mã môn học</th>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Tên môn học</th>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Ký hiệu</th>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Số học trình</th>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Số tiết</th>");
            tblMonKy.Append("\n\t\t\t\t\t<th>Giáo viên giảng dạy</th>\n\t\t\t\t</tr>");

            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                tblMonKy.Append("\n\t\t\t\t<tr>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["MaMonHoc"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["TenMonHoc"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["KyHieuMon"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["SoHocTrinh"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["SoTiet"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t\t<td>" + dr["HoTen"] + "</td>");
                tblMonKy.Append("\n\t\t\t\t</tr>");
            }
            // Dua phan TKB vao view
            Content = Content.Replace("@TKB@", GenTKB(ds.Tables[1], ds.Tables[0]));

            // Dua bang mon ky vao view
            Content = Content.Replace("@MonKy@", tblMonKy.ToString());
            return Content;
        }

        private string GenTKB(DataTable dt, DataTable dtTKB)
        {
            StringBuilder Header = new StringBuilder();
            DataTable dtHeader = new DataTable();
            dtHeader.Columns.Add("Thu", typeof(string));
            dtHeader.Columns.Add("CaHoc", typeof(string));
            dtHeader.Columns.Add("Tiet", typeof(string));

            for (int i = 0; i < 4; i++)
            {
                dtHeader.Rows.Add(dtHeader.NewRow());
                dtHeader.Rows[i]["Thu"] = "Thứ";
                dtHeader.Rows[i]["CaHoc"] = "Ca";
                dtHeader.Rows[i]["Tiet"] = "Số tiết";
            }

            DateTime TuNgay;
            string TuanThu;
            foreach (DataRow dr in dt.Rows)
            {
                TuanThu = dr["TuanThu"].ToString();
                dtHeader.Columns.Add("T" + TuanThu);
                TuNgay = DateTime.Parse(dr["TuNgay"].ToString());
                dtHeader.Rows[0]["T" + TuanThu] = "Tháng " + TuNgay.Month.ToString();
                dtHeader.Rows[1]["T" + TuanThu] = TuanThu;
                dtHeader.Rows[2]["T" + TuanThu] = TuNgay.Day.ToString();
                dtHeader.Rows[3]["T" + TuanThu] = (DateTime.Parse(dr["DenNgay"].ToString())).Day.ToString();
            }

            Header.Append("\n\t\t\t\t<tr>");
            Header.Append("\n\t\t\t\t\t<th rowspan='4'>Thứ</th>");
            //Header.Append("\n\t\t\t\t\t<th rowspan='4'>Ca</th>");
            //Header.Append("\n\t\t\t\t\t<th rowspan='4'>Số tiết</th>");

            int Count = 0;
            string Thang = dtHeader.Rows[0][3].ToString();
            for (int i = 3; i < dtHeader.Columns.Count; i++)
            {
                if (Thang != dtHeader.Rows[0][i].ToString())
                {
                    Header.Append("\n\t\t\t\t\t<th colspan='" + Count.ToString() + "'>" + Thang + "</th>");
                    Thang = dtHeader.Rows[0][i].ToString();
                    Count = 1;
                }
                else
                    Count++;
            }
            Header.Append("\n\t\t\t\t\t<th colspan='" + Count.ToString() + "'>" + Thang + "</th>");
            Header.Append("\n\t\t\t\t</tr>");

            for (int i = 1; i < dtHeader.Rows.Count; i++)
            {
                Header.Append("\n\t\t\t\t<tr>");
                for (int j = 3; j < dtHeader.Columns.Count; j++)
                {
                    Header.Append("\n\t\t\t\t\t<th>" + dtHeader.Rows[i][j] + "</th>");
                }
                Header.Append("\n\t\t\t\t</tr>");
            }

            DataRow drNew;
            for (int i = 2; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    drNew = dtHeader.NewRow();
                    drNew["Thu"] = i.ToString();
                    dtHeader.Rows.Add(drNew);
                }
            }
            int r;
            foreach (DataRow dr in dtTKB.Rows)
            {
                if (int.Parse(dr["Thu"].ToString()) >= 0 && int.Parse(dr["Thu"].ToString()) < 5)
                {
                    r = int.Parse(dr["Thu"].ToString()) * 2 + int.Parse(dr["NhomTiet"].ToString());
                    dtHeader.Rows[4 + r]["T" + dr["TuanThu"]] = dr["HienThi"].ToString();
                }
            }

            for (int i = 4; i < dtHeader.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Header.Append("\n\t\t\t\t<tr>");
                    Header.Append("\n\t\t\t\t\t<td rowspan='2'>" + dtHeader.Rows[i]["Thu"] + "</td>");
                    //Header.Append("\n\t\t\t\t\t<td rowspan='2'></td>");
                    //Header.Append("\n\t\t\t\t\t<td rowspan='2'></td>");
                }

                for (int j = 3; j < dtHeader.Columns.Count; j++)
                {
                    Header.Append("\n\t\t\t\t\t<td>" + dtHeader.Rows[i][j] + "</td>");
                }
                Header.Append("\n\t\t\t\t</tr>");
            }

            return Header.ToString();
        }
    }
}