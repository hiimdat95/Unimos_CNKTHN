using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_DiemRenLuyenTheoThang : cBBase
    {
        private cDSV_DiemRenLuyenTheoThang oDSV_DiemRenLuyenTheoThang;
        private SV_DiemRenLuyenTheoThangInfo oSV_DiemRenLuyenTheoThangInfo;

        public cBSV_DiemRenLuyenTheoThang()        
        {
            oDSV_DiemRenLuyenTheoThang = new cDSV_DiemRenLuyenTheoThang();
        }

        public DataTable Get(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)        
        {
            return oDSV_DiemRenLuyenTheoThang.Get(pSV_DiemRenLuyenTheoThangInfo);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDSV_DiemRenLuyenTheoThang.GetByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
			int ID = 0;
            ID = oDSV_DiemRenLuyenTheoThang.Add(pSV_DiemRenLuyenTheoThangInfo);
            mErrorMessage = oDSV_DiemRenLuyenTheoThang.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenTheoThang.ErrorNumber;
            return ID;
        }

        public void Update(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            oDSV_DiemRenLuyenTheoThang.Update(pSV_DiemRenLuyenTheoThangInfo);
            mErrorMessage = oDSV_DiemRenLuyenTheoThang.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenTheoThang.ErrorNumber;
        }

        public void UpdateChange(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            oDSV_DiemRenLuyenTheoThang.UpdateChange(pSV_DiemRenLuyenTheoThangInfo);
            mErrorMessage = oDSV_DiemRenLuyenTheoThang.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenTheoThang.ErrorNumber;
        }
        
        public void Delete(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            oDSV_DiemRenLuyenTheoThang.Delete(pSV_DiemRenLuyenTheoThangInfo);
            mErrorMessage = oDSV_DiemRenLuyenTheoThang.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenTheoThang.ErrorNumber;
        }

        public List<SV_DiemRenLuyenTheoThangInfo> GetList(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            List<SV_DiemRenLuyenTheoThangInfo> oSV_DiemRenLuyenTheoThangInfoList = new List<SV_DiemRenLuyenTheoThangInfo>();
            DataTable dtb = Get(pSV_DiemRenLuyenTheoThangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_DiemRenLuyenTheoThangInfo = new SV_DiemRenLuyenTheoThangInfo();

                    oSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID = int.Parse(dtb.Rows[i]["SV_DiemRenLuyenTheoThangID"].ToString());
                    oSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy = int.Parse(dtb.Rows[i]["IDSV_ThangRenLuyenTrongKy"].ToString());
                    oSV_DiemRenLuyenTheoThangInfo.SoDiem = double.Parse(dtb.Rows[i]["SoDiem"].ToString());
                    oSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen = int.Parse(dtb.Rows[i]["IDDM_XepLoaiRenLuyen"].ToString());
                    oSV_DiemRenLuyenTheoThangInfo.NhanXet = dtb.Rows[i]["NhanXet"].ToString();
                    
                    oSV_DiemRenLuyenTheoThangInfoList.Add(oSV_DiemRenLuyenTheoThangInfo);
                }
            }
            return oSV_DiemRenLuyenTheoThangInfoList;
        }
        
        public void ToDataRow(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo, ref DataRow dr)
        {

			dr[pSV_DiemRenLuyenTheoThangInfo.strSV_DiemRenLuyenTheoThangID] = pSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID;
			dr[pSV_DiemRenLuyenTheoThangInfo.strIDSV_SinhVien] = pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien;
			dr[pSV_DiemRenLuyenTheoThangInfo.strIDSV_ThangRenLuyenTrongKy] = pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy;
			dr[pSV_DiemRenLuyenTheoThangInfo.strSoDiem] = pSV_DiemRenLuyenTheoThangInfo.SoDiem;
			dr[pSV_DiemRenLuyenTheoThangInfo.strIDDM_XepLoaiRenLuyen] = pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen;
			dr[pSV_DiemRenLuyenTheoThangInfo.strNhanXet] = pSV_DiemRenLuyenTheoThangInfo.NhanXet;
        }
        
        public void ToInfo(ref SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo, DataRow dr)
        {

			pSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID = int.Parse(dr[pSV_DiemRenLuyenTheoThangInfo.strSV_DiemRenLuyenTheoThangID].ToString());
			pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien = int.Parse(dr[pSV_DiemRenLuyenTheoThangInfo.strIDSV_SinhVien].ToString());
			pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy = int.Parse(dr[pSV_DiemRenLuyenTheoThangInfo.strIDSV_ThangRenLuyenTrongKy].ToString());
			pSV_DiemRenLuyenTheoThangInfo.SoDiem = double.Parse(dr[pSV_DiemRenLuyenTheoThangInfo.strSoDiem].ToString());
			pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen = int.Parse(dr[pSV_DiemRenLuyenTheoThangInfo.strIDDM_XepLoaiRenLuyen].ToString());
			pSV_DiemRenLuyenTheoThangInfo.NhanXet = dr[pSV_DiemRenLuyenTheoThangInfo.strNhanXet].ToString();
        }
    }
}
