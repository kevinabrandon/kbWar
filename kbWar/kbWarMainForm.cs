using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace kbWar
{
    #region public partial class kbWarMainForm : Form
    public partial class kbWarMainForm : Form
    {
        #region private member vars...

        private kbCardGameWar m_Game = new kbCardGameWar();     // the game to be used with the UI
        
        BackgroundWorker[] m_Workers = null;            // the background threads for the monte-carlo simulation.
        BackgroundWorkerOutput m_WorkersOutput = null;  // used to collect output from the multitple workers.

        #endregion

        #region construction...
        public kbWarMainForm()
        {
            InitializeComponent();

            Restart();
            UpdateUI();
            UpdateCountsUI();
            textBoxOutput.Clear();
            buttonCancel.Enabled = false;
            checkBoxVerbose.Enabled = false;

            numericUpDownNPlayers_ValueChanged(this, new EventArgs());
        }
        #endregion

        #region UpdateUI()
        private void UpdateUI()
        {
            lock (m_Game)
            {
                richTextBoxDeck.Text = m_Game.Deck;
                richTextBoxPlayer1.Text = m_Game.GetPlayer(0);
                richTextBoxPlayer2.Text = m_Game.GetPlayer(1);

                if (m_Game.nPlayers >= 3) richTextBoxPlayer3.Text = m_Game.GetPlayer(2);
                else richTextBoxPlayer3.Clear();

                if (m_Game.nPlayers >= 4) richTextBoxPlayer4.Text = m_Game.GetPlayer(3);
                else richTextBoxPlayer4.Clear();

                if (m_Game.nPlayers >= 5) richTextBoxPlayer5.Text = m_Game.GetPlayer(4);
                else richTextBoxPlayer5.Clear();

                if (m_Game.nPlayers >= 6) richTextBoxPlayer6.Text = m_Game.GetPlayer(5);
                else richTextBoxPlayer6.Clear();

                if (m_Game.WinnerOfLastTurn > -2)
                {
                    richTextBoxPot.Clear();
                    if (m_Game.WinnerOfLastTurn < 0) richTextBoxPot.AppendText("TIE!!\n\n");
                    else    richTextBoxPot.AppendText("Player " + (m_Game.WinnerOfLastTurn + 1).ToString() + " Won:\n\n");

                    richTextBoxPot.AppendText(m_Game.MostRecentlyWonCards.ToString());
                    if(m_Game.Winner > 0) richTextBoxPot.AppendText("\nPLAYER " + (m_Game.Winner+1).ToString() + " WINS!!!");
                }
                else richTextBoxPot.Clear();
            }
            ColorTextBoxes();
        }
        #endregion

        #region ColorTextBoxes()
        private void ColorTextBoxes()
        {
            ColorTextBoxeSelection(richTextBoxPot, "TIE!!", Color.White, Color.Black);

            ColorTextBoxeSelection(richTextBoxPot, "Player 1 Won:", Color.White, Color.Maroon);
            ColorTextBoxeSelection(richTextBoxPot, "Player 2 Won:", Color.White, Color.Blue);
            ColorTextBoxeSelection(richTextBoxPot, "Player 3 Won:", Color.White, Color.Green);
            ColorTextBoxeSelection(richTextBoxPot, "Player 4 Won:", Color.White, Color.Purple);
            ColorTextBoxeSelection(richTextBoxPot, "Player 5 Won:", Color.Black, Color.Orange);
            ColorTextBoxeSelection(richTextBoxPot, "Player 6 Won:", Color.Black, Color.Teal);

            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 1 WINS!!!", Color.White, Color.Maroon);
            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 2 WINS!!!", Color.White, Color.Blue);
            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 3 WINS!!!", Color.White, Color.Green);
            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 4 WINS!!!", Color.White, Color.Purple);
            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 5 WINS!!!", Color.Black, Color.Orange);
            ColorTextBoxeSelection(richTextBoxPot, "PLAYER 6 WINS!!!", Color.Black, Color.Teal);          

            ColorTextBoxeSelection(richTextBoxPot, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxDeck, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer1, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer2, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer3, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer4, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer5, "Ace", Color.Red, Color.GreenYellow);
            ColorTextBoxeSelection(richTextBoxPlayer6, "Ace", Color.Red, Color.GreenYellow);

            ColorTextBoxeSelection(richTextBoxPot, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxDeck, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer1, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer2, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer3, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer4, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer5, "Hearts", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer6, "Hearts", Color.White, Color.Red);

            ColorTextBoxeSelection(richTextBoxDeck, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPot, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer1, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer2, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer3, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer4, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer5, "Diamonds", Color.White, Color.Red);
            ColorTextBoxeSelection(richTextBoxPlayer6, "Diamonds", Color.White, Color.Red);

            ColorTextBoxeSelection(richTextBoxDeck, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPot, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer1, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer2, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer3, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer4, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer5, "Spades", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer6, "Spades", Color.White, Color.Black);

            ColorTextBoxeSelection(richTextBoxDeck, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPot, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer1, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer2, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer3, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer4, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer5, "Clubs", Color.White, Color.Black);
            ColorTextBoxeSelection(richTextBoxPlayer6, "Clubs", Color.White, Color.Black); 
        }
        #endregion

        #region UpdateCountsUI()
        private void UpdateCountsUI()
        {
            lock(m_Game)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("# of Throws:   {0,5}", m_Game.Counters.nTurns.ToString("N0")));
                sb.AppendLine(String.Format("# of Ties:     {0,5}", m_Game.Counters.nTies.ToString("N0")));
                sb.AppendLine(String.Format("Total Wars:    {0,5}", m_Game.Counters.nTotalWars.ToString("N0")));
                sb.AppendLine(String.Format("Single Wars:   {0,5}", m_Game.Counters.nSingleWars.ToString("N0")));
                sb.AppendLine(String.Format("Double Wars:   {0,5}", m_Game.Counters.nDoubleWars.ToString("N0")));
                sb.AppendLine(String.Format("Triple Wars:   {0,5}", m_Game.Counters.nTripleWars.ToString("N0")));
                sb.AppendLine(String.Format("Quad Wars:     {0,5}", m_Game.Counters.nQuadrupleWars.ToString("N0")));
                sb.AppendLine(String.Format("Quintuple Wars:{0,5}", m_Game.Counters.nQuintupleWars.ToString("N0")));
                sb.AppendLine(String.Format("Sextuple Wars: {0,5}", m_Game.Counters.nSextupleWars.ToString("N0")));
                sb.AppendLine(String.Format("Septuple Wars: {0,5}", m_Game.Counters.nSeptupleWars.ToString("N0")));
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
            lock (m_Game)
            {
                m_Game.ShuffleDeck();
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
            lock (m_Game)
            {
                m_Game.Restart((int)numericUpDownNPlayers.Value);
            }
        }
        #endregion

        #region Deal()
        /// <summary>
        /// Deal the cards.
        /// </summary>
        private void Deal()
        {
            lock (m_Game)
            {
                m_Game.Deal();
            }
        }
        #endregion

        #region Throw()
        private void Throw()
        {
            lock (m_Game)
            {
                m_Game.NewTurn();
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
            if (m_Game.State != kbCardGameWar.GameState.eNotStarted) 
            {   // if the game is already playing, restart
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
            lock (m_Game)
            {
                if (m_Game.State == kbCardGameWar.GameState.eInfiniteLoop)
                {
                    MessageBox.Show("We're currently in an infinite loop, try restarting instead!");
                    return;
                }
                else if (m_Game.State == kbCardGameWar.GameState.eNotStarted)
                {
                    MessageBox.Show("We haven't started the game yet, try dealing the cards first!");
                    return;
                }
                else if (m_Game.State == kbCardGameWar.GameState.eOverWithWinner)
                {
                    MessageBox.Show("The game is over, Player " + (m_Game.Winner + 1).ToString() + " has already won!");
                    return;
                }
            }
            Throw();
            UpdateUI();
            UpdateCountsUI();

            lock(m_Game)    if (m_Game.Winner >= 0) MessageBox.Show("Player " + (m_Game.Winner + 1).ToString() + " WINS!!!  in " + m_Game.Counters.nTurns + " turns.");
        }
        #endregion

        #region auto-throw clicked
        private void buttonAutoThrow_Clicked(object sender, EventArgs e)
        {
            if (CheckIfAllDone() && !workerAutoThrow.IsBusy)
            {
                lock (m_Game)
                {
                    if (m_Game.State == kbCardGameWar.GameState.eOverWithWinner || 
                        m_Game.State == kbCardGameWar.GameState.eInfiniteLoop)
                    {
                        m_Game.Restart((int)numericUpDownNPlayers.Value);
                    }
                }
                EnableUI(false);
                workerAutoThrow.RunWorkerAsync();
            }
            else MessageBox.Show("Auto run already running!");
        }
        #endregion

        #region cancel clicked
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (workerAutoThrow.IsBusy) workerAutoThrow.CancelAsync();
            if (m_Workers != null)
            {
                foreach (var worker in m_Workers)
                {
                    if (worker.IsBusy) worker.CancelAsync();
                }
            }
        }
        #endregion

        #region clear output clicked
        private void buttonClearOutput_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
        }
        #endregion

        #region checkBoxOutputFiles Checked Changed()
        private void checkBoxOutputFiles_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxVerbose.Enabled = checkBoxOutputFiles.Checked;
        }
        #endregion

        #region checkBoxShuffleResult checked changed
        private void checkBoxShuffleResult_CheckedChanged(object sender, EventArgs e)
        {
            lock (m_Game) m_Game.ShuffleRecentlyWonCards = checkBoxShuffleResult.Checked;
        }
        #endregion

        #endregion

        #region EnableUI()
        private void EnableUI(bool bEnable)
        {
            foreach (Control c in splitContainer2.Panel1.Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control c2 in c.Controls)
                    {   // disables all the controls inside the groupboxes without disabling the groupboxes themselves.
                        c2.Enabled = bEnable;
                    }
                }
                else c.Enabled = bEnable;
            }
            buttonCancel.Enabled = !bEnable;
            if (checkBoxVerbose.Enabled) checkBoxVerbose.Enabled = checkBoxOutputFiles.Checked;
        }
        #endregion

        #region private class BackgroundWorkerOutput
        private class BackgroundWorkerOutput
        {
            public List<int> nThrowsList = new List<int>();
            public List<int> nTiesList = new List<int>();
            public List<int> iWinnerList = new List<int>();
            public List<int> nTotalWarsList = new List<int>();
            public List<int> nSingleWarsList = new List<int>();
            public List<int> nDoubleWarsList = new List<int>();
            public List<int> nTripleWarsList = new List<int>();
            public List<int> nQuadWarsList = new List<int>();
            public List<int> nFiveWarsList = new List<int>();
            public List<int> nSixWarsList = new List<int>();
            public List<int> nSevenWarsList = new List<int>();
            public int nRuns = 0;
            public int nInfiniteLoops = 0;
            public int iThread;
            public int nPlayers;
        }
        #endregion

        #region private void CombineOutputs(BackgroundWorkerOutput bwo)
        private void CombineOutputs(BackgroundWorkerOutput bwo)
        {
            if (m_WorkersOutput == null)
            {
                m_WorkersOutput = new BackgroundWorkerOutput();
            }

            m_WorkersOutput.iThread++;  // use this as a counter to know how many times we've combined outputs.
            m_WorkersOutput.nPlayers = bwo.nPlayers;
            m_WorkersOutput.nInfiniteLoops += bwo.nInfiniteLoops;
            m_WorkersOutput.nRuns += bwo.nRuns;
            m_WorkersOutput.iWinnerList.AddRange(bwo.iWinnerList);
            m_WorkersOutput.nThrowsList.AddRange(bwo.nThrowsList);
            m_WorkersOutput.nTiesList.AddRange(bwo.nTiesList);
            m_WorkersOutput.nTotalWarsList.AddRange(bwo.nTotalWarsList);
            m_WorkersOutput.nSingleWarsList.AddRange(bwo.nSingleWarsList);
            m_WorkersOutput.nDoubleWarsList.AddRange(bwo.nDoubleWarsList);
            m_WorkersOutput.nTripleWarsList.AddRange(bwo.nTripleWarsList);
            m_WorkersOutput.nQuadWarsList.AddRange(bwo.nQuadWarsList);
            m_WorkersOutput.nFiveWarsList.AddRange(bwo.nFiveWarsList);
            m_WorkersOutput.nSixWarsList.AddRange(bwo.nSixWarsList);
            m_WorkersOutput.nSevenWarsList.AddRange(bwo.nSevenWarsList);
        }
        #endregion

        #region private class BackgroundWorkerUpdate
        private class BackgroundWorkerUpdate
        {
            public int nRuns = 0;
            public int iThread = 0;
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
            public Int64 nTotalTies = 0;
        }
        #endregion

        #region private class ManyGamesArgs
        private class ManyGamesArgs
        {
            public int nGames;
            public int nPlayers;
            public int iSeed;
            public bool bShuffleWinnings;
            public int nThreads;
            public int iThread;
        }
        #endregion

        #region StartMonteCarloSimulation
        private void StartMonteCarloSimulation(object sender, EventArgs e)
        {
            if (!workerAutoThrow.IsBusy || m_Workers != null)
            {
                EnableUI(false);
                int nThreads = (int)numericUpDownNThreads.Value;
                m_Workers = new BackgroundWorker[nThreads];

                var rand = new Random();
                m_WorkersOutput = new BackgroundWorkerOutput();
                m_WorkersOutput.iThread = 0;

                for (int iThread = 0; iThread < nThreads; iThread++)
                {
                    m_Workers[iThread] = new BackgroundWorker();
                    m_Workers[iThread].WorkerReportsProgress = true;
                    m_Workers[iThread].WorkerSupportsCancellation = true;
                    m_Workers[iThread].DoWork += new DoWorkEventHandler(workerManyGames_DoWork);
                    m_Workers[iThread].ProgressChanged += new ProgressChangedEventHandler(workerManyGames_ProgressChanged);
                    m_Workers[iThread].RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerManyGames_RunWorkerCompleted);

                    ManyGamesArgs args = new ManyGamesArgs();

                    args.nGames = (int)numericUpDownNGames.Value / nThreads;
                    args.nPlayers = (int)numericUpDownNPlayers.Value;
                    args.iSeed = rand.Next();
                    args.bShuffleWinnings = checkBoxShuffleResult.Checked;
                    args.nThreads = nThreads;
                    args.iThread = iThread;

                    m_Workers[iThread].RunWorkerAsync(args);
                }
            }
            else MessageBox.Show("Auto run already running!");
        }
        #endregion

        #region workerManyGames DoWork
        private void workerManyGames_DoWork(object sender, DoWorkEventArgs e)
        {
            ManyGamesArgs args = e.Argument as ManyGamesArgs;
            BackgroundWorker bw = sender as BackgroundWorker;
            BackgroundWorkerOutput bwo = new BackgroundWorkerOutput();
            bwo.iThread = args.iThread;
            bwo.nPlayers = args.nPlayers;

            kbCardGameWar game = new kbCardGameWar(args.nPlayers, new Random(args.iSeed));
            game.ShuffleRecentlyWonCards = args.bShuffleWinnings;

            for (int i = 0; i < args.nGames; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                game.Restart(args.nPlayers);
                game.ShuffleDeck();
                game.Deal();
                game.PlayTillFinished();

                if (game.State == kbCardGameWar.GameState.eInfiniteLoop) bwo.nThrowsList.Add(0);
                else bwo.nThrowsList.Add(game.Counters.nTurns);

                if (game.State == kbCardGameWar.GameState.eInfiniteLoop) bwo.nInfiniteLoops++;
                bwo.iWinnerList.Add(game.Winner);
                bwo.nTiesList.Add(game.Counters.nTies);
                bwo.nTotalWarsList.Add(game.Counters.nTotalWars);
                bwo.nSingleWarsList.Add(game.Counters.nSingleWars);
                bwo.nDoubleWarsList.Add(game.Counters.nDoubleWars);
                bwo.nTripleWarsList.Add(game.Counters.nTripleWars);
                bwo.nQuadWarsList.Add(game.Counters.nQuadrupleWars);
                bwo.nFiveWarsList.Add(game.Counters.nQuintupleWars);
                bwo.nSixWarsList.Add(game.Counters.nSextupleWars);
                bwo.nSevenWarsList.Add(game.Counters.nSeptupleWars);
                bwo.nRuns++;
                if (i % 500 == 0)
                {
                    MultiAutoRunUpdateProgress(bw, bwo, i, args);
                }
            }
            MultiAutoRunUpdateProgress(bw, bwo, args.nGames, args);
            
            e.Result = bwo;
        }
        #endregion

        #region UpdateCountersAtEndOfSim()
        private void UpdateCountersAtEndOfSim(BackgroundWorkerOutput bwo)
        {
            BackgroundWorkerUpdate update = new BackgroundWorkerUpdate();
            update.nRuns = bwo.nRuns;
            update.iThread = -1;
            update.nTotalThrows = Sum(bwo.nThrowsList);
            update.nInfinateLoops = bwo.nInfiniteLoops;
            update.nTotalWars = Sum(bwo.nTotalWarsList);
            update.nTotalTies = Sum(bwo.nTiesList);
            update.nTotalSingleWars = Sum(bwo.nSingleWarsList);
            update.nTotalDoubleWars = Sum(bwo.nDoubleWarsList);
            update.nTotalTripleWars = Sum(bwo.nTripleWarsList);
            update.nTotalQuadWars = Sum(bwo.nQuadWarsList);
            update.nTotalFiveWars = Sum(bwo.nFiveWarsList);
            update.nTotalSixWars = Sum(bwo.nSixWarsList);
            update.nTotalSevenWars = Sum(bwo.nSevenWarsList);

            int iProgress = 100;
            workerManyGames_ProgressChanged(this, new ProgressChangedEventArgs(iProgress, update));

        }
        #endregion

        #region MultiAutoRunUpdateProgress()
        private void MultiAutoRunUpdateProgress(BackgroundWorker bw, BackgroundWorkerOutput bwo, int iRun, ManyGamesArgs args)
        {
            BackgroundWorkerUpdate update = new BackgroundWorkerUpdate();
            update.nRuns = bwo.nRuns;
            update.iThread = args.iThread;
            update.nTotalThrows = Sum(bwo.nThrowsList);
            update.nInfinateLoops = bwo.nInfiniteLoops;
            update.nTotalWars = Sum(bwo.nTotalWarsList);
            update.nTotalTies = Sum(bwo.nTiesList);
            update.nTotalSingleWars = Sum(bwo.nSingleWarsList);
            update.nTotalDoubleWars = Sum(bwo.nDoubleWarsList);
            update.nTotalTripleWars = Sum(bwo.nTripleWarsList);
            update.nTotalQuadWars = Sum(bwo.nQuadWarsList);
            update.nTotalFiveWars = Sum(bwo.nFiveWarsList);
            update.nTotalSixWars = Sum(bwo.nSixWarsList);
            update.nTotalSevenWars = Sum(bwo.nSevenWarsList);

            bw.ReportProgress((int)(100.0 * iRun / (double)args.nGames), update);
        }
        #endregion

        #region workerManyGames ProgressChanged
        private void workerManyGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                BackgroundWorkerUpdate update = e.UserState as BackgroundWorkerUpdate;

                if (update.iThread == 0 || update.iThread == -1)
                {   // here -1 means it's over and it's the main thread calling it.

                    progressBar1.Value = e.ProgressPercentage;
                    int nThreads = (int)numericUpDownNThreads.Value;

                    if (update.iThread == 0)
                    {// multiplying by number of threads is kinda cheating here...
                        update.nRuns *= nThreads;
                        update.nInfinateLoops *= nThreads;
                        update.nTotalThrows *= nThreads;
                        update.nTotalTies *= nThreads;
                        update.nTotalWars *= nThreads;
                        update.nTotalSingleWars *= nThreads;
                        update.nTotalDoubleWars *= nThreads;
                        update.nTotalTripleWars *= nThreads;
                        update.nTotalQuadWars *= nThreads;
                        update.nTotalFiveWars *= nThreads;
                        update.nTotalSixWars *= nThreads;
                        update.nTotalSevenWars *= nThreads;
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(String.Format("Games:    {0,15}", update.nRuns.ToString("N0")));
                    sb.AppendLine(String.Format("Infinite Loops:{0,10}", update.nInfinateLoops.ToString("N0")));
                    sb.AppendLine(String.Format("Throws:   {0,15}", update.nTotalThrows.ToString("N0")));
                    sb.AppendLine(String.Format("Total Ties:    {0,10}", update.nTotalTies.ToString("N0")));
                    sb.AppendLine(String.Format("Total Wars: {0,13}", update.nTotalWars.ToString("N0")));
                    sb.AppendLine(String.Format("Single Wars:{0,13}", update.nTotalSingleWars.ToString("N0")));
                    sb.AppendLine(String.Format("Double Wars:{0,13}", update.nTotalDoubleWars.ToString("N0")));
                    sb.AppendLine(String.Format("Triple Wars:{0,13}", update.nTotalTripleWars.ToString("N0")));
                    sb.AppendLine(String.Format("Quad Wars:     {0,10}", update.nTotalQuadWars.ToString("N0")));
                    sb.AppendLine(String.Format("Quintuple Wars:{0,10}", update.nTotalFiveWars.ToString("N0")));
                    sb.AppendLine(String.Format("Sextuple Wars: {0,10}", update.nTotalSixWars.ToString("N0")));
                    sb.AppendLine(String.Format("Septuble Wars: {0,10}", update.nTotalSevenWars.ToString("N0")));
                    textBoxCounts.Text = sb.ToString();
                }
            }
        }
        #endregion

        #region workerManyGames RunWorkerCompleted
        private void workerManyGames_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {   // if it was cancelled or there was an error, just return
                if (CheckIfAllDone())
                {
                    foreach (var worker in m_Workers) worker.Dispose();
                    m_Workers = null;
                    progressBar1.Value = 0;
                    EnableUI(true);
                }
                return; 
            }

            BackgroundWorkerOutput bwo = e.Result as BackgroundWorkerOutput;
            CombineOutputs(bwo);

            if (CheckIfAllDone())
            {
                UpdateCountersAtEndOfSim(m_WorkersOutput);

                textBoxOutput.AppendText(GetOutputText(m_WorkersOutput));

                if (checkBoxOutputFiles.Checked) SaveOutputFiles(m_WorkersOutput);

                foreach (var worker in m_Workers) worker.Dispose();
                m_Workers = null;

                progressBar1.Value = 0;
                EnableUI(true);
            }
        }
        #endregion

        #region private bool CheckIfAllDone()
        /// <summary>
        /// Checks if all the background threads are complete.
        /// </summary>
        private bool CheckIfAllDone()
        {
            if (m_Workers == null) return true;

            foreach (var bw in m_Workers)
            {
                if (bw.IsBusy) return false;
            }

            return true;
        }
        #endregion

        #region SaveOutputFiles()
        private void SaveOutputFiles(BackgroundWorkerOutput bwo)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv|Text File|*.txt|All Files|*.*";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            StreamWriter sw = new StreamWriter(sfd.FileName);

            int nMinThrows, nMaxThrows, nMinTotalWars, nMaxTotalWars, nMinTies, nMaxTies, nMinSingleWars, nMaxSingleWars, nMinDouble, nMaxDouble;
            int nMinTriple, nMaxTriple, nMinQuad, nMaxQuad, nMinFive, nMaxFive, nMinSix, nMaxSix, nMinSeven, nMaxSeven;
            Int64 nCountThrows, nCountTotalWars, nCountTies, nCountSingleWars, nCountDouble, nCountTriple, nCountQuad, nCountFive, nCountSix, nCountSeven;
            double dAvgThrows, dAvgTotalWars, dAvgTies, dAvgSingleWars, dAvgDouble, dAvgTriple, dAvgQuad, dAvgFive, dAvgSix, dAvgSeven;

            GetMaxMinAvgCount(bwo.nThrowsList, out nMaxThrows, out nMinThrows, out dAvgThrows, out nCountThrows, bwo.nInfiniteLoops);
            GetMaxMinAvgCount(bwo.nTotalWarsList, out nMaxTotalWars, out nMinTotalWars, out dAvgTotalWars, out nCountTotalWars);
            GetMaxMinAvgCount(bwo.nTiesList, out nMaxTies, out nMinTies, out dAvgTies, out nCountTies);
            GetMaxMinAvgCount(bwo.nSingleWarsList, out nMaxSingleWars, out nMinSingleWars, out dAvgSingleWars, out nCountSingleWars);
            GetMaxMinAvgCount(bwo.nDoubleWarsList, out nMaxDouble, out nMinDouble, out dAvgDouble, out nCountDouble);
            GetMaxMinAvgCount(bwo.nTripleWarsList, out nMaxTriple, out nMinTriple, out dAvgTriple, out nCountTriple);
            GetMaxMinAvgCount(bwo.nQuadWarsList, out nMaxQuad, out nMinQuad, out dAvgQuad, out nCountQuad);
            GetMaxMinAvgCount(bwo.nFiveWarsList, out nMaxFive, out nMinFive, out dAvgFive, out nCountFive);
            GetMaxMinAvgCount(bwo.nSixWarsList, out nMaxSix, out nMinSix, out dAvgSix, out nCountSix);
            GetMaxMinAvgCount(bwo.nSevenWarsList, out nMaxSeven, out nMinSeven, out dAvgSeven, out nCountSeven);
            
            sw.WriteLine("Number of Games, " + bwo.nRuns);
            int[] PlayerWins = GetPlayerWinners(bwo);
            for (int i = 0; i < bwo.nPlayers; i++)
            {
                sw.WriteLine("Player " + (i+1) + " Wins, " + PlayerWins[i]);
            }
            sw.WriteLine("Number of infinite loops, " + bwo.nInfiniteLoops);

            sw.WriteLine("Max Throws in a game, " + nMaxThrows);
            sw.WriteLine("Min Throws in a game, " + nMinThrows);
            sw.WriteLine("Avg Throws in a game, " + dAvgThrows);
            sw.WriteLine("Total Throws in all games, " + nCountThrows);

            sw.WriteLine("Max Ties in a game, " + nMaxTies);
            sw.WriteLine("Avg Ties in a game, " + dAvgTies);
            sw.WriteLine("Total Ties in all games, " + nCountTies);

            sw.WriteLine("Max total wars in a game, " + nMaxTotalWars);
            sw.WriteLine("Avg total wars in a game, " + dAvgTotalWars);
            sw.WriteLine("Total total wars in all games, " + nCountTotalWars);

            sw.WriteLine("Max single wars in a game, " + nMaxSingleWars);
            sw.WriteLine("Avg single wars in a game, " + dAvgSingleWars);
            sw.WriteLine("Total single wars in all games, " + nCountSingleWars);

            sw.WriteLine("Max double wars in a game, " + nMaxDouble);
            sw.WriteLine("Avg double wars in a game, " + dAvgDouble);
            sw.WriteLine("Total double wars in all games, " + nCountDouble);

            sw.WriteLine("Max triple wars in a game, " + nMaxTriple);
            sw.WriteLine("Avg triple wars in a game, " + dAvgTriple);
            sw.WriteLine("Total triple wars in all games, " + nCountTriple);

            sw.WriteLine("Max quad wars in a game, " + nMaxQuad);
            sw.WriteLine("Avg quad wars in a game, " + dAvgQuad);
            sw.WriteLine("Total quad wars in all games, " + nCountQuad);

            sw.WriteLine("Max quintuple wars in a game, " + nMaxFive);
            sw.WriteLine("Avg quintuple wars in a game, " + dAvgFive);
            sw.WriteLine("Total quintuple wars in all games, " + nCountFive);

            sw.WriteLine("Max sextuple wars in a game, " + nMaxSix);
            sw.WriteLine("Avg sextuple wars in a game, " + dAvgSix);
            sw.WriteLine("Total sextuple wars in all games, " + nCountSix);

            sw.WriteLine("Max septuble wars in a game, " + nMaxSeven);
            sw.WriteLine("Avg septuble wars in a game, " + dAvgSeven);
            sw.WriteLine("Total septuble wars in all games, " + nCountSeven);

            sw.WriteLine();
            sw.WriteLine();

            if( checkBoxVerbose.Checked)
            {
                sw.WriteLine("Game Number, Winner, Number of Throws, Total Wars, Single Wars, Double Wars, Triple Wars, Quadruple Wars, Quintuple Wars, Sextuple Wars, Septuble Wars");
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bwo.nThrowsList.Count; i++)
                {
                    sb.Clear();
                    sb.Append((i+1).ToString());
                    sb.Append(", " + (bwo.iWinnerList[i]+1));
                    sb.Append(", " + bwo.nThrowsList[i]);
                    sb.Append(", " + bwo.nTotalWarsList[i]);
                    sb.Append(", " + bwo.nSingleWarsList[i]);
                    sb.Append(", " + bwo.nDoubleWarsList[i]);
                    sb.Append(", " + bwo.nTripleWarsList[i]);
                    sb.Append(", " + bwo.nQuadWarsList[i]);
                    sb.Append(", " + bwo.nFiveWarsList[i]);
                    sb.Append(", " + bwo.nSixWarsList[i]);
                    sb.Append(", " + bwo.nSevenWarsList[i]);
                    sw.WriteLine(sb.ToString());
                }
                sw.WriteLine();
                sw.WriteLine();
            }


            sw.Close();

        }
        #endregion

        #region private int[] GetPlayerWinners(BackgroundWorkerOutput bwo)
        private int[] GetPlayerWinners(BackgroundWorkerOutput bwo)
        {
            int[] winners = new int[bwo.nPlayers + 1];
            foreach (int winner in bwo.iWinnerList)
            {
                if (winner < 0) winners[bwo.nPlayers]++;    // this is for when there was no winner.
                else winners[winner]++;
            }
            return winners;
        }
        #endregion

        #region GetOutputText()
        /// <summary>
        /// Gets the output text
        /// </summary>
        private string GetOutputText(BackgroundWorkerOutput bwo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************************");
            sb.AppendLine("Number of games played: " + bwo.nRuns.ToString("N0"));
            if (checkBoxShuffleResult.Checked) sb.AppendLine("Shuffle the winning cards every turn");
            else sb.AppendLine("Perfect play, no shuffling of cards between turns, infinate loops possible!");

            int[] PlayerWins = GetPlayerWinners(bwo);
            for (int i = 0; i < bwo.nPlayers; i++)
            {
                sb.AppendLine("Player " + (i+1) + " Wins: " + PlayerWins[i].ToString("N0"));
            }
            sb.AppendLine("Number of infinite loops: " + bwo.nInfiniteLoops.ToString("N0"));
            sb.AppendLine("");

            int nMinThrows, nMaxThrows;
            Int64 nCountThrows;
            double dAvgThrows;
            GetMaxMinAvgCount(bwo.nThrowsList, out nMaxThrows, out nMinThrows, out dAvgThrows, out nCountThrows, bwo.nInfiniteLoops);
            sb.AppendLine("Max throws in a game: " + nMaxThrows.ToString("N0"));
            sb.AppendLine("Min throws in a game: " + nMinThrows.ToString("N0"));
            sb.AppendLine("Avg throws in a game: " + dAvgThrows.ToString());
            sb.AppendLine("Total throws in all games: " + nCountThrows.ToString("N0"));
            sb.AppendLine("");

            int nMaxTies, nMinTies;
            Int64 nCountTies;
            double dAvgTies;
            GetMaxMinAvgCount(bwo.nTiesList, out nMaxTies, out nMinTies, out dAvgTies, out nCountTies);
            sb.AppendLine("Max ties in a game: " + nMaxTies.ToString("N0"));
            sb.AppendLine("Avg ties in a game: " + dAvgTies.ToString());
            sb.AppendLine("Total ties in all games: " + nCountTies.ToString("N0"));
            sb.AppendLine("");

            int nMinTotalWars, nMaxTotalWars;
            Int64 nCountTotalWars;
            double dAvgTotalWars;
            GetMaxMinAvgCount(bwo.nTotalWarsList, out nMaxTotalWars, out nMinTotalWars, out dAvgTotalWars, out nCountTotalWars);
            sb.AppendLine("Max total wars in a game: " + nMaxTotalWars.ToString("N0"));
            sb.AppendLine("Min total wars in a game: " + nMinTotalWars.ToString("N0"));
            sb.AppendLine("Avg total wars in a game: " + dAvgTotalWars.ToString());
            sb.AppendLine("Total total wars in all games: " + nCountTotalWars.ToString("N0"));
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

            return sb.ToString();
        }
        #endregion

        #region workerAutoThrow DoWork
        private void workerAutoThrow_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            if (m_Game.State == kbCardGameWar.GameState.eNotStarted)
            {
                Restart();     // restart with a new deck
                Shuffle();     // shuffle the deck
                Deal();        // deal the deck out to the hands
            }
            int count = 0;
            while (true)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                lock(m_Game)
                {    
                    var state = m_Game.NewTurn();

                    if (state == kbCardGameWar.GameState.eInfiniteLoop || state == kbCardGameWar.GameState.eOverWithWinner)
                    {
                        break;
                    }
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
            lock (m_Game)
            {
                if (m_Game.State == kbCardGameWar.GameState.eInfiniteLoop) MessageBox.Show("Infinite Loop!!!");
                if (m_Game.State == kbCardGameWar.GameState.eOverWithWinner) MessageBox.Show("Player " + (m_Game.Winner + 1).ToString() + " WINS!!! In " + m_Game.Counters.nTurns.ToString() + " turns.");
            }
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

        /// <summary>
        /// This is a kludge version of GetMaxMinAvgCount which works with the number of throws.  
        /// It doesn't include zeros into the minimum, or avarage because those are cases where 
        /// we had an infinite loop.
        /// </summary>
        private void GetMaxMinAvgCount(List<int> input, out int max, out int min, out double avg, out Int64 count, int nInfiniteLoops)
        {
            max = Int32.MinValue;
            min = Int32.MaxValue;
            avg = 0;
            count = 0;

            foreach (int i in input)
            {
                if (i != 0)
                {
                    if (i > max) max = i;
                    if (i < min) min = i;
                    count += i;
                }
            }
            avg = (double)count / (double)(input.Count - nInfiniteLoops);
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

        #region numbericUPDownNPlayers Value Changed
        /// <summary>
        /// When the number of players change, we change the window to make  
        /// the correct number of players visible.  Then we restart the game.
        /// </summary>
        private void numericUpDownNPlayers_ValueChanged(object sender, EventArgs e)
        {
            // splitter distance is 936 when all 6 are visible.
            // full window size is 1463 when all 6 are visible.
            // textbox is 127 px wide plus 3 px margin, 130 per player.

            int width = 1463;
            int split = 936;
            int playerSize = 130;

            if (numericUpDownNPlayers.Value >= 6)
            {
                richTextBoxPlayer3.Visible = richTextBoxPlayer4.Visible = richTextBoxPlayer5.Visible = richTextBoxPlayer6.Visible = true;
                labelPlayer3.Visible = labelPlayer4.Visible = labelPlayer5.Visible = labelPlayer6.Visible = true;
                this.Width = width;
                splitContainer1.SplitterDistance = split;
            }
            else if (numericUpDownNPlayers.Value == 5)
            {
                richTextBoxPlayer3.Visible = richTextBoxPlayer4.Visible = richTextBoxPlayer5.Visible = true;
                labelPlayer3.Visible = labelPlayer4.Visible = labelPlayer5.Visible = true;

                richTextBoxPlayer6.Visible = false;
                labelPlayer6.Visible = false;

                this.Width = width - (playerSize);
                splitContainer1.SplitterDistance = split - (playerSize);

            }
            else if (numericUpDownNPlayers.Value == 4)
            {
                richTextBoxPlayer3.Visible = richTextBoxPlayer4.Visible = true;
                labelPlayer3.Visible = labelPlayer4.Visible = true;

                richTextBoxPlayer5.Visible = richTextBoxPlayer6.Visible = false;
                labelPlayer5.Visible = labelPlayer6.Visible = false;
                
                this.Width = width - (playerSize * 2);
                splitContainer1.SplitterDistance = split - (playerSize * 2);
            }
            else if (numericUpDownNPlayers.Value == 3)
            {
                richTextBoxPlayer3.Visible = true;
                labelPlayer3.Visible = true;

                richTextBoxPlayer4.Visible = richTextBoxPlayer5.Visible = richTextBoxPlayer6.Visible = false;
                labelPlayer4.Visible = labelPlayer5.Visible = labelPlayer6.Visible = false;
                
                this.Width = width - (playerSize * 3);
                splitContainer1.SplitterDistance = split - (playerSize * 3);
            }
            else if (numericUpDownNPlayers.Value <= 2)
            {
                richTextBoxPlayer3.Visible = richTextBoxPlayer4.Visible = richTextBoxPlayer5.Visible = richTextBoxPlayer6.Visible = false;
                labelPlayer3.Visible = labelPlayer4.Visible = labelPlayer5.Visible = labelPlayer6.Visible = false;

                this.Width = width - (playerSize * 4);
                splitContainer1.SplitterDistance = split - (playerSize * 4);
            }

            Restart();
            UpdateUI();
            UpdateCountsUI();
        }
        #endregion

    }
    #endregion
}
