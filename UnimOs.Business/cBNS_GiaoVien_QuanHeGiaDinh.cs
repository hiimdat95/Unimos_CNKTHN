using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_GiaoVien_QuanHeGiaDinh : cBBase
    {
        private cDNS_GiaoVien_QuanHeGiaDinh oDNS_GiaoVien_QuanHeGiaDinh;
        private NS_GiaoVien_QuanHeGiaDinhInfo oNS_GiaoVien_QuanHeGiaDinhInfo;

        public cBNS_GiaoVien_QuanHeGiaDinh()        
        {
            oDNS_GiaoVien_QuanHeGiaDinh = new cDNS_GiaoVien_QuanHeGiaDinh();
        }

        public DataTable Get(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)        
        {
            return oDNS_GiaoVien_QuanHeGiaDinh.Get(pNS_GiaoVien_QuanHeGiaDinhInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_GiaoVien_QuanHeGiaDinh.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
			int ID = 0;
            ID = oDNS_GiaoVien_QuanHeGiaDinh.Add(pNS_GiaoVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDNS_GiaoVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_QuanHeGiaDinh.ErrorNumber;
            return ID;
        }

        public void Update(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            oDNS_GiaoVien_QuanHeGiaDinh.Update(pNS_GiaoVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDNS_GiaoVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_QuanHeGiaDinh.ErrorNumber;
        }
        
        public void Delete(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            oDNS_GiaoVien_QuanHeGiaDinh.Delete(pNS_GiaoVien_QuanHeGiaDinhInfo);
            mErrorMessage = oDNS_GiaoVien_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_QuanHeGiaDinh.ErrorNumber;
        }

        public List<NS_GiaoVien_QuanHeGiaDinhInfo> GetList(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            List<NS_GiaoVien_QuanHeGiaDinhInfo> oNS_GiaoVien_QuanHeGiaDinhInfoList = new List<NS_GiaoVien_QuanHeGiaDinhInfo>();
            DataTable dtb = Get(pNS_GiaoVien_QuanHeGiaDinhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_GiaoVien_QuanHeGiaDinhInfo = new NS_GiaoVien_QuanHeGiaDinhInfo();

                    oNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID = int.Parse(dtb.Rows[i]["NS_GiaoVien_QuanHeGiaDinhID"].ToString());
                    oNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse(dtb.Rows[i]["IDDM_QuanHeGiaDinh"].ToString());
                    oNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen = dtb.Rows[i]["HoVaTen"].ToString();
                    oNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh = dtb.Rows[i]["NamSinh"].ToString();
                    oNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan = dtb.Rows[i]["DiaChiQueQuan"].ToString();
                    oNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaQueQuan"].ToString());
                    oNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep = dtb.Rows[i]["NgheNghiep"].ToString();
                    oNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac = dtb.Rows[i]["ThongTinKhac"].ToString();
                    
                    oNS_GiaoVien_QuanHeGiaDinhInfoList.Add(oNS_GiaoVien_QuanHeGiaDinhInfo);
                }
            }
            return oNS_GiaoVien_QuanHeGiaDinhInfoList;
        }
        
        public void ToDataRow(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo, ref DataRow dr)
        {

			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNS_GiaoVien_QuanHeGiaDinhID] = pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDNS_GiaoVien] = pNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDDM_QuanHeGiaDinh] = pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strHoVaTen] = pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNamSinh] = pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strDiaChiQueQuan] = pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDDM_TinhHuyenXaQueQuan] = pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan;
            dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNgheNghiep] = pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep;
			dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strThongTinKhac] = pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac;
        }
        
        public void ToInfo(ref NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo, DataRow dr)
        {

			pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID = int.Parse(dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNS_GiaoVien_QuanHeGiaDinhID].ToString());
			pNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDNS_GiaoVien]);
			pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh = int.Parse("0" + dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDDM_QuanHeGiaDinh]);
			pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen = dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strHoVaTen].ToString();
			pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh = dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNamSinh].ToString();
			pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan = dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strDiaChiQueQuan].ToString();
			pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan = int.Parse("0" + dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strIDDM_TinhHuyenXaQueQuan]);
            pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep = dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strNgheNghiep].ToString();
            pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac = dr[pNS_GiaoVien_QuanHeGiaDinhInfo.strThongTinKhac].ToString();
        }
    }
}
