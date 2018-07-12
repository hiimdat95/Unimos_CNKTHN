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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace UnimOs.UI 
{
    public partial class dlgThamSo : frmBase
    {
        private int KQHT_QuyCheID;
        private DataTable dtThamSoDuocCap, dtThamSoChuaCap;
        private cBKQHT_QuyChe oBKQHT_QuyChe;
        private cBKQHT_QuyChe_ThamSoQuyChe oBKQHT_QuyChe_ThamSoQuyChe;
        private KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo;

        public dlgThamSo(int mKQHT_QuyCheID)
        {
            InitializeComponent();
            this.Tag = "";
            oBKQHT_QuyChe = new cBKQHT_QuyChe();
            pKQHT_QuyChe_ThamSoQuyCheInfo = new KQHT_QuyChe_ThamSoQuyCheInfo();
            oBKQHT_QuyChe_ThamSoQuyChe = new cBKQHT_QuyChe_ThamSoQuyChe();
           
            KQHT_QuyCheID = mKQHT_QuyCheID;
        }

        private void dlgThamSo_Load(object sender, EventArgs e)
        {
            dtThamSoChuaCap = oBKQHT_QuyChe.GetThamSo_NotIn(KQHT_QuyCheID);
            if (dtThamSoChuaCap != null)
            {

                trlThamSoChuaCap.DataSource = dtThamSoChuaCap;
                trlThamSoChuaCap.ExpandAll();
                dtThamSoChuaCap.AcceptChanges();
            }

            dtThamSoDuocCap = oBKQHT_QuyChe.GetThamSo(KQHT_QuyCheID);
            trlThamSoDuocCap.DataSource = dtThamSoDuocCap;
            trlThamSoDuocCap.ExpandAll();

           
        }

        private void GetThamSoDuocCap(DataTable dtDuLieu)
        {
        //    DataTable dtTemp =  dtThamSoChuaCap.Copy();
            if (dtDuLieu != null)
            {
                for (int i = dtDuLieu.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow[] dr = dtThamSoChuaCap.Select("KQHT_QuyCheID =" + dtDuLieu.Rows[i]["KQHT_QuyCheID"].ToString());
                    DataRow[] drNew = dtThamSoDuocCap.Select("KQHT_QuyCheID =" + dtDuLieu.Rows[i]["KQHT_QuyCheID"].ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                           
                            dtThamSoDuocCap.ImportRow(dr[0]);
                        }
                        // neu ko con node con nua moi remove

                       dtThamSoChuaCap.Rows.Remove(dr[0]);
                       
                    }
                }
            
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtThamSoDuocCap != null)
            {
                if (KQHT_QuyCheID > 0)
                {

                // xoa het truoc du lieu truoc khi capnhat
                oBKQHT_QuyChe_ThamSoQuyChe.Delete_By_QuyChe(KQHT_QuyCheID);
                for (int i = 0; i < dtThamSoDuocCap.Rows.Count; i++)
                {
                  
                        try
                        {
                            // cap nhat du lieu
                            pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe = KQHT_QuyCheID;
                            pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe = int.Parse(dtThamSoDuocCap.Rows[i]["KQHT_ThamSoQuyCheID"].ToString());
                            pKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri = dtThamSoDuocCap.Rows[i]["GiaTri"].ToString();
                            oBKQHT_QuyChe_ThamSoQuyChe.Add(pKQHT_QuyChe_ThamSoQuyCheInfo);
                        }
                        catch
                        {
 
                        }
                    }
                    
                }
                ThongBao("Cập nhật thành công!");
                this.Tag = "1";
                this.Close();
            }
            else
                ThongBao("Bạn chưa thay đổi dữ liệu!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = trlThamSoChuaCap.Nodes.Count - 1; i >= 0; i--)
            {
                if (trlThamSoChuaCap.Nodes[i].CheckState == CheckState.Checked)
                {
                    DataRow[] dr = dtThamSoChuaCap.Select("KQHT_ThamSoQuyCheID =" + trlThamSoChuaCap.Nodes[i].GetValue("KQHT_ThamSoQuyCheID").ToString());
                    DataRow[] drNew = dtThamSoDuocCap.Select("KQHT_ThamSoQuyCheID =" + trlThamSoChuaCap.Nodes[i].GetValue("KQHT_ThamSoQuyCheID").ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                            // neu chua ton tai moi import
                            dtThamSoDuocCap.ImportRow(dr[0]);
                        }
                        dtThamSoChuaCap.Rows.Remove(dr[0]);
                    }

                }
            }
           
            trlThamSoDuocCap.RefreshDataSource();
        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = trlThamSoChuaCap.Nodes.Count - 1; i >= 0; i--)
            {
                if (trlThamSoChuaCap.Nodes[i].CheckState == CheckState.Checked)
                {
                    DataRow[] dr = dtThamSoDuocCap.Select("KQHT_QuyCheID =" + trlThamSoChuaCap.Nodes[i].GetValue("KQHT_QuyCheID").ToString());
                    DataRow[] drNew = dtThamSoChuaCap.Select("KQHT_QuyCheID =" + trlThamSoChuaCap.Nodes[i].GetValue("KQHT_QuyCheID").ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                            dtThamSoChuaCap.ImportRow(dr[0]);
                        }
                        dtThamSoDuocCap.Rows.Remove(dr[0]);
                    }

                }
            }
            
            trlThamSoChuaCap.RefreshDataSource();
        }


    

    }
}