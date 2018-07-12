using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_AnhXaMon : cBBase
    {
        private cDSV_AnhXaMon oDSV_AnhXaMon;
        private SV_AnhXaMonInfo oSV_AnhXaMonInfo;

        public cBSV_AnhXaMon()        
        {
            oDSV_AnhXaMon = new cDSV_AnhXaMon();
        }

        public DataTable Get(SV_AnhXaMonInfo pSV_AnhXaMonInfo)        
        {
            return oDSV_AnhXaMon.Get(pSV_AnhXaMonInfo);
        }
      
        public DataTable GetMonLopMoi(int IDSV_SinhVien, int IDDM_Lop)
        {
            return oDSV_AnhXaMon.GetMonLopMoi(IDSV_SinhVien, IDDM_Lop);
        }
        public DataTable GetMonLopCu(int IDSV_SinhVien, int IDDM_Lop)
        {
            return oDSV_AnhXaMon.GetMonLopCu(IDSV_SinhVien, IDDM_Lop);
        }
        public DataTable GetChiTiet(int IDSV_SinhVien, int IDDM_Lop)
        {
            return oDSV_AnhXaMon.GetChiTiet(IDSV_SinhVien, IDDM_Lop);
        }
        public void ApDung(string ChuoiID, int IDSV_SinhVien, int IDDM_Lop)
        {
            oDSV_AnhXaMon.ApDung(ChuoiID, IDSV_SinhVien, IDDM_Lop);
        }
        public int Add(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
			int ID = 0;
            ID = oDSV_AnhXaMon.Add(pSV_AnhXaMonInfo);
            mErrorMessage = oDSV_AnhXaMon.ErrorMessages;
            mErrorNumber = oDSV_AnhXaMon.ErrorNumber;
            return ID;
        }

        public void Update(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            oDSV_AnhXaMon.Update(pSV_AnhXaMonInfo);
            mErrorMessage = oDSV_AnhXaMon.ErrorMessages;
            mErrorNumber = oDSV_AnhXaMon.ErrorNumber;
        }
        
        public void Delete(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            oDSV_AnhXaMon.Delete(pSV_AnhXaMonInfo);
            mErrorMessage = oDSV_AnhXaMon.ErrorMessages;
            mErrorNumber = oDSV_AnhXaMon.ErrorNumber;
        }

        public List<SV_AnhXaMonInfo> GetList(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            List<SV_AnhXaMonInfo> oSV_AnhXaMonInfoList = new List<SV_AnhXaMonInfo>();
            DataTable dtb = Get(pSV_AnhXaMonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_AnhXaMonInfo = new SV_AnhXaMonInfo();

                    oSV_AnhXaMonInfo.SV_AnhXaMonID = long.Parse(dtb.Rows[i]["SV_AnhXaMonID"].ToString());
                    oSV_AnhXaMonInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKyCu"].ToString());
                    oSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKyMoi"].ToString());
                    oSV_AnhXaMonInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    
                    oSV_AnhXaMonInfoList.Add(oSV_AnhXaMonInfo);
                }
            }
            return oSV_AnhXaMonInfoList;
        }
        
        public void ToDataRow(SV_AnhXaMonInfo pSV_AnhXaMonInfo, ref DataRow dr)
        {

			dr[pSV_AnhXaMonInfo.strSV_AnhXaMonID] = pSV_AnhXaMonInfo.SV_AnhXaMonID;
			dr[pSV_AnhXaMonInfo.strIDSV_SinhVien] = pSV_AnhXaMonInfo.IDSV_SinhVien;
			dr[pSV_AnhXaMonInfo.strIDXL_MonHocTrongKyCu] = pSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu;
			dr[pSV_AnhXaMonInfo.strIDXL_MonHocTrongKyMoi] = pSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi;
			dr[pSV_AnhXaMonInfo.strIDDM_Lop] = pSV_AnhXaMonInfo.IDDM_Lop;
        }
        
        public void ToInfo(ref SV_AnhXaMonInfo pSV_AnhXaMonInfo, DataRow dr)
        {

			pSV_AnhXaMonInfo.SV_AnhXaMonID = long.Parse(dr[pSV_AnhXaMonInfo.strSV_AnhXaMonID].ToString());
			pSV_AnhXaMonInfo.IDSV_SinhVien = int.Parse(dr[pSV_AnhXaMonInfo.strIDSV_SinhVien].ToString());
			pSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu = int.Parse(dr[pSV_AnhXaMonInfo.strIDXL_MonHocTrongKyCu].ToString());
			pSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi = int.Parse(dr[pSV_AnhXaMonInfo.strIDXL_MonHocTrongKyMoi].ToString());
			pSV_AnhXaMonInfo.IDDM_Lop = int.Parse(dr[pSV_AnhXaMonInfo.strIDDM_Lop].ToString());
        }
    }
}
