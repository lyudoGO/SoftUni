using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.GameEngine;


namespace TheSlum
{
    public class StarGame : Engine
    {
        protected override void CreateCharacter(string[] inputParams)
        {
            Character character = null;
            Team team = 0;
            if (inputParams[5] == "Red")
            {
                team = Team.Red;
            }

            if (inputParams[5] == "Blue")
            {
                team = Team.Blue;
            }

            switch (inputParams[1])
            {
                case "warrior":
                    character = new Warrior(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 100, 50, team, 5, 80);
                    break;
                case "mage":
                    character = new Mage(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 100, 80, team, 20, 90);
                    break;
                case "healer":
                    character = new Healer(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 100, 10, team, 5, 50);
                    break;
                default:
                    break;
            }

            this.characterList.Add(character);
        }

        public new void AddItem(string[] inputParams) 
        {
            Item item = null;
            switch (inputParams[2])
            {
                case "axe":
                    item = new Axe(inputParams[3]);
                    break;
                case "shield":
                    item = new Shield(inputParams[3]);
                    break;
                case "injection":
                    item = new Injection(inputParams[3]);
                    break;
                case "pill":
                    item = new Pill(inputParams[3]);
                    break;
                default:
                    break;
            }

            this.characterList.First(x => x.Id == inputParams[1]).AddToInventory(item);
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }
    }
}
