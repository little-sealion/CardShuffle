﻿using System.Linq;
using CardShuffle;
var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                   from r in Ranks().LogQuery("Rank Generation")
                    select new { Suit = s, Rank = r }).LogQuery("starting deck")
                    .ToArray();
foreach (var c in startingDeck)
{
    Console.WriteLine(c);
}

var times = 0;
var shuffle = startingDeck;
do
{
    // Out shuffle
   
    //shuffle = shuffle.Take(26)
    //    .LogQuery("Top Half")
    //    .InterleaveSequenceWith(shuffle.Skip(26)
    //    .LogQuery("Bottom Half"))
    //    .LogQuery("Shuffle")
    //    .ToArray();


    // In shuffle
    shuffle = shuffle.Skip(26)
           .LogQuery("Bottom Half")
           .InterleaveSequenceWith(shuffle.Take(26)
           .LogQuery("Top Half"))
           .LogQuery("Shuffle")
           .ToArray();
    foreach (var card in shuffle)
    {
        Console.WriteLine(card);
    }
    Console.WriteLine();
    times++;
} while (!startingDeck.SequenceEquals(shuffle));
Console.WriteLine(times);





IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "spades";
    yield return "diamonds";
    yield return "hearts";
}

IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}
