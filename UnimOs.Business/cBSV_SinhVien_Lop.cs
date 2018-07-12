using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_Lop : cBBase
    {
        private cDSV_SinhVien_Lop oDSV_SinhVien_Lop;
        private SV_SinhVien_LopInfo oSV_SinhVien_LopInfo;

        public cBSV_SinhVien_Lop()        
        {
            oDSV_SinhVien_Lop = new cDSV_SinhVien_Lop();
        }

        public DataTable Get(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)        
        {
            return oDSV_SinhVien_Lop.Get(pSV_SinhVien_LopInfo);
        }

        public DataTable Get_ThuChi(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDSV_SinhVien_Lop.Get_ThuChi(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_Lop.Add(pSV_SinhVien_LopInfo);
            mErrorMessage = oDSV_SinhVien_Lop.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_Lop.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            oDSV_SinhVien_Lop.Update(pSV_SinhVien_LopInfo);
            mErrorMessage = oDSV_SinhVien_Lop.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_Lop.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            oDSV_SinhVien_Lop.Delete(pSV_SinhVien_LopInfo);
            mErrorMessage = oDSV_SinhVien_Lop.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_Lop.ErrorNumber;
        }

        public List<SV_SinhVien_LopInfo> GetList(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            List<SV_SinhVien_LopInfo> oSV_SinhVien_LopInfoList = new List<SV_SinhVien_LopInfo>();
            DataTable dtb = Get(pSV_SinhVien_LopInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_LopInfo = new SV_SinhVien_LopInfo();

                    oSV_SinhVien_LopInfo.SV_SinhVien_LopID = int.Parse(dtb.Rows[i]["SV_SinhVien_LopID"].ToString());
                    oSV_SinhVien_LopInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_LopInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oSV_SinhVien_LopInfo.TrangThaiSinhVien = int.Parse(dtb.Rows[i]["TrangThaiSinhVien"].ToString());
                    
                    oSV_SinhVien_LopInfoList.Add(oSV_SinhVien_LopInfo);
                }
            }
            return oSV_SinhVien_LopInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_LopInfo.strSV_SinhVien_LopID] = pSV_SinhVien_LopInfo.SV_SinhVien_LopID;
			dr[pSV_SinhVien_LopInfo.strIDSV_SinhVien] = pSV_SinhVien_LopInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_LopInfo.strIDDM_Lop] = pSV_SinhVien_LopInfo.IDDM_Lop;
			dr[pSV_SinhVien_LopInfo.strTrangThaiSinhVien] = pSV_SinhVien_LopInfo.TrangThaiSinhVien;
        }
        
        public void ToInfo(ref SV_SinhVien_LopInfo pSV_SinhVien_LopInfo, DataRow dr)
        {

			pSV_SinhVien_LopInfo.SV_SinhVien_LopID = int.Parse(dr[pSV_SinhVien_LopInfo.strSV_SinhVien_LopID].ToString());
			pSV_SinhVien_LopInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_LopInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_LopInfo.IDDM_Lop = int.Parse(dr[pSV_SinhVien_LopInfo.strIDDM_Lop].ToString());
			pSV_SinhVien_LopInfo.TrangThaiSinhVien = int.Parse(dr[pSV_SinhVien_LopInfo.strTrangThaiSinhVien].ToString());
        }
    }
}
