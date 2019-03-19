CC = CSC

NAME = BlackJack.exe

SRC = BlackJack.cs CardDeck.cs Character.cs Dealer.cs Hand.cs Player.cs

all:
	$(CC) -out:$(NAME) $(SRC)

fclean:
	@/bin/rm $(NAME)


