# Common Files

In this folder, there are classes and other components that are used in both the server and client side of the project

## ***Table of Contents***

| C# Component Name     | Type       |
|-----------------------|------------|
| Bid                   | Class      |
| Card                  | Class      |
| HandRank              | Class      |
| IMessage              | Interface  |
| Message               | Class      |
| MessageEventArgs      | Class      |
| Player                | Class      |
| eBlind                | enumerator |
| eCardRank             | enumerator |
| eCommand              | enumerator |
| eSuit                 | enumerator |
| eValue                | enumerator |

### **[Bid](https://github.com/Hamartia666/PokerGame/blob/master/Common/PokerGame.Common/Bid.cs) Class**

This class is used to set a specific blind to players, using the **[eBlind](https://github.com/Hamartia666/PokerGame/blob/master/Common/PokerGame.Common/eBlind.cs)** enumerator component

| Blind value | Meaning                                             |
|-------------|-----------------------------------------------------|
| small       | Small Blind, player has to bid a small sum of money |
| big         | Big Blind, player has to bid a bigger sum           |
| no          | No blind, i.e. the player doesn't have to bid       |

### **[Card](https://github.com/Hamartia666/PokerGame/blob/master/Common/PokerGame.Common/Card.cs) Class**

This class represents a playing card.
To represent the card, we use the **[eSuit](https://github.com/Hamartia666/PokerGame/blob/master/Common/PokerGame.Common/eSuit.cs)** and **[eValue](https://github.com/Hamartia666/PokerGame/blob/master/Common/PokerGame.Common/eValue.cs)** enumerators.

* In Poker, each card's suit and value are important, and have different strength:
<table>
<tr><td>

| Suit     | Suit Strength |
|----------|-------|
| clubs    | 0     |
| diamonds | 1     |
| hearts   | 2     |
| spades   | 3     |

</td><td>

| Value    | Value Strength |
|----------|----------------|
| two      | 0              |
| three    | 1              |
| four     | 2              |
| five     | 3              |
| six      | 4              |
| seven    | 5              |
| eight    | 6              |
| nine     | 7              |
| ten      | 8              |
| jack     | 9              |
| queen    | 10             |
| king     | 11             |
| ace      | 12             |

</td></tr> </table>

* The Class has a `Compare()` method that compares the instantiated card to another card.
    - The method first compares which value is stronger
    - If the values are equal, the method then checks the strength of the suits
    - The method returns `-1` if the instantiated card is smaller than the other card, and `1` if the card is greater.


