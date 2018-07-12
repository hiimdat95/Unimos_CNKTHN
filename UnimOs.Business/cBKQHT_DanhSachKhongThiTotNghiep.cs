using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DanhSachKhongThiTotNghiep : cBBase
    {
        private cDKQHT_DanhSachKhongThiTotNghiep oDKQHT_DanhSachKhongThiTotNghiep;
        private KQHT_DanhSachKhongThiTotNghiepInfo oKQHT_DanhSachKhongThiTotNghiepInfo;

        public cBKQHT_DanhSachKhongThiTotNghiep()        
        {
            oDKQHT_DanhSachKhongThiTotNghiep = new cDKQHT_DanhSachKhongThiTotNghiep();
        }

        public DataTable Get(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)        
        {
            return oDKQHT_DanhSachKhongThiTotNghiep.Get(pKQHT_DanhSachKhongThiTotNghiepInfo);
        }

        public DataTable GetInSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DanhSachKhongThiTotNghiep.GetInSinhVien(pDM_LopInfo, NamHoc, IDDM_NamHoc);
        }

        public DataTable GetNotInSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DanhSachKhongThiTotNghiep.GetNotInSinhVien(pDM_LopInfo, NamHoc, IDDM_NamHoc);
        }

        public int Add(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_DanhSachKhongThiTotNghiep.Add(pKQHT_DanhSachKhongThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThiTotNghiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            oDKQHT_DanhSachKhongThiTotNghiep.Update(pKQHT_DanhSachKhongThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThiTotNghiep.ErrorNumber;
        }
        
        public void Delete(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            oDKQHT_DanhSachKhongThiTotNghiep.Delete(pKQHT_DanhSachKhongThiTotNghiepInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThiTotNghiep.ErrorNumber;
        }

        public void DeleteAll(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            oDKQHT_DanhSachKhongThiTotNghiep.DeleteAll(pDM_LopInfo, NamHoc, IDDM_NamHoc);
        }

        public List<KQHT_DanhSachKhongThiTotNghiepInfo> GetList(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            List<KQHT_DanhSachKhongThiTotNghiepInfo> oKQHT_DanhSachKhongThiTotNghiepInfoList = new List<KQHT_DanhSachKhongThiTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_DanhSachKhongThiTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DanhSachKhongThiTotNghiepInfo = new KQHT_DanhSachKhongThiTotNghiepInfo();

                    oKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID = int.Parse(dtb.Rows[i]["KQHT_DanhSachKhongThiTotNghiepID"].ToString());
                    oKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DanhSachKhongThiTotNghiepInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    oKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DanhSachKhongThiTotNghiepInfo.XetVot = bool.Parse(dtb.Rows[i]["XetVot"].ToString());
                    
                    oKQHT_DanhSachKhongThiTotNghiepInfoList.Add(oKQHT_DanhSachKhongThiTotNghiepInfo);
                }
            }
            return oKQHT_DanhSachKhongThiTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo, ref DataRow dr)
        {
			dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strKQHT_DanhSachKhongThiTotNghiepID] = pKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID;
			dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strIDSV_SinhVien] = pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien;
			dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strLyDo] = pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo;
			dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strIDDM_NamHoc] = pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc;
			dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strXetVot] = pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot;
        }
        
        public void ToInfo(ref KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo, DataRow dr)
        {
			pKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID = int.Parse(dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strKQHT_DanhSachKhongThiTotNghiepID].ToString());
			pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strIDSV_SinhVien].ToString());
			pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo = dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strLyDo].ToString();
			pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strIDDM_NamHoc].ToString());
			pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot = bool.Parse(dr[pKQHT_DanhSachKhongThiTotNghiepInfo.strXetVot].ToString());
        }
    }
}
