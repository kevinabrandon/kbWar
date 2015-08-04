﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kbWar
{
    #region kbCardGameWar
    /// <summary>
    /// Simulates a game of war.  
    /// 
    /// Allows between 2 and 26 players.
    /// </summary>
    class kbCardGameWar
    {
        #region public enum GameState
        public enum GameState { eNotStarted, eCurrentlyPlaying, eInfiniteLoop, eOverWithWinner }
        #endregion

        #region struct GameCounters
        public struct GameCounters
        {
            public int nTurns;
            public int nTies;
            public int nTotalWars;
            public int nSingleWars;
            public int nDoubleWars;
            public int nTripleWars;
            public int nQuadrupleWars;
            public int nQuintupleWars;
            public int nSextupleWars;
            public int nSeptupleWars;
        }
        #endregion

        #region private member vars...

        private GameState m_State;                      // the current state of the game

        private kb52CardDeck m_Deck;                    // the starting deck
        private kbCardHand[] m_Players;                 // an array of players
        private kbCardHand[] m_ThrownCards;             // an array of cards thrown to the middle pile

        private kbCardHand m_MostRecentlyWonCards;      // a copy of the most recently won cards.
        private int m_iMostRecentWinner;                // an index to the most recent winner.
                                                        // -2 means the game hasn't started, so there is no recent winner
                                                        // -1 means the most recent turn resulted in a tie, so there were multiple winners.

        private GameCounters m_Counters;                // Counters used to keep track of the game.

        private bool m_bShuffleRecentlyWonCards = true; // flag to see if we should shuffle the most recently won cards.

        private Random m_Rand;                          // The random number generator used for shuffling.

        #endregion

        #region constructors...
        /// <summary>
        /// Creates a new game of war for two players.
        /// </summary>
        public kbCardGameWar() : this(2, new Random())  {   }

        /// <summary>
        /// Creates a new game of war for two players.
        /// </summary>
        /// <param name="r">An external random number generator</param>
        public kbCardGameWar(Random r) : this(2, r)     {   }

        /// <summary>
        /// Creates a new game of war.
        /// </summary>
        /// <param name="nPlayers">The number of players.</param>
        public kbCardGameWar(int nPlayers) : this(nPlayers, new Random())   {  }

        /// <summary>
        /// Creats a new game of war.
        /// </summary>
        /// <param name="nPlayers">The number of players</param>
        /// <param name="r">An external random number generator.</param>
        public kbCardGameWar(int nPlayers, Random r)
        {
            m_Rand = r;

            Restart(nPlayers);
        }
        #endregion

        #region public void Restart(int nPlayers)
        /// <summary>
        /// Restarts the game, with a new ordered deck.
        /// </summary>
        /// <param name="nPlayers">The number of players in the game (default is 2 players).</param>
        public void Restart(int nPlayers = 2)
        {
            if (nPlayers < 2 || nPlayers > 26) throw new Exception(nPlayers.ToString() + " Players!  Number of players must be between 2 and 26.");
            m_Deck = new kb52CardDeck(m_Rand);
            m_Players = new kbCardHand[nPlayers];
            m_ThrownCards = new kbCardHand[nPlayers];
            for (int i = 0; i < nPlayers; i++)
            {
                m_Players[i] = new kbCardHand(m_Rand);
                m_ThrownCards[i] = new kbCardHand(m_Rand);
            }
            m_MostRecentlyWonCards = new kb52CardDeck(m_Rand);
            m_iMostRecentWinner = -2;
            
            m_State = GameState.eNotStarted;

            m_Counters = new GameCounters();
        }
        #endregion

        #region public bool ShuffleRecentlyWonCards
        /// <summary>
        /// Gets or sets the flag to shuffle the middle pile between turns.
        ///     The default value is true.
        /// </summary>
        public bool ShuffleRecentlyWonCards
        {
            get { return m_bShuffleRecentlyWonCards; }
            set { m_bShuffleRecentlyWonCards = value; }
        }
        #endregion

        #region public GameState State
        /// <summary>
        /// Gets the current game state
        /// </summary>
        public GameState State
        {
            get { return m_State; }
        }
        #endregion

        #region public int Winner
        /// <summary>
        /// Gets the index to the winning hand (returns -1 if no winner)
        /// </summary>
        public int Winner
        {
            get
            {
                for (int i = 0; i < m_Players.Length; i++)
                {
                    if (m_Players[i].Count == 52) return i;
                }
                return -1;
            }
        }
        #endregion

        #region public GameCounters Counters
        /// <summary>
        /// Gets a copy of the game counters.
        /// </summary>
        public GameCounters Counters
        {
            get { return m_Counters; }
        }
        #endregion

        #region public void ShuffleDeck()
        /// <summary>
        /// Shuffles the Deck
        /// </summary>
        public void ShuffleDeck()
        {
            m_Deck.Shuffle();
        }
        #endregion

        #region public void Deal()
        /// <summary>
        /// Deals all the cards currently in the deck to the players one at a time
        /// </summary>
        public void Deal()
        {
            if(m_Deck.Count == 0) return;

            int count = 0;
            while (m_Deck.Count > 0)
            {
                int iPlayer = count % m_Players.Length;
                m_Players[iPlayer].AddToTop(m_Deck.DrawFromTop());
                count++;
            }
            m_State = GameState.eCurrentlyPlaying;
        }
        #endregion

        #region public int PlayTillFinished()
        /// <summary>
        /// Play the game till it's over.
        /// </summary>
        /// <returns>Returns an index to the winner (-1 if there is no winner).</returns>
        public int PlayTillFinished()
        {
            // check to see if the game is already over...
            if (m_State == GameState.eOverWithWinner || m_State == GameState.eInfiniteLoop) return Winner;  

            // check to see if the game is not started:
            if (m_State == GameState.eNotStarted)
            {   // start the game!
                ShuffleDeck();
                Deal();
            }

            // while we're still playing, keep taking turns!
            while (m_State == GameState.eCurrentlyPlaying)
            {
                NewTurn();
            }

            // return an index to the winner.
            return Winner;
        }
        #endregion

        #region public GameState NewTurn()
        /// <summary>
        /// It plays one turn of the game.
        /// </summary>
        /// <returns>It returns the game state.</returns>
        public GameState NewTurn()
        {
            if (m_State == GameState.eNotStarted)
            {   // let's start the game by shuffling and dealing
                ShuffleDeck();
                Deal();
            }
            if (m_State == GameState.eInfiniteLoop || m_State == GameState.eOverWithWinner) return m_State;

            // get a list of players that still have cards...
            List<int> players = new List<int>();
            for (int iPlayer = 0; iPlayer < m_Players.Length; iPlayer++) if (m_Players[iPlayer].Count > 0) players.Add(iPlayer);

            // all active players need to throw down!
            int nWars = 0;
            m_iMostRecentWinner = ThrowDown(players, ref nWars);

            // add all the cards thrown into recently won hand
            m_MostRecentlyWonCards.Clear();
            foreach( var cards in m_ThrownCards) 
            {
                while (cards.Count > 0) m_MostRecentlyWonCards.AddToBottom(cards.DrawFromBottom());
            }
            
            // if we need to, shuffle the winning cards.
            if (m_bShuffleRecentlyWonCards) m_MostRecentlyWonCards.Shuffle();

            if (m_iMostRecentWinner < 0)
            {   // tie!
                // deal out cards to the tied players
                m_Counters.nTies++;
                for (int iCard = 0; iCard < m_MostRecentlyWonCards.Count; iCard++)
                {
                    m_Players[players[iCard % players.Count]].AddToBottom(m_MostRecentlyWonCards[iCard]);
                }
            }
            else
            {   // only one winner.
                // add winning cards into bottom of winners hand
                for (int iCard = 0; iCard < m_MostRecentlyWonCards.Count; iCard++)
                {
                    m_Players[m_iMostRecentWinner].AddToBottom(m_MostRecentlyWonCards[iCard]);
                }
            }
            // update counters:
            UpdateCounters(nWars);

            // adjust the game state and return it.
            if (this.Winner >= 0) m_State = GameState.eOverWithWinner;              // do we have a winner?
            else if (m_Counters.nTurns > 20000) m_State = GameState.eInfiniteLoop;  // do we have an infinite loop?
            else m_State = GameState.eCurrentlyPlaying;                             // we're still playing

            return m_State;
        }
        #endregion

        #region private void UpdateCounters(int nWars)
        private void UpdateCounters(int nWars)
        {
            m_Counters.nTurns++;
            m_Counters.nTotalWars += nWars;
            if (nWars == 1) m_Counters.nSingleWars++;
            else if (nWars == 2) m_Counters.nDoubleWars++;
            else if (nWars == 3) m_Counters.nTripleWars++;
            else if (nWars == 4) m_Counters.nQuadrupleWars++;
            else if (nWars == 5) m_Counters.nQuintupleWars++;
            else if (nWars == 6) m_Counters.nSextupleWars++;
            else if (nWars == 7) m_Counters.nSeptupleWars++;
        }
        #endregion

        #region private int ThrowDown(List<int> Players, ref int recursionCount)
        /// <summary>
        /// Throw Down!
        /// </summary>
        /// <param name="Players">List of players that are about to throw down.</param>
        /// <param name="recursionCount">A counter, to count how many times we recure (keeps track of the number of wars!)</param>
        /// <returns>Returns the index to the winning player.</returns>
        private int ThrowDown(List<int> Players, ref int recursionCount)
        {
            foreach (int iPlayer in Players)
            {   // all players required to throw a card down throws.
                m_ThrownCards[iPlayer].AddToBottom(m_Players[iPlayer].DrawFromTop());
            }

            // find the max card, and the players that have it:
            List<int> winningPlayers = new List<int>();
            int winningRank = 0;
            foreach (int iPlayer in Players)
            {
                int rank = (int)m_ThrownCards[iPlayer][m_ThrownCards[iPlayer].Count - 1].rank;
                if (rank > winningRank)
                {
                    winningPlayers.Clear();
                    winningPlayers.Add(iPlayer);
                    winningRank = rank;
                }
                else if (rank == winningRank) winningPlayers.Add(iPlayer);
            }

            if (winningPlayers.Count == 1) return winningPlayers[0];    // the turn is over! return the winner!
            else
            {   // we have a war!
                // all the winning players need to throw down an additional 3 cards - if they have them, before recursing.
                List<int> PlayersReadyToThrowDown = new List<int>();
                foreach(int iPlayer in winningPlayers)
                {
                    int nCardsToThrow = m_Players[iPlayer].Count;

                    if (nCardsToThrow == 0)
                    {   // if it doesn't have any more cards left to throw, 
                        continue;
                    }
                    else PlayersReadyToThrowDown.Add(iPlayer);

                    if (nCardsToThrow > 4) nCardsToThrow = 4;
                    for (int j = 0; j < nCardsToThrow - 1; j++) m_ThrownCards[iPlayer].AddToBottom(m_Players[iPlayer].DrawFromTop());
                }

                if (PlayersReadyToThrowDown.Count == 0)
                {   // we have a tie...
                    // in this case we should split the winnings to the original winners...
                    Players.Clear();
                    Players.AddRange(winningPlayers);
                    return -1;  // return -1 meaning there is no winner.
                }
                else if (PlayersReadyToThrowDown.Count == 1)
                {   // there is only one player ready, they're the winner!!
                    return PlayersReadyToThrowDown[0];    
                }
                else    // if(PlayersReadyToThrowDown.Count > 1)
                {   // okay, let's throw down again, this time with our new winners
                    recursionCount++;
                    return ThrowDown(PlayersReadyToThrowDown, ref recursionCount);
                }
            }
        }
        #endregion

        #region public string Deck
        /// <summary>
        /// Gets the Deck.ToString()
        /// </summary>
        public string Deck { get { return m_Deck.ToString(); } }
        #endregion

        #region public string GetPlayer(int iHand)
        /// <summary>
        /// Gets Players.ToString()
        /// </summary>
        /// <param name="iHand">The Player index.</param>
        public string GetPlayer(int iHand) { return m_Players[iHand].ToString(); }
        #endregion

        #region public kbCardHand MostRecentlyWonCards
        /// <summary>
        /// Gets a copy of the most recently won cards.
        /// </summary>
        public kbCardHand MostRecentlyWonCards
        {
            get
            {
                kbCardHand newHand = new kbCardHand(m_Rand);
                for (int i = 0; i < m_MostRecentlyWonCards.Count; i++) newHand.AddToBottom(m_MostRecentlyWonCards[i]);
                return newHand;
            }
        }
        #endregion

        #region public int WinnerOfLastTurn
        /// <summary>
        /// Gets the index to the player who won the last turn.  
        ///   -2 means there hasn't been a turn yet. 
        ///   -1 means the last turn had no winner
        /// </summary>
        public int WinnerOfLastTurn
        {
            get { return m_iMostRecentWinner; }
        }
        #endregion

        #region public int nPlayers
        /// <summary>
        /// Gets the number of players in the Game
        /// </summary>
        public int nPlayers { get { return m_Players.Length; } }
        #endregion

    }
    #endregion
}
