using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyFantasyNFL
{
    class Player
    {
        public int id;
        private String lastName;
        public String firstName;
        public String position;
        public String team;
        public String opponent;
        public String gameDay;
        public int fanDuelCost;
        public double rotogrindersFanDuelProjection;
        public double numberfireFanDuelProjection;
        public double proFootballFocusProjection;
        public String fanDuelID;

        public Player()
        {
            lastName = "";
            firstName = "";
            position = "";
            fanDuelCost = -1;
            rotogrindersFanDuelProjection = -1;
            numberfireFanDuelProjection = -1;
            proFootballFocusProjection = -1;
            team = "";
            opponent = "";
            gameDay = "";
            id = -1;
            fanDuelID = "0";
        }

        public void SetLastName(String newLastName)
        {
            if (newLastName.Contains(" ")) {
                lastName = newLastName.Substring(0, newLastName.IndexOf(" "));
            } else {
                lastName = newLastName;
            }
        }

        public String getLastName() {
            return lastName;
        }

        public void SetTeamNumFire(String newTeam)
        {
            if (newTeam == "LA")
            {
                team = "LAR";
            }
            else
            {
                team = newTeam;
            }
        }

        public double getExpectedValue()
        {
            //return (numberfireFanDuelProjection + rotogrindersFanDuelProjection + proFootballFocusProjection) / 3;
            return proFootballFocusProjection;
        }

        public double playerValue()
        {
            return getExpectedValue() * 10000 / fanDuelCost;
        }

        public String print()
        {
            return lastName + ", " + firstName + " Pos: " + position + " Cost: " + fanDuelCost.ToString() + " rotoProjection: " + rotogrindersFanDuelProjection.ToString() + " numfireProj: " + numberfireFanDuelProjection.ToString();
        }

        public bool isValidForStart()
        {
            foreach (int exclude in Variables.excludePlayer)
            {
                if (id == exclude)
                {
                    return false;
                }
            }
            if (position == "QB" && playerValue() < Variables.minQBValue)
            {
                return false;
            }
        
            bool validStart = false;
            if (!Variables.teamEligible[team])
            {
                return false;
            }
            if (getExpectedValue() > Variables.minPlayerPoints)
            {
                validStart = true;
            }
            //return numberfireFanDuelProjection > 0 && rotogrindersFanDuelProjection > 0 && validStart;
            return validStart;
        }

        public override string ToString()
        {
            return lastName + ", " + firstName + " Pos: " + position + " Cost: " + fanDuelCost.ToString() + " rotoProjection: " + rotogrindersFanDuelProjection.ToString() + " numfireProj: " + numberfireFanDuelProjection.ToString() + " playerValue: " + playerValue();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Player);
        }

        public bool Equals(Player p)
        {
            return this.id == p.id;
        }

        public DataRow CreateDataRow(DataRow workRow)
        {
            workRow["id"] = id;
            workRow["lastName"] = lastName;
            workRow["firstName"] = firstName;
            workRow["fanDuelCost"] = fanDuelCost;
            workRow["numberfireFanDuelProjection"] = numberfireFanDuelProjection;
            workRow["rotogrindersFanDuelProjection"] = rotogrindersFanDuelProjection;
            workRow["proFootballFocusProjection"] = proFootballFocusProjection;
            workRow["position"] = position;
            workRow["fanDuelValue"] = getExpectedValue() * 10000 / fanDuelCost;
            workRow["team"] = team;
            workRow["opponent"] = opponent;
            workRow["gameday"] = gameDay;
            workRow["pointsProjection"] = getExpectedValue();
            return workRow;
        }

        public PlayerStats GenerateStruct()
        {
            PlayerStats newStruct = new PlayerStats();
            newStruct.lastName = lastName;
            newStruct.firstName = firstName;
            newStruct.position = position;
            newStruct.fanDuelID = fanDuelID;
            newStruct.fanDuelCost = fanDuelCost;
            newStruct.fanDuelProjection = Convert.ToInt32(getExpectedValue());
            newStruct.id = id;
            return newStruct;
        }
    }
}
