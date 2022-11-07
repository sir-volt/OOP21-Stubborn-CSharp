using System;
using System.Collections.Generic;

namespace models
{

	public sealed class COLLECTABLETYPE
	{

		public static readonly COLLECTABLETYPE DIAMOND = new COLLECTABLETYPE("DIAMOND", InnerEnum.DIAMOND, 100);
		public static readonly COLLECTABLETYPE COIN = new COLLECTABLETYPE("COIN", InnerEnum.COIN, 50);
		public static readonly COLLECTABLETYPE CHALICE = new COLLECTABLETYPE("CHALICE", InnerEnum.CHALICE, 150);
		public static readonly COLLECTABLETYPE CROWN = new COLLECTABLETYPE("CROWN", InnerEnum.CROWN, 200);
		public static readonly COLLECTABLETYPE BAGOFCOINS = new COLLECTABLETYPE("BAGOFCOINS", InnerEnum.BAGOFCOINS, 200);

		private static readonly List<COLLECTABLETYPE> valueList = new List<COLLECTABLETYPE>();

		static COLLECTABLETYPE()
		{
			valueList.Add(DIAMOND);
			valueList.Add(COIN);
			valueList.Add(CHALICE);
			valueList.Add(CROWN);
			valueList.Add(BAGOFCOINS);
		}

		public enum InnerEnum
		{
			DIAMOND,
			COIN,
			CHALICE,
			CROWN,
			BAGOFCOINS
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly int points;

		public int Points
		{
			get
			{
				return this.points;
			}
		}

		public static COLLECTABLETYPE RandomType
		{
			get
			{
				Random random = new Random();
				return values()[random.Next(values().Length)];
			}
		}

		internal COLLECTABLETYPE(string name, InnerEnum innerEnum, int points)
		{
			this.points = points;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public static COLLECTABLETYPE[] values()
		{
			return valueList.ToArray();
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static COLLECTABLETYPE valueOf(string name)
		{
			foreach (COLLECTABLETYPE enumInstance in COLLECTABLETYPE.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}