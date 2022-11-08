namespace models
{
	public class EnemyImpl : IEnemy
	{
		private Point2D position;
		private int health;
		private const int MAXHEALTH = 1;
		private AiEnemy aiEnemy;

		public EnemyImpl(Point2D position, int health, AiEnemy aiEnemy)
		{
			this.position = position;
			this.health = health;
			this.aiEnemy = aiEnemy;
		}

		public override int Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (this.health < MAXHEALTH)
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

		public override AiEnemy Ai
		{
			get
			{
				return this.aiEnemy;
			}
		}
	}
}