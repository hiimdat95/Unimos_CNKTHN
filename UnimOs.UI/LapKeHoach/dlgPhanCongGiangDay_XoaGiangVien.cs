using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class dlgPhanCongGiangDay_XoaGiangVien : frmBase
    {
        string[] arrHoTen, arrIDNS_GiaoVien, arrSoTiet;
        public string HoTens, IDNS_GiaoViens, SoTiets;
        DataTable dtGiangVien = new DataTable();

        public dlgPhanCongGiangDay_XoaGiangVien(string _HoTens, string _IDNS_GiaoViens, string _SoTiet)
        {
            InitializeComponent();
            HoTens = _HoTens + ",";
            IDNS_GiaoViens = "," + _IDNS_GiaoViens + ",";
            SoTiets = _SoTiet + ",";
            arrHoTen = _HoTens.Split(',');
            arrIDNS_GiaoVien = _IDNS_GiaoViens.Split(',');
            arrSoTiet = _SoTiet.Split(',');
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgPhanCongGiangDay_XoaGiangVien_Load(object sender, EventArgs e)
        {
            CreateTableGiangVien();
            grdGiangVien.DataSource = dtGiangVien;
            dtGiangVien.AcceptChanges();
        }

        private void CreateTableGiangVien()
        {
            dtGiangVien.Columns.Add("Chon", typeof(bool));
            dtGiangVien.Columns.Add("HoTen", typeof(string));
            dtGiangVien.Columns.Add("IDNS_GiangVien", typeof(string));
            dtGiangVien.Columns.Add("SoTiet", typeof(int));
            for (int i = 0; i < arrHoTen.Length; i++)
            {
                DataRow drNew = dtGiangVien.NewRow();
                drNew["Chon"] = false;
                drNew["HoTen"] = arrHoTen[i];
                drNew["IDNS_GiangVien"] = arrIDNS_GiaoVien[i];
                drNew["SoTiet"] = int.Parse(arrSoTiet[i]);
                dtGiangVien.Rows.Add(drNew);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtGiangVien.GetChanges();
            if (dtTemp != null)
            {
                string strIDNS_GiaoViens = "";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if ((bool)(dtTemp.Rows[i]["Chon"]))
                    {
                        strIDNS_GiaoViens += dtTemp.Rows[i]["IDNS_GiangVien"].ToString() + ",";
                        HoTens = HoTens.Replace(dtTemp.Rows[i]["HoTen"].ToString() + ",", "");
                        IDNS_GiaoViens = IDNS_GiaoViens.Replace("," + dtTemp.Rows[i]["IDNS_GiangVien"].ToString() + ",", ",");
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Tag = strIDNS_GiaoViens;
                this.Close();
            }
        }
    }
}