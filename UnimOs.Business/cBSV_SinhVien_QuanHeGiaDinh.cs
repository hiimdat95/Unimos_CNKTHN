using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_QuanHeGiaDinh : cBBase
    {
        private cDSV_SinhVien_QuanHeGiaDinh oDSV_SinhVien_QuanHeGiaDinh;
        private SV_SinhVien_QuanHeGiaDinhInfo oSV_SinhVien_QuanHeGiaDinhInfo;

        public cBSV_SinhVien_QuanHeGiaDinh()        
        {
            oDSV_SinhVien_QuanHeGiaDinh = new cDSV_SinhVien_QuanHeGiaDinh();
        }

        public DataTable Get(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)        
        {
            return oDSV_SinhVien_QuanHeGiaDinh.Get(pSV_SinhVien_QuanHeGiaDinhInfo);
        }

        public DataTable GetBySinhVien(int IDSV_SinhVien)
        {
            return oDSV_SinhVien_QuanHeGiaDinh.GetBySinhVien(IDSV_SinhVien);
        }

        public int Add(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_QuanHeGiaDinh.Add(pSV_SinhVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDSV_SinhVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_QuanHeGiaDinh.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            oDSV_SinhVien_QuanHeGiaDinh.Update(pSV_SinhVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDSV_SinhVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_QuanHeGiaDinh.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            oDSV_SinhVien_QuanHeGiaDinh.Delete(pSV_SinhVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDSV_SinhVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_QuanHeGiaDinh.ErrorNumber;
        }

        public List<SV_SinhVien_QuanHeGiaDinhInfo> GetList(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            List<SV_SinhVien_QuanHeGiaDinhInfo> oSV_SinhVien_QuanHeGiaDinhInfoList = new List<SV_SinhVien_QuanHeGiaDinhInfo>();
            DataTable dtb = Get(pSV_SinhVien_QuanHeGiaDinhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_QuanHeGiaDinhInfo = new SV_SinhVien_QuanHeGiaDinhInfo();

                    oSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID = int.Parse(dtb.Rows[i]["SV_SinhVien_QuanHeGiaDinhID"].ToString());
                    oSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse(dtb.Rows[i]["IDDM_QuanHeGiaDinh"].ToString());
                    oSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen = dtb.Rows[i]["HoVaTen"].ToString();
                    oSV_SinhVien_QuanHeGiaDinhInfo.NamSinh = dtb.Rows[i]["NamSinh"].ToString();
                    oSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep = dtb.Rows[i]["NgheNghiep"].ToString();
                    oSV_SinhVien_QuanHeGiaDinhInfo.DiaChi = dtb.Rows[i]["DiaChi"].ToString();
                    oSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac = dtb.Rows[i]["ThongTinKhac"].ToString();
                    
                    oSV_SinhVien_QuanHeGiaDinhInfoList.Add(oSV_SinhVien_QuanHeGiaDinhInfo);
                }
            }
            return oSV_SinhVien_QuanHeGiaDinhInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strSV_SinhVien_QuanHeGiaDinhID] = pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strIDSV_SinhVien] = pSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strIDDM_QuanHeGiaDinh] = pSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strHoVaTen] = pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strNamSinh] = pSV_SinhVien_QuanHeGiaDinhInfo.NamSinh;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strNgheNghiep] = pSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strDiaChi] = pSV_SinhVien_QuanHeGiaDinhInfo.DiaChi;
			dr[pSV_SinhVien_QuanHeGiaDinhInfo.strThongTinKhac] = pSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac;
        }
        
        public void ToInfo(ref SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo, DataRow dr)
        {

			pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID = int.Parse(dr[pSV_SinhVien_QuanHeGiaDinhInfo.strSV_SinhVien_QuanHeGiaDinhID].ToString());
			pSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_QuanHeGiaDinhInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse(dr[pSV_SinhVien_QuanHeGiaDinhInfo.strIDDM_QuanHeGiaDinh].ToString());
			pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen = dr[pSV_SinhVien_QuanHeGiaDinhInfo.strHoVaTen].ToString();
			pSV_SinhVien_QuanHeGiaDinhInfo.NamSinh = dr[pSV_SinhVien_QuanHeGiaDinhInfo.strNamSinh].ToString();
			pSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep = dr[pSV_SinhVien_QuanHeGiaDinhInfo.strNgheNghiep].ToString();
			pSV_SinhVien_QuanHeGiaDinhInfo.DiaChi = dr[pSV_SinhVien_QuanHeGiaDinhInfo.strDiaChi].ToString();
			pSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac = dr[pSV_SinhVien_QuanHeGiaDinhInfo.strThongTinKhac].ToString();
        }
    }
}
