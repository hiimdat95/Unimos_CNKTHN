using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_NhomNgach : cBBase
    {
        private cDNS_NhomNgach oDNS_NhomNgach;
        private NS_NhomNgachInfo oNS_NhomNgachInfo;

        public cBNS_NhomNgach()        
        {
            oDNS_NhomNgach = new cDNS_NhomNgach();
        }

        public DataTable Get(NS_NhomNgachInfo pNS_NhomNgachInfo)        
        {
            return oDNS_NhomNgach.Get(pNS_NhomNgachInfo);
        }

        public DataTable GetBy_NS_NgachCongChucID(int NS_NgachCongChucID)
        {
            return oDNS_NhomNgach.GetBy_NS_NgachCongChucID(NS_NgachCongChucID);
        }

        public int Add(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
			int ID = 0;
            ID = oDNS_NhomNgach.Add(pNS_NhomNgachInfo);
            mErrorMessage = oDNS_NhomNgach.ErrorMessages;
            mErrorNumber = oDNS_NhomNgach.ErrorNumber;
            return ID;
        }

        public void Update(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            oDNS_NhomNgach.Update(pNS_NhomNgachInfo);
            mErrorMessage = oDNS_NhomNgach.ErrorMessages;
            mErrorNumber = oDNS_NhomNgach.ErrorNumber;
        }
        
        public void Delete(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            oDNS_NhomNgach.Delete(pNS_NhomNgachInfo);
            mErrorMessage = oDNS_NhomNgach.ErrorMessages;
            mErrorNumber = oDNS_NhomNgach.ErrorNumber;
        }

        public List<NS_NhomNgachInfo> GetList(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            List<NS_NhomNgachInfo> oNS_NhomNgachInfoList = new List<NS_NhomNgachInfo>();
            DataTable dtb = Get(pNS_NhomNgachInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_NhomNgachInfo = new NS_NhomNgachInfo();

                    oNS_NhomNgachInfo.NS_NhomNgachID = int.Parse(dtb.Rows[i]["NS_NhomNgachID"].ToString());
                    oNS_NhomNgachInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oNS_NhomNgachInfo.TenNhomNgach = dtb.Rows[i]["TenNhomNgach"].ToString();
                    oNS_NhomNgachInfo.LoaiCongChuc = dtb.Rows[i]["LoaiCongChuc"].ToString();
                    oNS_NhomNgachInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    oNS_NhomNgachInfo.SoNamNangBac = double.Parse(dtb.Rows[i]["SoNamNangBac"].ToString());
                    oNS_NhomNgachInfo.BacCaoNhat = int.Parse(dtb.Rows[i]["BacCaoNhat"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_1 = double.Parse(dtb.Rows[i]["HeSoLuongBac_1"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_2 = double.Parse(dtb.Rows[i]["HeSoLuongBac_2"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_3 = double.Parse(dtb.Rows[i]["HeSoLuongBac_3"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_4 = double.Parse(dtb.Rows[i]["HeSoLuongBac_4"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_5 = double.Parse(dtb.Rows[i]["HeSoLuongBac_5"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_6 = double.Parse(dtb.Rows[i]["HeSoLuongBac_6"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_7 = double.Parse(dtb.Rows[i]["HeSoLuongBac_7"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_8 = double.Parse(dtb.Rows[i]["HeSoLuongBac_8"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_9 = double.Parse(dtb.Rows[i]["HeSoLuongBac_9"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_10 = double.Parse(dtb.Rows[i]["HeSoLuongBac_10"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_11 = double.Parse(dtb.Rows[i]["HeSoLuongBac_11"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_12 = double.Parse(dtb.Rows[i]["HeSoLuongBac_12"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_13 = double.Parse(dtb.Rows[i]["HeSoLuongBac_13"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_14 = double.Parse(dtb.Rows[i]["HeSoLuongBac_14"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_15 = double.Parse(dtb.Rows[i]["HeSoLuongBac_15"].ToString());
                    oNS_NhomNgachInfo.HeSoLuongBac_16 = double.Parse(dtb.Rows[i]["HeSoLuongBac_16"].ToString());
                    
                    oNS_NhomNgachInfoList.Add(oNS_NhomNgachInfo);
                }
            }
            return oNS_NhomNgachInfoList;
        }
        
        public void ToDataRow(NS_NhomNgachInfo pNS_NhomNgachInfo, ref DataRow dr)
        {

			dr[pNS_NhomNgachInfo.strNS_NhomNgachID] = pNS_NhomNgachInfo.NS_NhomNgachID;
			dr[pNS_NhomNgachInfo.strKyHieu] = pNS_NhomNgachInfo.KyHieu;
			dr[pNS_NhomNgachInfo.strTenNhomNgach] = pNS_NhomNgachInfo.TenNhomNgach;
			dr[pNS_NhomNgachInfo.strLoaiCongChuc] = pNS_NhomNgachInfo.LoaiCongChuc;
            dr[pNS_NhomNgachInfo.strIDNS_LinhVucCongTac] = pNS_NhomNgachInfo.IDNS_LinhVucCongTac;
			dr[pNS_NhomNgachInfo.strMoTa] = pNS_NhomNgachInfo.MoTa;
			dr[pNS_NhomNgachInfo.strSoNamNangBac] = pNS_NhomNgachInfo.SoNamNangBac;
			dr[pNS_NhomNgachInfo.strBacCaoNhat] = pNS_NhomNgachInfo.BacCaoNhat;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_1] = pNS_NhomNgachInfo.HeSoLuongBac_1;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_2] = pNS_NhomNgachInfo.HeSoLuongBac_2;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_3] = pNS_NhomNgachInfo.HeSoLuongBac_3;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_4] = pNS_NhomNgachInfo.HeSoLuongBac_4;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_5] = pNS_NhomNgachInfo.HeSoLuongBac_5;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_6] = pNS_NhomNgachInfo.HeSoLuongBac_6;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_7] = pNS_NhomNgachInfo.HeSoLuongBac_7;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_8] = pNS_NhomNgachInfo.HeSoLuongBac_8;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_9] = pNS_NhomNgachInfo.HeSoLuongBac_9;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_10] = pNS_NhomNgachInfo.HeSoLuongBac_10;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_11] = pNS_NhomNgachInfo.HeSoLuongBac_11;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_12] = pNS_NhomNgachInfo.HeSoLuongBac_12;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_13] = pNS_NhomNgachInfo.HeSoLuongBac_13;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_14] = pNS_NhomNgachInfo.HeSoLuongBac_14;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_15] = pNS_NhomNgachInfo.HeSoLuongBac_15;
			dr[pNS_NhomNgachInfo.strHeSoLuongBac_16] = pNS_NhomNgachInfo.HeSoLuongBac_16;
        }
        
        public void ToInfo(ref NS_NhomNgachInfo pNS_NhomNgachInfo, DataRow dr)
        {

			pNS_NhomNgachInfo.NS_NhomNgachID = int.Parse(dr[pNS_NhomNgachInfo.strNS_NhomNgachID].ToString());
			pNS_NhomNgachInfo.KyHieu = dr[pNS_NhomNgachInfo.strKyHieu].ToString();
			pNS_NhomNgachInfo.TenNhomNgach = dr[pNS_NhomNgachInfo.strTenNhomNgach].ToString();
			pNS_NhomNgachInfo.LoaiCongChuc = dr[pNS_NhomNgachInfo.strLoaiCongChuc].ToString();
            pNS_NhomNgachInfo.IDNS_LinhVucCongTac = int.Parse("0" + dr[pNS_NhomNgachInfo.strIDNS_LinhVucCongTac]);
			pNS_NhomNgachInfo.MoTa = dr[pNS_NhomNgachInfo.strMoTa].ToString();
            pNS_NhomNgachInfo.SoNamNangBac = double.Parse(dr[pNS_NhomNgachInfo.strSoNamNangBac].ToString());
			pNS_NhomNgachInfo.BacCaoNhat = int.Parse(dr[pNS_NhomNgachInfo.strBacCaoNhat].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_1 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_1].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_2 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_2].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_3 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_3].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_4 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_4].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_5 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_5].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_6 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_6].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_7 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_7].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_8 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_8].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_9 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_9].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_10 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_10].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_11 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_11].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_12 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_12].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_13 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_13].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_14 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_14].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_15 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_15].ToString());
            pNS_NhomNgachInfo.HeSoLuongBac_16 = double.Parse(dr[pNS_NhomNgachInfo.strHeSoLuongBac_16].ToString());
        }
    }
}
