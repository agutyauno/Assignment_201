public class Point2D
{
    #region fields
    float x, y;
    #endregion

    #region properties
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    #endregion

    #region constructors
    public Point2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Point2D()
    {
        x = 0;
        y = 0;
    }

    public Point2D(Point2D p)
    {
        X = p.X;
        Y = p.Y;
    }
    #endregion

    #region methods

    #region set point methods
    public void SetPoint(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetPoint(Point2D p)
    {
        x = p.X;
        y = p.Y;
    }
    #endregion

    #region move methods
    public void Move(Point2D p)
    {
        X += p.X;
        Y += p.Y;
    }

    public void Move(float dx, float dy)
    {
        X += dx;
        Y += dy;
    }
    #endregion

    
    #endregion

    #region operator overloading
    public static Point2D operator +(Point2D p1, Point2D p2)
    {
        return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
    }
    #endregion
}