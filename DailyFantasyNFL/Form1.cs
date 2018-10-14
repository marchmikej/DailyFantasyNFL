using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyFantasyNFL
{
    public partial class Form1 : Form
    {
        List<Player> players = new List<Player>();
        List<PlayerStats> qbs = new List<PlayerStats>();
        List<PlayerStats> rbs1 = new List<PlayerStats>();
        List<PlayerStats> rbs2 = new List<PlayerStats>();
        List<PlayerStats> wrs1 = new List<PlayerStats>();
        List<PlayerStats> wrs2 = new List<PlayerStats>();
        List<PlayerStats> wrs3 = new List<PlayerStats>();
        List<PlayerStats> tes = new List<PlayerStats>();
        List<PlayerStats> flexs = new List<PlayerStats>();
        List<PlayerStats> defs = new List<PlayerStats>();
        List<String> lineups = new List<String>();
        String highLineup = "";
        String highLineupIDs = "";
        int playerCount = 0;
        int totalThreads = 0;
        int threadsDone = 0;
        DataTable playersTable = new DataTable("Players");
        DataTable lineupsTable = new DataTable("Lineups");
        String rb2sdone = "";
        
        int highScore = 0;
        int highCost = 0;
        int qbCount = 0;
        int wr1Count = 0;
        int rb2Count = 0;

        public Form1()
        {
            InitializeComponent();
            playersTable.Columns.Add("id", typeof(System.Int32));
            playersTable.Columns.Add("position", typeof(System.String));
            playersTable.Columns.Add("lastName", typeof(System.String));
            playersTable.Columns.Add("firstName", typeof(System.String));
            playersTable.Columns.Add("fanDuelCost", typeof(System.Int32));
            playersTable.Columns.Add("fanDuelValue", typeof(System.Int32));
            playersTable.Columns.Add("pointsProjection", typeof(System.Int32));
            playersTable.Columns.Add("team", typeof(System.String));
            playersTable.Columns.Add("opponent", typeof(System.String));
            playersTable.Columns.Add("gameday", typeof(System.String));
            playersTable.Columns.Add("numberfireFanDuelProjection", typeof(System.Int32));
            playersTable.Columns.Add("rotogrindersFanDuelProjection", typeof(System.Int32));
            playersTable.Columns.Add("proFootballFocusProjection", typeof(System.Int32));

            dataGridPlayers.DataSource = playersTable;

            lineupsTable.Columns.Add("score", typeof(System.String));
            lineupsTable.Columns.Add("cost", typeof(System.String));
            lineupsTable.Columns.Add("qb", typeof(System.String));
            lineupsTable.Columns.Add("rb1", typeof(System.String));
            lineupsTable.Columns.Add("rb2", typeof(System.String));
            lineupsTable.Columns.Add("wr1", typeof(System.String));
            lineupsTable.Columns.Add("wr2", typeof(System.String));
            lineupsTable.Columns.Add("wr3", typeof(System.String));
            lineupsTable.Columns.Add("te", typeof(System.String));
            lineupsTable.Columns.Add("flex", typeof(System.String));
            lineupsTable.Columns.Add("def", typeof(System.String));

            txtMinHighScore.Text = Variables.minPointLineup.ToString();
            txtThreadNumber.Text = Variables.threads.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rdoFanDuel.Checked)
            {
                Variables.gameCost = 60000;
                if (rdoRotoGrinders.Checked)
                {
                    radioRotGrindersNFL("https://rotogrinders.com/lineups/nfl?site=fanduel");
                }
                else if (rdoNumberFire.Checked)
                {
                    radioNumFireNFL("https://www.numberfire.com/nfl/daily-fantasy/daily-football-projections");
                }
                else if (rdoNumberFireDefense.Checked)
                {
                    radioNumFireNFL("https://www.numberfire.com/nfl/daily-fantasy/daily-football-projections/D");
                }
                else if (rdoRotoWire.Checked)
                {
                    readCSVProFootballFocus("Incoming CSV");
                }
                else if (rdoFanDuelCSV.Checked)
                {
                    readCSVFanDuel("nothing yet");
                }
            }
            else if (rdoDraftKings.Checked)
            {
                Variables.gameCost = 50000;
                if (rdoRotoGrinders.Checked)
                {
                    radioRotGrindersNFL("https://rotogrinders.com/lineups/nfl?site=draftkings");
                }
                else if (rdoNumberFire.Checked)
                {
                    radioNumFireNFL(txtIncomingText.Text);
                }
                else if (rdoRotoWire.Checked)
                {
                    readCSVProFootballFocus("Incoming CSV");
                }
            }
        }

        private void radioNumFireNFL(String url)
        {
            String NFLFIle = txtIncomingText.Text;
            using (WebClient client = new WebClient())
            {
                NFLFIle = client.DownloadString(url);
            }
            int playerLocal = NFLFIle.IndexOf("<a class=\"full\" href=\"");
            txtIncomingText.Text = "";
            while (playerLocal > 0)
            {
                NFLFIle = NFLFIle.Substring(playerLocal + 2);

                //Player Name Start
                int locStart = NFLFIle.IndexOf(">");
                int locEnd = NFLFIle.IndexOf("<");
                String playerName = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                NFLFIle = NFLFIle.Substring(locEnd + 3);
                String lastName = "";
                String firstName = "";
                playerName = playerName.Trim();
                int spaceName = playerName.IndexOf(" ");
                if (spaceName > 0)
                {
                    lastName = playerName.Substring(spaceName + 1);
                    firstName = playerName.Substring(0, spaceName);
                }
                else
                {
                    lastName = playerName;
                }
                //Player Name End

                //Position Start
                String playerPosition = "";
                if (lastName.IndexOf("D/ST") < 0)
                {
                    locStart = NFLFIle.IndexOf("<span class=\"player-info--position");
                    NFLFIle = NFLFIle.Substring(locStart + 5);
                    locStart = NFLFIle.IndexOf(">");
                    locEnd = NFLFIle.IndexOf("<");
                    playerPosition = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                }
                else
                {
                    playerPosition = "D/ST";
                }
                //Position End 

                //Team Start
                locStart = NFLFIle.IndexOf("<span class=\"team-player__team active");
                NFLFIle = NFLFIle.Substring(locStart + 5);
                locStart = NFLFIle.IndexOf(">");
                locEnd = NFLFIle.IndexOf("<");
                String playerTeam = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                //Team End 

                //GameDay Start
                locStart = NFLFIle.IndexOf("<span class=\"gametim");
                NFLFIle = NFLFIle.Substring(locStart + 10);
                locStart = NFLFIle.IndexOf(">");
                locEnd = NFLFIle.IndexOf("<");

                String gameDay = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                NFLFIle = NFLFIle.Substring(locEnd + 3);
                gameDay = gameDay.Trim();
                //GameDay End

                //Projected Points Start
                locStart = NFLFIle.IndexOf("<td class=\"fp active\">");
                NFLFIle = NFLFIle.Substring(locStart + 10);
                locStart = NFLFIle.IndexOf(">");
                locEnd = NFLFIle.IndexOf("<");
                String playerPointsString = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                playerPointsString = playerPointsString.Replace(" ", "");
                playerPointsString = playerPointsString.Replace("\n", "");
                double playerPoints = Double.Parse(playerPointsString);
                //Projected Points End

                //Salary Start
                locStart = NFLFIle.IndexOf("<td class=\"cost\"");
                NFLFIle = NFLFIle.Substring(locStart + 2);
                locStart = NFLFIle.IndexOf(">");
                locEnd = NFLFIle.IndexOf("<");
                String playerFanDuelSalaryString = NFLFIle.Substring(locStart + 1, locEnd - locStart - 1);
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(" ", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(",", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("\n", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("$", "");
                int playerFanDuelSalary = -1;
                if (playerFanDuelSalaryString.IndexOf("N/A")==-1)
                {
                    playerFanDuelSalary = Int32.Parse(playerFanDuelSalaryString);
                }
                //Salary End

                txtIncomingText.Text = txtIncomingText.Text + " " + lastName + ", " + firstName + " position: " + playerPosition + " projected: " + playerPoints + " Salary: " + playerFanDuelSalary.ToString() + "\n";

                Player thisPlayer = new Player();
                thisPlayer.SetLastName(lastName);
                thisPlayer.firstName = firstName;
                thisPlayer.fanDuelCost = playerFanDuelSalary;
                thisPlayer.gameDay = gameDay;
                thisPlayer.SetTeamNumFire(playerTeam);
                thisPlayer.numberfireFanDuelProjection = playerPoints;
                if (playerPosition == "D/ST")
                {
                    thisPlayer.rotogrindersFanDuelProjection = playerPoints;
                    thisPlayer.proFootballFocusProjection = playerPoints;
                }
                else
                {
                    thisPlayer.rotogrindersFanDuelProjection = -1;
                }
                thisPlayer.position = playerPosition;


                //players.Add(thisPlayer);

                UpdatePlayerList(thisPlayer);

                playerLocal = NFLFIle.IndexOf("<a class=\"full\" href=\"");
            }
        }

        private void radioRotGrindersNFL(String url)
        {
            string NFLFile = "";
            
            using (WebClient client = new WebClient())
            {
                //NFLFile = client.DownloadString("https://www.numberfire.com/nfl/daily-fantasy/daily-football-projections");
                NFLFile = client.DownloadString("https://rotogrinders.com/lineups/nfl?site=fanduel");
                //txtIncomingText.Text = NFLFile;
            } 
            //NFLFile = txtIncomingText.Text;
            txtIncomingText.Text = "";
            int playerLocal = playerLocal = NFLFile.IndexOf("<a class=\"player-popup\" data-url=\"https://rotogrinders.com/players");

            while (playerLocal > 0)
            {
                NFLFile = NFLFile.Substring(playerLocal + 2);

                //Player Name Start
                int locStart = NFLFile.IndexOf(">");
                int locEnd = NFLFile.IndexOf("<");
                String playerName = NFLFile.Substring(locStart + 1, locEnd - locStart - 1);
                NFLFile = NFLFile.Substring(locEnd + 3);
                String lastName = "";
                String firstName = "";
                playerName = playerName.Trim();
                int spaceName = playerName.IndexOf(" ");
                if (spaceName > 0)
                {
                    lastName = playerName.Substring(spaceName + 1);
                    firstName = playerName.Substring(0, spaceName);
                }
                else
                {
                    lastName = playerName;
                }
                //Player Name End

                //Position Start
                locStart = NFLFile.IndexOf("<span class=\"position\">");
                NFLFile = NFLFile.Substring(locStart + 5);
                locStart = NFLFile.IndexOf(">");
                locEnd = NFLFile.IndexOf("<");
                String playerPosition = NFLFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerPosition = playerPosition.Replace(" ", "");
                playerPosition = playerPosition.Replace("\n", "");
                //Position End 

                //Salary Start
                locStart = NFLFile.IndexOf("<span class=\"salary\"");
                NFLFile = NFLFile.Substring(locStart + 2);
                locStart = NFLFile.IndexOf(">");
                locEnd = NFLFile.IndexOf("<");
                String playerFanDuelSalaryString = NFLFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(" ", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(",", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("\n", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("$", "");
                Double playerFanDuelSalaryDouble = -1;
                if (playerFanDuelSalaryString.Length > 0)
                {
                    playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("$", "");
                    if (playerFanDuelSalaryString.Contains("K"))
                    {
                        playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("K", "");
                        playerFanDuelSalaryDouble = Double.Parse(playerFanDuelSalaryString);
                        playerFanDuelSalaryDouble = playerFanDuelSalaryDouble * 1000;
                    }
                }
                int playerFanDuelSalary = Int32.Parse(playerFanDuelSalaryDouble.ToString());
                //Salary End

                //Projected Points Start
                locStart = NFLFile.IndexOf("<span class=\"fpts\"");
                NFLFile = NFLFile.Substring(locStart + 10);
                locStart = NFLFile.IndexOf(">");
                locEnd = NFLFile.IndexOf("<");
                String playerPointsString = NFLFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerPointsString = playerPointsString.Replace(" ", "");
                playerPointsString = playerPointsString.Replace("\n", "");
                double playerPoints = Double.Parse(playerPointsString);
                //Projected Points End

                txtIncomingText.Text = txtIncomingText.Text + "\n" + lastName + ", " + firstName + " position: " + playerPosition + " projected: " + playerPoints + " Salary: " + playerFanDuelSalary.ToString() + "\n";

                Player thisPlayer = new Player();
                thisPlayer.SetLastName(lastName);
                thisPlayer.firstName = firstName;
                thisPlayer.fanDuelCost = playerFanDuelSalary;
                thisPlayer.numberfireFanDuelProjection = -1;
                thisPlayer.rotogrindersFanDuelProjection = playerPoints;
                thisPlayer.position = playerPosition;

                UpdatePlayerList(thisPlayer);

                playerLocal = playerLocal = NFLFile.IndexOf("<a class=\"playe");
            }
            txtIncomingText.Text = txtIncomingText.Text + "done";
        }

        private bool UpdatePlayerList(Player newPlayer)
        {
            foreach (Player player in players)
            {
                if (player.getLastName() == newPlayer.getLastName() && player.firstName == newPlayer.firstName && player.position == newPlayer.position)
                {
                    // Player already exists
                    if (player.rotogrindersFanDuelProjection == -1)
                    {
                        player.rotogrindersFanDuelProjection = newPlayer.rotogrindersFanDuelProjection;
                    }
                    if (player.numberfireFanDuelProjection == -1)
                    {
                        player.numberfireFanDuelProjection = newPlayer.numberfireFanDuelProjection;
                    }
                    if (player.proFootballFocusProjection == -1)
                    {
                        player.proFootballFocusProjection = newPlayer.proFootballFocusProjection;
                    }
                    //if (player.fanDuelCost == -1)
                    //{
                    //    player.fanDuelCost = newPlayer.fanDuelCost;
                    //}
                    //if (player.team == "")
                    //{
                    //    player.team = newPlayer.team;
                    //}
                    //if (player.opponent == "")
                    //{
                    //    player.opponent = newPlayer.opponent;
                    //}
                    if (player.gameDay == "")
                    {
                        player.gameDay = newPlayer.gameDay;
                    }
                    return false;
                }
            }
            if (rdoFanDuelCSV.Checked)
            {
                playerCount++;
                newPlayer.id = playerCount;
                players.Add(newPlayer);
                DataRow workRow = playersTable.NewRow();
                playersTable.Rows.Add(newPlayer.CreateDataRow(workRow));
                return true;
            }
            return false;
        }

        private void txtIncomingText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            txtIncomingText.Text = "";
            playersTable.Clear();
            
        }

        private void btnViewPlayers_Click(object sender, EventArgs e)
        {
            txtIncomingText.Text = "Player count: " + players.Count.ToString() + "\n";
            UpdateTeamAvailability();
            playersTable.Clear();
            dataGridPlayers.DataSource = playersTable;
          
            foreach (Player player in players)
            {
                txtIncomingText.Text = txtIncomingText.Text + player.ToString() + "\n";
                if (player.isValidForStart())
                {
                    playersTable.Rows.Add(player.CreateDataRow(playersTable.NewRow()));
                }
            }
        }

        private void btnRunStats_Click(object sender, EventArgs e)
        {
            btnRunStats.Enabled = false;
            txtIncomingText.Text = "Running Stats";
            int minValue = Int32.Parse(txtMinValue.Text);
            Variables.minPointLineup = Int32.Parse(txtMinHighScore.Text);
            Variables.threads = Int32.Parse(txtThreadNumber.Text);

            int qbid = Int32.Parse(txtQBid.Text);
            int rb1id = Int32.Parse(txtRB1id.Text);
            int wr1id = Int32.Parse(txtWR1id.Text);
            int teid = Int32.Parse(txtTEid.Text);
            int defid = Int32.Parse(txtDEFid.Text);
            int utilid = Int32.Parse(txtUTILid.Text);

            //qbs.Clear();
            //rbs1.Clear();
            //rbs2.Clear();
            //wrs1.Clear();
            //wrs2.Clear();
            //wrs3.Clear();
            //tes.Clear();
            //flexs.Clear();
            //defs.Clear();
            //qbCount = 0;
            //rb2Count = 0;
            //wr1Count = 0;
            highCost = 0;
            highScore = 0;
            //lineupsTable.Clear();

            Variables.excludePlayer.Clear();
            String excludeText = txtExcludePlayers.Text;
            if (excludeText.Length > 0)
            {
                if (excludeText.Contains(",")) {
                    while (excludeText.Contains(","))
                    {
                        String tempInt = excludeText.Substring(0, excludeText.IndexOf(","));
                        Variables.excludePlayer.Add(Int32.Parse(tempInt));
                        excludeText = excludeText.Substring(excludeText.IndexOf(",") + 1);
                        if (!excludeText.Contains(","))
                        {
                            Variables.excludePlayer.Add(Int32.Parse(excludeText));
                        }
                    }
                } else {
                    Variables.excludePlayer.Add(Int32.Parse(excludeText));
                }
            }

            foreach (Player player in players)
            {
                if ((player.isValidForStart() && player.playerValue() > minValue) || qbid == player.id || rb1id == player.id || wr1id == player.id || teid == player.id || utilid == player.id || defid == player.id)
                {
                    if (player.position == "QB" && ((qbid > 0 && qbid == player.id) || qbid == 0))
                    {
                        qbs.Add(player.GenerateStruct());
                    }
                    else if (player.position == "RB")
                    {
                        if ((rb1id > 0 && rb1id == player.id) || rb1id == 0)
                        {
                            rbs1.Add(player.GenerateStruct());
                        }
                        rbs2.Add(player.GenerateStruct());
                    }
                    else if (player.position == "WR")
                    {
                        if ((wr1id > 0 && wr1id == player.id) || wr1id == 0)
                        {
                            wrs1.Add(player.GenerateStruct());
                        }
                        wrs2.Add(player.GenerateStruct());
                        wrs3.Add(player.GenerateStruct());
                    }
                    else if (player.position == "TE" && ((teid > 0 && teid == player.id) || teid == 0))
                    {
                        tes.Add(player.GenerateStruct());
                    }
                    else if (player.position == "D/ST" && ((defid > 0 && defid == player.id) || defid == 0))
                    {
                        defs.Add(player.GenerateStruct());
                    }
                    if ((player.position == "RB" || player.position == "WR") && ((utilid > 0 && utilid == player.id) || utilid == 0))
                    {
                        flexs.Add(player.GenerateStruct());
                    }
                }
            }

            int threadsPlayer = rbs2.Count / Variables.threads;

            txtIncomingText.Text = "rbs2: " + rbs2.Count().ToString() + " threadsPlayer: " + threadsPlayer;

            for (int j = 0; j < Variables.threads; j++)
            {
                if (j + 1 == Variables.threads)
                {
                    //This is needed for remainders in the thread
                    runThreadForStats(j * threadsPlayer, rbs2.Count);
                    txtIncomingText.Text = txtIncomingText.Text + " : " + j * threadsPlayer + " to " + rbs2.Count;
                }
                else
                {
                    runThreadForStats(j * threadsPlayer, ((j + 1) * threadsPlayer) - 1);
                    txtIncomingText.Text = txtIncomingText.Text + " : " + j * threadsPlayer + " to " + ((j + 1) * threadsPlayer - 1);
                }
            }

        }
        
        public void runThreadForStats(int playerNumberStart, int playerNumberEnd)
        {

            new Thread(() =>
            {
                totalThreads++;
                for (int i = playerNumberStart; i < playerNumberEnd; i++)
                {
                    rb2Count++;
                    PlayerStats rb2 = rbs2.ElementAt<PlayerStats>(i);
                    rb2sdone = rb2sdone + " : " + playerNumberEnd + " " + rb2.lastName + " " + rb2.firstName;
                    foreach (PlayerStats qb in qbs)
                    {
                        int currentScore = 0;
                        int currentSalary = 0;
                        qbCount++;
                        foreach (PlayerStats rb1 in rbs1)
                        {
                            if (rb1.id != rb2.id)
                            {
                                foreach (PlayerStats wr1 in wrs1)
                                {
                                    wr1Count++;
                                    foreach (PlayerStats wr2 in wrs2)
                                    {
                                        if (wr2.id != wr1.id)
                                        {
                                            foreach (PlayerStats wr3 in wrs3)
                                            {
                                                if (wr3.id != wr2.id && wr3.id != wr1.id)
                                                {
                                                    foreach (PlayerStats te in tes)
                                                    {
                                                        foreach (PlayerStats flex in flexs)
                                                        {
                                                            if (flex.id != wr1.id && flex.id != wr2.id && flex.id != wr3.id && flex.id != rb1.id && flex.id != rb2.id)
                                                            {
                                                                foreach (PlayerStats def in defs)
                                                                {
                                                                    currentSalary = qb.fanDuelCost + rb1.fanDuelCost + rb2.fanDuelCost + wr1.fanDuelCost + wr2.fanDuelCost + wr3.fanDuelCost + te.fanDuelCost + flex.fanDuelCost + def.fanDuelCost;
                                                                    currentScore = qb.fanDuelProjection + rb1.fanDuelProjection + rb2.fanDuelProjection + wr1.fanDuelProjection + wr2.fanDuelProjection + wr3.fanDuelProjection + te.fanDuelProjection + flex.fanDuelProjection + def.fanDuelProjection;
                                                                    if (currentSalary < Variables.gameCost && currentScore > highScore)
                                                                    {
                                                                        highCost = currentSalary;
                                                                        highScore = currentScore;
                                                                        highLineup = "QB: " + qb.lastName + ", " + qb.firstName + "RB1: " + rb1.lastName + ", " + rb1.firstName + "RB2: " + rb2.lastName + ", " + rb2.firstName + "WR1: " + wr1.lastName + ", " + wr1.firstName + "WR2: " + wr2.lastName + ", " + wr2.firstName + "WR3: " + wr3.lastName + ", " + wr3.firstName + "TE: " + te.lastName + ", " + te.firstName + "FLEX: " + flex.lastName + ", " + flex.firstName + "DEF: " + def.lastName + ", " + def.firstName;
                                                                        highLineupIDs = qb.fanDuelID + " " + rb1.fanDuelID + " " + rb2.fanDuelID + " " + wr1.fanDuelID + " " + wr2.fanDuelID + " " + wr3.fanDuelID + " " + te.fanDuelID + " " + flex.fanDuelID + " " + def.fanDuelID;
                                                                    }

                                                                    if (currentSalary <= Variables.gameCost && currentScore > Variables.minPointLineup)
                                                                    {
                                                                        //String lineup = "Score: " + currentScore + " Salary: " + currentSalary.ToString() + " QB: " + qb.lastName + ", " + qb.firstName + " RB1: " + rb1.lastName + ", " + rb1.firstName + " RB2: " + rb2.lastName + ", " + rb2.firstName + " WR1: " + wr1.lastName + ", " + wr1.firstName + " WR2: " + wr2.lastName + ", " + wr2.firstName + " WR3: " + wr3.lastName + ", " + wr3.firstName + " TE: " + te.lastName + ", " + te.firstName + " FLEX: " + flex.lastName + ", " + flex.firstName + " DEF: " + def.lastName + ", " + def.firstName;
                                                                        //lineups.Add(lineup);
                                                                        DataRow workRow = lineupsTable.NewRow();
                                                                        workRow["cost"] = currentSalary;
                                                                        workRow["score"] = currentScore;
                                                                        workRow["qb"] = qb.firstName + " " + qb.lastName;
                                                                        workRow["rb1"] = rb1.firstName + " " + rb1.lastName;
                                                                        workRow["rb2"] = rb2.firstName + " " + rb2.lastName;
                                                                        workRow["wr1"] = wr1.firstName + " " + wr1.lastName;
                                                                        workRow["wr2"] = wr2.firstName + " " + wr2.lastName;
                                                                        workRow["wr3"] = wr3.firstName + " " + wr3.lastName;
                                                                        workRow["te"] = te.firstName + " " + te.lastName;
                                                                        workRow["flex"] = flex.firstName + " " + flex.lastName;
                                                                        workRow["def"] = def.firstName + " " + def.lastName;
                                                                        lineupsTable.Rows.Add(workRow);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            }
                    }
                }
                threadsDone++;
            }).Start();
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            txtIncomingText.Text = "qb: " + qbCount.ToString() + " wr1: " + wr1Count.ToString() + " RB2: " + rb2Count + " ThreadCount: " + totalThreads + " threadsDone: " + threadsDone;
            txtIncomingText.Text = txtIncomingText.Text + "\nhigh score: " + highScore.ToString() + "\nhigh cost: " + highCost.ToString() + "\nhigh lineup: " + highLineup + "\nhigh lineup csv: " + highLineupIDs;
            txtIncomingText.Text = txtIncomingText.Text + "\nrb2s: " + rb2sdone;
        }

        private void rdoViewLineups_Click(object sender, EventArgs e)
        {

            this.dataGridPlayers.AutoGenerateColumns = true;
            this.dataGridPlayers.Columns.Clear();
            
            dataGridPlayers.DataSource = lineupsTable;
            /*
            txtIncomingText.Text = txtIncomingText.Text + "\nlineups count: " + lineups.Count();
            foreach (String lineup in lineups)
            {
                txtIncomingText.Text = txtIncomingText.Text + "\n" + lineup;
            }*/
        }

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            qbs.Clear();
            rbs1.Clear();
            rbs2.Clear();
            wrs1.Clear();
            wrs2.Clear();
            wrs3.Clear();
            tes.Clear();
            flexs.Clear();
            defs.Clear();
            lineups.Clear();
            lineupsTable.Clear();
            qbCount = 0;
            wr1Count = 0;
            btnRunStats.Enabled = true;
        }

        public void readCSVProFootballFocus(String filepath)
        {
            txtIncomingText.Text = "";
            //C:\Users\michael.march\Downloads\projections.csv
            {
                StreamReader reader = new StreamReader(File.OpenRead(txtIncomingFile.Text));
                //string vara1, vara2, vara3, vara4;
                int linecount = 0;
                while (!reader.EndOfStream)
                {
                    linecount++;
                    txtIncomingText.Text = txtIncomingText.Text + "\n";
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line) && linecount > 2)
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 7)
                        {                            
                            int playerId = Int32.Parse(values[0].Replace("\"", ""));
                            if (playerId > 0) {
                                String playerName = values[1].Replace("\"", "");
                                String lastName = "";
                                String firstName = "";
                                int spaceName = playerName.IndexOf(" ");
                                if (spaceName > 0)
                                {
                                    lastName = playerName.Substring(spaceName + 1);
                                    firstName = playerName.Substring(0, spaceName);
                                }
                                else
                                {
                                    lastName = playerName;
                                }
                                String playerPosition = values[3].Replace("\"", "").ToUpper();
                                String team = values[2].Replace("\"", "");
                                String opponent = values[5];

                                if (playerPosition == "dst" || playerPosition == "DST") {
                                    playerPosition = "D/ST";
                                    lastName = "D/ST";
                                }

                                double playerProjection = Double.Parse(values[6].Replace("\"", ""));

                                Player thisPlayer = new Player();
                                thisPlayer.SetLastName(lastName);
                                thisPlayer.firstName = firstName;
                                thisPlayer.fanDuelCost = -1;
                                thisPlayer.numberfireFanDuelProjection = -1;
                                thisPlayer.rotogrindersFanDuelProjection = -1;
                                thisPlayer.proFootballFocusProjection = playerProjection;
                                thisPlayer.position = playerPosition;
                                thisPlayer.team = values[2].Replace("\"", "");
                                thisPlayer.opponent = values[5].Replace("\"", "");

                                txtIncomingText.Text = txtIncomingText.Text + thisPlayer.ToString() + "\n";

                                UpdatePlayerList(thisPlayer);
                            }
                        }
                    }
                }
            }
        }

        public void readCSVFanDuel(String filepath)
        {
            txtIncomingText.Text = "";
            //C:\Users\michael.march\Downloads\projections.csv
            {
                //StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\michael.march\Downloads\FanDuel-NFL-2018-09-16-28171-players-list.csv"));
                StreamReader reader = new StreamReader(File.OpenRead(txtIncomingFile.Text));
                //string vara1, vara2, vara3, vara4;
                int linecount = 0;
                while (!reader.EndOfStream)
                {
                    linecount++;
                    txtIncomingText.Text = txtIncomingText.Text + "\n";
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line) && linecount > 1)
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 7)
                        {
                            int playerId = values[0].Length;
                            if (playerId > 0)
                            {
                                String lastName = values[4].Replace("\"", "");
                                String firstName = values[2].Replace("\"", "");

                                String playerPosition = values[1].Replace("\"", "").ToUpper();
                                if (playerPosition == "D")
                                {
                                    playerPosition = "D/ST";
                                    lastName = "D/ST";
                                }
                                String team = values[9].Replace("\"", "");
                                String opponent = values[10].Replace("\"", "");

                                int cost = Int32.Parse(values[7].Replace("\"", ""));

                                Player thisPlayer = new Player();
                                thisPlayer.SetLastName(lastName);
                                thisPlayer.firstName = firstName;
                                thisPlayer.fanDuelCost = cost;
                                thisPlayer.numberfireFanDuelProjection = -1;
                                thisPlayer.rotogrindersFanDuelProjection = -1;
                                thisPlayer.proFootballFocusProjection = -1;
                                thisPlayer.position = playerPosition;
                                thisPlayer.team = team;
                                thisPlayer.opponent = opponent;
                                thisPlayer.fanDuelID = values[0].Replace("\"", "");

                                txtIncomingText.Text = txtIncomingText.Text + thisPlayer.ToString() + "\n";

                                UpdatePlayerList(thisPlayer);
                            }
                        }
                    }
                }
            }
        }

        private void rdoRotoWire_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtIncomingFile.Text = file.FileName;
            }
        }

        private void UpdateTeamAvailability()
        {
            Variables.teamEligible.Clear();
            try
            {
                if (chkArizona.Checked)
                {
                    Variables.teamEligible.Add("ARI", true);
                }
                else
                {
                    Variables.teamEligible.Add("ARI", false);
                }
                if (chkAtlanta.Checked)
                {
                    Variables.teamEligible.Add("ATL", true);
                }
                else
                {
                    Variables.teamEligible.Add("ATL", false);
                }
                if (chkBaltimore.Checked)
                {
                    Variables.teamEligible.Add("BAL", true);
                }
                else
                {
                    Variables.teamEligible.Add("BAL", false);
                }
                if (chkBuffalo.Checked)
                {
                    Variables.teamEligible.Add("BUF", true);
                }
                else
                {
                    Variables.teamEligible.Add("BUF", false);
                }
                if (chkCarolina.Checked)
                {
                    Variables.teamEligible.Add("CAR", true);
                }
                else
                {
                    Variables.teamEligible.Add("CAR", false);
                }
                if (chkChicago.Checked)
                {
                    Variables.teamEligible.Add("CHI", true);
                }
                else
                {
                    Variables.teamEligible.Add("CHI", false);
                }
                if (chkCincinnati.Checked)
                {
                    Variables.teamEligible.Add("CIN", true);
                }
                else
                {
                    Variables.teamEligible.Add("CIN", false);
                }
                if (chkCleveland.Checked)
                {
                    Variables.teamEligible.Add("CLE", true);
                }
                else
                {
                    Variables.teamEligible.Add("CLE", false);
                }
                if (chkDallas.Checked)
                {
                    Variables.teamEligible.Add("DAL", true);
                }
                else
                {
                    Variables.teamEligible.Add("DAL", false);
                }
                if (chkDenver.Checked)
                {
                    Variables.teamEligible.Add("DEN", true);
                }
                else
                {
                    Variables.teamEligible.Add("DEN", false);
                }
                if (chkDetroit.Checked)
                {
                    Variables.teamEligible.Add("DET", true);
                }
                else
                {
                    Variables.teamEligible.Add("DET", false);
                }
                if (chkGreenBay.Checked)
                {
                    Variables.teamEligible.Add("GB", true);
                }
                else
                {
                    Variables.teamEligible.Add("GB", false);
                }
                if (chkHouston.Checked)
                {
                    Variables.teamEligible.Add("HOU", true);
                }
                else
                {
                    Variables.teamEligible.Add("HOU", false);
                }
                if (chkIndianapolis.Checked)
                {
                    Variables.teamEligible.Add("IND", true);
                }
                else
                {
                    Variables.teamEligible.Add("IND", false);
                }
                if (chkJacksonville.Checked)
                {
                    Variables.teamEligible.Add("JAC", true);
                }
                else
                {
                    Variables.teamEligible.Add("JAC", false);
                }
                if (chkKansasCity.Checked)
                {
                    Variables.teamEligible.Add("KC", true);
                }
                else
                {
                    Variables.teamEligible.Add("KC", false);
                }
                if (chkLAChargers.Checked)
                {
                    Variables.teamEligible.Add("LAC", true);
                }
                else
                {
                    Variables.teamEligible.Add("LAC", false);
                }
                if (chkLARams.Checked)
                {
                    Variables.teamEligible.Add("LAR", true);
                }
                else
                {
                    Variables.teamEligible.Add("LAR", false);
                }
                if (chkMiami.Checked)
                {
                    Variables.teamEligible.Add("MIA", true);
                }
                else
                {
                    Variables.teamEligible.Add("MIA", false);
                }
                if (chkMinnesota.Checked)
                {
                    Variables.teamEligible.Add("MIN", true);
                }
                else
                {
                    Variables.teamEligible.Add("MIN", false);
                }
                if (chkNewEngland.Checked)
                {
                    Variables.teamEligible.Add("NE", true);
                }
                else
                {
                    Variables.teamEligible.Add("NE", false);
                }
                if (chkNewOrleans.Checked)
                {
                    Variables.teamEligible.Add("NO", true);
                }
                else
                {
                    Variables.teamEligible.Add("NO", false);
                }
                if (chkNewYorkGiants.Checked)
                {
                    Variables.teamEligible.Add("NYG", true);
                }
                else
                {
                    Variables.teamEligible.Add("NYG", false);
                }
                if (chkNewYorkJets.Checked)
                {
                    Variables.teamEligible.Add("NYJ", true);
                }
                else
                {
                    Variables.teamEligible.Add("NYJ", false);
                }
                if (chkOakland.Checked)
                {
                    Variables.teamEligible.Add("OAK", true);
                }
                else
                {
                    Variables.teamEligible.Add("OAK", false);
                }
                if (chkPhiladelphia.Checked)
                {
                    Variables.teamEligible.Add("PHI", true);
                }
                else
                {
                    Variables.teamEligible.Add("PHI", false);
                }
                if (chkPittsburgh.Checked)
                {
                    Variables.teamEligible.Add("PIT", true);
                }
                else
                {
                    Variables.teamEligible.Add("PIT", false);
                }
                if (chkSanFrancisco.Checked)
                {
                    Variables.teamEligible.Add("SF", true);
                }
                else
                {
                    Variables.teamEligible.Add("SF", false);
                }
                if (chkSeattle.Checked)
                {
                    Variables.teamEligible.Add("SEA", true);
                }
                else
                {
                    Variables.teamEligible.Add("SEA", false);
                }
                if (chkTampaBay.Checked)
                {
                    Variables.teamEligible.Add("TB", true);
                }
                else
                {
                    Variables.teamEligible.Add("TB", false);
                }
                if (chkTenessee.Checked)
                {
                    Variables.teamEligible.Add("TEN", true);
                }
                else
                {
                    Variables.teamEligible.Add("TEN", false);
                }
                if (chkWashington.Checked)
                {
                    Variables.teamEligible.Add("WAS", true);
                }
                else
                {
                    Variables.teamEligible.Add("WAS", false);
                }
            }
            catch (ArgumentException)
            {
                txtIncomingText.Text = "Teams already set";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    public struct PlayerStats
    {
        public int id;
        public String lastName;
        public String firstName;
        public String position;
        public String fanDuelID;
        public int fanDuelCost;
        public int fanDuelProjection;
    }
}
