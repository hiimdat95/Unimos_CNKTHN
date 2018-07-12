using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_GiaoVien_NgoaiNgu : cBBase
    {
        private cDNS_GiaoVien_NgoaiNgu oDNS_GiaoVien_NgoaiNgu;
        private NS_GiaoVien_NgoaiNguInfo oNS_GiaoVien_NgoaiNguInfo;

        public cBNS_GiaoVien_NgoaiNgu()        
        {
            oDNS_GiaoVien_NgoaiNgu = new cDNS_GiaoVien_NgoaiNgu();
        }

        public DataTable Get(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)        
        {
            return oDNS_GiaoVien_NgoaiNgu.Get(pNS_GiaoVien_NgoaiNguInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_GiaoVien_NgoaiNgu.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
			int ID = 0;
            ID = oDNS_GiaoVien_NgoaiNgu.Add(pNS_GiaoVien_NgoaiNguInfo);
            mErrorMessage = oDNS_GiaoVien_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NgoaiNgu.ErrorNumber;
            return ID;
        }

        public void Update(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            oDNS_GiaoVien_NgoaiNgu.Update(pNS_GiaoVien_NgoaiNguInfo);
            mErrorMessage = oDNS_GiaoVien_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NgoaiNgu.ErrorNumber;
        }
        
        public void Delete(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            oDNS_GiaoVien_NgoaiNgu.Delete(pNS_GiaoVien_NgoaiNguInfo);
            mErrorMessage = oDNS_GiaoVien_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NgoaiNgu.ErrorNumber;
        }

        public List<NS_GiaoVien_NgoaiNguInfo> GetList(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            List<NS_GiaoVien_NgoaiNguInfo> oNS_GiaoVien_NgoaiNguInfoList = new List<NS_GiaoVien_NgoaiNguInfo>();
            DataTable dtb = Get(pNS_GiaoVien_NgoaiNguInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_GiaoVien_NgoaiNguInfo = new NS_GiaoVien_NgoaiNguInfo();

                    oNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID = int.Parse(dtb.Rows[i]["NS_GiaoVien_NgoaiNguID"].ToString());
                    oNS_GiaoVien_NgoaiNguInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_GiaoVien_NgoaiNguInfo.IDDM_NgoaiNgu = int.Parse(dtb.Rows[i]["IDDM_NgoaiNgu"].ToString());
                    oNS_GiaoVien_NgoaiNguInfo.TrinhDo = dtb.Rows[i]["TrinhDo"].ToString();
                    oNS_GiaoVien_NgoaiNguInfo.SoChungChi = dtb.Rows[i]["SoChungChi"].ToString();
                    oNS_GiaoVien_NgoaiNguInfo.NgayCap = DateTime.Parse(dtb.Rows[i]["NgayCap"].ToString());
                    oNS_GiaoVien_NgoaiNguInfo.NoiCap = dtb.Rows[i]["NoiCap"].ToString();
                    oNS_GiaoVien_NgoaiNguInfo.IDDM_TinhHuyenXaNoiCap = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaNoiCap"].ToString());
                    
                    oNS_GiaoVien_NgoaiNguInfoList.Add(oNS_GiaoVien_NgoaiNguInfo);
                }
            }
            return oNS_GiaoVien_NgoaiNguInfoList;
        }
        
        public void ToDataRow(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo, ref DataRow dr)
        {

			dr[pNS_GiaoVien_NgoaiNguInfo.strNS_GiaoVien_NgoaiNguID] = pNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID;
			dr[pNS_GiaoVien_NgoaiNguInfo.strIDNS_GiaoVien] = pNS_GiaoVien_NgoaiNguInfo.IDNS_GiaoVien;
			dr[pNS_GiaoVien_NgoaiNguInfo.strIDDM_NgoaiNgu] = pNS_GiaoVien_NgoaiNguInfo.IDDM_NgoaiNgu;
            dr[pNS_GiaoVien_NgoaiNguInfo.strIDTrinhDo] = pNS_GiaoVien_NgoaiNguInfo.IDTrinhDo;
			dr[pNS_GiaoVien_NgoaiNguInfo.strTrinhDo] = pNS_GiaoVien_NgoaiNguInfo.TrinhDo;
			dr[pNS_GiaoVien_NgoaiNguInfo.strSoChungChi] = pNS_GiaoVien_NgoaiNguInfo.SoChungChi;
			dr[pNS_GiaoVien_NgoaiNguInfo.strNgayCap] = pNS_GiaoVien_NgoaiNguInfo.NgayCap;
			dr[pNS_GiaoVien_NgoaiNguInfo.strNoiCap] = pNS_GiaoVien_NgoaiNguInfo.NoiCap;
			dr[pNS_GiaoVien_NgoaiNguInfo.strIDDM_TinhHuyenXaNoiCap] = pNS_GiaoVien_NgoaiNguInfo.IDDM_TinhHuyenXaNoiCap;
        }
        
        public void ToInfo(ref NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo, DataRow dr)
        {

			pNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID = int.Parse(dr[pNS_GiaoVien_NgoaiNguInfo.strNS_GiaoVien_NgoaiNguID].ToString());
			pNS_GiaoVien_NgoaiNguInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_GiaoVien_NgoaiNguInfo.strIDNS_GiaoVien]);
			pNS_GiaoVien_NgoaiNguInfo.IDDM_NgoaiNgu = int.Parse("0" + dr[pNS_GiaoVien_NgoaiNguInfo.strIDDM_NgoaiNgu]);
            pNS_GiaoVien_NgoaiNguInfo.IDTrinhDo = "" + dr[pNS_GiaoVien_NgoaiNguInfo.strIDTrinhDo];
			pNS_GiaoVien_NgoaiNguInfo.TrinhDo = dr[pNS_GiaoVien_NgoaiNguInfo.strTrinhDo].ToString();
			pNS_GiaoVien_NgoaiNguInfo.SoChungChi = dr[pNS_GiaoVien_NgoaiNguInfo.strSoChungChi].ToString();
            if(dr[pNS_GiaoVien_NgoaiNguInfo.strNgayCap].ToString() != "")
			    pNS_GiaoVien_NgoaiNguInfo.NgayCap = DateTime.Parse(dr[pNS_GiaoVien_NgoaiNguInfo.strNgayCap].ToString());
			pNS_GiaoVien_NgoaiNguInfo.NoiCap = dr[pNS_GiaoVien_NgoaiNguInfo.strNoiCap].ToString();
			pNS_GiaoVien_NgoaiNguInfo.IDDM_TinhHuyenXaNoiCap = int.Parse("0" + dr[pNS_GiaoVien_NgoaiNguInfo.strIDDM_TinhHuyenXaNoiCap]);
        }
    }
}
