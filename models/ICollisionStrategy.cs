using System.Collections.Generic;

namespace models
{

	public interface ICollisionStrategy
	{

		bool checkCollisions(IDictionary<Point2D, Optional<Entity>> board, Point2D newPos, int width, int height);

	}

}