using System.Collections.Generic;
using Entity = models.Entity;
using MOVEMENT = models.MOVEMENT;
using Player = models.Player;
using Point2D = models.Point2D;
using RandomSpawnStrategy = models.RandomSpawnStrategy;
using SpawnStrategy = models.SpawnStrategy;
using WorldMap = models.WorldMap;
using WorldMapImpl = models.WorldMapImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace worldMapTest
{

	[TestClass]
	public class WorldMapTest
	{
		
		WorldMap worldMap = new WorldMapImpl();
		

		[TestMethod]
        public void testRandomSpawnStrategy()
        {
            WorldMap worldMap = new WorldMapImpl();
            Assert.AreEqual(ENEMIES_NUMBER, worldMap.Enemies.Count);
            Assert.IsNull(worldMap.updatePlayerPosition(Movement.valueOf(Movement.InnerEnum.LEFT)));
            Assert.IsNotNull(worldMap.updatePlayerPosition(Movement.valueOf(Movement.InnerEnum.RIGTH)));
        }

		private void InitializeInstanceFields()
		{
			worldMap = new WorldMapImpl(WIDTH, HEIGHT, NUM_ENEMIES, NUM_COLLECTABLES, randomStrategy);
		}


		private static int WIDTH = 51;
		private static int HEIGHT = 51;
		private static int NUM_ENEMIES = 5;
		private static int NUM_COLLECTABLES = 15;
		private static int EXPECTED_SIZE = 5;

		private SpawnStrategy randomStrategy = new RandomSpawnStrategy();
		private WorldMap worldMap;
		private Point2D startPlayerPos = new Point2D(WIDTH / 2, HEIGHT / 2);
		private Point2D randomPos = new Point2D(3, EXPECTED_SIZE);



		public virtual void testRandomSpawnStrategy()
		{
			int width = 10;
			int height = 10;
			int numEntities = 4;
			ISet<Point2D> set1 = this.randomStrategy.getSpawnPoints(width, height, numEntities);
			set1.Add(randomPos);
			ISet<Point2D> set2 = this.randomStrategy.getSpawnPoints(width, height, numEntities);
			set2.Add(randomPos);
			ISet<Point2D> allSet = this.randomStrategy.getDoubleSpawnPoints(width, height, set1, set2);
			assertEquals(EXPECTED_SIZE, set1.Count);
			assertEquals(EXPECTED_SIZE * 2, allSet.Count);
			assertTrue(allSet.ContainsAll(set1));
			assertTrue(allSet.ContainsAll(set2));
		}

		public virtual void testWorldMapCreation()
		{
			IDictionary<Point2D, Optional<Entity>> board = worldMap.getBoard();
			long count = board.Values.Where(v => v.isPresent()).Count();
			assertEquals(WIDTH * HEIGHT, board.Count);
			assertTrue(board[startPlayerPos].get() is Player);
			assertEquals(NUM_ENEMIES + NUM_COLLECTABLES + 1, count);
		}


		public virtual void testMovePlayer()
		{
			worldMap.movePlayer(MOVEMENT.LEFT);
			worldMap.movePlayer(MOVEMENT.UP);
			IDictionary<Point2D, Optional<Entity>> board = worldMap.getBoard();
			Point2D leftPosition = new Point2D(24, 26);
			assertTrue(board[leftPosition].isPresent());
			assertTrue(board[leftPosition].get() is Player);
			assertTrue(board[startPlayerPos].isEmpty());
		}
	}

}

//Class imported from internet to better use Collections

using System;
using System.Collections.Generic;

internal static class CollectionHelper
{
	public static bool ContainsAll<T>(this ICollection<T> c1, ICollection<T> c2)
	{
		if (c2 is null)
			throw new NullReferenceException();

		foreach (T item in c2)
		{
			if (!c1.Contains(item))
				return false;
		}
		return true;
	}

	public static bool RemoveAll<T>(this ICollection<T> c1, ICollection<T> c2)
	{
		if (c2 is null)
			throw new NullReferenceException();

		bool changed = false;
		foreach (T item in c2)
		{
			if (c1.Contains(item))
			{
				c1.Remove(item);
				changed = true;
			}
		}
		return changed;
	}

	public static bool RetainAll<T>(this ICollection<T> c1, ICollection<T> c2)
	{
		if (c2 is null)
			throw new NullReferenceException();

		bool changed = false;
		T[] arrayCopy = new T[c1.Count];
		c1.CopyTo(arrayCopy, 0);
		foreach (T item in arrayCopy)
		{
			if (!c2.Contains(item))
			{
				c1.Remove(item);
				changed = true;
			}
		}
		return changed;
	}
}