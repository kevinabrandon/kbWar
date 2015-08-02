using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kbWar
{
    #region public class kbPlayingCard
    /// <summary>
    /// Simulates a playing card.
    /// 
    /// This class is immutable.
    /// </summary>
    public class kbPlayingCard
    {
        #region public enum Suit and Rank
        public enum Suit { Hearts, Clubs, Dimonds, Spades };
        public enum Rank
        {
            Deuce = 2,
            Trey = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        };
        #endregion

        #region private member vars...
        private Suit m_Suit = new Suit();
        private Rank m_Rank = new Rank();
        #endregion

        #region constructor....
        public kbPlayingCard(Suit s, Rank r)
        {
            m_Suit = s;
            m_Rank = r;
        }
        #endregion

        #region public properties...
        public Suit suit { get { return m_Suit; } }
        public Rank rank { get { return m_Rank; } }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("{0,5} of {1,-7}", rank, suit);
        }
        #endregion
    }
    #endregion

    #region public class kbCardHand
    /// <summary>
    /// Simulates a card hand.
    /// </summary>
    public class kbCardHand
    {
        #region private member vars...
        protected List<kbPlayingCard> m_Cards = new List<kbPlayingCard>();    // the list of cards in the hand.
        protected Random m_Rand = null;                           // used for shuffeling
        protected object m_Lock = new object();                           // used to make the object thread safe
        #endregion

        #region public constructors...
        /// <summary>
        /// Creates an empty hand.
        ///     Uses it's own random number generator.
        /// </summary>
        public kbCardHand() { m_Rand = new Random(); }

        /// <summary>
        /// Creates an empty hand.
        ///     Uses an external random number generator.
        /// </summary>
        /// <param name="r">Random number generator</param>
        public kbCardHand(Random r) { m_Rand = r; }

        #endregion

        #region public Count property
        /// <summary>
        /// Gets the number of cards in the hand
        /// </summary>
        public int Count { get { lock (m_Lock) return m_Cards.Count; } }
        #endregion

        #region public Clear()
        /// <summary>
        /// Removes all the cards from the hand
        /// </summary>
        public void Clear()
        {
            lock (m_Lock) m_Cards.Clear();
        }
        #endregion

        #region public add card routine...

        #region AddToBottom()
        /// <summary>
        /// Adds card to the bottom of the hand
        /// </summary>
        public void AddToBottom(kbPlayingCard pc)
        {
            lock (m_Lock) m_Cards.Add(pc);
        }
        #endregion

        #region AddToTop()
        /// <summary>
        /// Adds card to the top of the hand.
        /// </summary>
        public void AddToTop(kbPlayingCard pc)
        {
            lock (m_Lock) m_Cards.Insert(0, pc);
        }
        #endregion

        #region AddTo()
        /// <summary>
        /// Adds card to the hand
        /// </summary>
        /// <param name="pc">Card to Add</param>
        /// <param name="index">Index location where to add the card.</param>
        public void AddTo(kbPlayingCard pc, int index)
        {
            lock (m_Lock) m_Cards.Insert(index, pc);
        }
        #endregion
            
        #endregion

        #region public draw card routines...

        #region DrawFromBottom()
        /// <summary>
        /// Draws a card from the bottom of the hand
        /// </summary>
        public kbPlayingCard DrawFromBottom()
        {
            lock (m_Lock)
            {
                kbPlayingCard pc = m_Cards.Last();
                m_Cards.RemoveAt(m_Cards.Count - 1);
                return pc;
            }
        }
        #endregion

        #region DrawFromTop()
        /// <summary>
        /// Draws a card from the top of the hand
        /// </summary>
        public kbPlayingCard DrawFromTop()
        {
            lock (m_Lock)
            {
                kbPlayingCard pc = m_Cards.First();
                m_Cards.RemoveAt(0);
                return pc;
            }
        }
        #endregion

        #region DrawFrom()
        /// <summary>
        /// Draws a card from the hand
        /// </summary>
        /// <param name="index">The index location where to draw the card from</param>
        public kbPlayingCard DrawFrom(int index)
        {
            lock (m_Lock)
            {
                kbPlayingCard pc = m_Cards[index];
                m_Cards.RemoveAt(index);
                return pc;
            }
        }
        #endregion

        #endregion

        #region public Contains()
        /// <summary>
        /// Check to see if hand contains a certain card
        /// </summary>
        public bool Contains(kbPlayingCard pc)
        {
            lock (m_Lock) return m_Cards.Any(w => w.suit == pc.suit && w.rank == pc.rank);
        }
        #endregion

        #region public GetIndexOf()
        /// <summary>
        /// Gets the index of a particular card.  Returns -1 if the card isn't in the deck.
        /// </summary>
        public int GetIndexOf(kbPlayingCard pc)
        {
            lock (m_Lock) return m_Cards.FindIndex(w => w.suit == pc.suit && w.rank == pc.rank);
        }
        #endregion

        #region public indexer (get only)
        /// <summary>
        /// Indexer with get only access.
        /// Index zero is the top of the deck.  The last item in the index is the bottom of the deck.
        /// </summary>
        public kbPlayingCard this[int i]
        {
            get { lock (m_Lock)  return m_Cards[i]; }
        }
        #endregion

        #region public Shuffle()
        /// <summary>
        /// Shuffles the hand, by going through the cards one by one and swapping it with a random location
        /// </summary>
        public void Shuffle()
        {
            lock (m_Lock)
            {
                int nCardsInDeck = m_Cards.Count;
                for (int i = 0; i < nCardsInDeck; i++)
                {
                    int iSwap = (int)(m_Rand.NextDouble() * nCardsInDeck);

                    kbPlayingCard swap = m_Cards[i];
                    m_Cards[i] = m_Cards[iSwap];
                    m_Cards[iSwap] = swap;
                }
            }
        }
        #endregion

        #region public ToString()
        public override string ToString()
        {
            lock (m_Lock)
            {
                StringBuilder sb = new StringBuilder();
                foreach (kbPlayingCard pc in m_Cards)
                {
                    sb.AppendLine(pc.ToString());
                }
                return sb.ToString();
            }
        }
        #endregion
    }
    #endregion

    #region public class kbCardDeck
    /// <summary>
    /// This is a card hand that starts out as a new 52 card deck.
    /// </summary>
    public class kbCardDeck : kbCardHand
    {
        #region Constructors...
        /// <summary>
        /// Creates a new ordered 52-card deck.
        ///    Uses an external random number generator.
        /// </summary>
        /// <param name="r"></param>
        public kbCardDeck(Random r) : base(r)
        {
            CreateNew52CardDeck();
        }

        /// <summary>
        /// Creats a new ordered 52-card deck.
        ///    Uses it's own internal random number generator.
        /// </summary>
        public kbCardDeck() : base()
        {
            CreateNew52CardDeck();
        }
        #endregion

        #region public CreateNew52CardDeck()
        /// <summary>
        /// Creates a new 52-card ordered deck if true, and empty deck if false.
        /// If true the the order is A->K Hearts, A->K Clubs, K->A Dimonds, K->A Spades.  
        ///      So Ace of Hearts is on top, and Ace of Spades is on bottom.
        ///      (this is the order of a new deck of Bicycle brand cards)
        /// </summary>
        private void CreateNew52CardDeck()
        {
            lock (m_Lock)
            {
                m_Cards.Clear();
                foreach (kbPlayingCard.Suit s in Enum.GetValues(typeof(kbPlayingCard.Suit)))
                {
                    if (s == kbPlayingCard.Suit.Hearts || s == kbPlayingCard.Suit.Clubs)
                    {
                        m_Cards.Add(new kbPlayingCard(s, kbPlayingCard.Rank.Ace));
                        for (int iVal = 2; iVal < 14; iVal++)
                        {
                            m_Cards.Add(new kbPlayingCard(s, (kbPlayingCard.Rank)iVal));
                        }
                    }
                    else
                    {
                        for (int iVal = 13; iVal >= 2; iVal--)
                        {
                            m_Cards.Add(new kbPlayingCard(s, (kbPlayingCard.Rank)iVal));
                        }
                        m_Cards.Add(new kbPlayingCard(s, kbPlayingCard.Rank.Ace));
                    }
                }
            }
        }
        #endregion
    }
    #endregion
}
