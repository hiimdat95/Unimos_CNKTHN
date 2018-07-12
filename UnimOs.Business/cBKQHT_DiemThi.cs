﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemThi : cBBase
    {
        private cDKQHT_DiemThi oDKQHT_DiemThi;
        private KQHT_DiemThiInfo oKQHT_DiemThiInfo;

        public cBKQHT_DiemThi()        
        {
            oDKQHT_DiemThi = new cDKQHT_DiemThi();
        }

        public DataTable Get(KQHT_DiemThiInfo pKQHT_DiemThiInfo)        
        {
            return oDKQHT_DiemThi.Get(pKQHT_DiemThiInfo);
        }

        public DataTable GetDanhSachThiLai(int IDDM_Lop, int IDDM_MonHoc,int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemThi.GetDanhSachThiLai(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public DataTable GetDanhSachKhongQua(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemThi.GetDanhSachKhongQua(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc,int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemThi.GetDanhSach(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy, LanThi);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_DiemThi.GetByLop(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            return oDKQHT_DiemThi.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
        }

        public DataTable GetSinhVien(int KQHT_ToChucID)
        {
            return oDKQHT_DiemThi.GetSinhVien(KQHT_ToChucID);
        }

        public int Add(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
			int ID = 0;
            ID = oDKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
            mErrorMessage = oDKQHT_DiemThi.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThi.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            oDKQHT_DiemThi.Update(pKQHT_DiemThiInfo);
            mErrorMessage = oDKQHT_DiemThi.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThi.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            oDKQHT_DiemThi.Delete(pKQHT_DiemThiInfo);
            mErrorMessage = oDKQHT_DiemThi.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThi.ErrorNumber;
        }

        public void DeleteByInfo(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            oDKQHT_DiemThi.DeleteByInfo(pKQHT_DiemThiInfo);
            mErrorMessage = oDKQHT_DiemThi.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThi.ErrorNumber;
        }

        public List<KQHT_DiemThiInfo> GetList(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            List<KQHT_DiemThiInfo> oKQHT_DiemThiInfoList = new List<KQHT_DiemThiInfo>();
            DataTable dtb = Get(pKQHT_DiemThiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DiemThiInfo = new KQHT_DiemThiInfo();

                    oKQHT_DiemThiInfo.KQHT_DiemThiID = int.Parse(dtb.Rows[i]["KQHT_DiemThiID"].ToString());
                    oKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemThiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DiemThiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DiemThiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DiemThiInfo.LanThi = int.Parse(dtb.Rows[i]["LanThi"].ToString());
                    oKQHT_DiemThiInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
                    oKQHT_DiemThiInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    oKQHT_DiemThiInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oKQHT_DiemThiInfo.NgayTao = DateTime.Parse(dtb.Rows[i]["NgayTao"].ToString());
                    
                    oKQHT_DiemThiInfoList.Add(oKQHT_DiemThiInfo);
                }
            }
            return oKQHT_DiemThiInfoList;
        }
        
        public void ToDataRow(KQHT_DiemThiInfo pKQHT_DiemThiInfo, ref DataRow dr)
        {

			dr[pKQHT_DiemThiInfo.strKQHT_DiemThiID] = pKQHT_DiemThiInfo.KQHT_DiemThiID;
			dr[pKQHT_DiemThiInfo.strIDSV_SinhVien] = pKQHT_DiemThiInfo.IDSV_SinhVien;
			dr[pKQHT_DiemThiInfo.strIDDM_MonHoc] = pKQHT_DiemThiInfo.IDDM_MonHoc;
			dr[pKQHT_DiemThiInfo.strIDDM_NamHoc] = pKQHT_DiemThiInfo.IDDM_NamHoc;
			dr[pKQHT_DiemThiInfo.strHocKy] = pKQHT_DiemThiInfo.HocKy;
			dr[pKQHT_DiemThiInfo.strLanThi] = pKQHT_DiemThiInfo.LanThi;
			dr[pKQHT_DiemThiInfo.strDiem] = pKQHT_DiemThiInfo.Diem;
			dr[pKQHT_DiemThiInfo.strLyDo] = pKQHT_DiemThiInfo.LyDo;
			dr[pKQHT_DiemThiInfo.strIDHT_User] = pKQHT_DiemThiInfo.IDHT_User;
			dr[pKQHT_DiemThiInfo.strNgayTao] = pKQHT_DiemThiInfo.NgayTao;
        }
        
        public void ToInfo(ref KQHT_DiemThiInfo pKQHT_DiemThiInfo, DataRow dr)
        {

			pKQHT_DiemThiInfo.KQHT_DiemThiID = int.Parse(dr[pKQHT_DiemThiInfo.strKQHT_DiemThiID].ToString());
			pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemThiInfo.strIDSV_SinhVien].ToString());
			pKQHT_DiemThiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DiemThiInfo.strIDDM_MonHoc].ToString());
			pKQHT_DiemThiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DiemThiInfo.strIDDM_NamHoc].ToString());
			pKQHT_DiemThiInfo.HocKy = int.Parse(dr[pKQHT_DiemThiInfo.strHocKy].ToString());
			pKQHT_DiemThiInfo.LanThi = int.Parse(dr[pKQHT_DiemThiInfo.strLanThi].ToString());
			pKQHT_DiemThiInfo.Diem = double.Parse(dr[pKQHT_DiemThiInfo.strDiem].ToString());
			pKQHT_DiemThiInfo.LyDo = dr[pKQHT_DiemThiInfo.strLyDo].ToString();
			pKQHT_DiemThiInfo.IDHT_User = int.Parse(dr[pKQHT_DiemThiInfo.strIDHT_User].ToString());
			pKQHT_DiemThiInfo.NgayTao = DateTime.Parse(dr[pKQHT_DiemThiInfo.strNgayTao].ToString());
        }
    }
}
