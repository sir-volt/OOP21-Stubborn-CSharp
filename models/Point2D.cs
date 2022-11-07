namespace models
{
	public class Point2D : Pair<int, int>
	{

		public Point2D(int x, int y) : base(x, y)
		{
		}

		public static Point2D sum(Point2D point1, Point2D point2)
		{
			return new Point2D(point1.getX() + point2.getX(), point1.getY() + point2.getY());
		}

	}

}