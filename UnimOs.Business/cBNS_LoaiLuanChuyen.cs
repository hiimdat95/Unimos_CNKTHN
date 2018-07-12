using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_LoaiLuanChuyen : cBBase
    {
        private cDNS_LoaiLuanChuyen oDNS_LoaiLuanChuyen;
        private NS_LoaiLuanChuyenInfo oNS_LoaiLuanChuyenInfo;

        public cBNS_LoaiLuanChuyen()        
        {
            oDNS_LoaiLuanChuyen = new cDNS_LoaiLuanChuyen();
        }

        public DataTable Get(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)        
        {
            return oDNS_LoaiLuanChuyen.Get(pNS_LoaiLuanChuyenInfo);
        }

        public int Add(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
			int ID = 0;
            ID = oDNS_LoaiLuanChuyen.Add(pNS_LoaiLuanChuyenInfo);
            mErrorMessage = oDNS_LoaiLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_LoaiLuanChuyen.ErrorNumber;
            return ID;
        }

        public void Update(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            oDNS_LoaiLuanChuyen.Update(pNS_LoaiLuanChuyenInfo);
            mErrorMessage = oDNS_LoaiLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_LoaiLuanChuyen.ErrorNumber;
        }
        
        public void Delete(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            oDNS_LoaiLuanChuyen.Delete(pNS_LoaiLuanChuyenInfo);
            mErrorMessage = oDNS_LoaiLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_LoaiLuanChuyen.ErrorNumber;
        }

        public List<NS_LoaiLuanChuyenInfo> GetList(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            List<NS_LoaiLuanChuyenInfo> oNS_LoaiLuanChuyenInfoList = new List<NS_LoaiLuanChuyenInfo>();
            DataTable dtb = Get(pNS_LoaiLuanChuyenInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_LoaiLuanChuyenInfo = new NS_LoaiLuanChuyenInfo();

                    oNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = int.Parse(dtb.Rows[i]["NS_LoaiLuanChuyenID"].ToString());
                    oNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen = dtb.Rows[i]["TenLoaiLuanChuyen"].ToString();
                    oNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien = int.Parse(dtb.Rows[i]["TrangThaiGiaoVien"].ToString());
                    
                    oNS_LoaiLuanChuyenInfoList.Add(oNS_LoaiLuanChuyenInfo);
                }
            }
            return oNS_LoaiLuanChuyenInfoList;
        }
        
        public void ToDataRow(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo, ref DataRow dr)
        {

			dr[pNS_LoaiLuanChuyenInfo.strNS_LoaiLuanChuyenID] = pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID;
			dr[pNS_LoaiLuanChuyenInfo.strTenLoaiLuanChuyen] = pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen;
			dr[pNS_LoaiLuanChuyenInfo.strTrangThaiGiaoVien] = pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien;
        }
        
        public void ToInfo(ref NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo, DataRow dr)
        {

			pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = int.Parse(dr[pNS_LoaiLuanChuyenInfo.strNS_LoaiLuanChuyenID].ToString());
			pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen = dr[pNS_LoaiLuanChuyenInfo.strTenLoaiLuanChuyen].ToString();
			pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien = int.Parse("0" + dr[pNS_LoaiLuanChuyenInfo.strTrangThaiGiaoVien]);
        }
    }
}
