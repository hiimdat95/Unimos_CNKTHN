using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_DiemRenLuyenToanKhoa : cBBase
    {
        private cDSV_DiemRenLuyenToanKhoa oDSV_DiemRenLuyenToanKhoa;
        private SV_DiemRenLuyenToanKhoaInfo oSV_DiemRenLuyenToanKhoaInfo;

        public cBSV_DiemRenLuyenToanKhoa()        
        {
            oDSV_DiemRenLuyenToanKhoa = new cDSV_DiemRenLuyenToanKhoa();
        }

        public DataTable Get(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)        
        {
            return oDSV_DiemRenLuyenToanKhoa.Get(pSV_DiemRenLuyenToanKhoaInfo);
        }

        public int Add(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
			int ID = 0;
            ID = oDSV_DiemRenLuyenToanKhoa.Add(pSV_DiemRenLuyenToanKhoaInfo);
            mErrorMessage = oDSV_DiemRenLuyenToanKhoa.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenToanKhoa.ErrorNumber;
            return ID;
        }

        public void Update(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            oDSV_DiemRenLuyenToanKhoa.Update(pSV_DiemRenLuyenToanKhoaInfo);
            mErrorMessage = oDSV_DiemRenLuyenToanKhoa.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenToanKhoa.ErrorNumber;
        }
        
        public void Delete(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            oDSV_DiemRenLuyenToanKhoa.Delete(pSV_DiemRenLuyenToanKhoaInfo);
            mErrorMessage = oDSV_DiemRenLuyenToanKhoa.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyenToanKhoa.ErrorNumber;
        }

        public List<SV_DiemRenLuyenToanKhoaInfo> GetList(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            List<SV_DiemRenLuyenToanKhoaInfo> oSV_DiemRenLuyenToanKhoaInfoList = new List<SV_DiemRenLuyenToanKhoaInfo>();
            DataTable dtb = Get(pSV_DiemRenLuyenToanKhoaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_DiemRenLuyenToanKhoaInfo = new SV_DiemRenLuyenToanKhoaInfo();

                    oSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID = int.Parse(dtb.Rows[i]["SV_DiemRenLuyenToanKhoaID"].ToString());
                    oSV_DiemRenLuyenToanKhoaInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_DiemRenLuyenToanKhoaInfo.SoDiem = double.Parse(dtb.Rows[i]["SoDiem"].ToString());
                    oSV_DiemRenLuyenToanKhoaInfo.IDDM_XepLoaiRenLuyen = int.Parse(dtb.Rows[i]["IDDM_XepLoaiRenLuyen"].ToString());
                    oSV_DiemRenLuyenToanKhoaInfo.NhanXet = dtb.Rows[i]["NhanXet"].ToString();
                    
                    oSV_DiemRenLuyenToanKhoaInfoList.Add(oSV_DiemRenLuyenToanKhoaInfo);
                }
            }
            return oSV_DiemRenLuyenToanKhoaInfoList;
        }
        
        public void ToDataRow(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo, ref DataRow dr)
        {

			dr[pSV_DiemRenLuyenToanKhoaInfo.strSV_DiemRenLuyenToanKhoaID] = pSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID;
			dr[pSV_DiemRenLuyenToanKhoaInfo.strIDSV_SinhVien] = pSV_DiemRenLuyenToanKhoaInfo.IDSV_SinhVien;
			dr[pSV_DiemRenLuyenToanKhoaInfo.strSoDiem] = pSV_DiemRenLuyenToanKhoaInfo.SoDiem;
			dr[pSV_DiemRenLuyenToanKhoaInfo.strIDDM_XepLoaiRenLuyen] = pSV_DiemRenLuyenToanKhoaInfo.IDDM_XepLoaiRenLuyen;
			dr[pSV_DiemRenLuyenToanKhoaInfo.strNhanXet] = pSV_DiemRenLuyenToanKhoaInfo.NhanXet;
        }
        
        public void ToInfo(ref SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo, DataRow dr)
        {

			pSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID = int.Parse(dr[pSV_DiemRenLuyenToanKhoaInfo.strSV_DiemRenLuyenToanKhoaID].ToString());
			pSV_DiemRenLuyenToanKhoaInfo.IDSV_SinhVien = int.Parse(dr[pSV_DiemRenLuyenToanKhoaInfo.strIDSV_SinhVien].ToString());
			pSV_DiemRenLuyenToanKhoaInfo.SoDiem = double.Parse(dr[pSV_DiemRenLuyenToanKhoaInfo.strSoDiem].ToString());
			pSV_DiemRenLuyenToanKhoaInfo.IDDM_XepLoaiRenLuyen = int.Parse(dr[pSV_DiemRenLuyenToanKhoaInfo.strIDDM_XepLoaiRenLuyen].ToString());
			pSV_DiemRenLuyenToanKhoaInfo.NhanXet = dr[pSV_DiemRenLuyenToanKhoaInfo.strNhanXet].ToString();
        }
    }
}
