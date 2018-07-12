using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DangKyThiLaiTotNghiep : cBBase
    {
        private cDKQHT_DangKyThiLaiTotNghiep oDKQHT_DangKyThiLaiTotNghiep;
        private KQHT_DangKyThiLaiTotNghiepInfo oKQHT_DangKyThiLaiTotNghiepInfo;

        public cBKQHT_DangKyThiLaiTotNghiep()        
        {
            oDKQHT_DangKyThiLaiTotNghiep = new cDKQHT_DangKyThiLaiTotNghiep();
        }
        public DataTable GetByMon(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DangKyThiLaiTotNghiep.GetByMon(IDDM_MonHoc, IDDM_NamHoc);
        }
        public DataTable GetThiLai(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DangKyThiLaiTotNghiep.GetThiLai(IDDM_MonHoc, IDDM_NamHoc);
        }
        public DataTable GetChuaThi(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DangKyThiLaiTotNghiep.GetChuaThi(IDDM_MonHoc, IDDM_NamHoc);
        }
        public DataTable Get(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)        
        {
            return oDKQHT_DangKyThiLaiTotNghiep.Get(pKQHT_DangKyThiLaiTotNghiepInfo);
        }

        public int Add(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_DangKyThiLaiTotNghiep.Add(pKQHT_DangKyThiLaiTotNghiepInfo);
            mErrorMessage = oDKQHT_DangKyThiLaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLaiTotNghiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            oDKQHT_DangKyThiLaiTotNghiep.Update(pKQHT_DangKyThiLaiTotNghiepInfo);
            mErrorMessage = oDKQHT_DangKyThiLaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLaiTotNghiep.ErrorNumber;
        }
        public void DeleteByMon(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            oDKQHT_DangKyThiLaiTotNghiep.DeleteByMon(IDDM_MonHoc, IDDM_NamHoc);
            mErrorMessage = oDKQHT_DangKyThiLaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLaiTotNghiep.ErrorNumber;
        }
        public void Delete(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            oDKQHT_DangKyThiLaiTotNghiep.Delete(pKQHT_DangKyThiLaiTotNghiepInfo);
            mErrorMessage = oDKQHT_DangKyThiLaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLaiTotNghiep.ErrorNumber;
        }

        public List<KQHT_DangKyThiLaiTotNghiepInfo> GetList(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            List<KQHT_DangKyThiLaiTotNghiepInfo> oKQHT_DangKyThiLaiTotNghiepInfoList = new List<KQHT_DangKyThiLaiTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_DangKyThiLaiTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DangKyThiLaiTotNghiepInfo = new KQHT_DangKyThiLaiTotNghiepInfo();

                    oKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID = int.Parse(dtb.Rows[i]["KQHT_DangKyThiLaiTotNghiepID"].ToString());
                    oKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DangKyThiLaiTotNghiepInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    
                    oKQHT_DangKyThiLaiTotNghiepInfoList.Add(oKQHT_DangKyThiLaiTotNghiepInfo);
                }
            }
            return oKQHT_DangKyThiLaiTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo, ref DataRow dr)
        {

			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strKQHT_DangKyThiLaiTotNghiepID] = pKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID;
			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_MonHoc] = pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc;
			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDSV_SinhVien] = pKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien;
			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_NamHoc] = pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc;
			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strHocKy] = pKQHT_DangKyThiLaiTotNghiepInfo.HocKy;
			dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_Lop] = pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop;
        }
        
        public void ToInfo(ref KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo, DataRow dr)
        {

			pKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strKQHT_DangKyThiLaiTotNghiepID].ToString());
			pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_MonHoc].ToString());
			pKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDSV_SinhVien].ToString());
			pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_NamHoc].ToString());
			pKQHT_DangKyThiLaiTotNghiepInfo.HocKy = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strHocKy].ToString());
			pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop = int.Parse(dr[pKQHT_DangKyThiLaiTotNghiepInfo.strIDDM_Lop].ToString());
        }
    }
}
