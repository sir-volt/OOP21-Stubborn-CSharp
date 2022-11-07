namespace models
{
	/*
	 * A standard generic Pair<X,Y>, with getters, hashCode, equals, and toString well implemented. 
	 */

	public class Pair<X, Y>
	{

		private readonly X x;
		private readonly Y y;

		public Pair(X x, Y y) : base()
		{
			this.x = x;
			this.y = y;
		}

		public virtual X X
		{
			get
			{
				return x;
			}
		}

		public virtual Y Y
		{
			get
			{
				return y;
			}
		}

		public override int GetHashCode()
		{
			const int prime = 31;
			int result = 1;
			result = prime * result + ((x == null) ? 0 : x.GetHashCode());
			result = prime * result + ((y == null) ? 0 : y.GetHashCode());
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj == null)
			{
				return false;
			}
			if (this.GetType() != obj.GetType())
			{
				return false;
			}
			Pair other = (Pair) obj;
			if (x == null)
			{
				if (other.x != null)
				{
					return false;
				}
			}
			else if (!x.Equals(other.x))
			{
				return false;
			}
			if (y == null)
			{
				if (other.y != null)
				{
					return false;
				}
			}
			else if (!y.Equals(other.y))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Pair [x=" + x + ", y=" + y + "]";
		}

	}

}