using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kbWar
{
    /// <summary>
    /// Simulates a single game of war.  
    /// When the game is over, the game is over.  No restarting.  
    /// If you need to restart, create another game.
    /// 
    /// *** Allows for a variable number of players! ***
    /// </summary>
    class kbWarGame
    {
        #region public enum GameState
        public enum GameState { eNotStarted, eCurrentlyPlaying, eInfiniteLoop, eOverWithWinner }
        #endregion

        #region struct GameCounters
        public struct GameCounters
        {
            public int nTurns;
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

        private GameState m_State = GameState.eNotStarted;

        private kbCardDeck m_Deck;
        private kbCardHand[] m_Hands;
        private kbCardHand m_MiddlePile;

        private GameCounters m_Counters = new GameCounters();

        private bool m_bShuffleMiddlePile = true;

        #endregion

        #region constructors...
        /// <summary>
        /// Creates a new game of war for two players.
        /// </summary>
        public kbWarGame() : this(2, new Random())  {   }

        /// <summary>
        /// Creates a new game of war for two players.
        /// </summary>
        /// <param name="r">An external random number generator</param>
        public kbWarGame(Random r) : this(2, r)     {   }

        /// <summary>
        /// Creates a new game of war.
        /// </summary>
        /// <param name="nPlayers">The number of players.</param>
        public kbWarGame(int nPlayers) : this(nPlayers, new Random())   {  }

        /// <summary>
        /// Creats a new game of war.
        /// </summary>
        /// <param name="nPlayers">The number of players</param>
        /// <param name="r">An external random number generator.</param>
        public kbWarGame(int nPlayers, Random r)
        {
            m_Deck = new kbCardDeck(r);
            m_Hands = new kbCardHand[nPlayers];
            for(int i = 0; i < nPlayers; i++) m_Hands[i] = new kbCardHand(r);
            m_MiddlePile = new kbCardHand(r);
        }
        #endregion

        #region public bool ShuffleMiddlePile
        /// <summary>
        /// Gets or sets the flag to shuffle the middle pile between turns.
        ///     The default value is true.
        /// </summary>
        public bool ShuffleMiddlePile
        {
            get { return m_bShuffleMiddlePile; }
            set { m_bShuffleMiddlePile = value; }
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
                for (int i = 0; i < m_Hands.Length; i++)
                {
                    if (m_Hands[i].Count == 52) return i;
                }
                return -1;
            }
        }
        #endregion

        #region public GameCounters Counters
        /// <summary>
        /// Gets the game counters.
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

        #region public void ShuffleHands()
        /// <summary>
        /// Shuffles all the players hands
        /// </summary>
        public void ShuffleHands()
        {
            foreach(kbCardHand hand in m_Hands) hand.Shuffle();
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
                int iPlayer = count % m_Hands.Length;
                m_Hands[iPlayer].AddToTop(m_Deck.DrawFromTop());
                count++;
            }
            m_State = GameState.eCurrentlyPlaying;
        }
        #endregion
        
        public GameState NewTurn()
        {
            if (m_State != GameState.eCurrentlyPlaying) return m_State;

            // make recursive call to throw!

            // move cards from pile to winning hand.

            // adjust the game state and return it.

            return m_State;
        }
    }
}
