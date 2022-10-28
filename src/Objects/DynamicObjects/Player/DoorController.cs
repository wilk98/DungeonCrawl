﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class DoorController : Controller<Door>
    {
        Door? latestFound;
        bool DoorIsOpened = false;
        public DoorController(Map map, Player player) : base(map, player)
        {
        }

        protected override AskDialog GetInfo(Door foundedItem)
        {
            if (latestFound == null)
            {
                latestFound = foundedItem;
                return new AskDialog($"Open '{foundedItem.Name}'?", new Tuple<string, string>("Yes", "No"), OnFound);
            }
            if (!DoorIsOpened)
            {
                latestFound = null;
                return new InfoDialog("You can't open this door", "Ok", EmptyDialog);       
            }
            return new AskDialog("Opened! Start next level?", new Tuple<string, string>("Yes", "No"), EndGame);        
        }

        private void EndGame(bool accepted)
        {
            if (accepted)
            {
                Console.Clear();
                Console.WriteLine("Game over, thank you for playing!");
                Environment.Exit(0);
            }
            IgnoreItemSearching = 2;
        }

        internal override void OnFound(bool accepted)
        {
            if (latestFound is null || !accepted)
            {
                IgnoreItemSearching = 2;
                latestFound = null;
                return;
            }
            var keys = player.Inventory.GetItems().Where(item => item is Key);
            DoorIsOpened = keys.Any(key => latestFound.CanBeOpened((Key) key));
        }
        internal void EmptyDialog(bool accepted)
        {
            IgnoreItemSearching = 2;
        }
    }
}
