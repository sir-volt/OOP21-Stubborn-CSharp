namespace models
{

	public class CollectableImpl : ICollectable
	{

		private Point2D position;
		private COLLECTABLETYPE type;

		public CollectableImpl()
		{
			type = COLLECTABLETYPE.getRandomType();
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


		public override int Points
		{
			get
			{
				return type.getPoints();
			}
		}

	}

}