using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhCongTac : cBBase
    {
        private cDNS_QuaTrinhCongTac oDNS_QuaTrinhCongTac;
        private NS_QuaTrinhCongTacInfo oNS_QuaTrinhCongTacInfo;

        public cBNS_QuaTrinhCongTac()        
        {
            oDNS_QuaTrinhCongTac = new cDNS_QuaTrinhCongTac();
        }

        public DataTable Get(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)        
        {
            return oDNS_QuaTrinhCongTac.Get(pNS_QuaTrinhCongTacInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhCongTac.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhCongTac.Add(pNS_QuaTrinhCongTacInfo);
            mErrorMessage = oDNS_QuaTrinhCongTac.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhCongTac.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            oDNS_QuaTrinhCongTac.Update(pNS_QuaTrinhCongTacInfo);
            mErrorMessage = oDNS_QuaTrinhCongTac.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhCongTac.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            oDNS_QuaTrinhCongTac.Delete(pNS_QuaTrinhCongTacInfo);
            mErrorMessage = oDNS_QuaTrinhCongTac.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhCongTac.ErrorNumber;
        }

        public List<NS_QuaTrinhCongTacInfo> GetList(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            List<NS_QuaTrinhCongTacInfo> oNS_QuaTrinhCongTacInfoList = new List<NS_QuaTrinhCongTacInfo>();
            DataTable dtb = Get(pNS_QuaTrinhCongTacInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhCongTacInfo = new NS_QuaTrinhCongTacInfo();

                    oNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID = int.Parse(dtb.Rows[i]["NS_QuaTrinhCongTacID"].ToString());
                    oNS_QuaTrinhCongTacInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhCongTacInfo.NoiCongTac = dtb.Rows[i]["NoiCongTac"].ToString();
                    oNS_QuaTrinhCongTacInfo.NoiDungCongTac = dtb.Rows[i]["NoiDungCongTac"].ToString();
                    oNS_QuaTrinhCongTacInfo.ChucVuDamNhiem = dtb.Rows[i]["ChucVuDamNhiem"].ToString();
                    oNS_QuaTrinhCongTacInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oNS_QuaTrinhCongTacInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    oNS_QuaTrinhCongTacInfo.DiNuocNgoai = bool.Parse(dtb.Rows[i]["DiNuocNgoai"].ToString());
                    oNS_QuaTrinhCongTacInfo.IDDM_QuocTich = int.Parse(dtb.Rows[i]["IDDM_QuocTich"].ToString());
                    
                    oNS_QuaTrinhCongTacInfoList.Add(oNS_QuaTrinhCongTacInfo);
                }
            }
            return oNS_QuaTrinhCongTacInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhCongTacInfo.strNS_QuaTrinhCongTacID] = pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID;
			dr[pNS_QuaTrinhCongTacInfo.strIDNS_GiaoVien] = pNS_QuaTrinhCongTacInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhCongTacInfo.strNoiCongTac] = pNS_QuaTrinhCongTacInfo.NoiCongTac;
			dr[pNS_QuaTrinhCongTacInfo.strNoiDungCongTac] = pNS_QuaTrinhCongTacInfo.NoiDungCongTac;
			dr[pNS_QuaTrinhCongTacInfo.strChucVuDamNhiem] = pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem;
			dr[pNS_QuaTrinhCongTacInfo.strTuNgay] = pNS_QuaTrinhCongTacInfo.TuNgay;
			dr[pNS_QuaTrinhCongTacInfo.strDenNgay] = pNS_QuaTrinhCongTacInfo.DenNgay;
			dr[pNS_QuaTrinhCongTacInfo.strDiNuocNgoai] = pNS_QuaTrinhCongTacInfo.DiNuocNgoai;
			dr[pNS_QuaTrinhCongTacInfo.strIDDM_QuocTich] = pNS_QuaTrinhCongTacInfo.IDDM_QuocTich;
        }
        
        public void ToInfo(ref NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo, DataRow dr)
        {

			pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID = int.Parse(dr[pNS_QuaTrinhCongTacInfo.strNS_QuaTrinhCongTacID].ToString());
			pNS_QuaTrinhCongTacInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhCongTacInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhCongTacInfo.NoiCongTac = dr[pNS_QuaTrinhCongTacInfo.strNoiCongTac].ToString();
			pNS_QuaTrinhCongTacInfo.NoiDungCongTac = dr[pNS_QuaTrinhCongTacInfo.strNoiDungCongTac].ToString();
			pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem = dr[pNS_QuaTrinhCongTacInfo.strChucVuDamNhiem].ToString();
            if (dr[pNS_QuaTrinhCongTacInfo.strTuNgay].ToString() != "")
			    pNS_QuaTrinhCongTacInfo.TuNgay = DateTime.Parse(dr[pNS_QuaTrinhCongTacInfo.strTuNgay].ToString());
            if (dr[pNS_QuaTrinhCongTacInfo.strDenNgay].ToString() != "")
			    pNS_QuaTrinhCongTacInfo.DenNgay = DateTime.Parse(dr[pNS_QuaTrinhCongTacInfo.strDenNgay].ToString());
			pNS_QuaTrinhCongTacInfo.DiNuocNgoai = bool.Parse(dr[pNS_QuaTrinhCongTacInfo.strDiNuocNgoai].ToString());
			pNS_QuaTrinhCongTacInfo.IDDM_QuocTich = int.Parse("0" + dr[pNS_QuaTrinhCongTacInfo.strIDDM_QuocTich]);
        }
    }
}
