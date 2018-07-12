using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_QuyetDinhTotNghiep : cBBase
    {
        private cDKQHT_QuyetDinhTotNghiep oDKQHT_QuyetDinhTotNghiep;

        public cBKQHT_QuyetDinhTotNghiep()        
        {
            oDKQHT_QuyetDinhTotNghiep = new cDKQHT_QuyetDinhTotNghiep();
        }

        public DataTable Get(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)        
        {
            return oDKQHT_QuyetDinhTotNghiep.Get(pKQHT_QuyetDinhTotNghiepInfo);
        }

        public DataTable GetByIDDM_NamHoc(int IDDM_NamHoc)
        {
            return oDKQHT_QuyetDinhTotNghiep.GetByIDDM_NamHoc(IDDM_NamHoc);
        }

        public int Add(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_QuyetDinhTotNghiep.Add(pKQHT_QuyetDinhTotNghiepInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            oDKQHT_QuyetDinhTotNghiep.Update(pKQHT_QuyetDinhTotNghiepInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep.ErrorNumber;
        }
        
        public void Delete(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            oDKQHT_QuyetDinhTotNghiep.Delete(pKQHT_QuyetDinhTotNghiepInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep.ErrorNumber;
        }

        public List<KQHT_QuyetDinhTotNghiepInfo> GetList(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            List<KQHT_QuyetDinhTotNghiepInfo> oKQHT_QuyetDinhTotNghiepInfoList = new List<KQHT_QuyetDinhTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_QuyetDinhTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pKQHT_QuyetDinhTotNghiepInfo = new KQHT_QuyetDinhTotNghiepInfo();

                    pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID = int.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID].ToString());
                    pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh = dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strSoQuyetDinh].ToString();
                    pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strNgayQuyetDinh].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strNoiDung] != "")
                    	pKQHT_QuyetDinhTotNghiepInfo.NoiDung = dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strNoiDung].ToString();
                    pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiepInfo.strIDDM_NamHoc].ToString());
                    
                    oKQHT_QuyetDinhTotNghiepInfoList.Add(pKQHT_QuyetDinhTotNghiepInfo);
                }
            }
            return oKQHT_QuyetDinhTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo, ref DataRow dr)
        {

			dr[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID] = pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID;
			dr[pKQHT_QuyetDinhTotNghiepInfo.strSoQuyetDinh] = pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh;
			dr[pKQHT_QuyetDinhTotNghiepInfo.strNgayQuyetDinh] = pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh;
			dr[pKQHT_QuyetDinhTotNghiepInfo.strNoiDung] = pKQHT_QuyetDinhTotNghiepInfo.NoiDung;
			dr[pKQHT_QuyetDinhTotNghiepInfo.strIDDM_NamHoc] = pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc;
        }
        
        public void ToInfo(ref KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo, DataRow dr)
        {

			pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID = int.Parse(dr[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID].ToString());
			pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh = dr[pKQHT_QuyetDinhTotNghiepInfo.strSoQuyetDinh].ToString();
			pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh = DateTime.Parse(dr[pKQHT_QuyetDinhTotNghiepInfo.strNgayQuyetDinh].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiepInfo.strNoiDung] != "")
				pKQHT_QuyetDinhTotNghiepInfo.NoiDung = dr[pKQHT_QuyetDinhTotNghiepInfo.strNoiDung].ToString();
			pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_QuyetDinhTotNghiepInfo.strIDDM_NamHoc].ToString());
        }
    }
}
