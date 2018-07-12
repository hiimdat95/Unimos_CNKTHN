using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_LoaiPhong : cBBase
    {
        private cDDM_LoaiPhong oDDM_LoaiPhong;
        private DM_LoaiPhongInfo oDM_LoaiPhongInfo;

        public cBDM_LoaiPhong()        
        {
            oDDM_LoaiPhong = new cDDM_LoaiPhong();
        }

        public DataTable Get(DM_LoaiPhongInfo pDM_LoaiPhongInfo)        
        {
            return oDDM_LoaiPhong.Get(pDM_LoaiPhongInfo);
        }

        public int Add(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
			int ID = 0;
            ID = oDDM_LoaiPhong.Add(pDM_LoaiPhongInfo);
            mErrorMessage = oDDM_LoaiPhong.ErrorMessages;
            mErrorNumber = oDDM_LoaiPhong.ErrorNumber;
            return ID;
        }

        public void Update(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            oDDM_LoaiPhong.Update(pDM_LoaiPhongInfo);
            mErrorMessage = oDDM_LoaiPhong.ErrorMessages;
            mErrorNumber = oDDM_LoaiPhong.ErrorNumber;
        }
        
        public void Delete(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            oDDM_LoaiPhong.Delete(pDM_LoaiPhongInfo);
            mErrorMessage = oDDM_LoaiPhong.ErrorMessages;
            mErrorNumber = oDDM_LoaiPhong.ErrorNumber;
        }

        public List<DM_LoaiPhongInfo> GetList(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            List<DM_LoaiPhongInfo> oDM_LoaiPhongInfoList = new List<DM_LoaiPhongInfo>();
            DataTable dtb = Get(pDM_LoaiPhongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_LoaiPhongInfo = new DM_LoaiPhongInfo();
                    

                    oDM_LoaiPhongInfo.DM_LoaiPhongID = int.Parse(dtb.Rows[i]["DM_LoaiPhongID"].ToString());
                    oDM_LoaiPhongInfo.MaLoaiPhong = dtb.Rows[i]["MaLoaiPhong"].ToString();
                    oDM_LoaiPhongInfo.TenLoaiPhong = dtb.Rows[i]["TenLoaiPhong"].ToString();
                    
                    oDM_LoaiPhongInfoList.Add(oDM_LoaiPhongInfo);
                }
            }
            return oDM_LoaiPhongInfoList;
        }
    }
}
