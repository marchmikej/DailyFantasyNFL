using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        DataTable playersTable = new DataTable("Players");

        int minHighScore = 100;
        int maxCost = 60000;
        int highScore = 0;
        int highCost = 0;
        int qbCount = 0;
        int wr1Count = 0;

        public Form1()
        {
            InitializeComponent();
            playersTable.Columns.Add("position", typeof(System.String));
            playersTable.Columns.Add("lastName", typeof(System.String));
            playersTable.Columns.Add("firstName", typeof(System.String));
            playersTable.Columns.Add("fanDuelCost", typeof(System.Int32));
            playersTable.Columns.Add("numberfireFanDuelProjection", typeof(System.Int32));
            playersTable.Columns.Add("rotogrindersFanDuelProjection", typeof(System.Int32));
            playersTable.Columns.Add("fanDuelValue", typeof(System.Int32));
            dataGridPlayers.DataSource = playersTable;
            txtMinHighScore.Text = minHighScore.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rdoRotoGrinders.Checked)
            {
                radioRotGrindersNFL();
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
                radioRotoWireNFL("https://www.rotowire.com/daily/nfl/optimizer.php?site=FanDuel&slate=Main&type=main");
            }
        }

        private void radioRotoWireNFL(String url)
        {
            String NFLFile = txtIncomingText.Text;
            //int playerLocal = NFLFIle.IndexOf("<a class=\"full\" href=\"");
            //using (WebClient client = new WebClient())
            //{
            //    NFLFile = client.DownloadString(url);
            //}
            txtIncomingText.Text = NFLFile;

            int playerLocal = NFLFile.IndexOf("data-name=\"");
            txtIncomingText.Text = "";
            while (playerLocal > 0)
            {
                NFLFile = NFLFile.Substring(playerLocal + 2);

                //Player Name Start
                int locStart = NFLFile.IndexOf("\"");
                int locEnd = NFLFile.IndexOf("\">");
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
                txtIncomingText.Text = txtIncomingText.Text + playerName + "\n";
                playerLocal = NFLFile.IndexOf("data-name=\"");
            }
        }

            private void radioNumFireNFL(String url)
        {
            String NFLFIle = txtIncomingText.Text;
            //int playerLocal = NFLFIle.IndexOf("<a class=\"full\" href=\"");
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
                thisPlayer.lastName = lastName;
                thisPlayer.firstName = firstName;
                thisPlayer.fanDuelCost = playerFanDuelSalary;
                thisPlayer.numberfireFanDuelProjection = playerPoints;
                if (playerPosition == "D/ST")
                {
                    thisPlayer.rotogrindersFanDuelProjection = playerPoints;
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

        private void radioRotGrindersNFL()
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
                thisPlayer.lastName = lastName;
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
                if (player.lastName == newPlayer.lastName && player.firstName == newPlayer.firstName && player.position == newPlayer.position)
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
                    if (player.fanDuelCost == -1)
                    {
                        player.fanDuelCost = newPlayer.fanDuelCost;
                    }
                    return false;
                }
            }
            players.Add(newPlayer);
            DataRow workRow = playersTable.NewRow();
            playersTable.Rows.Add(newPlayer.CreateDataRow(workRow));
            return true;
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
            playersTable.Clear();
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
            minHighScore = Int32.Parse(txtMinHighScore.Text);
            int count = 1;
            foreach (Player player in players)
            {
                player.id = count;
                count++;
                if (player.isValidForStart() && player.playerValue() > minValue)
                {
                    if (player.position == "QB")
                    {
                        qbs.Add(player.GenerateStruct());
                    }
                    else if (player.position == "RB")
                    {
                        rbs1.Add(player.GenerateStruct());
                        rbs2.Add(player.GenerateStruct());
                    }
                    else if (player.position == "WR")
                    {
                        wrs1.Add(player.GenerateStruct());
                        wrs2.Add(player.GenerateStruct());
                        wrs3.Add(player.GenerateStruct());
                    }
                    else if (player.position == "TE")
                    {
                        tes.Add(player.GenerateStruct());
                    }
                    else if (player.position == "D/ST")
                    {
                        defs.Add(player.GenerateStruct());
                    }
                    if (player.position == "RB" || player.position == "WR")
                    {
                        flexs.Add(player.GenerateStruct());
                    }
                }
            }

            new Thread(() =>
            {
                foreach (PlayerStats qb in qbs)
                {
                    int currentScore = 0;
                    int currentSalary = 0;
                    qbCount++;
                    foreach (PlayerStats rb1 in rbs1)
                    {
                        foreach (PlayerStats rb2 in rbs2)
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
                                                                    if (currentSalary < 60000 && currentScore > highScore)
                                                                    {
                                                                        highCost = currentSalary;
                                                                        highScore = currentScore;
                                                                        highLineup = "QB: " + qb.lastName + ", " + qb.firstName + "RB1: " + rb1.lastName + ", " + rb1.firstName + "RB2: " + rb2.lastName + ", " + rb2.firstName + "WR1: " + wr1.lastName + ", " + wr1.firstName + "WR2: " + wr2.lastName + ", " + wr2.firstName + "WR3: " + wr3.lastName + ", " + wr3.firstName + "TE: " + te.lastName + ", " + te.firstName + "FLEX: " + flex.lastName + ", " + flex.firstName + "DEF: " + def.lastName + ", " + def.firstName;
                                                                    }

                                                                    if (currentSalary <= maxCost && currentScore > minHighScore)
                                                                    {
                                                                        String lineup = "Score: " + currentScore + " Salary: " + currentSalary.ToString() + " QB: " + qb.lastName + ", " + qb.firstName + " RB1: " + rb1.lastName + ", " + rb1.firstName + " RB2: " + rb2.lastName + ", " + rb2.firstName + " WR1: " + wr1.lastName + ", " + wr1.firstName + " WR2: " + wr2.lastName + ", " + wr2.firstName + " WR3: " + wr3.lastName + ", " + wr3.firstName + " TE: " + te.lastName + ", " + te.firstName + " FLEX: " + flex.lastName + ", " + flex.firstName + " DEF: " + def.lastName + ", " + def.firstName;
                                                                        lineups.Add(lineup);
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
            }).Start();
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            txtIncomingText.Text = "qb: " + qbCount.ToString() + "wr1: " + wr1Count.ToString();
            txtIncomingText.Text = txtIncomingText.Text + "\nhigh score: " + highScore.ToString() + "\nhigh cost: " + highCost.ToString() + "\nhigh lineup: " + highLineup;
            txtIncomingText.Text = txtIncomingText.Text + "\nlineups count: " + lineups.Count();
        }

        private void rdoViewLineups_Click(object sender, EventArgs e)
        {
            txtIncomingText.Text = txtIncomingText.Text + "\nlineups count: " + lineups.Count();
            foreach (String lineup in lineups)
            {
                txtIncomingText.Text = txtIncomingText.Text + "\n" + lineup;
            }
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
            qbCount = 0;
            wr1Count = 0;
            btnRunStats.Enabled = true;
        }
    }
    public struct PlayerStats
    {
        public int id;
        public String lastName;
        public String firstName;
        public String position;
        public int fanDuelCost;
        public int fanDuelProjection;
    }
}
