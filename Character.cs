using System;

abstract class Character
{
	public string	name;
	protected bool	didBust;
	protected Hand	hand;
	protected bool	hasBJ;

	public virtual void PrintHand()
	{
		Console.Write("Hand Value[" + hand.HandValue + "] Hand of " + name);
		if (hasBJ)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(" BLACKJACK!");
			Console.ResetColor();
		}
		else
			Console.WriteLine();
		hand.Print();
	}

	public void DrawCard(Card card)
	{
		hand.AddCard(card);
	}

	public void Bust()
	{
		didBust = true;
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(name + " busted!");
		Console.ResetColor();
	}

	public int HandValue
	{
		get { return hand.HandValue; }
	}

	public void CheckForBlackJack()
	{
		if (hand.Size == 2 &&
			((hand.HandList[0].RankCode >= (int)Rank.Jack && hand.HandList[0].RankCode < (int)Rank.Ace && hand.HandList[1].RankCode == (int)Rank.Ace) ||
			hand.HandList[0].RankCode == (int)Rank.Ace && hand.HandList[1].RankCode >= (int)Rank.Jack && hand.HandList[1].RankCode < (int)Rank.Ace))
		{
			hasBJ = true;
		}
		else
		{
			hasBJ = false;
		}
	}

	public bool DidBust
	{
		get { return didBust; }
		set { didBust = value; }
	}

	public bool HasBJ
	{
		get { return hasBJ; }
		private set { hasBJ = value; }
	}
}
