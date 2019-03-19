using System;

enum Suit
{
	Diamonds,
	Clubs,
	Hearts,
	Spades
}

enum Rank
{
	None,
	None2,
	Two,
	Three,
	Four,
	Five,
	Six,
	Seven,
	Eight,
	Nine,
	Ten,
	Jack,
	Queen,
	King,
	Ace
}

class Card
{
	private int _suit;
	private char _suitSign;
	private char[] _suitSignLabel = new char[] {'H', 'T', 'C', 'P'};
	private int _rankCode;
	private int _rankValue;
	private string _rankSign;
	private string[] _rankNames = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

	public Card(int suitCode, int rankCode)
	{
		_suit = suitCode;
		if (suitCode >= 0 && suitCode <= 4)
		{
			_suitSign = _suitSignLabel[suitCode];
			_suit = suitCode;
		}
		if (rankCode >= (int)Rank.Two && rankCode <= (int)Rank.Ace)
		{
			_rankCode = rankCode;
			_rankSign = _rankNames[rankCode - 2];
			if (rankCode <= (int)Rank.Ten)
				_rankValue = rankCode;
			else if (rankCode == (int)Rank.Ace)
				_rankValue = 11;
			else
				_rankValue = 10;
		}
	}

	public int RankCode
	{
		get { return _rankCode; }
		private set { _rankCode = value; }
	}

	public int Suit
	{
		get { return _suit; }
		private set { if (value >= 0 && value <= 4) _suit = value; }
	}

	public char SuitSign
	{
		get ;
		private set ;
	}

	public int RankValue
	{
		get { return _rankValue; }
		private set { if (value >= (int)Rank.Two && value <= (int)Rank.Ace) _rankValue = value; }
	}

	public string RankSign
	{
		get ;
		private set ;
	}

	public void Print()
	{
		Console.WriteLine("[" + _suitSign + "]" + "(" + _rankSign + ")");
	}
}

class CardDeck
{

	// 52 Cards in a Deck
	private Card[] _deck = new Card[52];
	private int _cardsLeft;
	public CardDeck()
	{
		_cardsLeft = 52;
		// 4 sets in a CardDeck
		for (int suit = 0; suit < 4; suit++)
			for (int rank = (int)Rank.Two; rank < (int)Rank.Ace + 1; rank++)
				_deck[(suit * ((int)Rank.Ace - (int)Rank.Two + 1)) + (rank - 2)] = new Card(suit, rank);
	}

	public void Print()
	{
		for (int i = 0; i < 52; i++)
			_deck[i].Print();
	}

	public void Shuffle()
	{
		Card tmp;
		Random random = new Random();
		int r;
		for (int i = 0; i < _cardsLeft; i ++)
		{
			r = random.Next(0, 52);
			tmp = _deck[r];
			_deck[r] = _deck[i];
			_deck[i] = tmp;
		}
	}

	public Card DrawCard()
	{
		_cardsLeft--;
		if (_cardsLeft >= 0)
			return _deck[_cardsLeft];
		return null;
	}

	public void ResetDeck()
	{
		_cardsLeft = 52;
	}

	public int CardsLeft
	{
		get { return _cardsLeft; }
		private set { if (value == 52) _cardsLeft = value; }
	}
}