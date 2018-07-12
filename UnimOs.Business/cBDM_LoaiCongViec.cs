using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_LoaiCongViec : cBBase
    {
        private cDDM_LoaiCongViec oDDM_LoaiCongViec;
        private DM_LoaiCongViecInfo oDM_LoaiCongViecInfo;

        public cBDM_LoaiCongViec()        
        {
            oDDM_LoaiCongViec = new cDDM_LoaiCongViec();
        }

        public DataTable Get(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)        
        {
            return oDDM_LoaiCongViec.Get(pDM_LoaiCongViecInfo);
        }

        public int Add(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
			int ID = 0;
            ID = oDDM_LoaiCongViec.Add(pDM_LoaiCongViecInfo);
            mErrorMessage = oDDM_LoaiCongViec.ErrorMessages;
            mErrorNumber = oDDM_LoaiCongViec.ErrorNumber;
            return ID;
        }

        public void Update(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            oDDM_LoaiCongViec.Update(pDM_LoaiCongViecInfo);
            mErrorMessage = oDDM_LoaiCongViec.ErrorMessages;
            mErrorNumber = oDDM_LoaiCongViec.ErrorNumber;
        }
        
        public void Delete(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            oDDM_LoaiCongViec.Delete(pDM_LoaiCongViecInfo);
            mErrorMessage = oDDM_LoaiCongViec.ErrorMessages;
            mErrorNumber = oDDM_LoaiCongViec.ErrorNumber;
        }

        public List<DM_LoaiCongViecInfo> GetList(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            List<DM_LoaiCongViecInfo> oDM_LoaiCongViecInfoList = new List<DM_LoaiCongViecInfo>();
            DataTable dtb = Get(pDM_LoaiCongViecInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_LoaiCongViecInfo = new DM_LoaiCongViecInfo();

                    oDM_LoaiCongViecInfo.DM_LoaiCongViecID = int.Parse(dtb.Rows[i]["DM_LoaiCongViecID"].ToString());
                    oDM_LoaiCongViecInfo.TenLoaiCongViec = dtb.Rows[i]["TenLoaiCongViec"].ToString();
                    oDM_LoaiCongViecInfo.SoLuong = double.Parse(dtb.Rows[i]["SoLuong"].ToString());
                    oDM_LoaiCongViecInfo.DonVi = dtb.Rows[i]["DonVi"].ToString();
                    oDM_LoaiCongViecInfo.QuyChuan = double.Parse(dtb.Rows[i]["QuyChuan"].ToString());
                    
                    oDM_LoaiCongViecInfoList.Add(oDM_LoaiCongViecInfo);
                }
            }
            return oDM_LoaiCongViecInfoList;
        }
        
        public void ToDataRow(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo, ref DataRow dr)
        {

			dr[pDM_LoaiCongViecInfo.strDM_LoaiCongViecID] = pDM_LoaiCongViecInfo.DM_LoaiCongViecID;
			dr[pDM_LoaiCongViecInfo.strTenLoaiCongViec] = pDM_LoaiCongViecInfo.TenLoaiCongViec;
			dr[pDM_LoaiCongViecInfo.strSoLuong] = pDM_LoaiCongViecInfo.SoLuong;
			dr[pDM_LoaiCongViecInfo.strDonVi] = pDM_LoaiCongViecInfo.DonVi;
			dr[pDM_LoaiCongViecInfo.strQuyChuan] = pDM_LoaiCongViecInfo.QuyChuan;
        }
        
        public void ToInfo(ref DM_LoaiCongViecInfo pDM_LoaiCongViecInfo, DataRow dr)
        {

			pDM_LoaiCongViecInfo.DM_LoaiCongViecID = int.Parse(dr[pDM_LoaiCongViecInfo.strDM_LoaiCongViecID].ToString());
			pDM_LoaiCongViecInfo.TenLoaiCongViec = dr[pDM_LoaiCongViecInfo.strTenLoaiCongViec].ToString();
            pDM_LoaiCongViecInfo.SoLuong = double.Parse(dr[pDM_LoaiCongViecInfo.strSoLuong].ToString());
			pDM_LoaiCongViecInfo.DonVi = dr[pDM_LoaiCongViecInfo.strDonVi].ToString();
            pDM_LoaiCongViecInfo.QuyChuan = double.Parse(dr[pDM_LoaiCongViecInfo.strQuyChuan].ToString());
        }
    }
}
