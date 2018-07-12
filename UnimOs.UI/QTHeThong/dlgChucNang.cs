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
    public partial class dlgChucNang : frmBase
    {
        private int HT_UserID, HT_UserGroupID;
        private DataTable dtQuyenDuocCap, dtQuyenChuaCap;
        private cBHT_ChucNang oBHT_ChucNang;
        private cBHT_UserGroup_ChucNang oBNhom_ChucNang;
        private HT_UserGroup_ChucNangInfo pNhom_ChucNangInfo;
        private cBHT_User_ChucNang oBUser_ChucNang;
        private HT_User_ChucNangInfo pUser_ChucNangInfo;

        public dlgChucNang(int mHT_UserID, int mHT_UserGroupID)
        {
            InitializeComponent();
            this.Tag = "";
            oBHT_ChucNang = new cBHT_ChucNang();
            oBNhom_ChucNang = new cBHT_UserGroup_ChucNang();
            pNhom_ChucNangInfo = new HT_UserGroup_ChucNangInfo();
            pUser_ChucNangInfo = new HT_User_ChucNangInfo();
            oBUser_ChucNang = new cBHT_User_ChucNang();
            HT_UserID = mHT_UserID;
            HT_UserGroupID = mHT_UserGroupID;
        }

        private void dlgChucNang_Load(object sender, EventArgs e)
        {
            dtQuyenChuaCap = oBHT_ChucNang.GetNotIn(HT_UserGroupID, HT_UserID);
            if (dtQuyenChuaCap != null)
            {

                trlQuyenChuaCap.DataSource = dtQuyenChuaCap;
                trlQuyenChuaCap.ExpandAll();
                dtQuyenChuaCap.AcceptChanges();
            }

            dtQuyenDuocCap = oBHT_ChucNang.CreateTableTree();
            GetQuyenDuocCap(oBHT_ChucNang.GetIn(HT_UserGroupID, HT_UserID));
            trlQuyenDuocCap.DataSource = dtQuyenDuocCap;
            trlQuyenDuocCap.ExpandAll();

           
        }

        private void GetQuyenDuocCap(DataTable dtDuLieu)
        {
        //    DataTable dtTemp =  dtQuyenChuaCap.Copy();
            if (dtDuLieu != null)
            {
                for (int i = dtDuLieu.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow[] dr = dtQuyenChuaCap.Select("HT_ChucNangID =" + dtDuLieu.Rows[i]["HT_ChucNangID"].ToString());
                    DataRow[] drNew = dtQuyenDuocCap.Select("HT_ChucNangID =" + dtDuLieu.Rows[i]["HT_ChucNangID"].ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                            // neu chua ton tai moi import
                            GetParentID_QuyenDuocCap(int.Parse(dr[0]["ParentIDs"].ToString()));
                            dtQuyenDuocCap.ImportRow(dr[0]);
                        }
                        // neu ko con node con nua moi remove

                        DataRow[] drChuaCap = dtQuyenChuaCap.Select("ParentIDs =" + dr[0]["ID"].ToString());
                        if (drChuaCap.Length == 0 || drChuaCap == null)
                        {
                            dtQuyenChuaCap.Rows.Remove(dr[0]);
                        }
                    }
                }
                // xoa node cha
                Delete_Node(trlQuyenChuaCap, dtQuyenChuaCap);
              
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtQuyenDuocCap != null)
            {
                string strNotIn = "";
                if (HT_UserGroupID > 0)
                {
                    for (int i = 0; i < dtQuyenDuocCap.Rows.Count; i++)
                    {
                        try
                        {
                            pNhom_ChucNangInfo.IDHT_ChucNang = int.Parse(dtQuyenDuocCap.Rows[i]["HT_ChucNangID"].ToString());
                            pNhom_ChucNangInfo.Sua = bool.Parse(dtQuyenDuocCap.Rows[i]["Sua"].ToString());
                            pNhom_ChucNangInfo.Them = bool.Parse(dtQuyenDuocCap.Rows[i]["Them"].ToString());
                            pNhom_ChucNangInfo.Xoa = bool.Parse(dtQuyenDuocCap.Rows[i]["Xoa"].ToString());
                            pNhom_ChucNangInfo.Xem = true;
                            pNhom_ChucNangInfo.IDHT_UserGroup = HT_UserGroupID;
                            pNhom_ChucNangInfo.HT_UserGroup_ChucNangID = int.Parse(dtQuyenDuocCap.Rows[i]["GanQuyenID"].ToString());

                            if (pNhom_ChucNangInfo.HT_UserGroup_ChucNangID > 0)
                                oBNhom_ChucNang.Update(pNhom_ChucNangInfo);
                            else
                                oBNhom_ChucNang.Add(pNhom_ChucNangInfo);
                            strNotIn += pNhom_ChucNangInfo.IDHT_ChucNang.ToString() + ",";
                        }
                        catch
                        {

                        }
                    }
                    if (strNotIn != "")
                    {
                        strNotIn = strNotIn.Substring(0, strNotIn.Length - 1);
                        oBNhom_ChucNang.DeleteNotIn(pNhom_ChucNangInfo.IDHT_UserGroup, strNotIn);
                    }
                }
                else if (HT_UserID > 0)
                {
                    for (int i = 0; i < dtQuyenDuocCap.Rows.Count; i++)
                    {
                        try
                        {
                            pUser_ChucNangInfo.IDHT_ChucNang = int.Parse(dtQuyenDuocCap.Rows[i]["HT_ChucNangID"].ToString());
                            pUser_ChucNangInfo.IDHT_User = HT_UserID;
                            pUser_ChucNangInfo.Sua = bool.Parse(dtQuyenDuocCap.Rows[i]["Sua"].ToString());
                            pUser_ChucNangInfo.Them = bool.Parse(dtQuyenDuocCap.Rows[i]["Them"].ToString());
                            pUser_ChucNangInfo.Xoa = bool.Parse(dtQuyenDuocCap.Rows[i]["Xoa"].ToString());
                            pUser_ChucNangInfo.HT_User_ChucNangID = int.Parse(dtQuyenDuocCap.Rows[i]["GanQuyenID"].ToString());

                            if (pUser_ChucNangInfo.HT_User_ChucNangID > 0)
                                oBUser_ChucNang.Update(pUser_ChucNangInfo);
                            else
                                oBUser_ChucNang.Add(pUser_ChucNangInfo);
                            strNotIn += pUser_ChucNangInfo.IDHT_ChucNang + ",";
                        }
                        catch
                        {

                        }
                    }
                    if (strNotIn != "")
                    {
                        strNotIn = strNotIn.Substring(0, strNotIn.Length - 1);
                        oBUser_ChucNang.DeleteNotIn(pUser_ChucNangInfo.IDHT_User, strNotIn);
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
            List<TreeListNode> listNode = GetVisibleNodes(trlQuyenChuaCap);
            for (int i = listNode.Count - 1; i >= 0; i--)
            {
                if (listNode[i].CheckState == CheckState.Checked)
                {
                    DataRow[] dr = dtQuyenChuaCap.Select("HT_ChucNangID =" + listNode[i].GetValue("HT_ChucNangID").ToString());
                    DataRow[] drNew = dtQuyenDuocCap.Select("HT_ChucNangID =" + listNode[i].GetValue("HT_ChucNangID").ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                            // neu chua ton tai moi import
                            GetParentID_QuyenDuocCap(int.Parse(listNode[i].GetValue("ParentIDs").ToString()));
                            dtQuyenDuocCap.ImportRow(dr[0]);
                        }
                        dtQuyenChuaCap.Rows.Remove(dr[0]);
                    }

                }
            }
            // xoa node cha
            Delete_Node(trlQuyenChuaCap, dtQuyenChuaCap);
           
            trlQuyenDuocCap.RefreshDataSource();
            trlQuyenDuocCap.ExpandAll();
            trlQuyenChuaCap.ExpandAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TreeListNode> listNode = GetVisibleNodes(trlQuyenDuocCap);
            for (int i = listNode.Count - 1; i >= 0; i--)
            {
                if (listNode[i].CheckState == CheckState.Checked)
                {
                    DataRow[] dr = dtQuyenDuocCap.Select("HT_ChucNangID =" + listNode[i].GetValue("HT_ChucNangID").ToString());
                    DataRow[] drNew = dtQuyenChuaCap.Select("HT_ChucNangID =" + listNode[i].GetValue("HT_ChucNangID").ToString());
                    if (dr.Length > 0)
                    {
                        if (drNew.Length == 0 || drNew == null)
                        {
                            // neu chua ton tai moi import
                            GetParentID_QuyenChuaCap(int.Parse(listNode[i].GetValue("ParentIDs").ToString()));
                            dtQuyenChuaCap.ImportRow(dr[0]);
                        }
                        dtQuyenDuocCap.Rows.Remove(dr[0]);
                    }

                }
            }
            // xoa node cha
            Delete_Node(trlQuyenDuocCap, dtQuyenDuocCap);
            
            trlQuyenChuaCap.RefreshDataSource();
            trlQuyenChuaCap.ExpandAll();
            trlQuyenDuocCap.ExpandAll();
        }

        private void trlQuyenDuocCap_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void trlQuyenDuocCap_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void trlQuyenChuaCap_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void trlQuyenChuaCap_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        
        private void GetParentID_QuyenDuocCap(int ParentID)
        {
            // add ParentID
            DataRow[] dr = dtQuyenDuocCap.Select("ID =" + ParentID.ToString());
            if (dr.Length > 0)
                return;
            else
            {
                DataRow[] drNew = dtQuyenChuaCap.Select("ID =" + ParentID.ToString());
                if (drNew.Length > 0)
                {
                    dtQuyenDuocCap.ImportRow(drNew[0]);
                    GetParentID_QuyenDuocCap(int.Parse(drNew[0]["ParentIDs"].ToString()));
                }
                else
                    return;
            }

        }

        private void GetParentID_QuyenChuaCap(int ParentID)
        {
            // add ParentID
            DataRow[] dr = dtQuyenChuaCap.Select("ID =" + ParentID.ToString());
            if (dr.Length > 0)
                return;
            else
            {
                DataRow[] drNew = dtQuyenDuocCap.Select("ID =" + ParentID.ToString());
                if (drNew.Length > 0)
                {
                    dtQuyenChuaCap.ImportRow(drNew[0]);
                    GetParentID_QuyenChuaCap(int.Parse(drNew[0]["ParentIDs"].ToString()));
                }
                else
                    return;
            }

        }

        private void Delete_Node(TreeList mTree, DataTable dtTemp)
        {
            foreach (TreeListNode mTreeNode in mTree.Nodes)
            {
              //  if (mTreeNode.CheckState == CheckState.Checked)
               // {
                    if (mTreeNode.Nodes.Count == 0)
                    {
                        if (mTreeNode.GetValue("HT_ChucNangID").ToString() != "")
                        {
                            DataRow[] dr = dtTemp.Select("HT_ChucNangID =" + mTreeNode.GetValue("HT_ChucNangID").ToString());
                            if (dr.Length > 0)
                            {
                                dtTemp.Rows.Remove(dr[0]);
                            }
                        }
                    }
                    else
                        mTreeNode.Checked = false;
              //  }
            }
        }

        private List<TreeListNode> GetVisibleNodes(TreeList treeList)
        {

            List<TreeListNode> nodes = new List<TreeListNode>();

            int i = 0;

            for (i = 0; i < treeList.Nodes.Count; i++)
            {
               // nodes.Add(treeList.Nodes[i]);
                GetAllNode(treeList.Nodes[i], nodes);

            }

            return nodes;

        }

        private void GetAllNode(TreeListNode Node, List<TreeListNode> listNode)
        {

            List<TreeListNode> nodes = new List<TreeListNode>();

            if (Node.Nodes.Count > 0)
            {

                int i = 0;

                for (i = 0; i < Node.Nodes.Count; i++)
                {
                    listNode.Add(Node.Nodes[i]);
                    GetAllNode(Node.Nodes[i], listNode);
                }
            }
        }

        private void trlQuyenDuocCap_KeyDown(object sender, KeyEventArgs e)
        {
           if (trlQuyenDuocCap.FocusedColumn.FieldName == "Them" || trlQuyenDuocCap.FocusedColumn.FieldName == "Sua" || trlQuyenDuocCap.FocusedColumn.FieldName == "Xoa")
               CheckAllTree(dtQuyenDuocCap, trlQuyenDuocCap.FocusedColumn.FieldName, e);
        }
     
    }
}