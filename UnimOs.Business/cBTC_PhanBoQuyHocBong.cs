using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_PhanBoQuyHocBong : cBBase
    {
        private cDTC_PhanBoQuyHocBong oDTC_PhanBoQuyHocBong;
        private TC_PhanBoQuyHocBongInfo oTC_PhanBoQuyHocBongInfo;

        public cBTC_PhanBoQuyHocBong()        
        {
            oDTC_PhanBoQuyHocBong = new cDTC_PhanBoQuyHocBong();
        }

        public DataTable Get(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)        
        {
            return oDTC_PhanBoQuyHocBong.Get(pTC_PhanBoQuyHocBongInfo);
        }

        public DataTable GetDoiTuong(int KHoa,int KhoaHOc, int Nganh, int Lop)
        {
            return oDTC_PhanBoQuyHocBong.GetDoiTuong(KHoa, KhoaHOc, Nganh, Lop);
        }

        public DataTable GetByQuyHocBong(int IDTC_QuyHocBong, int IDDM_NamHoc, int HOcKy,int PhanDacBiet)
        {
            return oDTC_PhanBoQuyHocBong.GetByQuyHocBong(IDTC_QuyHocBong, IDDM_NamHoc, HOcKy, PhanDacBiet);
        }

        public int Add(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
			int ID = 0;
            ID = oDTC_PhanBoQuyHocBong.Add(pTC_PhanBoQuyHocBongInfo);
            mErrorMessage = oDTC_PhanBoQuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_PhanBoQuyHocBong.ErrorNumber;
            return ID;
        }

        public void Update(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            oDTC_PhanBoQuyHocBong.Update(pTC_PhanBoQuyHocBongInfo);
            mErrorMessage = oDTC_PhanBoQuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_PhanBoQuyHocBong.ErrorNumber;
        }
        
        public void Delete(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            oDTC_PhanBoQuyHocBong.Delete(pTC_PhanBoQuyHocBongInfo);
            mErrorMessage = oDTC_PhanBoQuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_PhanBoQuyHocBong.ErrorNumber;
        }

        public void DeleteBy_QuyHocBong(int IDTC_QuyHocBong, int HocKy, int IDDM_NamHoc)
        {
            oDTC_PhanBoQuyHocBong.DeleteBy_QuyHocBong(IDTC_QuyHocBong,HocKy,IDDM_NamHoc);
            mErrorMessage = oDTC_PhanBoQuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_PhanBoQuyHocBong.ErrorNumber;
        }

        public List<TC_PhanBoQuyHocBongInfo> GetList(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            List<TC_PhanBoQuyHocBongInfo> oTC_PhanBoQuyHocBongInfoList = new List<TC_PhanBoQuyHocBongInfo>();
            DataTable dtb = Get(pTC_PhanBoQuyHocBongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_PhanBoQuyHocBongInfo = new TC_PhanBoQuyHocBongInfo();

                    oTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID = int.Parse(dtb.Rows[i]["TC_PhanBoQuyHocBongID"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_PhanBoQuyHocBongInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong = int.Parse(dtb.Rows[i]["IDTC_QuyHocBong"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc = int.Parse(dtb.Rows[i]["IDDM_KhoaHoc"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oTC_PhanBoQuyHocBongInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oTC_PhanBoQuyHocBongInfo.SoSinhVien = int.Parse(dtb.Rows[i]["SoSinhVien"].ToString());
                    oTC_PhanBoQuyHocBongInfo.SoTien = float.Parse(dtb.Rows[i]["SoTien"].ToString());
                    oTC_PhanBoQuyHocBongInfo.PhanDacBiet = bool.Parse(dtb.Rows[i]["PhanDacBiet"].ToString());
                    
                    oTC_PhanBoQuyHocBongInfoList.Add(oTC_PhanBoQuyHocBongInfo);
                }
            }
            return oTC_PhanBoQuyHocBongInfoList;
        }
        
        public void ToDataRow(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo, ref DataRow dr)
        {

			dr[pTC_PhanBoQuyHocBongInfo.strTC_PhanBoQuyHocBongID] = pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID;
			dr[pTC_PhanBoQuyHocBongInfo.strIDDM_NamHoc] = pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc;
			dr[pTC_PhanBoQuyHocBongInfo.strHocKy] = pTC_PhanBoQuyHocBongInfo.HocKy;
			dr[pTC_PhanBoQuyHocBongInfo.strIDTC_QuyHocBong] = pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong;
			dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Khoa] = pTC_PhanBoQuyHocBongInfo.IDDM_Khoa;
			dr[pTC_PhanBoQuyHocBongInfo.strIDDM_KhoaHoc] = pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc;
			dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Nganh] = pTC_PhanBoQuyHocBongInfo.IDDM_Nganh;
			dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Lop] = pTC_PhanBoQuyHocBongInfo.IDDM_Lop;
			dr[pTC_PhanBoQuyHocBongInfo.strSoSinhVien] = pTC_PhanBoQuyHocBongInfo.SoSinhVien;
			dr[pTC_PhanBoQuyHocBongInfo.strSoTien] = pTC_PhanBoQuyHocBongInfo.SoTien;
			dr[pTC_PhanBoQuyHocBongInfo.strPhanDacBiet] = pTC_PhanBoQuyHocBongInfo.PhanDacBiet;
        }
        
        public void ToInfo(ref TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo, DataRow dr)
        {

			pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strTC_PhanBoQuyHocBongID].ToString());
			pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDDM_NamHoc].ToString());
			pTC_PhanBoQuyHocBongInfo.HocKy = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strHocKy].ToString());
			pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDTC_QuyHocBong].ToString());
			pTC_PhanBoQuyHocBongInfo.IDDM_Khoa = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Khoa].ToString());
			pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDDM_KhoaHoc].ToString());
			pTC_PhanBoQuyHocBongInfo.IDDM_Nganh = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Nganh].ToString());
			pTC_PhanBoQuyHocBongInfo.IDDM_Lop = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strIDDM_Lop].ToString());
			pTC_PhanBoQuyHocBongInfo.SoSinhVien = int.Parse(dr[pTC_PhanBoQuyHocBongInfo.strSoSinhVien].ToString());
			pTC_PhanBoQuyHocBongInfo.SoTien = float.Parse(dr[pTC_PhanBoQuyHocBongInfo.strSoTien].ToString());
			pTC_PhanBoQuyHocBongInfo.PhanDacBiet = bool.Parse(dr[pTC_PhanBoQuyHocBongInfo.strPhanDacBiet].ToString());
        }
    }
}
