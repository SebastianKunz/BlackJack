using System;

class Player : Character
{
	private int		_betAmount;

	public Player(string playerName)
	{
		hand = new Hand();
		name = playerName;
		didBust = false;
	}

	public void AcceptCard(Card card)
	{
		hand.AddCard(card);
	}

	public int BetAmount
	{
		get { return _betAmount; }
		set { if (value > 0) _betAmount = value; }
	}

	public override void PrintHand()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		base.PrintHand();
		Console.ResetColor();
	}
}