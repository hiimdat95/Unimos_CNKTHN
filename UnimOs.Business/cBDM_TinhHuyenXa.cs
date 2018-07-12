using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TinhHuyenXa : cBBase
    {
        private cDDM_TinhHuyenXa oDDM_TinhHuyenXa;
        private DM_TinhHuyenXaInfo oDM_TinhHuyenXaInfo;

        public cBDM_TinhHuyenXa()        
        {
            oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
        }

        public DataTable Get(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)        
        {
            return oDDM_TinhHuyenXa.Get(pDM_TinhHuyenXaInfo);
        }

        public DataTable GetByCap(int Level, int ParentID)
        {
            return oDDM_TinhHuyenXa.GetByCap(Level, ParentID);
        }

        public DataTable GetTinh(int DM_TinhHuyenXaID)
        {
            return oDDM_TinhHuyenXa.GetTinh(DM_TinhHuyenXaID);
        }

        /// <summary>
        /// Hàm trả về tree
        /// </summary>
        /// <returns></returns>
        public DataTable GetTree()
        {
            return oDDM_TinhHuyenXa.GetTree();
        }

        public string CheckExistByMa(string Mas)
        {
            return oDDM_TinhHuyenXa.CheckExistByMa(Mas);
        }

        public int Add(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
			int ID = 0;
            ID = oDDM_TinhHuyenXa.Add(pDM_TinhHuyenXaInfo);
            mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
            mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
            return ID;
        }

        public int AddByImport(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo, string MaCha)
        {
            int ID = 0;
            ID = oDDM_TinhHuyenXa.AddByImport(pDM_TinhHuyenXaInfo, MaCha);
            mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
            mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
            return ID;
        }

        public void Update(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            oDDM_TinhHuyenXa.Update(pDM_TinhHuyenXaInfo);
            mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
            mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
        }
        
        public void Delete(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            oDDM_TinhHuyenXa.Delete(pDM_TinhHuyenXaInfo);
            mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
            mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
        }

        public List<DM_TinhHuyenXaInfo> GetList(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            List<DM_TinhHuyenXaInfo> oDM_TinhHuyenXaInfoList = new List<DM_TinhHuyenXaInfo>();
            DataTable dtb = Get(pDM_TinhHuyenXaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
                    

                    oDM_TinhHuyenXaInfo.DM_TinhHuyenXaID = int.Parse(dtb.Rows[i]["DM_TinhHuyenXaID"].ToString());
                    oDM_TinhHuyenXaInfo.Ma = dtb.Rows[i]["Ma"].ToString();
                    oDM_TinhHuyenXaInfo.Ten = dtb.Rows[i]["Ten"].ToString();
                    oDM_TinhHuyenXaInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
                    oDM_TinhHuyenXaInfo.Level = int.Parse(dtb.Rows[i]["Level"].ToString());
                    
                    oDM_TinhHuyenXaInfoList.Add(oDM_TinhHuyenXaInfo);
                }
            }
            return oDM_TinhHuyenXaInfoList;
        }
    }
}
