using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ChoNhapLaiDiem_SinhVien : cBBase
    {
        private cDKQHT_ChoNhapLaiDiem_SinhVien oDKQHT_ChoNhapLaiDiem_SinhVien;

        public cBKQHT_ChoNhapLaiDiem_SinhVien()        
        {
            oDKQHT_ChoNhapLaiDiem_SinhVien = new cDKQHT_ChoNhapLaiDiem_SinhVien();
        }

        public DataTable Get(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)        
        {
            return oDKQHT_ChoNhapLaiDiem_SinhVien.Get(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
        }

        public int Add(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
			int ID = 0;
            ID = oDKQHT_ChoNhapLaiDiem_SinhVien.Add(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            oDKQHT_ChoNhapLaiDiem_SinhVien.Update(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorNumber;
        }
        
        public void Delete(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            oDKQHT_ChoNhapLaiDiem_SinhVien.Delete(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem_SinhVien.ErrorNumber;
        }

        public List<KQHT_ChoNhapLaiDiem_SinhVienInfo> GetList(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            List<KQHT_ChoNhapLaiDiem_SinhVienInfo> oKQHT_ChoNhapLaiDiem_SinhVienInfoList = new List<KQHT_ChoNhapLaiDiem_SinhVienInfo>();
            DataTable dtb = Get(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pKQHT_ChoNhapLaiDiem_SinhVienInfo = new KQHT_ChoNhapLaiDiem_SinhVienInfo();

                    pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiem_SinhVienInfo.strKQHT_ChoNhapLaiDiem_SinhVienID].ToString());
                    pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDKQHT_ChoNhapLaiDiem].ToString());
                    pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDSV_SinhVien].ToString());
                    
                    oKQHT_ChoNhapLaiDiem_SinhVienInfoList.Add(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
                }
            }
            return oKQHT_ChoNhapLaiDiem_SinhVienInfoList;
        }
        
        public void ToDataRow(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo, ref DataRow dr)
        {

			dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strKQHT_ChoNhapLaiDiem_SinhVienID] = pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID;
			dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDKQHT_ChoNhapLaiDiem] = pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem;
			dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDSV_SinhVien] = pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien;
        }
        
        public void ToInfo(ref KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo, DataRow dr)
        {

			pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID = int.Parse(dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strKQHT_ChoNhapLaiDiem_SinhVienID].ToString());
			pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem = int.Parse(dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDKQHT_ChoNhapLaiDiem].ToString());
			pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_ChoNhapLaiDiem_SinhVienInfo.strIDSV_SinhVien].ToString());
        }
    }
}
