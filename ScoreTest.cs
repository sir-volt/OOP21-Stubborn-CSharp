using System.Collections.Generic;
using Pair = models.Pair;
using IScores = models.IScores;
using ScoresImpl = models.ScoresImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace scoresTest
{
	[TestClass]
	public class ScoreTest
	{
		private Scores s = new ScoresImpl();

		[TestMethod]
		public void WriteScoreTest()
		{
			s.setScore("Marco", 50);
			s.setScore("Matteo", 150);
			s.setScore("Andrea", 180);
			IList<Pair<string, int>> result = s.getAllScores();
			Assert.True(result.Contains(new Pair<>("Marco", 50)));
			Assert.True(result.Contains(new Pair<>("Matteo", 150)));
			Assert.True(result.Contains(new Pair<>("Andrea", 180)));
		}

		[TestMethod]
		public void ReadScoreTest()
		{
			Pair<string, int> expected = new Pair<string, int>("Marco", 50);
			IList<Pair<string, int>> result = s.getAllScores();
			Assert.True(result.Contains(expected));
		}
	}

}