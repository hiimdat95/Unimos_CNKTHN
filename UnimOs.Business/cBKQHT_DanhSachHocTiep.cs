using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DanhSachHocTiep : cBBase
    {
        private cDKQHT_DanhSachHocTiep oDKQHT_DanhSachHocTiep;
        private KQHT_DanhSachHocTiepInfo oKQHT_DanhSachHocTiepInfo;

        public cBKQHT_DanhSachHocTiep()        
        {
            oDKQHT_DanhSachHocTiep = new cDKQHT_DanhSachHocTiep();
        }

        public DataTable Get(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)        
        {
            return oDKQHT_DanhSachHocTiep.Get(pKQHT_DanhSachHocTiepInfo);
        }

        public DataTable GetSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc)
        {
            return oDKQHT_DanhSachHocTiep.GetSinhVien(pDM_LopInfo, IDDM_NamHoc);
        }

        public int Add(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_DanhSachHocTiep.Add(pKQHT_DanhSachHocTiepInfo);
            mErrorMessage = oDKQHT_DanhSachHocTiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachHocTiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            oDKQHT_DanhSachHocTiep.Update(pKQHT_DanhSachHocTiepInfo);
            mErrorMessage = oDKQHT_DanhSachHocTiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachHocTiep.ErrorNumber;
        }
        
        public void Delete(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            oDKQHT_DanhSachHocTiep.Delete(pKQHT_DanhSachHocTiepInfo);
            mErrorMessage = oDKQHT_DanhSachHocTiep.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachHocTiep.ErrorNumber;
        }

        public List<KQHT_DanhSachHocTiepInfo> GetList(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            List<KQHT_DanhSachHocTiepInfo> oKQHT_DanhSachHocTiepInfoList = new List<KQHT_DanhSachHocTiepInfo>();
            DataTable dtb = Get(pKQHT_DanhSachHocTiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DanhSachHocTiepInfo = new KQHT_DanhSachHocTiepInfo();

                    oKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID = int.Parse(dtb.Rows[i]["KQHT_DanhSachHocTiepID"].ToString());
                    oKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc = int.Parse(dtb.Rows[i]["IDKQHT_DanhSachNgungHoc"].ToString());
                    oKQHT_DanhSachHocTiepInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DanhSachHocTiepInfo.Hocky = int.Parse(dtb.Rows[i]["Hocky"].ToString());
                    oKQHT_DanhSachHocTiepInfo.IDDM_Namhoc = int.Parse(dtb.Rows[i]["IDDM_Namhoc"].ToString());
                    oKQHT_DanhSachHocTiepInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oKQHT_DanhSachHocTiepInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oKQHT_DanhSachHocTiepInfo.Lydo = dtb.Rows[i]["Lydo"].ToString();
                    oKQHT_DanhSachHocTiepInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    
                    oKQHT_DanhSachHocTiepInfoList.Add(oKQHT_DanhSachHocTiepInfo);
                }
            }
            return oKQHT_DanhSachHocTiepInfoList;
        }
        
        public void ToDataRow(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo, ref DataRow dr)
        {

			dr[pKQHT_DanhSachHocTiepInfo.strKQHT_DanhSachHocTiepID] = pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID;
			dr[pKQHT_DanhSachHocTiepInfo.strIDKQHT_DanhSachNgungHoc] = pKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc;
			dr[pKQHT_DanhSachHocTiepInfo.strIDSV_SinhVien] = pKQHT_DanhSachHocTiepInfo.IDSV_SinhVien;
			dr[pKQHT_DanhSachHocTiepInfo.strHocky] = pKQHT_DanhSachHocTiepInfo.Hocky;
			dr[pKQHT_DanhSachHocTiepInfo.strIDDM_Namhoc] = pKQHT_DanhSachHocTiepInfo.IDDM_Namhoc;
			dr[pKQHT_DanhSachHocTiepInfo.strSoQuyetDinh] = pKQHT_DanhSachHocTiepInfo.SoQuyetDinh;
			dr[pKQHT_DanhSachHocTiepInfo.strNgayQuyetDinh] = pKQHT_DanhSachHocTiepInfo.NgayQuyetDinh;
			dr[pKQHT_DanhSachHocTiepInfo.strLydo] = pKQHT_DanhSachHocTiepInfo.Lydo;
			dr[pKQHT_DanhSachHocTiepInfo.strIDDM_Lop] = pKQHT_DanhSachHocTiepInfo.IDDM_Lop;
        }
        
        public void ToInfo(ref KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo, DataRow dr)
        {

			pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strKQHT_DanhSachHocTiepID].ToString());
			pKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strIDKQHT_DanhSachNgungHoc].ToString());
			pKQHT_DanhSachHocTiepInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strIDSV_SinhVien].ToString());
			pKQHT_DanhSachHocTiepInfo.Hocky = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strHocky].ToString());
			pKQHT_DanhSachHocTiepInfo.IDDM_Namhoc = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strIDDM_Namhoc].ToString());
			pKQHT_DanhSachHocTiepInfo.SoQuyetDinh = dr[pKQHT_DanhSachHocTiepInfo.strSoQuyetDinh].ToString();
			pKQHT_DanhSachHocTiepInfo.NgayQuyetDinh = DateTime.Parse(dr[pKQHT_DanhSachHocTiepInfo.strNgayQuyetDinh].ToString());
			pKQHT_DanhSachHocTiepInfo.Lydo = dr[pKQHT_DanhSachHocTiepInfo.strLydo].ToString();
			pKQHT_DanhSachHocTiepInfo.IDDM_Lop = int.Parse(dr[pKQHT_DanhSachHocTiepInfo.strIDDM_Lop].ToString());
        }
    }
}
