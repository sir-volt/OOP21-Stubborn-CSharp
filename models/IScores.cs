using System.Collections.Generic;

namespace models
{
	public interface IScores
	{
		void SetScore(string name, int? score);

		IList<Pair<string, int>> AllScores {get;}

		string Score {get;}
	}
}