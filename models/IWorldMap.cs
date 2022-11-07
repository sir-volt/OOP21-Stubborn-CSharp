using System;
using System.Collections.Generic;

namespace models
{

	public interface IWorldMap
	{
		void movePlayer(MOVEMENT movement);

		IDictionary<Point2D, Optional<Entity>> Board {get;}

		Point2D PlayerPos {get;}

		IList<Pair<Point2D, Type>> EntitiesPos {get;}
	}

}