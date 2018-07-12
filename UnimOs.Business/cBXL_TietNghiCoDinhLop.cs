using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_TietNghiCoDinhLop : cBBase
    {
        private cDXL_TietNghiCoDinhLop oDXL_TietNghiCoDinhLop;
        private XL_TietNghiCoDinhLopInfo oXL_TietNghiCoDinhLopInfo;

        public cBXL_TietNghiCoDinhLop()        
        {
            oDXL_TietNghiCoDinhLop = new cDXL_TietNghiCoDinhLop();
        }

        public DataTable Get(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)        
        {
            return oDXL_TietNghiCoDinhLop.Get(pXL_TietNghiCoDinhLopInfo);
        }

        public int Add(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
			int ID = 0;
            ID = oDXL_TietNghiCoDinhLop.Add(pXL_TietNghiCoDinhLopInfo);
            mErrorMessage = oDXL_TietNghiCoDinhLop.ErrorMessages;
            mErrorNumber = oDXL_TietNghiCoDinhLop.ErrorNumber;
            return ID;
        }

        public void Update(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            oDXL_TietNghiCoDinhLop.Update(pXL_TietNghiCoDinhLopInfo);
            mErrorMessage = oDXL_TietNghiCoDinhLop.ErrorMessages;
            mErrorNumber = oDXL_TietNghiCoDinhLop.ErrorNumber;
        }
        
        public void Delete(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            oDXL_TietNghiCoDinhLop.Delete(pXL_TietNghiCoDinhLopInfo);
            mErrorMessage = oDXL_TietNghiCoDinhLop.ErrorMessages;
            mErrorNumber = oDXL_TietNghiCoDinhLop.ErrorNumber;
        }

        public List<XL_TietNghiCoDinhLopInfo> GetList(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            List<XL_TietNghiCoDinhLopInfo> oXL_TietNghiCoDinhLopInfoList = new List<XL_TietNghiCoDinhLopInfo>();
            DataTable dtb = Get(pXL_TietNghiCoDinhLopInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_TietNghiCoDinhLopInfo = new XL_TietNghiCoDinhLopInfo();

                    oXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID = int.Parse(dtb.Rows[i]["XL_TietNghiCoDinhLopID"].ToString());
                    oXL_TietNghiCoDinhLopInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_TietNghiCoDinhLopInfo.Thu = int.Parse(dtb.Rows[i]["Thu"].ToString());
                    oXL_TietNghiCoDinhLopInfo.Tiet = int.Parse(dtb.Rows[i]["Tiet"].ToString());
                    oXL_TietNghiCoDinhLopInfo.Nghi = bool.Parse(dtb.Rows[i]["Nghi"].ToString());
                    oXL_TietNghiCoDinhLopInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    oXL_TietNghiCoDinhLopInfo.CaHoc = int.Parse(dtb.Rows[i]["CaHoc"].ToString());
                    
                    oXL_TietNghiCoDinhLopInfoList.Add(oXL_TietNghiCoDinhLopInfo);
                }
            }
            return oXL_TietNghiCoDinhLopInfoList;
        }
        
        public void ToDataRow(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo, ref DataRow dr)
        {

			dr[pXL_TietNghiCoDinhLopInfo.strXL_TietNghiCoDinhLopID] = pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID;
			dr[pXL_TietNghiCoDinhLopInfo.strIDDM_Lop] = pXL_TietNghiCoDinhLopInfo.IDDM_Lop;
			dr[pXL_TietNghiCoDinhLopInfo.strThu] = pXL_TietNghiCoDinhLopInfo.Thu;
			dr[pXL_TietNghiCoDinhLopInfo.strTiet] = pXL_TietNghiCoDinhLopInfo.Tiet;
			dr[pXL_TietNghiCoDinhLopInfo.strNghi] = pXL_TietNghiCoDinhLopInfo.Nghi;
			dr[pXL_TietNghiCoDinhLopInfo.strMoTa] = pXL_TietNghiCoDinhLopInfo.MoTa;
			dr[pXL_TietNghiCoDinhLopInfo.strCaHoc] = pXL_TietNghiCoDinhLopInfo.CaHoc;
        }
        
        public void ToInfo(ref XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo, DataRow dr)
        {

			pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID = int.Parse(dr[pXL_TietNghiCoDinhLopInfo.strXL_TietNghiCoDinhLopID].ToString());
			pXL_TietNghiCoDinhLopInfo.IDDM_Lop = int.Parse(dr[pXL_TietNghiCoDinhLopInfo.strIDDM_Lop].ToString());
			pXL_TietNghiCoDinhLopInfo.Thu = int.Parse(dr[pXL_TietNghiCoDinhLopInfo.strThu].ToString());
			pXL_TietNghiCoDinhLopInfo.Tiet = int.Parse(dr[pXL_TietNghiCoDinhLopInfo.strTiet].ToString());
			pXL_TietNghiCoDinhLopInfo.Nghi = bool.Parse(dr[pXL_TietNghiCoDinhLopInfo.strNghi].ToString());
			pXL_TietNghiCoDinhLopInfo.MoTa = dr[pXL_TietNghiCoDinhLopInfo.strMoTa].ToString();
			pXL_TietNghiCoDinhLopInfo.CaHoc = int.Parse(dr[pXL_TietNghiCoDinhLopInfo.strCaHoc].ToString());
        }
    }
}
