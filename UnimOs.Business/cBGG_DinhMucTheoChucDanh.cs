using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBGG_DinhMucTheoChucDanh : cBBase
    {
        private cDGG_DinhMucTheoChucDanh oDGG_DinhMucTheoChucDanh;
        private GG_DinhMucTheoChucDanhInfo oGG_DinhMucTheoChucDanhInfo;

        public cBGG_DinhMucTheoChucDanh()        
        {
            oDGG_DinhMucTheoChucDanh = new cDGG_DinhMucTheoChucDanh();
        }

        public DataTable Get(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            return oDGG_DinhMucTheoChucDanh.Get(pGG_DinhMucTheoChucDanhInfo);
        }

        public DataTable Get()
        {
            return oDGG_DinhMucTheoChucDanh.Get();
        }

        public int Add(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
			int ID = 0;
            ID = oDGG_DinhMucTheoChucDanh.Add(pGG_DinhMucTheoChucDanhInfo);
            mErrorMessage = oDGG_DinhMucTheoChucDanh.ErrorMessages;
            mErrorNumber = oDGG_DinhMucTheoChucDanh.ErrorNumber;
            return ID;
        }

        public void Update(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            oDGG_DinhMucTheoChucDanh.Update(pGG_DinhMucTheoChucDanhInfo);
            mErrorMessage = oDGG_DinhMucTheoChucDanh.ErrorMessages;
            mErrorNumber = oDGG_DinhMucTheoChucDanh.ErrorNumber;
        }
        
        public void Delete(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            oDGG_DinhMucTheoChucDanh.Delete(pGG_DinhMucTheoChucDanhInfo);
            mErrorMessage = oDGG_DinhMucTheoChucDanh.ErrorMessages;
            mErrorNumber = oDGG_DinhMucTheoChucDanh.ErrorNumber;
        }

        public List<GG_DinhMucTheoChucDanhInfo> GetList(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            List<GG_DinhMucTheoChucDanhInfo> oGG_DinhMucTheoChucDanhInfoList = new List<GG_DinhMucTheoChucDanhInfo>();
            DataTable dtb = Get(pGG_DinhMucTheoChucDanhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oGG_DinhMucTheoChucDanhInfo = new GG_DinhMucTheoChucDanhInfo();

                    oGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID = int.Parse(dtb.Rows[i]["GG_DinhMucTheoChucDanhID"].ToString());
                    oGG_DinhMucTheoChucDanhInfo.IDDM_ChucDanh = int.Parse(dtb.Rows[i]["IDDM_ChucDanh"].ToString());
                    oGG_DinhMucTheoChucDanhInfo.HeSo = double.Parse(dtb.Rows[i]["HeSo"].ToString());
                    oGG_DinhMucTheoChucDanhInfo.HeSoGioChuan = double.Parse(dtb.Rows[i]["HeSoGioChuan"].ToString());
                    oGG_DinhMucTheoChucDanhInfo.GioLamViec = double.Parse(dtb.Rows[i]["GioLamViec"].ToString());
                    oGG_DinhMucTheoChucDanhInfo.GioChuanGiang = double.Parse(dtb.Rows[i]["GioChuanGiang"].ToString());
                    
                    oGG_DinhMucTheoChucDanhInfoList.Add(oGG_DinhMucTheoChucDanhInfo);
                }
            }
            return oGG_DinhMucTheoChucDanhInfoList;
        }
        
        public void ToDataRow(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo, ref DataRow dr)
        {

			dr[pGG_DinhMucTheoChucDanhInfo.strGG_DinhMucTheoChucDanhID] = pGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID;
			dr[pGG_DinhMucTheoChucDanhInfo.strIDDM_ChucDanh] = pGG_DinhMucTheoChucDanhInfo.IDDM_ChucDanh;
			dr[pGG_DinhMucTheoChucDanhInfo.strHeSo] = pGG_DinhMucTheoChucDanhInfo.HeSo;
			dr[pGG_DinhMucTheoChucDanhInfo.strHeSoGioChuan] = pGG_DinhMucTheoChucDanhInfo.HeSoGioChuan;
			dr[pGG_DinhMucTheoChucDanhInfo.strGioLamViec] = pGG_DinhMucTheoChucDanhInfo.GioLamViec;
			dr[pGG_DinhMucTheoChucDanhInfo.strGioChuanGiang] = pGG_DinhMucTheoChucDanhInfo.GioChuanGiang;
        }
        
        public void ToInfo(ref GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo, DataRow dr)
        {

			pGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID = int.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strGG_DinhMucTheoChucDanhID].ToString());
			pGG_DinhMucTheoChucDanhInfo.IDDM_ChucDanh = int.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strIDDM_ChucDanh].ToString());
			pGG_DinhMucTheoChucDanhInfo.HeSo = double.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strHeSo].ToString());
			pGG_DinhMucTheoChucDanhInfo.HeSoGioChuan = double.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strHeSoGioChuan].ToString());
			pGG_DinhMucTheoChucDanhInfo.GioLamViec = double.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strGioLamViec].ToString());
			pGG_DinhMucTheoChucDanhInfo.GioChuanGiang = double.Parse(dr[pGG_DinhMucTheoChucDanhInfo.strGioChuanGiang].ToString());
        }
    }
}
