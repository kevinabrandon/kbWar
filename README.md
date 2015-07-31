# kbWar
A monte-carlo simulation for the card game WAR!

If you don’t know what the card game WAR is, read this article:
https://en.wikipedia.org/wiki/War_(card_game) 

After playing the simple card game with my 7-year-old daughter, I had several questions.  Questions like, how long does a typical game last?  How often do you get a WAR (tie)?  How often do you get a double WAR?  Can you ever have an unending game?  I decided to write a program to find answers to these questions.

Also, I’ve never used GitHub before, but I’ve heard this is the place to host your code, so I thought I might as well try it out.

##Answers

I've found the answers to my questions. [See all my results here](Results.md)  

Questions | Answers
 ------------- | -----------
How long does a game last? | About 270 moves.
How often do you get a WAR? | About 6 every 100 moves.
How often do you get a double war? | About 3 every 1000 moves.
Can you have an unending game? | YES, but only if the players don't mix up any cards won after a turn.
How often are there unending games? | About a tenth of all games are unending.

![Probability Distribution](http://i.imgur.com/GJrZyB0.png)

##Building

Open the [kbWar.sln](kbWar/kbWar.sln) file in Visual Studio 2010 and build the project.  
It should also work in later versions of Visual Studio, but I haven't tested it.
