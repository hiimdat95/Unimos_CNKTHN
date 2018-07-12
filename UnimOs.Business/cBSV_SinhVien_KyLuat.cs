using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_KyLuat : cBBase
    {
        private cDSV_SinhVien_KyLuat oDSV_SinhVien_KyLuat;
        private SV_SinhVien_KyLuatInfo oSV_SinhVien_KyLuatInfo;

        public cBSV_SinhVien_KyLuat()        
        {
            oDSV_SinhVien_KyLuat = new cDSV_SinhVien_KyLuat();
        }

        public DataTable Get(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)        
        {
            return oDSV_SinhVien_KyLuat.Get(pSV_SinhVien_KyLuatInfo);
        }

        public DataTable GetByQuyetDinh(int IDSV_QuyetDinhKyLuat)
        {
            return oDSV_SinhVien_KyLuat.GetByQuyetDinh(IDSV_QuyetDinhKyLuat);
        }

        public int Add(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_KyLuat.Add(pSV_SinhVien_KyLuatInfo);
            mErrorMessage = oDSV_SinhVien_KyLuat.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KyLuat.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            oDSV_SinhVien_KyLuat.Update(pSV_SinhVien_KyLuatInfo);
            mErrorMessage = oDSV_SinhVien_KyLuat.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KyLuat.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            oDSV_SinhVien_KyLuat.Delete(pSV_SinhVien_KyLuatInfo);
            mErrorMessage = oDSV_SinhVien_KyLuat.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KyLuat.ErrorNumber;
        }

        public List<SV_SinhVien_KyLuatInfo> GetList(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            List<SV_SinhVien_KyLuatInfo> oSV_SinhVien_KyLuatInfoList = new List<SV_SinhVien_KyLuatInfo>();
            DataTable dtb = Get(pSV_SinhVien_KyLuatInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_KyLuatInfo = new SV_SinhVien_KyLuatInfo();

                    oSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID = int.Parse(dtb.Rows[i]["SV_SinhVien_KyLuatID"].ToString());
                    oSV_SinhVien_KyLuatInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat = int.Parse(dtb.Rows[i]["IDSV_QuyetDinhKyLuat"].ToString());
                    oSV_SinhVien_KyLuatInfo.XoaKyLuat = bool.Parse(dtb.Rows[i]["XoaKyLuat"].ToString());
                    oSV_SinhVien_KyLuatInfo.NgayXoaKyLuat = DateTime.Parse(dtb.Rows[i]["NgayXoaKyLuat"].ToString());
                    oSV_SinhVien_KyLuatInfo.LyDoXoaKyLuat = dtb.Rows[i]["LyDoXoaKyLuat"].ToString();
                    
                    oSV_SinhVien_KyLuatInfoList.Add(oSV_SinhVien_KyLuatInfo);
                }
            }
            return oSV_SinhVien_KyLuatInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_KyLuatInfo.strSV_SinhVien_KyLuatID] = pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID;
			dr[pSV_SinhVien_KyLuatInfo.strIDSV_SinhVien] = pSV_SinhVien_KyLuatInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_KyLuatInfo.strIDSV_QuyetDinhKyLuat] = pSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat;
			dr[pSV_SinhVien_KyLuatInfo.strXoaKyLuat] = pSV_SinhVien_KyLuatInfo.XoaKyLuat;
			dr[pSV_SinhVien_KyLuatInfo.strNgayXoaKyLuat] = pSV_SinhVien_KyLuatInfo.NgayXoaKyLuat;
			dr[pSV_SinhVien_KyLuatInfo.strLyDoXoaKyLuat] = pSV_SinhVien_KyLuatInfo.LyDoXoaKyLuat;
        }
        
        public void ToInfo(ref SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo, DataRow dr)
        {

			pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID = int.Parse(dr[pSV_SinhVien_KyLuatInfo.strSV_SinhVien_KyLuatID].ToString());
			pSV_SinhVien_KyLuatInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_KyLuatInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat = int.Parse(dr[pSV_SinhVien_KyLuatInfo.strIDSV_QuyetDinhKyLuat].ToString());
			pSV_SinhVien_KyLuatInfo.XoaKyLuat = bool.Parse(dr[pSV_SinhVien_KyLuatInfo.strXoaKyLuat].ToString());
			pSV_SinhVien_KyLuatInfo.NgayXoaKyLuat = DateTime.Parse(dr[pSV_SinhVien_KyLuatInfo.strNgayXoaKyLuat].ToString());
			pSV_SinhVien_KyLuatInfo.LyDoXoaKyLuat = dr[pSV_SinhVien_KyLuatInfo.strLyDoXoaKyLuat].ToString();
        }
    }
}
