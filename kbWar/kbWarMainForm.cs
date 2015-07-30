using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace kbWar
{
    #region public partial class kbWarMainForm : Form
    public partial class kbWarMainForm : Form
    {
        #region private member vars...
        
        private kbCardHand m_Deck = new kbCardHand();
        private kbCardHand m_Hand1 = new kbCardHand();      // player one's hand  
        private kbCardHand m_Hand2 = new kbCardHand();      // player two's hand
        private kbCardHand m_MiddlePile = new kbCardHand(); // the pile of cards in the middle during wars!

        private kbCardHand m_LastWinnings = new kbCardHand();
        private bool m_bLastWinner = false;

        private object m_Lock = new object();           

        // stuff for keeping track:
        private int m_nThrows = 0;
        private int m_nTotalWars = 0;
        private int m_nSingleWars = 0;
        private int m_nDoubleWars = 0;
        private int m_nTripleWars = 0;
        private int m_nQuadWars = 0;
        private int m_nFiveWars = 0;
        private int m_nSixWars = 0;
        private int m_nSevenWars = 0;

        #endregion

        #region construction...
        public kbWarMainForm()
        {
            InitializeComponent();

            Restart();
            UpdateUI();
            UpdateCountsUI();
            textBoxOutput.Clear();
        }
        #endregion

        #region UpdateUI()
        private void UpdateUI()
        {
            lock (m_Lock)
            {
                richTextBoxDeck.Text = m_Deck.ToString();
                richTextBoxPlayer1.Text = m_Hand1.ToString();
                richTextBoxPlayer2.Text = m_Hand2.ToString();
                if (m_LastWinnings.Count > 0)
                {
                    string winner;
                    if (m_bLastWinner) winner = "Player One Won:\n\n";
                    else winner = "Player Two Won:\n\n";
                    richTextBoxPot.Clear();
                    richTextBoxPot.AppendText(winner);
                    richTextBoxPot.AppendText(m_LastWinnings.ToString());

                    if (m_Hand1.Count == 0) richTextBoxPot.AppendText("\nPLAYER TWO WINS!!!");
                    if (m_Hand2.Count == 0) richTextBoxPot.AppendText("\nPLAYER ONE WINS!!!");
                    ColorTextBoxeSelection(richTextBoxPot, "Player One Won:", Color.White, Color.Red);
                    ColorTextBoxeSelection(richTextBoxPot, "Player Two Won:", Color.White, Color.Blue);
                    ColorTextBoxeSelection(richTextBoxPot, "PLAYER ONE WINS!!!", Color.White, Color.Red);
                    ColorTextBoxeSelection(richTextBoxPot, "PLAYER TWO WINS!!!", Color.White, Color.Blue);
                    ColorTextBoxeSelection(richTextBoxPot, "Ace", Color.Red, Color.GreenYellow);
                    ColorTextBoxeSelection(richTextBoxPot, "Hearts", Color.White, Color.Red);
                    ColorTextBoxeSelection(richTextBoxPot, "Dimonds", Color.White, Color.Red);
                    ColorTextBoxeSelection(richTextBoxPot, "Spades", Color.White, Color.Black);
                    ColorTextBoxeSelection(richTextBoxPot, "Clubs", Color.White, Color.Black);
                }
                else richTextBoxPot.Clear();
                
                ColorTextBoxeSelection(richTextBoxDeck, "Ace", Color.Red, Color.GreenYellow);
                ColorTextBoxeSelection(richTextBoxPlayer1, "Ace", Color.Red, Color.GreenYellow);
                ColorTextBoxeSelection(richTextBoxPlayer2, "Ace", Color.Red, Color.GreenYellow);
                

                ColorTextBoxeSelection(richTextBoxDeck, "Hearts", Color.White, Color.Red);
                ColorTextBoxeSelection(richTextBoxPlayer1, "Hearts", Color.White, Color.Red);
                ColorTextBoxeSelection(richTextBoxPlayer2, "Hearts", Color.White, Color.Red);
                

                ColorTextBoxeSelection(richTextBoxDeck, "Dimonds", Color.White, Color.Red);
                ColorTextBoxeSelection(richTextBoxPlayer1, "Dimonds", Color.White, Color.Red);
                ColorTextBoxeSelection(richTextBoxPlayer2, "Dimonds", Color.White, Color.Red);
                

                ColorTextBoxeSelection(richTextBoxDeck, "Spades", Color.White, Color.Black);
                ColorTextBoxeSelection(richTextBoxPlayer1, "Spades", Color.White, Color.Black);
                ColorTextBoxeSelection(richTextBoxPlayer2, "Spades", Color.White, Color.Black);
                

                ColorTextBoxeSelection(richTextBoxDeck, "Clubs", Color.White, Color.Black);
                ColorTextBoxeSelection(richTextBoxPlayer1, "Clubs", Color.White, Color.Black);
                ColorTextBoxeSelection(richTextBoxPlayer2, "Clubs", Color.White, Color.Black);       
            }
        }
        #endregion

        #region UpdateCountsUI()
        private void UpdateCountsUI()
        {
            lock(m_Lock)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("# of Throws:   {0,5}", m_nThrows.ToString("N0")));
                sb.AppendLine(String.Format("Total Wars:    {0,5}", m_nTotalWars.ToString("N0")));
                sb.AppendLine(String.Format("Single Wars:   {0,5}", m_nSingleWars.ToString("N0")));
                sb.AppendLine(String.Format("Double Wars:   {0,5}", m_nDoubleWars.ToString("N0")));
                sb.AppendLine(String.Format("Triple Wars:   {0,5}", m_nTripleWars.ToString("N0")));
                sb.AppendLine(String.Format("Quad Wars:     {0,5}", m_nQuadWars.ToString("N0")));
                sb.AppendLine(String.Format("Quintuple Wars:{0,5}", m_nFiveWars.ToString("N0")));
                sb.AppendLine(String.Format("Sextuple Wars: {0,5}", m_nSixWars.ToString("N0")));
                textBoxCounts.Text = sb.ToString();
            }
        }
        #endregion

        #region ColorTextBoxeSelection()
        /// <summary>
        /// This is mostly a copy and paste of a bit I found online (probably stack exchange)
        /// </summary>
        private void ColorTextBoxeSelection(RichTextBox textBox, string s, Color textColor, Color backColor)
        {
            int start = 0, current = 0;
            RichTextBoxFinds options = RichTextBoxFinds.MatchCase;
            start = textBox.Find(s, start, options);
            while (start >= 0)
            {
                textBox.SelectionStart = start;
                textBox.SelectionLength = s.Length;
                textBox.SelectionColor = textColor;
                textBox.SelectionBackColor = backColor;

                current = start + s.Length;
                if (current < textBox.TextLength)
                    start = textBox.Find(s, current, options);
                else
                    break;
            }
        }
        #endregion

        #region Shuffle()
        /// <summary>
        /// Shuffles everything, the deck and the player's hands.
        /// </summary>
        private void Shuffle()
        {
            lock (m_Lock)
            {
                m_Deck.Shuffle();
                m_Hand1.Shuffle();
                m_Hand2.Shuffle();
            }
        }
        #endregion

        #region Restart()
        /// <summary>
        /// Clears the two hands, and resets the deck.
        ///   also clears the counters.
        /// </summary>
        void Restart()
        {
            lock (m_Lock)
            {
                m_Deck.CreateNew52CardDeck();
                m_Hand1.Clear();
                m_Hand2.Clear();
                m_LastWinnings.Clear();
                m_nThrows = 0;
                m_nTotalWars = 0;
                m_nSingleWars = 0;
                m_nDoubleWars = 0;
                m_nTripleWars = 0;
                m_nQuadWars = 0;
                m_nFiveWars = 0;
                m_nSixWars = 0;
                m_nSevenWars = 0;
            }
        }
        #endregion

        #region Deal()
        /// <summary>
        /// Simply deals the cards out, taking the cards from the top of the deck, 
        /// and putting them on top of the player's hands.  It alternating between 
        /// the players, player one gets the first card.  It deals out cards till 
        /// the deck is empty.
        /// </summary>
        private void Deal()
        {
            lock (m_Lock)
            {
                bool bHand1 = true;
                while (m_Deck.Count > 0)
                {
                    if (bHand1) m_Hand1.AddToTop(m_Deck.DrawFromTop());
                    else m_Hand2.AddToTop(m_Deck.DrawFromTop());
                    bHand1 = !bHand1;
                }
            }
        }
        #endregion

        #region Throw()
        private void Throw()
        {
            lock (m_Lock)
            {
                // setup stuff for call to the recursive throw function
                int nWars = 0;
                m_MiddlePile.Clear();   // should be clear already... but what the heck.

                // throw down!!!
                bool bPlayer1Wins = ThrowReal(ref nWars);

                // shuffle the middle pile of cards, if you want
                if (checkBoxShuffleResult.Checked) m_MiddlePile.Shuffle();

                // add last winnings:
                m_LastWinnings.Clear();
                for (int i = 0; i < m_MiddlePile.Count; i++) m_LastWinnings.AddToBottom(m_MiddlePile[i]);
                m_bLastWinner = bPlayer1Wins;

                if (bPlayer1Wins)
                {   // player one wins... add the cards to his hand
                    while (m_MiddlePile.Count > 0) m_Hand1.AddToBottom(m_MiddlePile.DrawFromBottom());
                }
                else
                {   // player two wins... add the cards to his hand
                    while (m_MiddlePile.Count > 0) m_Hand2.AddToBottom(m_MiddlePile.DrawFromBottom());
                }

                // keep track of stuff...
                m_nThrows++;
                m_nTotalWars += nWars;
                if (nWars == 1)      m_nSingleWars++;
                else if (nWars == 2) m_nDoubleWars++;
                else if (nWars == 3) m_nTripleWars++;
                else if (nWars == 4) m_nQuadWars++;
                else if (nWars == 5) m_nFiveWars++;
                else if (nWars == 6) m_nSixWars++;
                else if (nWars == 7) m_nSevenWars++;
            }

            if (checkBoxShuffleAll.Checked)
            {
                Shuffle();
            }
        }
        #endregion

        #region ThrowReal()
        /// <summary>
        /// Returns true if player 1 wins, false if player 1 looses
        /// </summary>
        /// <param name="recursionCount">A counter, to count how many times we recure (keeps track of the number of wars!)</param>
        /// <returns>Returns True if Player one wins, False if Player one looses.</returns>
        private bool ThrowReal(ref int recursionCount)
        {
            // if both hands are empty, then there is no winner... lets throw an exception:
            if (m_Hand1.Count == 0 && m_Hand2.Count == 0) throw new Exception("No cards to throw!  no winner!");
            
            if (m_Hand1.Count == 0) return false;   // player one has no cards and looses
            if (m_Hand2.Count == 0) return true;    // player two has no cards and player one wins

            // both players draw one card from the top
            kbPlayingCard card1 = m_Hand1.DrawFromTop();
            kbPlayingCard card2 = m_Hand2.DrawFromTop();
            
            // add their cards to the middle pile of cards
            m_MiddlePile.AddToBottom(card1);
            m_MiddlePile.AddToBottom(card2);

            if (card1.rank > card2.rank)
            {   // player one wins!  return true!
                return true;
            }
            else if (card1.rank < card2.rank)
            {   // player one looses!  return false!
                return false;
            }
            else
            {   // tie... this means... WAR!!!!
                
                // player one has no more cards, and can't war, player one looses!
                if (m_Hand1.Count == 0) return false;

                // player two has no more cards, and can't war, player one wins!
                if (m_Hand2.Count == 0) return true;

                // players must add 3 more cards to the thrown pile, then they must throw a 4th
                // if they don't have enough to do that, they need to throw as many as they can
                // before throwing their last card.

                // player one adding their three cards
                int nCardsToAdd = 4;
                if (m_Hand1.Count < 4) nCardsToAdd = m_Hand1.Count;
                for (int i = 0; i < nCardsToAdd - 1; i++) m_MiddlePile.AddToBottom(m_Hand1.DrawFromTop());

                // player two adding their three cards
                nCardsToAdd = 4;
                if (m_Hand2.Count < 4) nCardsToAdd = m_Hand2.Count;
                for (int i = 0; i < nCardsToAdd - 1; i++) m_MiddlePile.AddToBottom(m_Hand2.DrawFromTop());

                // we're going to recure... 
                recursionCount++;
                return ThrowReal(ref recursionCount);
            }
        }
        #endregion

        #region Button clicks...

        #region shuffle clicked
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Shuffle();
            UpdateUI();
        }
        #endregion

        #region restart clicked
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Restart();
            UpdateUI();
            UpdateCountsUI();
        }
        #endregion

        #region deal clicked
        private void buttonDeal_Click(object sender, EventArgs e)
        {
            if (m_Deck.Count == 0)
            {
                Restart();
                Shuffle();
            }
            Deal();
            UpdateUI();
            UpdateCountsUI();
        }
        #endregion

        #region throw clicked
        private void buttonThrow_Click(object sender, EventArgs e)
        {
            lock (m_Lock)
            {
                if (m_Hand1.Count == 0 || m_Hand2.Count == 0)
                {
                    MessageBox.Show("You need to make sure both players have cards.  Try dealing first.");
                    return;
                }
            }

            Throw();
            UpdateUI();
            UpdateCountsUI();
            if (m_Hand1.Count == 0) MessageBox.Show("Player 2 WINS!!! " + m_nThrows);
            if (m_Hand2.Count == 0) MessageBox.Show("Player 1 WINS!!! " + m_nThrows);
        }
        #endregion

        #region auto-throw clicked
        private void buttonAutoThrow_Clicked(object sender, EventArgs e)
        {
            if (!workerManyGames.IsBusy && !workerAutoThrow.IsBusy)
            {
                EnableUI(false);
                workerAutoThrow.RunWorkerAsync();
            }
            else MessageBox.Show("Auto run already running!");
        }
        #endregion

        #region run many games clicked
        private void buttonRunManyGames_Clicked(object sender, EventArgs e)
        {
            if (!workerManyGames.IsBusy && !workerAutoThrow.IsBusy)
            {
                EnableUI(false);
                workerManyGames.RunWorkerAsync();
            }
            else MessageBox.Show("Auto run already running!");

        }
        #endregion

        #region cancel clicked
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (workerAutoThrow.IsBusy) workerAutoThrow.CancelAsync();
            if (workerManyGames.IsBusy) workerManyGames.CancelAsync();
        }
        #endregion

        #region clear output clicked
        private void buttonClearOutput_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
        }
        #endregion

        #endregion

        #region EnableUI()
        private void EnableUI(bool bEnable)
        {
            foreach (Control c in splitContainer2.Panel1.Controls)
            {
                c.Enabled = bEnable;
            }
            buttonCancel.Enabled = !bEnable;
        }
        #endregion

        #region private class BackgroundWorkerOutput
        private class BackgroundWorkerOutput
        {
            public List<int> nThrowsList = new List<int>();
            public List<int> nTotalWarsList = new List<int>();
            public List<int> nSingleWarsList = new List<int>();
            public List<int> nDoubleWarsList = new List<int>();
            public List<int> nTripleWarsList = new List<int>();
            public List<int> nQuadWarsList = new List<int>();
            public List<int> nFiveWarsList = new List<int>();
            public List<int> nSixWarsList = new List<int>();
            public List<int> nSevenWarsList = new List<int>();
            public int nPlayer1Wins = 0;
            public int nPlayer2Wins = 0;
            public int nRuns = 0;
            public int nInfiniteLoops = 0;
        }
        #endregion

        #region private class BackgroundWorkerUpdate
        private class BackgroundWorkerUpdate
        {
            public int nRuns = 0;
            public Int64 nTotalThrows = 0;
            public Int64 nInfinateLoops = 0;
            public Int64 nTotalWars = 0;
            public Int64 nTotalSingleWars = 0;
            public Int64 nTotalDoubleWars = 0;
            public Int64 nTotalTripleWars = 0;
            public Int64 nTotalQuadWars = 0;
            public Int64 nTotalFiveWars = 0;
            public Int64 nTotalSixWars = 0;
            public Int64 nTotalSevenWars = 0;
        }
        #endregion

        #region workerManyGames DoWork
        private void workerManyGames_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            BackgroundWorkerOutput bwo = new BackgroundWorkerOutput();

            for (int i = 0; i < numericUpDownNGames.Value; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                Restart();  // restart with a new deck
                Shuffle();  // shuffle the deck
                Deal();     // deal the deck out to the hands

                bool bInfiniteLoop = false;
                while (m_Hand1.Count > 0 && m_Hand2.Count > 0)
                {
                    Throw();

                    if (m_nThrows > 20000)
                    {   // simple test to see if we've had an infinite loop
                        bwo.nInfiniteLoops++;
                        bInfiniteLoop = true;
                        break;
                    }
                    if (checkBoxDisplay.Checked)
                    {
                        Thread.Sleep((int)numericUpDownSleep.Value);
                        MultiAutoRunUpdateProgress(bw, bwo, i);
                    }
                }
                
                lock (m_Lock)
                {
                    if (m_Hand1.Count == 0) bwo.nPlayer2Wins++;
                    if (m_Hand2.Count == 0) bwo.nPlayer1Wins++;
                }
                if (!bInfiniteLoop) bwo.nThrowsList.Add(m_nThrows);
                bwo.nTotalWarsList.Add(m_nTotalWars);
                bwo.nSingleWarsList.Add(m_nSingleWars);
                bwo.nDoubleWarsList.Add(m_nDoubleWars);
                bwo.nTripleWarsList.Add(m_nTripleWars);
                bwo.nQuadWarsList.Add(m_nQuadWars);
                bwo.nFiveWarsList.Add(m_nFiveWars);
                bwo.nSixWarsList.Add(m_nSixWars);
                bwo.nSevenWarsList.Add(m_nSevenWars);
                bwo.nRuns++;
                if (i % 500 == 0)
                {
                    MultiAutoRunUpdateProgress(bw, bwo, i);
                }
            }
            MultiAutoRunUpdateProgress(bw, bwo, (int)numericUpDownNGames.Value);
            
            e.Result = bwo;
        }

        private void MultiAutoRunUpdateProgress(BackgroundWorker bw, BackgroundWorkerOutput bwo, int iRun)
        {
            BackgroundWorkerUpdate update = new BackgroundWorkerUpdate();
            update.nRuns = bwo.nRuns;
            update.nTotalThrows = Sum(bwo.nThrowsList);
            update.nInfinateLoops = bwo.nInfiniteLoops;
            update.nTotalWars = Sum(bwo.nTotalWarsList);
            update.nTotalSingleWars = Sum(bwo.nSingleWarsList);
            update.nTotalDoubleWars = Sum(bwo.nDoubleWarsList);
            update.nTotalTripleWars = Sum(bwo.nTripleWarsList);
            update.nTotalQuadWars = Sum(bwo.nQuadWarsList);
            update.nTotalFiveWars = Sum(bwo.nFiveWarsList);
            update.nTotalSixWars = Sum(bwo.nSixWarsList);
            update.nTotalSevenWars = Sum(bwo.nSevenWarsList);

            bw.ReportProgress((int)(100.0 * iRun / (double)numericUpDownNGames.Value), update);
        }
        #endregion

        #region workerManyGames ProgressChanged
        private void workerManyGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //if (checkBoxDisplay.Checked) UpdateUI();
            UpdateUI();
            if (e.UserState != null)
            {
                BackgroundWorkerUpdate update = e.UserState as BackgroundWorkerUpdate;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("# of games: {0,13}", update.nRuns.ToString("N0")));
                sb.AppendLine(String.Format("# of Throws:{0,13}", update.nTotalThrows.ToString("N0")));
                sb.AppendLine(String.Format("# Infinite Loops:{0,8}", update.nInfinateLoops.ToString("N0")));
                sb.AppendLine(String.Format("Total Wars:    {0,10}", update.nTotalWars.ToString("N0")));
                sb.AppendLine(String.Format("Single Wars:   {0,10}", update.nTotalSingleWars.ToString("N0")));
                sb.AppendLine(String.Format("Double Wars:   {0,10}", update.nTotalDoubleWars.ToString("N0")));
                sb.AppendLine(String.Format("Triple Wars:   {0,10}", update.nTotalTripleWars.ToString("N0")));
                sb.AppendLine(String.Format("Quad Wars:     {0,10}", update.nTotalQuadWars.ToString("N0")));
                sb.AppendLine(String.Format("Quintuple Wars:{0,10}", update.nTotalFiveWars.ToString("N0")));
                sb.AppendLine(String.Format("Sextuple Wars: {0,10}", update.nTotalSixWars.ToString("N0")));
                sb.AppendLine(String.Format("Septuble Wars: {0,10}", update.nTotalSevenWars.ToString("N0")));
                textBoxCounts.Text = sb.ToString();
            }
        }
        #endregion

        #region workerManyGames RunWorkerCompleted
        private void workerManyGames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;

            if (e.Cancelled || e.Error != null)
            {   // if it was cancelled or there was an error, just return
                EnableUI(true);
                return; 
            }

            BackgroundWorkerOutput bwo = e.Result as BackgroundWorkerOutput;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************************");
            sb.AppendLine("Number of games played: " + bwo.nRuns.ToString("N0"));
            if (checkBoxShuffleResult.Checked) sb.AppendLine("Shuffle the winning cards every turn");
            if (checkBoxShuffleAll.Checked) sb.AppendLine("Shuffled both hands every turn");
            if (!checkBoxShuffleAll.Checked && !checkBoxShuffleResult.Checked) sb.AppendLine("Perfect play, no shuffling of cards between turns, infinate loops possible!");
            sb.AppendLine("Player 1 wins: " + bwo.nPlayer1Wins.ToString("N0"));
            sb.AppendLine("Player 2 wins: " + bwo.nPlayer2Wins.ToString("N0"));
            sb.AppendLine("Number of infinate loops: " + bwo.nInfiniteLoops.ToString("N0"));
            sb.AppendLine("");

            int nMinThrows, nMaxThrows;
            Int64 nCountThrows;
            double dAvgThrows;
            GetMaxMinAvgCount(bwo.nThrowsList, out nMaxThrows, out nMinThrows, out dAvgThrows, out nCountThrows);
            sb.AppendLine("Max throws in a game: " + nMaxThrows.ToString("N0"));
            sb.AppendLine("Min throws in a game: " + nMinThrows.ToString("N0"));
            sb.AppendLine("Avg throws in a game: " + dAvgThrows.ToString());
            sb.AppendLine("Total throws in all games: " + nCountThrows.ToString("N0"));
            sb.AppendLine("");

            int nMinTotalWars, nMaxTotalWars;
            Int64 nCountTotalWars;
            double dAvgTotalWars;
            GetMaxMinAvgCount(bwo.nTotalWarsList, out nMaxTotalWars, out nMinTotalWars, out dAvgTotalWars, out nCountTotalWars);
            sb.AppendLine("Max single wars in a game: " + nMaxTotalWars.ToString("N0"));
            sb.AppendLine("Min single wars in a game: " + nMinTotalWars.ToString("N0"));
            sb.AppendLine("Avg single wars in a game: " + dAvgTotalWars.ToString());
            sb.AppendLine("Total single wars in all games: " + nCountTotalWars.ToString("N0"));
            sb.AppendLine("");

            int nMinSingleWars, nMaxSingleWars;
            Int64 nCountSingleWars;
            double dAvgSingleWars;
            GetMaxMinAvgCount(bwo.nSingleWarsList, out nMaxSingleWars, out nMinSingleWars, out dAvgSingleWars, out nCountSingleWars);
            sb.AppendLine("Max single wars in a game: " + nMaxSingleWars.ToString("N0"));
            sb.AppendLine("Min single wars in a game: " + nMinSingleWars.ToString("N0"));
            sb.AppendLine("Avg single wars in a game: " + dAvgSingleWars.ToString());
            sb.AppendLine("Total single wars in all games: " + nCountSingleWars.ToString("N0"));
            sb.AppendLine("");

            int nMinDouble, nMaxDouble;
            Int64 nCountDouble;
            double dAvgDouble;
            GetMaxMinAvgCount(bwo.nDoubleWarsList, out nMaxDouble, out nMinDouble, out dAvgDouble, out nCountDouble);
            sb.AppendLine("Max double wars in a game: " + nMaxDouble.ToString("N0"));
            sb.AppendLine("Avg double wars in a game: " + dAvgDouble.ToString());
            sb.AppendLine("Total double wars in all games: " + nCountDouble.ToString("N0"));
            sb.AppendLine("");

            int nMinTriple, nMaxTriple;
            Int64 nCountTriple;
            double dAvgTriple;
            GetMaxMinAvgCount(bwo.nTripleWarsList, out nMaxTriple, out nMinTriple, out dAvgTriple, out nCountTriple);
            sb.AppendLine("Max triple wars in a game: " + nMaxTriple.ToString("N0"));
            sb.AppendLine("Avg triple wars in a game: " + dAvgTriple.ToString());
            sb.AppendLine("Total triple wars in all games: " + nCountTriple.ToString("N0"));
            sb.AppendLine("");

            int nMinQuad, nMaxQuad;
            Int64 nCountQuad;
            double dAvgQuad;
            GetMaxMinAvgCount(bwo.nQuadWarsList, out nMaxQuad, out nMinQuad, out dAvgQuad, out nCountQuad);
            sb.AppendLine("Max quad wars in a game: " + nMaxQuad.ToString("N0"));
            sb.AppendLine("Avg quad wars in a game: " + dAvgQuad.ToString());
            sb.AppendLine("Total quad wars in all games: " + nCountQuad.ToString("N0"));
            sb.AppendLine("");

            int nMinFive, nMaxFive;
            Int64 nCountFive;
            double dAvgFive;
            GetMaxMinAvgCount(bwo.nFiveWarsList, out nMaxFive, out nMinFive, out dAvgFive, out nCountFive);
            sb.AppendLine("Max quintuple wars in a game: " + nMaxFive.ToString("N0"));
            sb.AppendLine("Avg quintuple wars in a game: " + dAvgFive.ToString());
            sb.AppendLine("Total quintuple wars in all games: " + nCountFive.ToString("N0"));
            sb.AppendLine("");

            int nMinSix, nMaxSix;
            Int64 nCountSix;
            double dAvgSix;
            GetMaxMinAvgCount(bwo.nSixWarsList, out nMaxSix, out nMinSix, out dAvgSix, out nCountSix);
            sb.AppendLine("Max sextuple wars in a game: " + nMaxSix.ToString("N0"));
            sb.AppendLine("Avg sextuple wars in a game: " + dAvgSix.ToString());
            sb.AppendLine("Total sextuple wars in all games: " + nCountSix.ToString("N0"));
            sb.AppendLine("");

            int nMinSeven, nMaxSeven;
            Int64 nCountSeven;
            double dAvgSeven;
            GetMaxMinAvgCount(bwo.nSevenWarsList, out nMaxSeven, out nMinSeven, out dAvgSeven, out nCountSeven);
            sb.AppendLine("Max septuble wars in a game: " + nMaxSeven.ToString("N0"));
            sb.AppendLine("Avg septuble wars in a game: " + dAvgSeven.ToString());
            sb.AppendLine("Total septuble wars in all games: " + nCountSeven.ToString("N0"));
            sb.AppendLine("");

            textBoxOutput.AppendText(sb.ToString());

            int[] hist = new int[nMaxThrows + 1];
            for (int i = 0; i < nMaxThrows + 1; i++) hist[i] = 0;
            for (int i = 0; i < bwo.nThrowsList.Count; i++) hist[bwo.nThrowsList[i]]++;

            EnableUI(true);
        }
        #endregion

        #region workerAutoThrow DoWork
        private void workerAutoThrow_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            if (m_Hand1.Count == 0 || m_Hand2.Count == 0)
            {
                Restart();     // restart with a new deck
                Shuffle();     // shuffle the deck
                Deal();        // deal the deck out to the hands
            }
            int count = 0;
            while (m_Hand1.Count > 0 && m_Hand2.Count > 0)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                Throw();
                if (m_nThrows > 20000)
                {
                    MessageBox.Show("Over a 20,000 throws?!  infinant loop maybe?");
                    // over a million throws?  infinant loop maybe?
                    break;
                }
                bw.ReportProgress(0);
                
                Thread.Sleep((int)numericUpDownSleep.Value);
                count++;
            }
            bw.ReportProgress(0);
        }
        #endregion

        #region workerAutoThrow progress changed
        private void workerAutoThrow_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateUI();
            UpdateCountsUI();
        }
        #endregion

        #region workerAutoThrow RunWorkerCompleted
        private void workerAutoThrow_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (m_Hand1.Count == 0) MessageBox.Show("Player 2 WINS!!! " + m_nThrows);
            if (m_Hand2.Count == 0) MessageBox.Show("Player 1 WINS!!! " + m_nThrows);

            EnableUI(true);
        }
        #endregion

        #region GetMaxMinAvgCount()
        private void GetMaxMinAvgCount(List<int> input, out int max, out int min, out double avg, out Int64 count)
        {
            max = Int32.MinValue;
            min = Int32.MaxValue;
            avg = 0;
            count = 0;

            foreach (int i in input)
            {
                if (i > max) max = i;
                if (i < min) min = i;
                count += i;
            }
            avg = (double)count / (double)input.Count;
        }
        #endregion

        #region Sum values in a list
        private Int64 Sum(List<int> l)
        {
            Int64 sum = 0;
            foreach (int i in l)
            {
                sum += i;
            }
            return sum;
        }
        #endregion
    }
    #endregion
}