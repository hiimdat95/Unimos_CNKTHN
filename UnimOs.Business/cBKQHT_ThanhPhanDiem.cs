using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ThanhPhanDiem : cBBase
    {
        private cDKQHT_ThanhPhanDiem oDKQHT_ThanhPhanDiem;
        private KQHT_ThanhPhanDiemInfo oKQHT_ThanhPhanDiemInfo;

        public cBKQHT_ThanhPhanDiem()        
        {
            oDKQHT_ThanhPhanDiem = new cDKQHT_ThanhPhanDiem();
        }

        public DataTable Get(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)        
        {
            return oDKQHT_ThanhPhanDiem.Get(pKQHT_ThanhPhanDiemInfo);
        }

        public DataTable GetLapCongThuc()
        {
            return oDKQHT_ThanhPhanDiem.GetLapCongThuc();
        }

        public DataTable GetNhapDuLieu()
        {
            return oDKQHT_ThanhPhanDiem.GetNhapDuLieu();
        }

        public DataTable GetByIDTrinhDo(int IDDM_TrinhDo)
        {
            return oDKQHT_ThanhPhanDiem.GetByIDTrinhDo(IDDM_TrinhDo);
        }

        public int Add(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
			int ID = 0;
            ID = oDKQHT_ThanhPhanDiem.Add(pKQHT_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiem.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            oDKQHT_ThanhPhanDiem.Update(pKQHT_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiem.ErrorNumber;
        }
        
        public void Delete(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            oDKQHT_ThanhPhanDiem.Delete(pKQHT_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ThanhPhanDiem.ErrorNumber;
        }

        public List<KQHT_ThanhPhanDiemInfo> GetList(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            List<KQHT_ThanhPhanDiemInfo> oKQHT_ThanhPhanDiemInfoList = new List<KQHT_ThanhPhanDiemInfo>();
            DataTable dtb = Get(pKQHT_ThanhPhanDiemInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_ThanhPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();

                    oKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID = int.Parse(dtb.Rows[i]["KQHT_ThanhPhanDiemID"].ToString());
                    oKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oKQHT_ThanhPhanDiemInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oKQHT_ThanhPhanDiemInfo.TenThanhPhan = dtb.Rows[i]["TenThanhPhan"].ToString();
                    oKQHT_ThanhPhanDiemInfo.SoDiem = int.Parse(dtb.Rows[i]["SoDiem"].ToString());
                    oKQHT_ThanhPhanDiemInfo.Thi = bool.Parse(dtb.Rows[i]["Thi"].ToString());
                    oKQHT_ThanhPhanDiemInfo.SoLanThi = int.Parse(dtb.Rows[i]["SoLanThi"].ToString());

                    oKQHT_ThanhPhanDiemInfoList.Add(oKQHT_ThanhPhanDiemInfo);
                }
            }
            return oKQHT_ThanhPhanDiemInfoList;
        }

        public void ToDataRow(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo, ref DataRow dr)
        {
            dr[pKQHT_ThanhPhanDiemInfo.strKQHT_ThanhPhanDiemID] = pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID;
            dr[pKQHT_ThanhPhanDiemInfo.strIDDM_TrinhDo] = pKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo;
            dr[pKQHT_ThanhPhanDiemInfo.strKyHieu] = pKQHT_ThanhPhanDiemInfo.KyHieu;
            dr[pKQHT_ThanhPhanDiemInfo.strTenThanhPhan] = pKQHT_ThanhPhanDiemInfo.TenThanhPhan;
            dr[pKQHT_ThanhPhanDiemInfo.strSoDiem] = pKQHT_ThanhPhanDiemInfo.SoDiem;
            dr[pKQHT_ThanhPhanDiemInfo.strThi] = pKQHT_ThanhPhanDiemInfo.Thi;
            if (pKQHT_ThanhPhanDiemInfo.SoLanThi != null)
                dr[pKQHT_ThanhPhanDiemInfo.strSoLanThi] = pKQHT_ThanhPhanDiemInfo.SoLanThi;
            if (pKQHT_ThanhPhanDiemInfo.STT != null)
                dr[pKQHT_ThanhPhanDiemInfo.strSTT] = pKQHT_ThanhPhanDiemInfo.STT;
        }

        public void ToInfo(ref KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo, DataRow dr)
        {
            pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID = int.Parse(dr[pKQHT_ThanhPhanDiemInfo.strKQHT_ThanhPhanDiemID].ToString());
            pKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo = int.Parse(dr[pKQHT_ThanhPhanDiemInfo.strIDDM_TrinhDo].ToString());
            pKQHT_ThanhPhanDiemInfo.KyHieu = dr[pKQHT_ThanhPhanDiemInfo.strKyHieu].ToString();
            pKQHT_ThanhPhanDiemInfo.TenThanhPhan = dr[pKQHT_ThanhPhanDiemInfo.strTenThanhPhan].ToString();
            pKQHT_ThanhPhanDiemInfo.SoDiem = int.Parse(dr[pKQHT_ThanhPhanDiemInfo.strSoDiem].ToString());
            pKQHT_ThanhPhanDiemInfo.Thi = bool.Parse(dr[pKQHT_ThanhPhanDiemInfo.strThi].ToString());
            if ("" + dr[pKQHT_ThanhPhanDiemInfo.strSoLanThi] != "")
                pKQHT_ThanhPhanDiemInfo.SoLanThi = int.Parse(dr[pKQHT_ThanhPhanDiemInfo.strSoLanThi].ToString());
            if ("" + dr[pKQHT_ThanhPhanDiemInfo.strSTT] != "")
                pKQHT_ThanhPhanDiemInfo.SoLanThi = int.Parse(dr[pKQHT_ThanhPhanDiemInfo.strSTT].ToString());
        }
    }
}
