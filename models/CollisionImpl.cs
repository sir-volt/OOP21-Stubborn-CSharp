using System.Collections.Generic;

namespace models
{

	public class CollisionImpl : ICollisionStrategy
	{

		public override bool checkCollisions(IDictionary<Point2D, Optional<Entity>> board, Point2D newPos, int width, int height)
		{
			if (newPos.getX() >= width || newPos.getX() < 0 || newPos.getY() >= height || newPos.getY() < 0)
			{
				return true;
			}
			return board[newPos].isPresent() && (board[newPos].get() is Enemy || board[newPos].get() is Player);
		}

	}

}