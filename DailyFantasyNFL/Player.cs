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
        public String lastName;
        public String firstName;
        public String position;
        public int fanDuelCost;
        public double rotogrindersFanDuelProjection;
        public double numberfireFanDuelProjection;
        public double proFootballFocusProjection;
        public double playerStartValue;

        public Player()
        {
            playerStartValue = 3;
            lastName = "";
            firstName = "";
            position = "";
            fanDuelCost = -1;
            rotogrindersFanDuelProjection = -1;
            numberfireFanDuelProjection = -1;
            proFootballFocusProjection = -1;
            id = -1;
        }

        public double getExpectedValue()
        {
            return (numberfireFanDuelProjection + rotogrindersFanDuelProjection + proFootballFocusProjection) / 3;
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
            bool validStart = false;
            if (getExpectedValue() > playerStartValue)
            {
                validStart = true;
            }
            return numberfireFanDuelProjection > 0 && rotogrindersFanDuelProjection > 0 && validStart;
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
            workRow["lastName"] = lastName;
            workRow["firstName"] = firstName;
            workRow["fanDuelCost"] = fanDuelCost;
            workRow["numberfireFanDuelProjection"] = numberfireFanDuelProjection;
            workRow["rotogrindersFanDuelProjection"] = rotogrindersFanDuelProjection;
            workRow["proFootballFocusProjection"] = proFootballFocusProjection;
            workRow["position"] = position;
            workRow["fanDuelValue"] = getExpectedValue() * 10000 / fanDuelCost;
            return workRow;
        }

        public PlayerStats GenerateStruct()
        {
            PlayerStats newStruct = new PlayerStats();
            newStruct.lastName = lastName;
            newStruct.firstName = firstName;
            newStruct.position = position;
            newStruct.fanDuelCost = fanDuelCost;
            newStruct.fanDuelProjection = Convert.ToInt32(getExpectedValue());
            newStruct.id = id;
            return newStruct;
        }
    }
}
