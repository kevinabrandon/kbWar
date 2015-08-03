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

        // the game to be used with the UI
        private kbWarGame m_Game = new kbWarGame();

        private object m_Lock = new object();      
     

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
        }
        #endregion

        #region UpdateUI()
        private void UpdateUI()
        {
            lock (m_Lock)
            {
                richTextBoxDeck.Text = m_Game.Deck;
                richTextBoxPlayer1.Text = m_Game.GetPlayer(0);
                richTextBoxPlayer2.Text = m_Game.GetPlayer(1);
                if (m_Game.State != kbWarGame.GameState.eNotStarted && m_Game.WinnerOfLastTurn > -1)
                {
                    richTextBoxPot.Clear();
                    richTextBoxPot.AppendText("Player " + (m_Game.WinnerOfLastTurn + 1).ToString() + " Won:\n\n");
                    richTextBoxPot.AppendText(m_Game.MostRecentlyWonCards.ToString());
                    if(m_Game.Winner > 0) richTextBoxPot.AppendText("\nPLAYER " + (m_Game.Winner+1).ToString() + " WINS!!!");

            //        ColorTextBoxeSelection(richTextBoxPot, "Player One Won:", Color.White, Color.Red);
            //        ColorTextBoxeSelection(richTextBoxPot, "Player Two Won:", Color.White, Color.Blue);
            //        ColorTextBoxeSelection(richTextBoxPot, "PLAYER ONE WINS!!!", Color.White, Color.Red);
            //        ColorTextBoxeSelection(richTextBoxPot, "PLAYER TWO WINS!!!", Color.White, Color.Blue);
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
                sb.AppendLine(String.Format("# of Throws:   {0,5}", m_Game.Counters.nTurns.ToString("N0")));
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
            lock (m_Lock)
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
            lock (m_Lock)
            {
                m_Game.Restart(2);
            }
        }
        #endregion

        #region Deal()
        /// <summary>
        /// Deal the cards.
        /// </summary>
        private void Deal()
        {
            lock (m_Lock)
            {
                m_Game.Deal();
            }
        }
        #endregion

        #region Throw()
        private void Throw()
        {
            lock (m_Lock)
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
            if (m_Game.State != kbWarGame.GameState.eNotStarted) 
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
            lock (m_Lock)
            {
                if (m_Game.State == kbWarGame.GameState.eInfiniteLoop)
                {
                    MessageBox.Show("We're currently in an infinite loop, try restarting instead!");
                    return;
                }
                else if (m_Game.State == kbWarGame.GameState.eNotStarted)
                {
                    MessageBox.Show("We haven't started the game yet, try dealing the cards first!");
                    return;
                }
                else if (m_Game.State == kbWarGame.GameState.eOverWithWinner)
                {
                    MessageBox.Show("The game is over, Player " + (m_Game.Winner + 1).ToString() + " has already won!");
                    return;
                }
            }
            Throw();
            UpdateUI();
            UpdateCountsUI();

            lock(m_Lock)    if (m_Game.Winner >= 0) MessageBox.Show("Player " + (m_Game.Winner + 1).ToString() + " WINS!!!  in " + m_Game.Counters.nTurns + " turns.");
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
                ManyGamesArgs args = new ManyGamesArgs();

                var rand = new Random();
                args.nGames = (int)numericUpDownNGames.Value;
                args.nPlayers = 2;
                args.iSeed = rand.Next();
                args.bShuffleWinnings = checkBoxShuffleResult.Checked;
                args.nThreads = (int)numericUpDownNThreads.Value;

                workerManyGames.RunWorkerAsync(args);
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

        #region checkBoxOutputFiles Checked Changed()
        private void checkBoxOutputFiles_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxVerbose.Enabled = checkBoxOutputFiles.Checked;
        }
        #endregion

        #region checkBoxShuffleResult checked changed
        private void checkBoxShuffleResult_CheckedChanged(object sender, EventArgs e)
        {
            lock (m_Lock) m_Game.ShuffleRecentlyWonCards = checkBoxShuffleResult.Checked;
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
            if (checkBoxVerbose.Enabled) checkBoxVerbose.Enabled = checkBoxOutputFiles.Checked;
        }
        #endregion

        #region private class BackgroundWorkerOutput
        private class BackgroundWorkerOutput
        {
            public List<int> nThrowsList = new List<int>();
            public List<bool> bPlayer1WinsList = new List<bool>();
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

        #region workerManyGames DoWork
        private void workerManyGames_DoWork(object sender, DoWorkEventArgs e)
        {
            ManyGamesArgs args = e.Argument as ManyGamesArgs;
            BackgroundWorker bw = sender as BackgroundWorker;

            BackgroundWorker[] workers = new BackgroundWorker[args.nThreads];

            Random r = new Random(args.iSeed);

            for (int iThread = 0; iThread < args.nThreads; iThread++)
            {
                workers[iThread] = new BackgroundWorker();
                workers[iThread].WorkerReportsProgress = true;
                workers[iThread].WorkerSupportsCancellation = true;
                workers[iThread].DoWork += new DoWorkEventHandler(ThreadsDoWork);
                ManyGamesArgs newArgs = new ManyGamesArgs();
                newArgs.iSeed = r.Next();
                newArgs.iThread = iThread;
                newArgs.nGames = args.nGames / args.nThreads;
                newArgs.nPlayers = args.nPlayers;
                newArgs.nThreads = args.nThreads;
                workers[iThread].RunWorkerAsync(newArgs);
            }

        }

        private void ThreadsDoWork(object sender, DoWorkEventArgs e)
        {
            ManyGamesArgs args = e.Argument as ManyGamesArgs;
            BackgroundWorker bw = sender as BackgroundWorker;
            BackgroundWorkerOutput bwo = new BackgroundWorkerOutput();

            kbWarGame game = new kbWarGame(args.nPlayers, new Random(args.iSeed));
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

                if (game.State == kbWarGame.GameState.eInfiniteLoop) bwo.nThrowsList.Add(0);
                else bwo.nThrowsList.Add(game.Counters.nTurns);

                if (game.State == kbWarGame.GameState.eInfiniteLoop) bwo.nInfiniteLoops++;
                if (game.Winner == 0) bwo.nPlayer1Wins++;
                if (game.Winner == 1) bwo.nPlayer2Wins++;
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

        private void MultiAutoRunUpdateProgress(BackgroundWorker bw, BackgroundWorkerOutput bwo, int iRun, ManyGamesArgs args)
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

            bw.ReportProgress((int)(100.0 * iRun / (double)args.nGames), update);
        }
        #endregion

        #region workerManyGames ProgressChanged
        private void workerManyGames_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //if (checkBoxDisplay.Checked) UpdateUI();
            //UpdateUI();
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

            textBoxOutput.AppendText(GetOutputText(bwo));

            if (checkBoxOutputFiles.Checked) SaveOutputFiles(bwo);
            // int[] hist = new int[nMaxThrows + 1];
            // for (int i = 0; i < nMaxThrows + 1; i++) hist[i] = 0;
            // for (int i = 0; i < bwo.nThrowsList.Count; i++) hist[bwo.nThrowsList[i]]++;

            EnableUI(true);
        }
        #endregion

        #region SaveOutputFiles()
        private void SaveOutputFiles(BackgroundWorkerOutput bwo)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv|Text File|*.txt|All Files|*.*";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            StreamWriter sw = new StreamWriter(sfd.FileName);

            int nMinThrows, nMaxThrows, nMinTotalWars, nMaxTotalWars, nMinSingleWars, nMaxSingleWars, nMinDouble, nMaxDouble;
            int nMinTriple, nMaxTriple, nMinQuad, nMaxQuad, nMinFive, nMaxFive, nMinSix, nMaxSix, nMinSeven, nMaxSeven;
            Int64 nCountThrows, nCountTotalWars, nCountSingleWars, nCountDouble, nCountTriple, nCountQuad, nCountFive, nCountSix, nCountSeven;
            double dAvgThrows, dAvgTotalWars, dAvgSingleWars, dAvgDouble, dAvgTriple, dAvgQuad, dAvgFive, dAvgSix, dAvgSeven;

            GetMaxMinAvgCount(bwo.nThrowsList, out nMaxThrows, out nMinThrows, out dAvgThrows, out nCountThrows, bwo.nInfiniteLoops);            
            GetMaxMinAvgCount(bwo.nTotalWarsList, out nMaxTotalWars, out nMinTotalWars, out dAvgTotalWars, out nCountTotalWars);
            GetMaxMinAvgCount(bwo.nSingleWarsList, out nMaxSingleWars, out nMinSingleWars, out dAvgSingleWars, out nCountSingleWars);
            GetMaxMinAvgCount(bwo.nDoubleWarsList, out nMaxDouble, out nMinDouble, out dAvgDouble, out nCountDouble);
            GetMaxMinAvgCount(bwo.nTripleWarsList, out nMaxTriple, out nMinTriple, out dAvgTriple, out nCountTriple);
            GetMaxMinAvgCount(bwo.nQuadWarsList, out nMaxQuad, out nMinQuad, out dAvgQuad, out nCountQuad);
            GetMaxMinAvgCount(bwo.nFiveWarsList, out nMaxFive, out nMinFive, out dAvgFive, out nCountFive);
            GetMaxMinAvgCount(bwo.nSixWarsList, out nMaxSix, out nMinSix, out dAvgSix, out nCountSix);
            GetMaxMinAvgCount(bwo.nSevenWarsList, out nMaxSeven, out nMinSeven, out dAvgSeven, out nCountSeven);

            sw.WriteLine("Number of Games, " + bwo.nRuns);
            sw.WriteLine("Player 1 Wins, " + bwo.nPlayer1Wins);
            sw.WriteLine("Player 2 Wins, " + bwo.nPlayer2Wins);
            sw.WriteLine("Number of infinite loops, " + bwo.nInfiniteLoops);
            sw.WriteLine("Max Throws in a game, " + nMaxThrows);
            sw.WriteLine("Min Throws in a game, " + nMinThrows);
            sw.WriteLine("Avg Throws in a game, " + dAvgThrows);
            sw.WriteLine("Total Throws in all games, " + nMinTotalWars);
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
                sw.WriteLine("Game Number, Player one Wins, Player two Wins, Number of Throws, Total Wars, Single Wars, Double Wars, Triple Wars, Quadruple Wars, Quintuple Wars, Sextuple Wars, Septuble Wars");
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bwo.nThrowsList.Count; i++)
                {
                    sb.Clear();
                    sb.Append((i+1).ToString());
                    sb.Append(", " + bwo.bPlayer1WinsList[i]);
                    sb.Append(", " + !bwo.bPlayer1WinsList[i]);
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
            if (checkBoxShuffleAll.Checked) sb.AppendLine("Shuffled both hands every turn");
            if (!checkBoxShuffleAll.Checked && !checkBoxShuffleResult.Checked) sb.AppendLine("Perfect play, no shuffling of cards between turns, infinate loops possible!");
            sb.AppendLine("Player 1 wins: " + bwo.nPlayer1Wins.ToString("N0"));
            sb.AppendLine("Player 2 wins: " + bwo.nPlayer2Wins.ToString("N0"));
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

            if (m_Game.State == kbWarGame.GameState.eNotStarted)
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
                lock(m_Lock)
                {    
                    var state = m_Game.NewTurn();

                    if (state == kbWarGame.GameState.eInfiniteLoop || state == kbWarGame.GameState.eOverWithWinner)
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
            lock (m_Lock)
            {
                if (m_Game.State == kbWarGame.GameState.eInfiniteLoop) MessageBox.Show("Infinite Loop!!!");
                if (m_Game.State == kbWarGame.GameState.eOverWithWinner) MessageBox.Show("Player " + (m_Game.Winner + 1).ToString() + " WINS!!! In " + m_Game.Counters.nTurns.ToString() + " turns.");
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

    }
    #endregion
}
