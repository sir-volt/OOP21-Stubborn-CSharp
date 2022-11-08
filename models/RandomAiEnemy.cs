using System;
using System.Collections.Generic;

namespace models
{
	public class RandomAiEnemy : IAiEnemy
	{
		public override Point2D Move(IDictionary<Point2D, Optional<Entity>> board, Point2D playerPosition, Point2D position)
		{
			Random r = new Random();
			int randomSelect = r.Next(4);
			Point2D newPosition = position;

			switch (randomSelect)
			{
			case 0:
				newPosition = new Point2D(position.getX() + MOVEMENT.LEFT.movement.getX(), position.getY() + MOVEMENT.LEFT.movement.getY());
				break;
			case 1:
				newPosition = new Point2D(position.getX() + MOVEMENT.RIGHT.movement.getX(), position.getY() + MOVEMENT.RIGHT.movement.getY());
				break;
			case 2:
				newPosition = new Point2D(position.getX() + MOVEMENT.UP.movement.getX(), position.getY() + MOVEMENT.UP.movement.getY());
				break;
			case 3:
				newPosition = new Point2D(position.getX() + MOVEMENT.DOWN.movement.getX(), position.getY() + MOVEMENT.DOWN.movement.getY());
				break;
			}
			return newPosition;
		}
	}
}