﻿using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string? input;
        while (true)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("1. Point2D");
            Console.WriteLine("2. StackF");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Quan ly nhan su");
            Console.WriteLine("0. Exit");
            Console.WriteLine("===================================");
            Console.Write("Moi chon chuong trinh: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        PointProgram();
                        break;
                    case 2:
                        StackProgram();
                        break;
                    case 3:
                        TriangleProgram();
                        break;
                    case 4:
                        EmployeeManageProgram();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Nhap khong hop le!");
                        break;
                }
            }
        }
    }
    static void PointProgram()
    {
        while (true)
        {
            Console.WriteLine("Chuong trinh Point2D");
            Console.WriteLine("===================================");
            Console.WriteLine("1. tao diem");
            Console.WriteLine("2. Di chuyen diem");
            Console.WriteLine("3. lay toa do doi xung");
            Console.WriteLine("3. dao vi tri toa do");
            Console.WriteLine("4. hien thi danh sach diem");
            Console.WriteLine("0. Exit");
            Console.WriteLine("===================================");
            Console.Write("Moi chon chuc nang: ");
            string? input = Console.ReadLine();
            List<Point2D> listPoint = new();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1: //tao diem
                        try
                        {
                            Console.WriteLine("Nhap toa do x:");
                            float x = float.Parse(Console.ReadLine());
                            Console.WriteLine("Nhap toa do y:");
                            float y = float.Parse(Console.ReadLine());
                            Point2D p = new(x, y);
                            listPoint.Add(p);
                            Console.WriteLine("diem da duoc tao");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine($"Nhap sai dinh dang! \nloi: {error.Message}");
                        }
                        break;
                    case 2: //di chuyen diem
                        try
                        {
                            Console.WriteLine("Nhap diem muon di chuyen:");
                            int n = int.Parse(Console.ReadLine());
                            Console.WriteLine("Nhap khoang cach di chuyen x:");
                            float x = float.Parse(Console.ReadLine());
                            Console.WriteLine("Nhap khoang cach di chuyen y:");
                            float y = float.Parse(Console.ReadLine());
                            listPoint[n].Move(x, y);
                            Console.WriteLine("Diem da duoc di chuyen");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine($"Nhap sai dinh dang! \nloi: {error.Message}");
                        }
                        break;
                    case 3: //lay toa do doi xung
                        try
                        {
                            Console.WriteLine("Nhap diem muon lay toa do doi xung:");
                            int n = int.Parse(Console.ReadLine());
                            listPoint[n].GetInvertCoorinate();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine($"Nhap sai dinh dang! \nloi: {error.Message}");
                        }
                        break;
                    case 4: //dao vi tri diem
                        try
                        {
                            Console.WriteLine("Nhap diem muon dao vi tri:");
                            int n = int.Parse(Console.ReadLine());
                            listPoint[n].InvertCoordinate();
                            Console.WriteLine("Diem da duoc di chuyen");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine($"Nhap sai dinh dang! \nloi: {error.Message}");
                        }
                        break;
                    case 5: //hien thi
                        for (int i = 0; i < listPoint.Count; i++)
                        {
                            Console.WriteLine($"Diem {i}: ({listPoint[i].X}, {listPoint[i].Y})");
                        }
                        break;
                    case 0: //exit
                        return;
                    default:
                        Console.WriteLine("Nhap khong hop le!");
                        break;
                }
            }
        }
    }

    static void StackProgram()
    {
        Console.WriteLine("Chuyen doi he co so");
        Console.WriteLine("nhap 1 so co so 10: ");
        string? input = Console.ReadLine();
        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Nhap khong hop le!");
            return;
        }
        Console.WriteLine($"He so 2: {ConvertToBase(number, 2)}");
        Console.WriteLine($"He so 8: {ConvertToBase(number, 8)}");
        Console.WriteLine($"He so 16: {ConvertToBase(number, 16)}");

        string ConvertToBase(int number, int radix)
        {
            if (number == 0) return "0";

            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            StackF stack = new(32); // Stack đủ lớn cho số 32-bit
            bool isNegative = number < 0;
            number = Math.Abs(number);

            // Đẩy các số dư vào stack
            while (number > 0)
            {
                int remainder = number % radix;
                stack.Push(remainder);
                number /= radix;
            }

            // Xây dựng kết quả từ stack
            string result = isNegative ? "-" : "";
            while (!stack.IsEmpty())
            {
                result += digits[stack.Pop()];
            }

            return result;
        }
    }

    static void TriangleProgram()
    {
        try
        {
            double a, b, c;
            Console.WriteLine("nhap chieu dai canh A: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("nhap chieu dai canh B: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("nhap chieu dai canh C: ");
            c = double.Parse(Console.ReadLine());

            Triangle triangle = new(a, b, c);
            Console.WriteLine($"Loai tam giac: {triangle.GetTriangleType()}");
            Console.WriteLine($"Dien tich tam giac la: {triangle.DienTich()}");
            Console.WriteLine($"Chu vi tam giac la: {triangle.ChuVi()}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Nhap sai dinh dang! \nloi: {error.Message}");
        }
    }

    #region Xây dựng chương trình quản lý nhân sự, bao gồm phân tích bài toán theo hướng đối tượng

    /* 
    I) Phân tích yêu cầu quản lý nhân sự
        Yêu cầu ứng dụng quản lý nhân sự của một công ty gồm các chức năng sau: 
        1. Nhập thông tin nhân viên 
        2. Phân phòng ban cho nhân viên 
        3. tìm kiếm nhân viên theo tên 
        4. Tìm kiếm nhân viên theo maNhanVien
        5. cập nhật nhân viên nghỉ làm
        6. Tính lương cho nhân viên
        7. Chuyển phòng ban làm việc
        8. In danh sách nhân viên

    II) phân tích hướng đối tượng
        Đối tượng Nhân viên (Employee):
            Thuộc tính: Mã nhân viên, Tên, Phòng ban, Lương cơ bản, Hệ số lương, Lương thưởng, Trạng thái (đang làm/nghỉ việc).
            Chức năng: Lưu trữ thông tin cá nhân và trạng thái làm việc.
        -Phương thức:
            +Constructor
            +Getter và setter cho từng thuộc tính
            +Tinh tong luong

        Đối tượng Quản lý nhân viên (EmployeeManager):
            Thuộc tính: Danh sách nhân viên.
            Chức năng: Quản lý toàn bộ nghiệp vụ (thêm, sửa, xóa, tìm kiếm, tính lương, chuyển phòng ban, in danh sách).
        -Phương thức:
            +Thêm nhân viên
            +Thay đổi thông tin nhân viên
            +Xóa thông tin nhân viên
            +Tìm kiếm theo tên hoặc mã nhân viên
            +In danh sách nhân viên
    */
    static void EmployeeManageProgram()
    {
        
    }
    #endregion

}