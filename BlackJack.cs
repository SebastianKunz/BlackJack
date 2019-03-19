using System;
using System.Collections.Generic;

namespace BlackJack
{
	enum CharacterRole
	{
		Dealer,
		Player
	}

	class Controller
	{
		private Dealer _dealer;
		private List<Player> _players = new List<Player>();
		private CardDeck _deck;

		public Controller()
		{
			_dealer = new Dealer("James");
			_deck = new CardDeck();
			_deck.Shuffle();

		}

		public void AddPlayer(string name)
		{
			_players.Add(new Player(name));
		}

		public void PlaceBets()
		{
			foreach (var player in _players)
			{
				string	descision;
				int		amount;

				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine(player.name + " Choose Bet Amount.(max. 1000$)");
				Console.ResetColor();
				descision = Console.ReadLine();
				int.TryParse(descision, out amount);
				if (amount > 0 && amount <= 1000)
					player.BetAmount = amount;
				else
				{
					Console.WriteLine("Invalid Amount!");
					player.DidBust = true;
				}
			}
		}

		public void DealCards()
		{
			foreach (var player in _players)
				_dealer.GiveCard(_deck, player);
			_dealer.GiveCard(_deck, _dealer);
			foreach (var player in _players)
			{
				_dealer.GiveCard(_deck, player);
				player.CheckForBlackJack();
			}
			_dealer.GiveCard(_deck, _dealer);
			_dealer.CheckForBlackJack();
			_dealer.PrintHand();
		}

		public void ListenForActions()
		{
			foreach (var player in _players)
			{
				string	descision;

				if (player.HasBJ)
					Console.WriteLine(player.name + " Has BlackJack!");
				else
				{
					while (!player.DidBust)
					{
						player.PrintHand();
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.WriteLine(player.name + " Hit(1) or Stand(0)");
						Console.ResetColor();
						descision = Console.ReadLine();
						if (int.Parse(descision) == 1)
						{
							_dealer.GiveCard(_deck, player);
							if (player.HandValue > 21)
							{
								player.PrintHand();
								player.Bust();
							}
						}
						else
							break;
					}
				}
			}
		}

		public void LetDealerDraw()
		{
			while (_dealer.HandValue < 17)
				_dealer.GiveCard(_deck, _dealer);
			if (_dealer.HandValue > 21)
				_dealer.Bust();
		}

		public void ChooseWinners()
		{
			_dealer.RevealCards();
			foreach (var player in _players)
			{
				if (_dealer.DidBust && !player.DidBust)
				{
					if (player.HasBJ)
						Console.WriteLine(player.name + " won " + player.BetAmount * 2.5);
					else
						Console.WriteLine(player.name + " won " + player.BetAmount * 2);
				}
				else if (!player.DidBust)
				{
					if (player.HasBJ && !_dealer.HasBJ)
						Console.WriteLine(player.name + " won with a BlackJack " + player.BetAmount * 2.5);
					else if (player.HasBJ && _dealer.HasBJ)
						Console.WriteLine(player.name + " tied with Dealer. Returned " + player.BetAmount );
					else if (player.HandValue > _dealer.HandValue)
						Console.WriteLine(player.name + " Won " + player.BetAmount * 2);
					else if (player.HandValue == _dealer.HandValue)
						Console.WriteLine(player.name + " tied with Dealer. Returned " + player.BetAmount );
					else
						Console.WriteLine(player.name + " lost " + player.BetAmount);
				}
			}
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			Controller controller = new Controller();

			if (args.Length == 0)
			{
				Console.WriteLine("No Players");
				System.Environment.Exit(0);
			}
			for (int i = 0; i < args.Length; i++)
				controller.AddPlayer(args[i]);
			controller.PlaceBets();
			controller.DealCards();
			controller.ListenForActions();
			controller.LetDealerDraw();
			controller.ChooseWinners();
		}
	}
}