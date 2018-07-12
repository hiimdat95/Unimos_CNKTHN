using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ThanhPhanDiemBatBuoc : cBBase
    {
        private cDKQHT_ThanhPhanDiemBatBuoc oDKQHT_ThanhPhanDiemBatBuoc;
        private KQHT_ThanhPhanDiemBatBuocInfo oKQHT_ThanhPhanDiemBatBuocInfo;

        public cBKQHT_ThanhPhanDiemBatBuoc()        
        {
            oDKQHT_ThanhPhanDiemBatBuoc = new cDKQHT_ThanhPhanDiemBatBuoc();
        }

        public DataTable Get(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)        
        {
            return oDKQHT_ThanhPhanDiemBatBuoc.Get(pKQHT_ThanhPhanDiemBatBuocInfo);
        }

        public DataTable GetByIDThanhPhanDiem(int IDKQHT_ThanhPhanDiem)
        {
            return oDKQHT_ThanhPhanDiemBatBuoc.GetByIDThanhPhanDiem(IDKQHT_ThanhPhanDiem);
        }

        public DataTable GetByTrinhDo(int IDDM_TrinhDo)
        {
            return oDKQHT_ThanhPhanDiemBatBuoc.GetByTrinhDo(IDDM_TrinhDo);
        }

        public int Add(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
			int ID = 0;
            ID = oDKQHT_ThanhPhanDiemBatBuoc.Add(pKQHT_ThanhPhanDiemBatBuocInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiemBatBuoc.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiemBatBuoc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            oDKQHT_ThanhPhanDiemBatBuoc.Update(pKQHT_ThanhPhanDiemBatBuocInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiemBatBuoc.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiemBatBuoc.ErrorNumber;
        }
        
        public void Delete(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            oDKQHT_ThanhPhanDiemBatBuoc.Delete(pKQHT_ThanhPhanDiemBatBuocInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiemBatBuoc.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiemBatBuoc.ErrorNumber;
        }

        public List<KQHT_ThanhPhanDiemBatBuocInfo> GetList(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            List<KQHT_ThanhPhanDiemBatBuocInfo> oKQHT_ThanhPhanDiemBatBuocInfoList = new List<KQHT_ThanhPhanDiemBatBuocInfo>();
            DataTable dtb = Get(pKQHT_ThanhPhanDiemBatBuocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_ThanhPhanDiemBatBuocInfo = new KQHT_ThanhPhanDiemBatBuocInfo();

                    oKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID = int.Parse(dtb.Rows[i]["KQHT_ThanhPhanDiemBatBuocID"].ToString());
                    oKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem = int.Parse(dtb.Rows[i]["IDKQHT_ThanhPhanDiem"].ToString());
                    oKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh = int.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    oKQHT_ThanhPhanDiemBatBuocInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc = int.Parse(dtb.Rows[i]["SoDiemBatBuoc"].ToString());
                    
                    oKQHT_ThanhPhanDiemBatBuocInfoList.Add(oKQHT_ThanhPhanDiemBatBuocInfo);
                }
            }
            return oKQHT_ThanhPhanDiemBatBuocInfoList;
        }
        
        public void ToDataRow(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo, ref DataRow dr)
        {

			dr[pKQHT_ThanhPhanDiemBatBuocInfo.strKQHT_ThanhPhanDiemBatBuocID] = pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID;
			dr[pKQHT_ThanhPhanDiemBatBuocInfo.strIDKQHT_ThanhPhanDiem] = pKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem;
			dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoHocTrinh] = pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh;
			dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoTiet] = pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet;
			dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoDiemBatBuoc] = pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc;
        }
        
        public void ToInfo(ref KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo, DataRow dr)
        {

			pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID = int.Parse(dr[pKQHT_ThanhPhanDiemBatBuocInfo.strKQHT_ThanhPhanDiemBatBuocID].ToString());
			pKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem = int.Parse(dr[pKQHT_ThanhPhanDiemBatBuocInfo.strIDKQHT_ThanhPhanDiem].ToString());
			pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh = int.Parse(dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoHocTrinh].ToString());
			pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet = int.Parse(dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoTiet].ToString());
			pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc = int.Parse(dr[pKQHT_ThanhPhanDiemBatBuocInfo.strSoDiemBatBuoc].ToString());
        }
    }
}
