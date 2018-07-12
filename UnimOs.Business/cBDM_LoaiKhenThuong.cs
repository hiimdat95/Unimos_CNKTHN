using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_LoaiKhenThuong : cBBase
    {
        private cDDM_LoaiKhenThuong oDDM_LoaiKhenThuong;
        private DM_LoaiKhenThuongInfo oDM_LoaiKhenThuongInfo;

        public cBDM_LoaiKhenThuong()        
        {
            oDDM_LoaiKhenThuong = new cDDM_LoaiKhenThuong();
        }

        public DataTable Get(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)        
        {
            return oDDM_LoaiKhenThuong.Get(pDM_LoaiKhenThuongInfo);
        }

        public int Add(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
			int ID = 0;
            ID = oDDM_LoaiKhenThuong.Add(pDM_LoaiKhenThuongInfo);
            mErrorMessage = oDDM_LoaiKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_LoaiKhenThuong.ErrorNumber;
            return ID;
        }

        public void Update(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            oDDM_LoaiKhenThuong.Update(pDM_LoaiKhenThuongInfo);
            mErrorMessage = oDDM_LoaiKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_LoaiKhenThuong.ErrorNumber;
        }
        
        public void Delete(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            oDDM_LoaiKhenThuong.Delete(pDM_LoaiKhenThuongInfo);
            mErrorMessage = oDDM_LoaiKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_LoaiKhenThuong.ErrorNumber;
        }

        public List<DM_LoaiKhenThuongInfo> GetList(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            List<DM_LoaiKhenThuongInfo> oDM_LoaiKhenThuongInfoList = new List<DM_LoaiKhenThuongInfo>();
            DataTable dtb = Get(pDM_LoaiKhenThuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_LoaiKhenThuongInfo = new DM_LoaiKhenThuongInfo();

                    oDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID = int.Parse(dtb.Rows[i]["DM_LoaiKhenThuongID"].ToString());
                    oDM_LoaiKhenThuongInfo.MaLoaiKhenThuong = dtb.Rows[i]["MaLoaiKhenThuong"].ToString();
                    oDM_LoaiKhenThuongInfo.TenLoaiKhenThuong = dtb.Rows[i]["TenLoaiKhenThuong"].ToString();
                    
                    oDM_LoaiKhenThuongInfoList.Add(oDM_LoaiKhenThuongInfo);
                }
            }
            return oDM_LoaiKhenThuongInfoList;
        }
        
        public void ToDataRow(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo, ref DataRow dr)
        {

			dr[pDM_LoaiKhenThuongInfo.strDM_LoaiKhenThuongID] = pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID;
			dr[pDM_LoaiKhenThuongInfo.strMaLoaiKhenThuong] = pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong;
			dr[pDM_LoaiKhenThuongInfo.strTenLoaiKhenThuong] = pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong;
        }
        
        public void ToInfo(ref DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo, DataRow dr)
        {

			pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID = int.Parse(dr[pDM_LoaiKhenThuongInfo.strDM_LoaiKhenThuongID].ToString());
			pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong = dr[pDM_LoaiKhenThuongInfo.strMaLoaiKhenThuong].ToString();
			pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong = dr[pDM_LoaiKhenThuongInfo.strTenLoaiKhenThuong].ToString();
        }
    }
}
