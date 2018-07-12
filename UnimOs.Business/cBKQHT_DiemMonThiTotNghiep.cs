using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemMonThiTotNghiep : cBBase
    {
        private cDKQHT_DiemMonThiTotNghiep oDKQHT_DiemMonThiTotNghiep;

        public cBKQHT_DiemMonThiTotNghiep()        
        {
            oDKQHT_DiemMonThiTotNghiep = new cDKQHT_DiemMonThiTotNghiep();
        }

        public DataTable Get(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)        
        {
            return oDKQHT_DiemMonThiTotNghiep.Get(pKQHT_DiemMonThiTotNghiepInfo);
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDKQHT_MonThiTotNghiep_Lop, int LanThi)
        {
            return oDKQHT_DiemMonThiTotNghiep.GetDanhSach(IDDM_Lop, IDKQHT_MonThiTotNghiep_Lop, LanThi);
        }

        public long Add(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
			long ID = 0;
            ID = oDKQHT_DiemMonThiTotNghiep.Add(pKQHT_DiemMonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DiemMonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DiemMonThiTotNghiep.ErrorNumber;
            return ID;
        }

        public void AddUpdate(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo,int IDDM_MonHoc, int IDDM_Lop)
        {
            oDKQHT_DiemMonThiTotNghiep.AddUpdate(pKQHT_DiemMonThiTotNghiepInfo, IDDM_MonHoc, IDDM_Lop);
            mErrorMessage = oDKQHT_DiemMonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DiemMonThiTotNghiep.ErrorNumber;
        }

        public void Update(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            oDKQHT_DiemMonThiTotNghiep.Update(pKQHT_DiemMonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DiemMonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DiemMonThiTotNghiep.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            oDKQHT_DiemMonThiTotNghiep.Delete(pKQHT_DiemMonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DiemMonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DiemMonThiTotNghiep.ErrorNumber;
        }

        public List<KQHT_DiemMonThiTotNghiepInfo> GetList(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            List<KQHT_DiemMonThiTotNghiepInfo> oKQHT_DiemMonThiTotNghiepInfoList = new List<KQHT_DiemMonThiTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_DiemMonThiTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pKQHT_DiemMonThiTotNghiepInfo = new KQHT_DiemMonThiTotNghiepInfo();

                    pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID = long.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strKQHT_DiemMonThiTotNghiepID].ToString());
                    pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strIDSV_SinhVien].ToString());
                    pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop = int.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_MonThiTotNghiep_Lop].ToString());
                    pKQHT_DiemMonThiTotNghiepInfo.LanThi = int.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strLanThi].ToString());
                    pKQHT_DiemMonThiTotNghiepInfo.Diem = double.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strDiem].ToString());
                    if("" + dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_XepLoai] != "")
                    	pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai = int.Parse(dtb.Rows[i][pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_XepLoai].ToString());
                    
                    oKQHT_DiemMonThiTotNghiepInfoList.Add(pKQHT_DiemMonThiTotNghiepInfo);
                }
            }
            return oKQHT_DiemMonThiTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo, ref DataRow dr)
        {

			dr[pKQHT_DiemMonThiTotNghiepInfo.strKQHT_DiemMonThiTotNghiepID] = pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID;
			dr[pKQHT_DiemMonThiTotNghiepInfo.strIDSV_SinhVien] = pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien;
			dr[pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_MonThiTotNghiep_Lop] = pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop;
			dr[pKQHT_DiemMonThiTotNghiepInfo.strLanThi] = pKQHT_DiemMonThiTotNghiepInfo.LanThi;
			dr[pKQHT_DiemMonThiTotNghiepInfo.strDiem] = pKQHT_DiemMonThiTotNghiepInfo.Diem;
			dr[pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_XepLoai] = pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai;
        }
        
        public void ToInfo(ref KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo, DataRow dr)
        {

			pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID = long.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strKQHT_DiemMonThiTotNghiepID].ToString());
			pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strIDSV_SinhVien].ToString());
			pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop = int.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_MonThiTotNghiep_Lop].ToString());
			pKQHT_DiemMonThiTotNghiepInfo.LanThi = int.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strLanThi].ToString());
			pKQHT_DiemMonThiTotNghiepInfo.Diem = double.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strDiem].ToString());
			if("" + dr[pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_XepLoai] != "")
				pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai = int.Parse(dr[pKQHT_DiemMonThiTotNghiepInfo.strIDKQHT_XepLoai].ToString());
        }
    }
}
