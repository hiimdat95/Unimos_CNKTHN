using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DangKyMonChon : cBBase
    {
        private cDKQHT_DangKyMonChon oDKQHT_DangKyMonChon;
        private KQHT_DangKyMonChonInfo oKQHT_DangKyMonChonInfo;

        public cBKQHT_DangKyMonChon()        
        {
            oDKQHT_DangKyMonChon = new cDKQHT_DangKyMonChon();
        }

        public DataTable Get(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)        
        {
            return oDKQHT_DangKyMonChon.Get(pKQHT_DangKyMonChonInfo);
        }

        public DataTable GetSinhVien(int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int Kieu)
        {
            return oDKQHT_DangKyMonChon.GetSinhVien( IDDM_Lop,  IDXL_MonHocTrongKy,  IDDM_NamHoc,  HocKy,  Kieu);
        }

        public int Add(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
			int ID = 0;
            ID = oDKQHT_DangKyMonChon.Add(pKQHT_DangKyMonChonInfo);
            mErrorMessage = oDKQHT_DangKyMonChon.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyMonChon.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            oDKQHT_DangKyMonChon.Update(pKQHT_DangKyMonChonInfo);
            mErrorMessage = oDKQHT_DangKyMonChon.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyMonChon.ErrorNumber;
        }
        
        public void Delete(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            oDKQHT_DangKyMonChon.Delete(pKQHT_DangKyMonChonInfo);
            mErrorMessage = oDKQHT_DangKyMonChon.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyMonChon.ErrorNumber;
        }

        public void DeleteByMonHoc(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            oDKQHT_DangKyMonChon.DeleteByMonHoc(pKQHT_DangKyMonChonInfo);
            mErrorMessage = oDKQHT_DangKyMonChon.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyMonChon.ErrorNumber;
        }

        public List<KQHT_DangKyMonChonInfo> GetList(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            List<KQHT_DangKyMonChonInfo> oKQHT_DangKyMonChonInfoList = new List<KQHT_DangKyMonChonInfo>();
            DataTable dtb = Get(pKQHT_DangKyMonChonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DangKyMonChonInfo = new KQHT_DangKyMonChonInfo();

                    oKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID = int.Parse(dtb.Rows[i]["KQHT_DangKyMonChonID"].ToString());
                    oKQHT_DangKyMonChonInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oKQHT_DangKyMonChonInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    
                    oKQHT_DangKyMonChonInfoList.Add(oKQHT_DangKyMonChonInfo);
                }
            }
            return oKQHT_DangKyMonChonInfoList;
        }
        
        public void ToDataRow(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo, ref DataRow dr)
        {

			dr[pKQHT_DangKyMonChonInfo.strKQHT_DangKyMonChonID] = pKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID;
			dr[pKQHT_DangKyMonChonInfo.strIDSV_SinhVien] = pKQHT_DangKyMonChonInfo.IDSV_SinhVien;
			dr[pKQHT_DangKyMonChonInfo.strIDXL_MonHocTrongKy] = pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy;
			dr[pKQHT_DangKyMonChonInfo.strIDHT_User] = pKQHT_DangKyMonChonInfo.IDHT_User;
        }
        
        public void ToInfo(ref KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo, DataRow dr)
        {

			pKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID = int.Parse(dr[pKQHT_DangKyMonChonInfo.strKQHT_DangKyMonChonID].ToString());
			pKQHT_DangKyMonChonInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DangKyMonChonInfo.strIDSV_SinhVien].ToString());
			pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy = int.Parse(dr[pKQHT_DangKyMonChonInfo.strIDXL_MonHocTrongKy].ToString());
			pKQHT_DangKyMonChonInfo.IDHT_User = int.Parse(dr[pKQHT_DangKyMonChonInfo.strIDHT_User].ToString());
        }
    }
}
