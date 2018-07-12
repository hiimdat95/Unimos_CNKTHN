using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_XepLoaiRenLuyen : cBBase
    {
        private cDDM_XepLoaiRenLuyen oDDM_XepLoaiRenLuyen;
        private DM_XepLoaiRenLuyenInfo oDM_XepLoaiRenLuyenInfo;

        public cBDM_XepLoaiRenLuyen()        
        {
            oDDM_XepLoaiRenLuyen = new cDDM_XepLoaiRenLuyen();
        }

        public DataTable Get(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)        
        {
            return oDDM_XepLoaiRenLuyen.Get(pDM_XepLoaiRenLuyenInfo);
        }

        public int Add(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
			int ID = 0;
            ID = oDDM_XepLoaiRenLuyen.Add(pDM_XepLoaiRenLuyenInfo);
            mErrorMessage = oDDM_XepLoaiRenLuyen.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiRenLuyen.ErrorNumber;
            return ID;
        }

        public void Update(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            oDDM_XepLoaiRenLuyen.Update(pDM_XepLoaiRenLuyenInfo);
            mErrorMessage = oDDM_XepLoaiRenLuyen.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiRenLuyen.ErrorNumber;
        }
        
        public void Delete(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            oDDM_XepLoaiRenLuyen.Delete(pDM_XepLoaiRenLuyenInfo);
            mErrorMessage = oDDM_XepLoaiRenLuyen.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiRenLuyen.ErrorNumber;
        }

        public List<DM_XepLoaiRenLuyenInfo> GetList(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            List<DM_XepLoaiRenLuyenInfo> oDM_XepLoaiRenLuyenInfoList = new List<DM_XepLoaiRenLuyenInfo>();
            DataTable dtb = Get(pDM_XepLoaiRenLuyenInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_XepLoaiRenLuyenInfo = new DM_XepLoaiRenLuyenInfo();

                    oDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID = int.Parse(dtb.Rows[i]["DM_XepLoaiRenLuyenID"].ToString());
                    oDM_XepLoaiRenLuyenInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen = dtb.Rows[i]["TenXepLoaiRenLuyen"].ToString();
                    oDM_XepLoaiRenLuyenInfo.TuDiem = int.Parse(dtb.Rows[i]["TuDiem"].ToString());
                    oDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong = double.Parse(dtb.Rows[i]["DiemCongXetHocBong"].ToString());
                    
                    oDM_XepLoaiRenLuyenInfoList.Add(oDM_XepLoaiRenLuyenInfo);
                }
            }
            return oDM_XepLoaiRenLuyenInfoList;
        }
        
        public void ToDataRow(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo, ref DataRow dr)
        {

			dr[pDM_XepLoaiRenLuyenInfo.strDM_XepLoaiRenLuyenID] = pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID;
			dr[pDM_XepLoaiRenLuyenInfo.strKyHieu] = pDM_XepLoaiRenLuyenInfo.KyHieu;
			dr[pDM_XepLoaiRenLuyenInfo.strTenXepLoaiRenLuyen] = pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen;
			dr[pDM_XepLoaiRenLuyenInfo.strTuDiem] = pDM_XepLoaiRenLuyenInfo.TuDiem;
			dr[pDM_XepLoaiRenLuyenInfo.strDiemCongXetHocBong] = pDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong;
        }
        
        public void ToInfo(ref DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo, DataRow dr)
        {

			pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID = int.Parse(dr[pDM_XepLoaiRenLuyenInfo.strDM_XepLoaiRenLuyenID].ToString());
			pDM_XepLoaiRenLuyenInfo.KyHieu = dr[pDM_XepLoaiRenLuyenInfo.strKyHieu].ToString();
			pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen = dr[pDM_XepLoaiRenLuyenInfo.strTenXepLoaiRenLuyen].ToString();
			pDM_XepLoaiRenLuyenInfo.TuDiem = int.Parse(dr[pDM_XepLoaiRenLuyenInfo.strTuDiem].ToString());
			pDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong = double.Parse(dr[pDM_XepLoaiRenLuyenInfo.strDiemCongXetHocBong].ToString());
        }
    }
}
