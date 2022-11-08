using System.Collections.Generic;

namespace models
{

	public interface IAiEnemy
	{

		Point2D Move(IDictionary<Point2D, Optional<Entity>> board, Point2D playerPosition, Point2D position);

	}

}