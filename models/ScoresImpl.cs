using System;
using System.Collections.Generic;
using System.IO;

namespace models
{
	public class ScoresImpl : IScores
	{
		private IList<Pair<string, int>> scores = new List<Pair<string, int>>();

		public ScoresImpl()
		{
			try
			{
				Scanner s = new Scanner(new File("score.txt"));
				while (s.hasNextLine())
				{
				   string[] split = s.nextLine().Split(":");
				   scores.Add(new Pair<string, int>(split[0], int.Parse(split[1])));
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("No file found");
			}
		}

		public override void SetScore(string name, int? score)
		{
			string result = name + ":" + score.ToString();
			WriteScoreIntoFile(result);
			this.scores.Add(new Pair<string, int>(name, score));
		}

		public override IList<Pair<string, int>> AllScores
		{
			get
			{
				return this.scores;
			}
		}

		public override string Score
		{
			get
			{
				string score = ReadScoreFromFile();
				return score;
			}
		}

		private void WriteScoreIntoFile(string score)
		{
			File scoreFile = new File("score.txt");
			if (!scoreFile.exists())
			{
				try
				{
					scoreFile.createNewFile();
				}
				catch (IOException e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}
			StreamWriter writeFile = null;
			StreamWriter writer = null;
			try
			{
				writeFile = new StreamWriter(scoreFile, true);
				writer = new StreamWriter(writeFile);
				writer.append(score + "\n");
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			finally
			{
				try
				{
					if (writer != null)
					{
						writer.Close();
					}
				}
				catch (IOException e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}
		}

		private string ReadScoreFromFile()
		{
			// format name:score (ex: Marco:100)

			StreamReader readFile = null;
			StreamReader reader = null;

			try
			{
				readFile = new StreamReader("score.txt");
				reader = new StreamReader(readFile);
				return reader.ReadLine();
			}
			catch (Exception)
			{
				return "0";
			}
			finally
			{
				try
				{
					if (reader != null)
					{
						reader.Close();
					}
				}
				catch (IOException e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}
		}
	}
}