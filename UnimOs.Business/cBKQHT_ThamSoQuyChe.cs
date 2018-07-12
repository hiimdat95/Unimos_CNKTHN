using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ThamSoQuyChe : cBBase
    {
        private cDKQHT_ThamSoQuyChe oDKQHT_ThamSoQuyChe;
        private KQHT_ThamSoQuyCheInfo oKQHT_ThamSoQuyCheInfo;

        public cBKQHT_ThamSoQuyChe()        
        {
            oDKQHT_ThamSoQuyChe = new cDKQHT_ThamSoQuyChe();
        }

        public DataTable Get(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)        
        {
            return oDKQHT_ThamSoQuyChe.Get(pKQHT_ThamSoQuyCheInfo);
        }

        public int Add(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
			int ID = 0;
            ID = oDKQHT_ThamSoQuyChe.Add(pKQHT_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_ThamSoQuyChe.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            oDKQHT_ThamSoQuyChe.Update(pKQHT_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_ThamSoQuyChe.ErrorNumber;
        }
        
        public void Delete(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            oDKQHT_ThamSoQuyChe.Delete(pKQHT_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_ThamSoQuyChe.ErrorNumber;
        }

        public List<KQHT_ThamSoQuyCheInfo> GetList(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            List<KQHT_ThamSoQuyCheInfo> oKQHT_ThamSoQuyCheInfoList = new List<KQHT_ThamSoQuyCheInfo>();
            DataTable dtb = Get(pKQHT_ThamSoQuyCheInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_ThamSoQuyCheInfo = new KQHT_ThamSoQuyCheInfo();

                    oKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID = int.Parse(dtb.Rows[i]["KQHT_ThamSoQuyCheID"].ToString());
                    oKQHT_ThamSoQuyCheInfo.MaThamSo = dtb.Rows[i]["MaThamSo"].ToString();
                    oKQHT_ThamSoQuyCheInfo.TenThamSo = dtb.Rows[i]["TenThamSo"].ToString();
                    oKQHT_ThamSoQuyCheInfo.GiaTriMacDinh = dtb.Rows[i]["GiaTriMacDinh"].ToString();
                    oKQHT_ThamSoQuyCheInfo.KieuTruong = dtb.Rows[i]["KieuTruong"].ToString();
                    
                    oKQHT_ThamSoQuyCheInfoList.Add(oKQHT_ThamSoQuyCheInfo);
                }
            }
            return oKQHT_ThamSoQuyCheInfoList;
        }
        
        public void ToDataRow(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo, ref DataRow dr)
        {

			dr[pKQHT_ThamSoQuyCheInfo.strKQHT_ThamSoQuyCheID] = pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID;
			dr[pKQHT_ThamSoQuyCheInfo.strMaThamSo] = pKQHT_ThamSoQuyCheInfo.MaThamSo;
			dr[pKQHT_ThamSoQuyCheInfo.strTenThamSo] = pKQHT_ThamSoQuyCheInfo.TenThamSo;
			dr[pKQHT_ThamSoQuyCheInfo.strGiaTriMacDinh] = pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh;
			dr[pKQHT_ThamSoQuyCheInfo.strKieuTruong] = pKQHT_ThamSoQuyCheInfo.KieuTruong;
        }
        
        public void ToInfo(ref KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo, DataRow dr)
        {

			pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID = int.Parse(dr[pKQHT_ThamSoQuyCheInfo.strKQHT_ThamSoQuyCheID].ToString());
			pKQHT_ThamSoQuyCheInfo.MaThamSo = dr[pKQHT_ThamSoQuyCheInfo.strMaThamSo].ToString();
			pKQHT_ThamSoQuyCheInfo.TenThamSo = dr[pKQHT_ThamSoQuyCheInfo.strTenThamSo].ToString();
			pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh = dr[pKQHT_ThamSoQuyCheInfo.strGiaTriMacDinh].ToString();
			pKQHT_ThamSoQuyCheInfo.KieuTruong = dr[pKQHT_ThamSoQuyCheInfo.strKieuTruong].ToString();
        }
    }
}
