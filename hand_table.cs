using System;
using System.Collections.Generic;


public class Program
{
	
	static List<int> tHand = new List<int>();
	static List<int> outCards = new List<int>();

	static int ended = 0;
	static int[] value6 = new int[6];

	
	
	public static void Main()
	{
		Console.WriteLine("Hello World");
		
		// tHand.Add(8);
		// outCards.Add(9);
		
		delahits(1.0);
		
		Console.WriteLine(  "\n{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10} ", "17","18","19","20","21","break","total" );
		Console.WriteLine(  "{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10} ", "--","--","--","--","--","-----" ,"-----" );
		int total =  value6[0]+ value6[1]+ value6[2]+ value6[3]+ value6[4]+ value6[5];
		Console.WriteLine(  "{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10} ", value6[0], value6[1], value6[2], value6[3], value6[4], value6[5], total );
	}
	

	static void delahits(double odd)
	{
		string s1 = handToString(tHand.ToArray());
		
		for (int i = 4; i < 13; i++)                      // change to zero
		{
			double cardOdds = GetOddOfCard(i);
			if (cardOdds < (1.0 / 52))
			{
				Console.WriteLine(  "no card ");
			}
			else
			{
				tHand.Add(i);
				int tempVal = handToVal( tHand.ToArray() );

				if (tempVal < 17)  // hit
				{
					double odds = odd * cardOdds;
					delahits(odds);
				}
				else
				{
					if (tempVal >= 17 && tempVal <= 21)  //  stand
					{
						//Console.WriteLine("stand");
						int i2 = tempVal - 17;
						value6[i2]++;
					}
					if (tempVal > 21)  //  break
					{
						value6[5]++;
					}
					ended++;
					string handS = handToString(tHand.ToArray());
					Console.WriteLine("{0,-25}{1,-40}{2,20}{3,20}", "ending", handS, ended, tempVal);
				}
				tHand.RemoveAt(tHand.Count - 1);
			}
		}
	}

	


	public static string handToString( int[] hand )
	{
		string s1 = "";
		for (int i = 0; i < hand.Length; i++)
		{
			s1 = s1 + hand[i] + " ";
		}

		return s1;
	}




	public static double GetOddOfCard(int target)
	{
		int count = 0;

		foreach (int outCard in outCards)
		{
			if (target == (outCard % 13))
			{
				count++;
			}
		}

		foreach (int handCard in tHand )
		{
			if (target == (handCard % 13))
			{
				count++;
			}
		}

		if (count == 0)
		{
			return 4.0 / (52 - outCards.Count);
		}
		if (count == 1)
		{
			return 3.0 / (52 - outCards.Count);
		}
		if (count == 2)
		{
			return 2.0 / (52 - outCards.Count);
		}
		if (count == 3)
		{
			return 1.0 / (52 - outCards.Count);
		}
		return 0;
	}

	public static int handToVal(int[] hand)
	{
		int handValue = 0;
		for (int i = 0; i < hand.Length; i++)
		{
			handValue = handValue + cardToVal(hand[i]);
		}

		return handValue;
	}


	public static int cardToVal(int card)
	{
		int val = card % 13;

		if (val == 9 || val == 10 || val == 11 || val == 12)
		{
			return 10;
		}
		return val + 1;
	}
}