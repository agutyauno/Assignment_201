public class Triangle
{
    #region fields
    double a, b, c;

    #endregion

    #region properties
    public double A { get => a; set => a = value; }
    public double B { get => b; set => b = value; }
    public double C { get => c; set => c = value; }

    #endregion

    #region constructors
    public Triangle(double a, double b, double c)
    {
        if (!IsTriangle(a, b, c))
        {
            throw new Exception("Khong phai tam giac");
        }
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // public Triangle()
    // {
    //     a = 3;
    //     b = 4;
    //     c = 5;
    // }

    public Triangle(Triangle t)
    {
        if (IsTriangle(t.A, t.B, t.C))
        {
            throw new Exception("Khong phai tam giac");
        }
        a = t.A;
        b = t.B;
        c = t.C;
    }

    #endregion

    #region methods
    bool IsTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    public double DienTich()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double ChuVi()
    {
        return a + b + c;
    }

    public string GetTriangleType()
    {
        if (LaTamGiacCan())
        {
            return "Tam giac can";
        }
        else if (LaTamGiacVuongCan())
        {
            return "Tam giac vuong can";
        }
        else if (LaTamGiacVuong())
        {
            return "Tam giac vuong";
        }
        else if (LaTamGiacDeu())
        {
            return "Tam giac deu";
        }
        else
        {
            return "Tam giac thuong";
        }
    }

    bool LaTamGiacDeu()
    {
        return a == b && b == C;
    }

    bool LaTamGiacVuongCan()
    {
        return LaTamGiacVuong() && LaTamGiacCan();
    }

    bool LaTamGiacVuong()
    {
        double[] canh = { a, b, c };
        Array.Sort(canh);
        return Math.Pow(canh[2], 2) == Math.Pow(canh[0], 2) + Math.Pow(canh[1], 2);
    }

    bool LaTamGiacCan()
    {
        return a == b || a == c || b == c;
    }
    #endregion
}