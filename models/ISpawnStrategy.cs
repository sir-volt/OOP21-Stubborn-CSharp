using System.Collections.Generic;

namespace models
{

	public interface ISpawnStrategy
	{

		ISet<Point2D> getSpawnPoints(int width, int height, int numPoints);

		bool checkNumPoints(int boardDimension, int numPoints);

		ISet<Point2D> getDoubleSpawnPoints(int width, int height, ISet<Point2D> points1, ISet<Point2D> points2);
	}

}