using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class eNumConst
    {
    }

    public enum CA_HOC
    {
        KHONG_XAC_DINH = -1,
        CA_SANG = 0,
        CA_CHIEU = 1,
        CA_TOI = 2
    }

    public enum LOAI_TIET
    {
        KHONG_XAC_DINH = -1,
        LY_THUYET = 0,
        THUC_HANH = 1,
        THI_NGHIEM = 2,
        THE_DUC = 3
    }

    public enum eLOAI_SK
    {
        LICH_HOC = 0,
        LK_LOP = 1,
        LK_GV = 2,
        LK_PHONG = 3
    }

    public enum REPORT_TYPE
    {
        THEO_SUKIEN = 1,
        THEO_PHONG = 2,
        THEO_LOP = 3,
        THEO_GIAOVIEN = 4
    }

    public enum GIOI_TINH
    {
        KHONG_XAC_DINH = -1,
        NU = 1,
        NAM = 0
    }

    public enum EDIT_MODE
    {
        THEM = 0,
        SUA = 1,
        KHAC = 2
    }

    public enum SU_DUNG_PHONG
    {
        KHONG_SD = 0,
        BAT_KY = 1,
        DUOI_DAY = 2
    }

    public enum LOP_KHOI
    {
        GOC = -1,
        TACH = 0,
        GOP = 1
    }

    public enum CHUAN_BO_GO
    {
        TCVN = 0,
        VNI = 1,
        UNICODE = 2
    }

    public enum TRANGTHAISINHVIEN
    {
        DANGHOC = 1,
        DATOTNGHIEP = 2,
        BAOLUU=3,
        DACHUYENTRUONG = 4,
        NGUNGHOC=5,
        THOIHOC = 6,
        BIDUOIHOC = 7,
        CHUYENLOP = 8,
        THISINHTUDO = 9
    }

    public enum HOCKY
    {
        HOCKY1 = 1,
        HOCKY2 = 2,
        CANAM = 3
    }
}
