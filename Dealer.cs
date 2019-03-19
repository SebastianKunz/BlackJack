using System;

class Dealer : Character
{
	public Dealer(string dealerName)
	{
		hand = new Hand();
		name = dealerName;
		didBust = false;
	}

	public void GiveCard(CardDeck deck, Player player)
	{
		//what if deck is empty?
		player.AcceptCard(deck.DrawCard());
	}

	public void GiveCard(CardDeck deck, Dealer dealer)
	{
		hand.AddCard(deck.DrawCard());
	}

	public override void PrintHand()
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine("Hand Value " + hand.HandList[0].RankValue  + " Hand of " + name);
		hand.HandList[0].Print();
		Console.WriteLine("[X](X)");
		Console.ResetColor();
	}

	public void RevealCards()
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		base.PrintHand();
		Console.ResetColor();
	}
}