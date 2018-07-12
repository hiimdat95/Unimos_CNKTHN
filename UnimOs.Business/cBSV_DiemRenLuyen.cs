using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_DiemRenLuyen : cBBase
    {
        private cDSV_DiemRenLuyen oDSV_DiemRenLuyen;
        private SV_DiemRenLuyenInfo oSV_DiemRenLuyenInfo;

        public cBSV_DiemRenLuyen()        
        {
            oDSV_DiemRenLuyen = new cDSV_DiemRenLuyen();
        }

        public DataTable Get(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)        
        {
            return oDSV_DiemRenLuyen.Get(pSV_DiemRenLuyenInfo);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc)
        {
            return oDSV_DiemRenLuyen.GetByLop(IDDM_Lop, IDDM_NamHoc);
        }

        public int Add(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
			int ID = 0;
            ID = oDSV_DiemRenLuyen.Add(pSV_DiemRenLuyenInfo);
            mErrorMessage = oDSV_DiemRenLuyen.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyen.ErrorNumber;
            return ID;
        }

        public void Update(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            oDSV_DiemRenLuyen.Update(pSV_DiemRenLuyenInfo);
            mErrorMessage = oDSV_DiemRenLuyen.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyen.ErrorNumber;
        }

        public void UpdateChange(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, double SoDiem, int IDDM_XepLoaiRenLuyen, string NhanXet)
        {
            oDSV_DiemRenLuyen.UpdateChange(IDSV_SinhVien, IDDM_NamHoc, HocKy, SoDiem, IDDM_XepLoaiRenLuyen, NhanXet);
            mErrorMessage = oDSV_DiemRenLuyen.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyen.ErrorNumber;
        }
        
        public void Delete(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            oDSV_DiemRenLuyen.Delete(pSV_DiemRenLuyenInfo);
            mErrorMessage = oDSV_DiemRenLuyen.ErrorMessages;
            mErrorNumber = oDSV_DiemRenLuyen.ErrorNumber;
        }

        public List<SV_DiemRenLuyenInfo> GetList(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            List<SV_DiemRenLuyenInfo> oSV_DiemRenLuyenInfoList = new List<SV_DiemRenLuyenInfo>();
            DataTable dtb = Get(pSV_DiemRenLuyenInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_DiemRenLuyenInfo = new SV_DiemRenLuyenInfo();

                    oSV_DiemRenLuyenInfo.SV_DiemRenLuyenID = int.Parse(dtb.Rows[i]["SV_DiemRenLuyenID"].ToString());
                    oSV_DiemRenLuyenInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_DiemRenLuyenInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_DiemRenLuyenInfo.SoDiemKy1 = double.Parse(dtb.Rows[i]["SoDiemKy1"].ToString());
                    oSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy1 = int.Parse(dtb.Rows[i]["IDDM_XepLoaiRenLuyenKy1"].ToString());
                    oSV_DiemRenLuyenInfo.NhanXetKy1 = dtb.Rows[i]["NhanXetKy1"].ToString();
                    oSV_DiemRenLuyenInfo.SoDiemKy2 = double.Parse(dtb.Rows[i]["SoDiemKy2"].ToString());
                    oSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy2 = int.Parse(dtb.Rows[i]["IDDM_XepLoaiRenLuyenKy2"].ToString());
                    oSV_DiemRenLuyenInfo.NhanXetKy2 = dtb.Rows[i]["NhanXetKy2"].ToString();
                    oSV_DiemRenLuyenInfo.SoDiemCaNam = double.Parse(dtb.Rows[i]["SoDiemCaNam"].ToString());
                    oSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenCaNam = int.Parse(dtb.Rows[i]["IDDM_XepLoaiRenLuyenCaNam"].ToString());
                    oSV_DiemRenLuyenInfo.NhanXetCaNam = dtb.Rows[i]["NhanXetCaNam"].ToString();
                    
                    oSV_DiemRenLuyenInfoList.Add(oSV_DiemRenLuyenInfo);
                }
            }
            return oSV_DiemRenLuyenInfoList;
        }
        
        public void ToDataRow(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo, ref DataRow dr)
        {

			dr[pSV_DiemRenLuyenInfo.strSV_DiemRenLuyenID] = pSV_DiemRenLuyenInfo.SV_DiemRenLuyenID;
			dr[pSV_DiemRenLuyenInfo.strIDSV_SinhVien] = pSV_DiemRenLuyenInfo.IDSV_SinhVien;
			dr[pSV_DiemRenLuyenInfo.strIDDM_NamHoc] = pSV_DiemRenLuyenInfo.IDDM_NamHoc;
			dr[pSV_DiemRenLuyenInfo.strSoDiemKy1] = pSV_DiemRenLuyenInfo.SoDiemKy1;
			dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenKy1] = pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy1;
			dr[pSV_DiemRenLuyenInfo.strNhanXetKy1] = pSV_DiemRenLuyenInfo.NhanXetKy1;
			dr[pSV_DiemRenLuyenInfo.strSoDiemKy2] = pSV_DiemRenLuyenInfo.SoDiemKy2;
			dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenKy2] = pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy2;
			dr[pSV_DiemRenLuyenInfo.strNhanXetKy2] = pSV_DiemRenLuyenInfo.NhanXetKy2;
			dr[pSV_DiemRenLuyenInfo.strSoDiemCaNam] = pSV_DiemRenLuyenInfo.SoDiemCaNam;
			dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenCaNam] = pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenCaNam;
			dr[pSV_DiemRenLuyenInfo.strNhanXetCaNam] = pSV_DiemRenLuyenInfo.NhanXetCaNam;
        }
        
        public void ToInfo(ref SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo, DataRow dr)
        {

			pSV_DiemRenLuyenInfo.SV_DiemRenLuyenID = int.Parse(dr[pSV_DiemRenLuyenInfo.strSV_DiemRenLuyenID].ToString());
			pSV_DiemRenLuyenInfo.IDSV_SinhVien = int.Parse(dr[pSV_DiemRenLuyenInfo.strIDSV_SinhVien].ToString());
			pSV_DiemRenLuyenInfo.IDDM_NamHoc = int.Parse(dr[pSV_DiemRenLuyenInfo.strIDDM_NamHoc].ToString());
			pSV_DiemRenLuyenInfo.SoDiemKy1 = double.Parse(dr[pSV_DiemRenLuyenInfo.strSoDiemKy1].ToString());
			pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy1 = int.Parse(dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenKy1].ToString());
			pSV_DiemRenLuyenInfo.NhanXetKy1 = dr[pSV_DiemRenLuyenInfo.strNhanXetKy1].ToString();
			pSV_DiemRenLuyenInfo.SoDiemKy2 = double.Parse(dr[pSV_DiemRenLuyenInfo.strSoDiemKy2].ToString());
			pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy2 = int.Parse(dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenKy2].ToString());
			pSV_DiemRenLuyenInfo.NhanXetKy2 = dr[pSV_DiemRenLuyenInfo.strNhanXetKy2].ToString();
			pSV_DiemRenLuyenInfo.SoDiemCaNam = double.Parse(dr[pSV_DiemRenLuyenInfo.strSoDiemCaNam].ToString());
			pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenCaNam = int.Parse(dr[pSV_DiemRenLuyenInfo.strIDDM_XepLoaiRenLuyenCaNam].ToString());
			pSV_DiemRenLuyenInfo.NhanXetCaNam = dr[pSV_DiemRenLuyenInfo.strNhanXetCaNam].ToString();
        }
    }
}
