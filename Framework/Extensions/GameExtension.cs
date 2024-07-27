namespace Extensions {

    using Interfaces;
    using System.Linq;

    public static class GameExtension {
        public static void Run(this GameInterface game) {
            Console.WriteLine($"Run Game: {game.Name}");
            Console.WriteLine("Game Loading Sequence");
            // Check for Existing Saves
            Saves(game,"check");
            // Existing Saves ? Provide Resume & Saved Games Options : Only New Game & Settings
            Menu(game);
        }
        public static void Action(this GameInterface game) {
            Console.WriteLine("Game Action");
        }
        public static void Stop(this GameInterface game) {
            Console.WriteLine("Stop Game");
        }

        public static void Menu(this GameInterface game) {
            Console.WriteLine("Game Menu");
            Dictionary<int,string> menuItems = game.SDataModel.GetRecordsBySObjectName("menuItem").Where(x => (bool)x["isActive"] == true).ToDictionary(x => (int)x["order"],x => (string)x["label"]);
            foreach(int menuItem in menuItems.Keys) {
                Console.WriteLine($"{menuItem} : {menuItems[menuItem]}");
            }
            bool hasSelected = false; 
            int selectedItem = -1;
            while(hasSelected == false) {
                if(int.TryParse(Console.ReadLine(), out selectedItem)) {
                    if(menuItems.ContainsKey(selectedItem)) {
                        hasSelected = true;
                        continue;
                    }
                    Console.WriteLine("Enter a valid value");
                } else {
                    Console.WriteLine("Enter an integer value");
                }
            }
            switch(menuItems[selectedItem]) {
                case "New Game":
                    MenuExtension.NewGame(game);
                    break;
                case "settings":
                    break;
                default:
                    break;
            }
        }
        public static void Saves(this GameInterface game, string action) {
            Console.WriteLine($"Game Saves Action: {action}");
            switch(action) {
                case "check":
                    Console.WriteLine("Check Saves");
                    SaveExtension.Check(game);
                    break;
                case "open":
                    Console.WriteLine("Open Saves");
                    break;
                default:
                    break;
            }
            return;
        }
        public static void Settings(this GameInterface game) {
            Console.WriteLine("Game Settings");
        }
    }
}
