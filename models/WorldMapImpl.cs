using System;
using System.Collections.Generic;

namespace models
{
	public class WorldMapImpl : IWorldMap
	{

		private int board_width;
		private int board_height;
		private int num_enemies;
		private int num_collectables;
		private IDictionary<Point2D, Optional<Entity>> board;
		private Point2D playerPosition;
		private ISpawnStrategy spawnStrategy;
		private ICollision collisionStrategy;

		public WorldMapImpl(int width, int height, int enemies, int collectables, ISpawnStrategy strategy)
		{
			this.board_width = width;
			this.board_height = height;
			this.num_enemies = enemies;
			this.num_collectables = collectables;
			this.spawnStrategy = strategy;
			this.collisionStrategy = new CollisionImpl();
			this.playerPosition = new Point2D(board_width / 2, board_height / 2);
			this.board = IntStream.range(0, board_width).boxed().flatMap(x => IntStream.range(0, board_height).boxed().map(y => new Point2D(x,y))).collect(Collectors.toMap(x => x, x => null));
			this.board[this.playerPosition] = (new PlayerImpl(this.playerPosition, 3));
			this.spawnEntity();
		}

		private void spawnEntity()
		{
			if (this.spawnStrategy.checkNumPoints(this.board_width * this.board_height, this.num_enemies + this.num_collectables))
			{
				ISet<Point2D> enSpawnPoints = this.spawnStrategy.getSpawnPoints(this.board_width, this.board_height, this.num_enemies);
				ISet<Point2D> collectSpawnPoints = this.spawnStrategy.getSpawnPoints(this.board_width, this.board_height, this.num_collectables);
				ISet<Point2D> everyPoint = this.spawnStrategy.getDoubleSpawnPoints(this.board_width, this.board_height, enSpawnPoints, collectSpawnPoints);
				IEnumerator<Point2D> pointIterator = everyPoint.GetEnumerator();
				for (int i = 0; i < this.num_enemies; i++)
				{
					Point2D enemyPos = pointIterator.next();
					this.board[enemyPos] = (new EnemyImpl(enemyPos, 1, this.EnemyAi));
				}
				for (int i = this.num_enemies; i < (this.num_enemies + this.num_collectables); i++)
				{
					this.board[pointIterator.next()] = (new CollectableImpl());
				}
			}
		}

		public override void movePlayer(MOVEMENT movement)
		{
			this.moveEnemies();
			Point2D newPos = Point2D.sum(this.playerPosition, movement.movement);
			if (!this.collisionStrategy.checkCollisions(this.Board, newPos, this.board_width, this.board_height))
			{
				Entity player = this.board.replace(this.playerPosition, null).get();
				this.playerPosition = newPos;
				player.setPosition(this.playerPosition);
				this.board[this.playerPosition] = player;
			}
		}

		private void moveEnemies()
		{
			IList<Pair<Point2D, Type>> entitiesPos = this.EntitiesPos;
			entitiesPos.removeIf(el => !el.getY().Equals(typeof(EnemyImpl)));
			if (entitiesPos.Count > 0)
			{
				foreach (Pair<Point2D, Type> enemy in entitiesPos)
				{
					Enemy en = (Enemy) this.board[enemy.getX()].get();
					Point2D newPos = en.getAi().move(this.Board, this.playerPosition, enemy.getX());
					if (!this.collisionStrategy.checkCollisions(this.Board, newPos, this.board_width, this.board_height))
					{
						this.board.replace(enemy.getX(), null);
						en.setPosition(newPos);
						this.board[newPos] = en;
					}
				}
			}
		}

		public override IDictionary<Point2D, Optional<Entity>> Board
		{
			get
			{
				return this.board;
			}
		}

		public override Point2D PlayerPos
		{
			get
			{
				return this.playerPosition;
			}
		}

		public override IList<Pair<Point2D, Type>> EntitiesPos
		{
			get
			{
				IList<Pair<Point2D, Type>> entitiesPos = new List<Pair<Point2D, Type>>();
				foreach (KeyValuePair<Point2D, Optional<Entity>> i in this.board.SetOfKeyValuePairs())
				{
					if (i.Value.isPresent() && !i.Key.Equals(this.PlayerPos))
					{
						entitiesPos.Add(new Pair<Point2D, Type>(i.Key, i.Value.get().GetType()));
					}
				}
				return entitiesPos;
			}
		}

		private AiEnemy EnemyAi
		{
			get
			{
				Random r = new Random();
				int randomSelect = r.Next(2);
				return randomSelect == 0 ? new RandomAiEnemy() : new FocusAiEnemy();
			}
		}
	}

}

//imported this from internet in order to properly use HashMap

using System;
using System.Collections.Generic;

internal static class HashMapHelper
{
	public static HashSet<KeyValuePair<TKey, TValue>> SetOfKeyValuePairs<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		HashSet<KeyValuePair<TKey, TValue>> entries = new HashSet<KeyValuePair<TKey, TValue>>();
		foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
		{
			entries.Add(keyValuePair);
		}
		return entries;
	}

	public static TValue GetValueOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
	{
		TValue ret;
		dictionary.TryGetValue(key, out ret);
		return ret;
	}

	public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
	{
		TValue ret;
		if (dictionary.TryGetValue(key, out ret))
			return ret;
		else
			return defaultValue;
	}

	public static void PutAll<TKey, TValue>(this IDictionary<TKey, TValue> d1, IDictionary<TKey, TValue> d2)
	{
		if (d2 is null)
			throw new NullReferenceException();

		foreach (TKey key in d2.Keys)
		{
			d1[key] = d2[key];
		}
	}
}