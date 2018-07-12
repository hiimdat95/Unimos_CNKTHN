using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_KeHoachThucHanhKyHieu : cBBase
    {
        private cDXL_KeHoachThucHanhKyHieu oDXL_KeHoachThucHanhKyHieu;
        private XL_KeHoachThucHanhKyHieuInfo oXL_KeHoachThucHanhKyHieuInfo;

        public cBXL_KeHoachThucHanhKyHieu()        
        {
            oDXL_KeHoachThucHanhKyHieu = new cDXL_KeHoachThucHanhKyHieu();
        }

        public DataTable Get(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)        
        {
            return oDXL_KeHoachThucHanhKyHieu.Get(pXL_KeHoachThucHanhKyHieuInfo);
        }

        public int Add(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
			int ID = 0;
            ID = oDXL_KeHoachThucHanhKyHieu.Add(pXL_KeHoachThucHanhKyHieuInfo);
            mErrorMessage = oDXL_KeHoachThucHanhKyHieu.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhKyHieu.ErrorNumber;
            return ID;
        }

        public void Update(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            oDXL_KeHoachThucHanhKyHieu.Update(pXL_KeHoachThucHanhKyHieuInfo);
            mErrorMessage = oDXL_KeHoachThucHanhKyHieu.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhKyHieu.ErrorNumber;
        }
        
        public void Delete(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            oDXL_KeHoachThucHanhKyHieu.Delete(pXL_KeHoachThucHanhKyHieuInfo);
            mErrorMessage = oDXL_KeHoachThucHanhKyHieu.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhKyHieu.ErrorNumber;
        }

        public List<XL_KeHoachThucHanhKyHieuInfo> GetList(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            List<XL_KeHoachThucHanhKyHieuInfo> oXL_KeHoachThucHanhKyHieuInfoList = new List<XL_KeHoachThucHanhKyHieuInfo>();
            DataTable dtb = Get(pXL_KeHoachThucHanhKyHieuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_KeHoachThucHanhKyHieuInfo = new XL_KeHoachThucHanhKyHieuInfo();

                    oXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID = int.Parse(dtb.Rows[i]["XL_KeHoachThucHanhKyHieuID"].ToString());
                    oXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_KeHoachThucHanhKyHieuInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oXL_KeHoachThucHanhKyHieuInfo.MauChu = int.Parse(dtb.Rows[i]["MauChu"].ToString());
                    oXL_KeHoachThucHanhKyHieuInfo.MauNen = int.Parse(dtb.Rows[i]["MauNen"].ToString());
                    
                    oXL_KeHoachThucHanhKyHieuInfoList.Add(oXL_KeHoachThucHanhKyHieuInfo);
                }
            }
            return oXL_KeHoachThucHanhKyHieuInfoList;
        }
        
        public void ToDataRow(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo, ref DataRow dr)
        {

			dr[pXL_KeHoachThucHanhKyHieuInfo.strXL_KeHoachThucHanhKyHieuID] = pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID;
			dr[pXL_KeHoachThucHanhKyHieuInfo.strIDDM_MonHoc] = pXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc;
			dr[pXL_KeHoachThucHanhKyHieuInfo.strKyHieu] = pXL_KeHoachThucHanhKyHieuInfo.KyHieu;
			dr[pXL_KeHoachThucHanhKyHieuInfo.strMauChu] = pXL_KeHoachThucHanhKyHieuInfo.MauChu;
			dr[pXL_KeHoachThucHanhKyHieuInfo.strMauNen] = pXL_KeHoachThucHanhKyHieuInfo.MauNen;
        }
        
        public void ToInfo(ref XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo, DataRow dr)
        {

			pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID = int.Parse(dr[pXL_KeHoachThucHanhKyHieuInfo.strXL_KeHoachThucHanhKyHieuID].ToString());
			pXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc = int.Parse(dr[pXL_KeHoachThucHanhKyHieuInfo.strIDDM_MonHoc].ToString());
			pXL_KeHoachThucHanhKyHieuInfo.KyHieu = dr[pXL_KeHoachThucHanhKyHieuInfo.strKyHieu].ToString();
			pXL_KeHoachThucHanhKyHieuInfo.MauChu = int.Parse(dr[pXL_KeHoachThucHanhKyHieuInfo.strMauChu].ToString());
			pXL_KeHoachThucHanhKyHieuInfo.MauNen = int.Parse(dr[pXL_KeHoachThucHanhKyHieuInfo.strMauNen].ToString());
        }
    }
}
