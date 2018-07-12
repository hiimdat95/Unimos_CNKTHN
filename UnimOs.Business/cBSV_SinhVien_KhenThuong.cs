using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_KhenThuong : cBBase
    {
        private cDSV_SinhVien_KhenThuong oDSV_SinhVien_KhenThuong;
        private SV_SinhVien_KhenThuongInfo oSV_SinhVien_KhenThuongInfo;

        public cBSV_SinhVien_KhenThuong()        
        {
            oDSV_SinhVien_KhenThuong = new cDSV_SinhVien_KhenThuong();
        }

        public DataTable Get(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)        
        {
            return oDSV_SinhVien_KhenThuong.Get(pSV_SinhVien_KhenThuongInfo);
        }

        public DataTable GetByQuyetDinh(int IDSV_QuyetDinhKhenThuong)
        {
            return oDSV_SinhVien_KhenThuong.GetByQuyetDinh(IDSV_QuyetDinhKhenThuong);
        }

        public int Add(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_KhenThuong.Add(pSV_SinhVien_KhenThuongInfo);
            mErrorMessage = oDSV_SinhVien_KhenThuong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KhenThuong.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            oDSV_SinhVien_KhenThuong.Update(pSV_SinhVien_KhenThuongInfo);
            mErrorMessage = oDSV_SinhVien_KhenThuong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KhenThuong.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            oDSV_SinhVien_KhenThuong.Delete(pSV_SinhVien_KhenThuongInfo);
            mErrorMessage = oDSV_SinhVien_KhenThuong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_KhenThuong.ErrorNumber;
        }

        public List<SV_SinhVien_KhenThuongInfo> GetList(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            List<SV_SinhVien_KhenThuongInfo> oSV_SinhVien_KhenThuongInfoList = new List<SV_SinhVien_KhenThuongInfo>();
            DataTable dtb = Get(pSV_SinhVien_KhenThuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_KhenThuongInfo = new SV_SinhVien_KhenThuongInfo();

                    oSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = int.Parse(dtb.Rows[i]["SV_SinhVien_KhenThuongID"].ToString());
                    oSV_SinhVien_KhenThuongInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong = int.Parse(dtb.Rows[i]["IDSV_QuyetDinhKhenThuong"].ToString());
                    
                    oSV_SinhVien_KhenThuongInfoList.Add(oSV_SinhVien_KhenThuongInfo);
                }
            }
            return oSV_SinhVien_KhenThuongInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_KhenThuongInfo.strSV_SinhVien_KhenThuongID] = pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID;
			dr[pSV_SinhVien_KhenThuongInfo.strIDSV_SinhVien] = pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_KhenThuongInfo.strIDSV_QuyetDinhKhenThuong] = pSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong;
        }
        
        public void ToInfo(ref SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo, DataRow dr)
        {

			pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = int.Parse(dr[pSV_SinhVien_KhenThuongInfo.strSV_SinhVien_KhenThuongID].ToString());
			pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_KhenThuongInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong = int.Parse(dr[pSV_SinhVien_KhenThuongInfo.strIDSV_QuyetDinhKhenThuong].ToString());
        }
    }
}
