using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_QuyenHoaDon : cBBase
    {
        private cDTC_QuyenHoaDon oDTC_QuyenHoaDon;
        private TC_QuyenHoaDonInfo oTC_QuyenHoaDonInfo;

        public cBTC_QuyenHoaDon()        
        {
            oDTC_QuyenHoaDon = new cDTC_QuyenHoaDon();
            oTC_QuyenHoaDonInfo = new TC_QuyenHoaDonInfo();
        }

        public DataTable GetByHocKy_NamHoc(int HocKy, int IDDM_NamHoc)
        {
            return oDTC_QuyenHoaDon.GetByHocKy_NamHoc(HocKy, IDDM_NamHoc);
        }

        public DataTable GetTrinhDo(int Type, int IDTC_QuyenHoaDon, int HocKy, int IDDM_NamHoc)
        {
            return oDTC_QuyenHoaDon.GetTrinhDo(Type, IDTC_QuyenHoaDon, HocKy, IDDM_NamHoc);
        }


        public DataTable Get(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)        
        {
            return oDTC_QuyenHoaDon.Get(pTC_QuyenHoaDonInfo);
        }

        public int Add(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
			int ID = 0;
            ID = oDTC_QuyenHoaDon.Add(pTC_QuyenHoaDonInfo);
            mErrorMessage = oDTC_QuyenHoaDon.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon.ErrorNumber;
            return ID;
        }

        public void Update(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            oDTC_QuyenHoaDon.Update(pTC_QuyenHoaDonInfo);
            mErrorMessage = oDTC_QuyenHoaDon.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon.ErrorNumber;
        }
        
        public void Delete(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            oDTC_QuyenHoaDon.Delete(pTC_QuyenHoaDonInfo);
            mErrorMessage = oDTC_QuyenHoaDon.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon.ErrorNumber;
        }

        public List<TC_QuyenHoaDonInfo> GetList(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            List<TC_QuyenHoaDonInfo> oTC_QuyenHoaDonInfoList = new List<TC_QuyenHoaDonInfo>();
            DataTable dtb = Get(pTC_QuyenHoaDonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_QuyenHoaDonInfo = new TC_QuyenHoaDonInfo();

                    oTC_QuyenHoaDonInfo.TC_QuyenHoaDonID = int.Parse(dtb.Rows[i][oTC_QuyenHoaDonInfo.strTC_QuyenHoaDonID].ToString());
                    oTC_QuyenHoaDonInfo.TenQuyenHoaDon = dtb.Rows[i][oTC_QuyenHoaDonInfo.strTenQuyenHoaDon].ToString();
                    oTC_QuyenHoaDonInfo.TuSo = dtb.Rows[i][oTC_QuyenHoaDonInfo.strTuSo].ToString();
                    oTC_QuyenHoaDonInfo.SoHienTai = dtb.Rows[i][oTC_QuyenHoaDonInfo.strSoHienTai].ToString();
                    oTC_QuyenHoaDonInfo.HocKy = int.Parse(dtb.Rows[i][oTC_QuyenHoaDonInfo.strHocKy].ToString());
                    oTC_QuyenHoaDonInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i][oTC_QuyenHoaDonInfo.strIDDM_NamHoc].ToString());
                    
                    oTC_QuyenHoaDonInfoList.Add(oTC_QuyenHoaDonInfo);
                }
            }
            return oTC_QuyenHoaDonInfoList;
        }
        
        public void ToDataRow(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo, ref DataRow dr)
        {

			dr[pTC_QuyenHoaDonInfo.strTC_QuyenHoaDonID] = pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID;
            dr[pTC_QuyenHoaDonInfo.strIDDM_DiaDiem] = pTC_QuyenHoaDonInfo.IDDM_DiaDiem;
			dr[pTC_QuyenHoaDonInfo.strTenQuyenHoaDon] = pTC_QuyenHoaDonInfo.TenQuyenHoaDon;
			dr[pTC_QuyenHoaDonInfo.strTuSo] = pTC_QuyenHoaDonInfo.TuSo;
			dr[pTC_QuyenHoaDonInfo.strSoHienTai] = pTC_QuyenHoaDonInfo.SoHienTai;
			dr[pTC_QuyenHoaDonInfo.strHocKy] = pTC_QuyenHoaDonInfo.HocKy;
			dr[pTC_QuyenHoaDonInfo.strIDDM_NamHoc] = pTC_QuyenHoaDonInfo.IDDM_NamHoc;
        }
        
        public void ToInfo(ref TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo, DataRow dr)
        {

			pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID = int.Parse(dr[oTC_QuyenHoaDonInfo.strTC_QuyenHoaDonID].ToString());
            pTC_QuyenHoaDonInfo.IDDM_DiaDiem = int.Parse(dr[oTC_QuyenHoaDonInfo.strIDDM_DiaDiem].ToString());
			pTC_QuyenHoaDonInfo.TenQuyenHoaDon = dr[oTC_QuyenHoaDonInfo.strTenQuyenHoaDon].ToString();
			pTC_QuyenHoaDonInfo.TuSo = dr[oTC_QuyenHoaDonInfo.strTuSo].ToString();
			pTC_QuyenHoaDonInfo.SoHienTai = dr[oTC_QuyenHoaDonInfo.strSoHienTai].ToString();
			pTC_QuyenHoaDonInfo.HocKy = int.Parse(dr[oTC_QuyenHoaDonInfo.strHocKy].ToString());
			pTC_QuyenHoaDonInfo.IDDM_NamHoc = int.Parse(dr[oTC_QuyenHoaDonInfo.strIDDM_NamHoc].ToString());
        }
    }
}
