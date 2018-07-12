using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_NhapHocLai : cBBase
    {
        private cDSV_NhapHocLai oDSV_NhapHocLai;
        private SV_NhapHocLaiInfo oSV_NhapHocLaiInfo;

        public cBSV_NhapHocLai()        
        {
            oDSV_NhapHocLai = new cDSV_NhapHocLai();
        }

        public DataTable Get(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)        
        {
            return oDSV_NhapHocLai.Get(pSV_NhapHocLaiInfo);
        }
        public DataTable GetSinhVien_ChuaNhapHoc()
        {
            return oDSV_NhapHocLai.GetSinhVien_ChuaNhapHoc();
        }
        public DataTable GetSinhVien(int IDDM_Lop)
        {
            return oDSV_NhapHocLai.GetSinhVien(IDDM_Lop);
        }

        public int Add(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
			int ID = 0;
            ID = oDSV_NhapHocLai.Add(pSV_NhapHocLaiInfo);
            mErrorMessage = oDSV_NhapHocLai.ErrorMessages;
            mErrorNumber = oDSV_NhapHocLai.ErrorNumber;
            return ID;
        }

        public void Update(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            oDSV_NhapHocLai.Update(pSV_NhapHocLaiInfo);
            mErrorMessage = oDSV_NhapHocLai.ErrorMessages;
            mErrorNumber = oDSV_NhapHocLai.ErrorNumber;
        }
        
        public void Delete(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            oDSV_NhapHocLai.Delete(pSV_NhapHocLaiInfo);
            mErrorMessage = oDSV_NhapHocLai.ErrorMessages;
            mErrorNumber = oDSV_NhapHocLai.ErrorNumber;
        }

        public List<SV_NhapHocLaiInfo> GetList(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            List<SV_NhapHocLaiInfo> oSV_NhapHocLaiInfoList = new List<SV_NhapHocLaiInfo>();
            DataTable dtb = Get(pSV_NhapHocLaiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_NhapHocLaiInfo = new SV_NhapHocLaiInfo();

                    oSV_NhapHocLaiInfo.SV_NhapHocLaiID = int.Parse(dtb.Rows[i]["SV_NhapHocLaiID"].ToString());
                    oSV_NhapHocLaiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_NhapHocLaiInfo.IDDM_LopCu = int.Parse(dtb.Rows[i]["IDDM_LopCu"].ToString());
                    oSV_NhapHocLaiInfo.IDDM_LopMoi = int.Parse(dtb.Rows[i]["IDDM_LopMoi"].ToString());
                    oSV_NhapHocLaiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_NhapHocLaiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    
                    oSV_NhapHocLaiInfoList.Add(oSV_NhapHocLaiInfo);
                }
            }
            return oSV_NhapHocLaiInfoList;
        }
        
        public void ToDataRow(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo, ref DataRow dr)
        {

			dr[pSV_NhapHocLaiInfo.strSV_NhapHocLaiID] = pSV_NhapHocLaiInfo.SV_NhapHocLaiID;
			dr[pSV_NhapHocLaiInfo.strIDSV_SinhVien] = pSV_NhapHocLaiInfo.IDSV_SinhVien;
			dr[pSV_NhapHocLaiInfo.strIDDM_LopCu] = pSV_NhapHocLaiInfo.IDDM_LopCu;
			dr[pSV_NhapHocLaiInfo.strIDDM_LopMoi] = pSV_NhapHocLaiInfo.IDDM_LopMoi;
			dr[pSV_NhapHocLaiInfo.strIDDM_NamHoc] = pSV_NhapHocLaiInfo.IDDM_NamHoc;
			dr[pSV_NhapHocLaiInfo.strHocKy] = pSV_NhapHocLaiInfo.HocKy;
        }
        
        public void ToInfo(ref SV_NhapHocLaiInfo pSV_NhapHocLaiInfo, DataRow dr)
        {

			pSV_NhapHocLaiInfo.SV_NhapHocLaiID = int.Parse(dr[pSV_NhapHocLaiInfo.strSV_NhapHocLaiID].ToString());
			pSV_NhapHocLaiInfo.IDSV_SinhVien = int.Parse(dr[pSV_NhapHocLaiInfo.strIDSV_SinhVien].ToString());
			pSV_NhapHocLaiInfo.IDDM_LopCu = int.Parse(dr[pSV_NhapHocLaiInfo.strIDDM_LopCu].ToString());
			pSV_NhapHocLaiInfo.IDDM_LopMoi = int.Parse(dr[pSV_NhapHocLaiInfo.strIDDM_LopMoi].ToString());
			pSV_NhapHocLaiInfo.IDDM_NamHoc = int.Parse(dr[pSV_NhapHocLaiInfo.strIDDM_NamHoc].ToString());
			pSV_NhapHocLaiInfo.HocKy = int.Parse(dr[pSV_NhapHocLaiInfo.strHocKy].ToString());
        }
    }
}
