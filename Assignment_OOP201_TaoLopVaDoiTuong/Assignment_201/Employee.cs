public class Employee
{
    #region fields
    string maNhanVien, tenNhanVien, phongBan;
    decimal luongCoBan, heSoLuong, luongThuong;
    bool dangLamViec;
    #endregion

    #region properties
    public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
    public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
    public string PhongBan { get => phongBan; set => phongBan = value; }
    public decimal LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
    public bool DangLamViec { get => dangLamViec; set => dangLamViec = value; }
    public decimal HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
    public decimal LuongThuong { get => luongThuong; set => luongThuong = value; }
    #endregion

    #region constructors
    public Employee(string maNhanVien, string tenNhanVien, string phongBan, decimal luongCoBan, decimal heSoLuong, decimal luongThuong, bool dangLamViec)
    {
        this.maNhanVien = maNhanVien;
        this.tenNhanVien = tenNhanVien;
        this.phongBan = phongBan;
        this.luongCoBan = luongCoBan;
        this.heSoLuong = heSoLuong;
        this.luongThuong = luongThuong;
        this.dangLamViec = dangLamViec;
    }

    public Employee(string maNhanVien, string tenNhanVien, string phongBan, decimal luongCoBan, bool dangLamViec)
    {
        this.maNhanVien = maNhanVien;
        this.tenNhanVien = tenNhanVien;
        this.phongBan = phongBan;
        this.luongCoBan = luongCoBan;
        heSoLuong = 1;
        luongThuong = 0;
        this.dangLamViec = dangLamViec;
    }

    public Employee()
    {
        maNhanVien = string.Empty;
        tenNhanVien = string.Empty;
        phongBan = string.Empty;
        luongCoBan = 0;
        heSoLuong = 1;
        luongThuong = 0;
        dangLamViec = false;
    }

    public Employee(Employee nv)
    {
        maNhanVien = nv.MaNhanVien;
        tenNhanVien = nv.TenNhanVien;
        phongBan = nv.PhongBan;
        luongCoBan = nv.LuongCoBan;
        heSoLuong = nv.HeSoLuong;
        luongThuong = nv.LuongThuong;
        dangLamViec = nv.DangLamViec;
    }
    #endregion

#region methods
    decimal CaculateSalary()
    {
        return luongCoBan * heSoLuong + luongThuong;
    }

    string IsWorking()
    {
        return dangLamViec? "dang lam viec" : "dang nghi";
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"{maNhanVien,-15}|{tenNhanVien,-30}|{phongBan,-30}|{luongCoBan,-50}|{heSoLuong,-5}|{luongThuong,-50}|{IsWorking,-10}|{CaculateSalary,-50}");
    }
#endregion
}