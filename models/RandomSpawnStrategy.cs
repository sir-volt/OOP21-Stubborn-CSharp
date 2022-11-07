using System;
using System.Collections.Generic;

namespace models
{

	public class RandomSpawnStrategy : ISpawnStrategy
	{


		public override ISet<Point2D> getSpawnPoints(int width, int height, int numPoints)
		{
			Random r = new Random();
			ISet<Point2D> spawnPoints = new HashSet<Point2D>();
			while (spawnPoints.Count < numPoints)
			{
				Point2D newPos = new Point2D(r.Next(width), r.Next(height));
				if (!newPos.Equals(new Point2D(width / 2, height / 2)))
				{
					spawnPoints.Add(newPos);
				}
			}
			return spawnPoints;
		}

		public override ISet<Point2D> getDoubleSpawnPoints(int width, int height, ISet<Point2D> points1, ISet<Point2D> points2)
		{
			ISet<Point2D> allPoints = new HashSet<Point2D>();
			allPoints.addAll(points1);
			allPoints.addAll(points2);
			while (allPoints.Count - (points1.Count + points2.Count) != 0)
			{
				allPoints.addAll(getSpawnPoints(width, height, (points1.Count + points2.Count) - allPoints.Count));
			}
			return allPoints;
		}

		public override bool checkNumPoints(int boardDimension, int numPoints)
		{
			return boardDimension > numPoints;
		}

	}

}