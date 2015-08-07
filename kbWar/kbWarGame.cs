using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kbWar
{
    #region kbCardGameWar
    /// <summary>
    /// Simulates a game of war.  
    /// 
    /// Allows between 2 and 52 players.
    /// </summary>
    class kbCardGameWar
    {
        #region public enum GameState
        public enum GameState { eNotStarted, eCurrentlyPlaying, eInfiniteLoop, eOverWithWinner }
        #endregion

        #region public const int MaxNumberOfPlayers
        /// <summary>
        /// The maximun number of players allowed.  52 cards... each player will start with exactly one card.
        /// </summary>
        public const int MaxNumberOfPlayers = 52;
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
        private List<int> m_MostRecentWinners;          // a list of the most recent winners.

        private GameCounters m_Counters;                // Counters used to keep track of the game.

        private bool m_bShuffleRecentlyWonCards = true; // flag to see if we should shuffle the most recently won cards.

        private Random m_Rand;                          // The random number generator used for shuffling.

        private List<kbCardHand[]> m_PreviousTurns;     // a list of hands from previous turns... used for infinite loop checks.

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
            if (nPlayers < 2 || nPlayers > MaxNumberOfPlayers) throw new Exception(nPlayers.ToString() + " Players!  Number of players must be between 2 and " + MaxNumberOfPlayers + ".");
            m_Deck = new kb52CardDeck(m_Rand);
            m_Players = new kbCardHand[nPlayers];
            m_ThrownCards = new kbCardHand[nPlayers];
            m_PreviousTurns = new List<kbCardHand[]>();
            for (int i = 0; i < nPlayers; i++)
            {
                m_Players[i] = new kbCardHand(m_Rand);
                m_ThrownCards[i] = new kbCardHand(m_Rand);
            }
            m_MostRecentlyWonCards = new kb52CardDeck(m_Rand);
            m_MostRecentWinners = new List<int>();
            
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
        /// It plays one turn of the game.  Forces all players with cards to throw down.
        /// </summary>
        /// <returns>Returns the game state.</returns>
        public GameState NewTurn()
        {
            if (m_State == GameState.eNotStarted)
            {   // maybe we should just return the game state
                // naw... let's start the game by shuffling and dealing
                ShuffleDeck();
                Deal();
            }
            if (m_State == GameState.eInfiniteLoop || m_State == GameState.eOverWithWinner) return m_State;

            // get a list of players that still have cards...
            List<int> players = new List<int>();
            for (int iPlayer = 0; iPlayer < m_Players.Length; iPlayer++) if (m_Players[iPlayer].Count > 0) players.Add(iPlayer);

            // all active players need to throw down!
            int nWars = 0;
            m_MostRecentWinners = ThrowDown(players, ref nWars);

            // add all the cards thrown into recently won hand
            m_MostRecentlyWonCards.Clear();
            foreach( var cards in m_ThrownCards) 
            {
                while (cards.Count > 0) m_MostRecentlyWonCards.AddToBottom(cards.DrawFromBottom());
            }
            
            // if we need to, shuffle the winning cards.
            if (m_bShuffleRecentlyWonCards) m_MostRecentlyWonCards.Shuffle();

            // deal out cards to the winner/winners
            for (int iCard = 0; iCard < m_MostRecentlyWonCards.Count; iCard++)
            {
                m_Players[m_MostRecentWinners[iCard % m_MostRecentWinners.Count]].AddToBottom(m_MostRecentlyWonCards[iCard]);
            }
            
            // update counters:
            UpdateCounters(nWars, m_MostRecentWinners);

            if (!m_bShuffleRecentlyWonCards)
            {   // if we aren't shuffling our recently won cards
                // then lets check to see if we've been here before
                // if we have, then it's an infinte loop
                if (HaveWeBeenHereBefore())
                {
                    m_State = GameState.eInfiniteLoop;
                    return m_State;
                }
            }

            // adjust the game state and return it.
            if (this.Winner >= 0) m_State = GameState.eOverWithWinner;              // do we have a winner?
            else if (m_Counters.nTurns > 20000) m_State = GameState.eInfiniteLoop; // do we have an infinite loop?
            else m_State = GameState.eCurrentlyPlaying;                             // we're still playing

            return m_State;
        }
        #endregion

        #region private bool HaveWeBeenHereBefore()
        /// <summary>
        /// Have we been here before?
        /// </summary>
        /// <returns>Returns true if we've seen this hand before</returns>
        private bool HaveWeBeenHereBefore()
        {
            // make a copy of the current turn
            kbCardHand[] currentTurn = new kbCardHand[nPlayers];
            for (int iPlayer = 0; iPlayer < nPlayers; iPlayer++)
            {
                currentTurn[iPlayer] = new kbCardHand();

                for (int iCard = 0; iCard < m_Players[iPlayer].Count; iCard++)
                {
                    currentTurn[iPlayer].AddToBottom(m_Players[iPlayer][iCard]);
                }
            }

            // check the current turn against the turn exactly 52 before us.
            bool bSeenBefore = false;
            if (m_PreviousTurns.Count == 52)
            {   
                bSeenBefore = true;
                for (int iPlayer = 0; iPlayer < nPlayers; iPlayer++)
                {
                    if (!m_PreviousTurns[0][iPlayer].SameHand(currentTurn[iPlayer]))
                    {
                        bSeenBefore = false;
                        break;
                    }
                }
            }

            // add the current turn to our list
            m_PreviousTurns.Add(currentTurn);

            // keep the list to only the previous 52 turns.
            if (m_PreviousTurns.Count > 52) m_PreviousTurns.RemoveAt(0);

            return bSeenBefore;
        }
        #endregion

        #region private void UpdateCounters(int nWars, List<int> players)
        private void UpdateCounters(int nWars, List<int> players)
        {
            m_Counters.nTurns++;
            if (players.Count > 1) m_Counters.nTies++;
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

        #region private List<int> ThrowDown(List<int> Players, ref int recursionCount)
        /// <summary>
        /// Throw Down!
        /// </summary>
        /// <param name="players">List of players that are about to throw down.  The winners are returned here.</param>
        /// <param name="recursionCount">A counter, to count how many times we recure (keeps track of the number of wars!)</param>
        /// <returns>Returns a list of the winning players.</returns>
        private List<int> ThrowDown(List<int> players, ref int recursionCount)
        {
            foreach (int iPlayer in players)
            {   // all players required to throw a card down throws.
                m_ThrownCards[iPlayer].AddToBottom(m_Players[iPlayer].DrawFromTop());
            }

            // find the max card, and the players that have it:
            List<int> winningPlayers = new List<int>();
            int winningRank = 0;
            foreach (int iPlayer in players)
            {   // get the rank of the most recently thrown card for the player
                int rank = (int)m_ThrownCards[iPlayer][m_ThrownCards[iPlayer].Count - 1].rank;  
                if (rank > winningRank)
                {   // if the rank is higher than the current wining rank, then it's a winner, and the current winners are not
                    winningRank = rank;
                    winningPlayers.Clear();
                    winningPlayers.Add(iPlayer);
                }
                else if (rank == winningRank) winningPlayers.Add(iPlayer);  // if it has the same rank as the current winners, then it's a winner too
            }

            if (winningPlayers.Count == 1)
            {   // we have a winner! 
                return winningPlayers;
            }
            else
            {   // we have multiple players with the highest card!
                // THIS MEANS WAR!!!
                // all the winning players need to throw down an additional 3 cards - if they have them, before recursing to ThrowDown their final card.
                List<int> PlayersReadyToThrowDown = new List<int>();
                foreach (int iPlayer in winningPlayers)
                {
                    int nCardsToThrow = m_Players[iPlayer].Count;

                    if (nCardsToThrow == 0)
                    {   // if it doesn't have any more cards left to throw, 
                        // then it's not ready to throw down... don't add
                        // it to the list, just continue;
                        continue;
                    }
                    else PlayersReadyToThrowDown.Add(iPlayer);

                    // if they have more than four to throw cap it at 4
                    if (nCardsToThrow > 4) nCardsToThrow = 4;
                    
                    // throw all the cards but one to their own piles.... the last one will be thrown when we recure.
                    for (int j = 0; j < nCardsToThrow - 1; j++) m_ThrownCards[iPlayer].AddToBottom(m_Players[iPlayer].DrawFromTop());
                }

                if (PlayersReadyToThrowDown.Count == 0)
                {   // we have a very rare TIE...
                    // we will return the winning players as winners
                    // so that they can split up the cards.
                    return winningPlayers;
                }
                else if (PlayersReadyToThrowDown.Count == 1)
                {   // there is only one player ready, they're the winner!!
                    return PlayersReadyToThrowDown;
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

        #region public List<int> MostRecentWinners
        /// <summary>
        /// Gets a list of the most recent winners.
        /// </summary>
        public List<int> MostRecentWinners
        {
            get { return m_MostRecentWinners.ToList(); }
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
