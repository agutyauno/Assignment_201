using System.Net.Mail;

public class EmployeeManager
{
    #region fields
    List<Employee> employees = new();
    #endregion

    #region methods
    public void AddEmployee()
    {
        string? input;
        string maNhanVien, tenNhanVien, phongBan;
        decimal luongCoBan, heSoLuong, luongThuong;
        bool dangLamViec;

        maNhanVien = InputCheck.String("ma nhan vien: ");
        tenNhanVien = InputCheck.String("ho ten nhan vien: ");
        phongBan = InputCheck.String("phong ban: ");
        luongCoBan = InputCheck.Decimal("luong co ban: ");
        heSoLuong = InputCheck.Decimal("he so luong (co the de trong): ", true);
        heSoLuong = heSoLuong == 0 ? 1 : heSoLuong;
        luongThuong = InputCheck.Decimal("luong thuong (co the de trong): ", true);
        while (true)
        {
            input = InputCheck.String("hien co dang lam viec hay khong (co/khong): ");
            if (input == "co")
            {
                dangLamViec = true;
                break;
            }
            else if (input == "khong")
            {
                dangLamViec = false;
                break;
            }
            else
            {
                Console.WriteLine("nhap khong hop le, moi nhap lai! ");
            }
        }

        Employee emp = new(maNhanVien, tenNhanVien, phongBan, luongCoBan, heSoLuong, luongThuong, dangLamViec);
        if (employees.Any(e => e.MaNhanVien == emp.MaNhanVien))
        {
            Console.WriteLine("nhan vien da ton tai!");
            return;
        }
        employees.Add(emp);
        Console.WriteLine("nhan vien da duoc them!");
    }

    public void UpdateEmployee()
    {
        string maNV = InputCheck.String("nhap ma nhan vien can sua: ");
        Employee? emp = SearchByID(maNV);
        if (emp == null)
        {
            Console.WriteLine("khong tim thay nhan vien!");
            return;
        }
        PrintEmployee(emp);

        bool isComplete = false;
        while (!isComplete)
        {
            Console.WriteLine("1. ten nhan vien");
            Console.WriteLine("2. phong ban");
            Console.WriteLine("3. luong co ban");
            Console.WriteLine("4. he so luong");
            Console.WriteLine("5. luong thuong");
            Console.WriteLine("6. trang thai lam viec");
            Console.WriteLine("0. thoat");
            int n = InputCheck.Int("nhap thong tin can sua: ");
            switch (n)
            {
                case 1: //doi ten
                    string input = InputCheck.String("doi thanh: ");
                    emp.TenNhanVien = input;
                    Console.WriteLine("doi thanh cong!");
                    isComplete = true;
                    break;
                case 2: //doi phong ban
                    input = InputCheck.String("doi thanh: ");
                    emp.PhongBan = input;
                    Console.WriteLine("doi thanh cong!");
                    isComplete = true;
                    break;
                case 3: //doi luong co ban
                    decimal d = InputCheck.Decimal("doi thanh: ");
                    emp.LuongCoBan = d;
                    Console.WriteLine("doi thanh cong!");
                    isComplete = true;
                    break;
                case 4: //doi he so luong
                    d = InputCheck.Decimal("doi thanh: ");
                    emp.HeSoLuong = d;
                    Console.WriteLine("doi thanh cong!");
                    isComplete = true;
                    break;
                case 5: //doi luong thuong
                    d = InputCheck.Decimal("doi thanh: ");
                    emp.LuongThuong = d;
                    Console.WriteLine("doi thanh cong!");
                    isComplete = true;
                    break;
                case 6: //doi trang thai hoat dong
                    while (true)
                    {
                        input = InputCheck.String("hien co dang lam viec hay khong (co/khong): ");
                        if (input == "co")
                        {
                            emp.DangLamViec = true;
                            Console.WriteLine("doi thanh cong!");
                            isComplete = true;
                            break;
                        }
                        else if (input == "khong")
                        {
                            emp.DangLamViec = false;
                            Console.WriteLine("doi thanh cong!");
                            isComplete = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("nhap khong hop le, moi nhap lai! ");
                        }
                    }
                    break;
                case 0: // thoat
                    isComplete = true;
                    break;
                default:
                    Console.WriteLine("nhap khong hop le, moi nhap lai! ");
                    break;
            }
        }
        PrintEmployee(emp);
    }

    public void RemoveEmployee()
    {
        string input = InputCheck.String("nhap ma nhan vien muon xoa: ");
        Employee? emp = SearchByID(input);
        if (emp == null)
        {
            Console.WriteLine("khong tim thay nhan vien!");
            return;
        }
        PrintEmployee(emp);

        while (true)
        {
            input = InputCheck.String("ban chac chan muon xoa nhan vien nay? (co/khong)");
            if (input == "co")
            {
                employees.Remove(emp);
                Console.WriteLine("da xoa nhan vien!");
            }
            else if (input == "khong")
            {
                return;
            }
            else
            {
                Console.WriteLine("nhap khong hop le, moi nhap lai! ");
            }
        }
    }

    #region PrintMethods
    public void PrintListEmployee()
    {
        Console.WriteLine("{0,-15}|{1,-30}|{2,-30}|{3,-50}|{4,-5}|{5,-50}|{6,-10}|{7,-50}", "ma nhan vien", "ho ten", "phong ban", "luong can ban", "he so luong", "luong thuong", "trang thai", "luong thang");
        foreach (var emp in employees)
        {
            emp.PrintInfo();
        }
    }

    public void PrintEmployee(Employee emp)
    {
        Console.WriteLine("{0,-15}|{1,-30}|{2,-30}|{3,-50}|{4,-5}|{5,-50}|{6,-10}|{7,-50}", "ma nhan vien", "ho ten", "phong ban", "luong can ban", "he so luong", "luong thuong", "trang thai", "luong thang");
        emp.PrintInfo();
    }
    #endregion

    #region SearchMethods
    public Employee? SearchByID(string maNV)
    {
        return employees.FirstOrDefault(e => e.MaNhanVien == maNV);
    }

    public List<Employee> SearchByName(string name)
    {
        return employees.Where(e => e.TenNhanVien.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    #endregion
    
    #endregion
}