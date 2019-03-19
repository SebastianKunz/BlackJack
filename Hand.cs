using System.Collections.Generic;

class Hand
{
	private List<Card> _hand;
	private int _handValue;
	private int _aceSub;

	public Hand()
	{
		_hand = new List<Card>();
		_handValue = 0;
	}

	public void AddCard(Card card)
	{
		_hand.Add(card);
		_handValue += card.RankValue;
		if (card.RankCode == (int)Rank.Ace)
			_aceSub += 10;
		if (_handValue > 21 && _aceSub > 0)
		{
			_handValue -= 10;
			_aceSub -= 10;
		}

	}

	public void Print()
	{
		foreach(var card in _hand)
			card.Print();
	}

	public void WipeHand()
	{
		_hand.Clear();
	}

	public int Size
	{
		get { return _hand.Count; }
	}

	public int HandValue
	{
		get { return _handValue; }
		private set { if (value > 0) _handValue = 0; }
	}

	public List<Card> HandList
	{
		get { return _hand; }
	}
}