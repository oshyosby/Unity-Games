namespace Extensions {
    
    using Interfaces;
    using Framework;

    public static class MenuExtension {

        public static void NewGame(this GameInterface game) {
            Console.WriteLine("New Game");
        } 
    }
}