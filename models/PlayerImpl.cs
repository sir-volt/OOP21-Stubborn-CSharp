namespace models
{
	public class PlayerImpl : IPlayer
	{
		private Point2D position;
		private int health;
		private const int MAXHEALTH = 3;

		public PlayerImpl(Point2D position, int health)
		{
			this.position = position;
			this.health = health;
		}

		public override int Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (this.health + value < MAXHEALTH)
				{
					this.health = this.health + value;
				}
			}
		}

		public override Point2D Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}
	}
}