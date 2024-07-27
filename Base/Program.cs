using Framework;

public class Program {
    public static void Main() {
        
        MiniGames.RockPaperScissors.Game rps = new MiniGames.RockPaperScissors.Game();
        rps.Run();
        /*
        Record player1 = rps.NewPlayer("Test","1");
        Record player2 = rps.NewPlayer("Test","2");
        Record match = rps.NewMatch(player1,player2);
        Console.WriteLine($"Game Instance Name: {Game.Instance.Name}");
        foreach(Record record in Game.Instance.SDataModel.Records) {
            Console.WriteLine($"Record Name: {record.Id}");
            Console.WriteLine($"Record Name: {record.Name}");
        }
        */
    }
}
