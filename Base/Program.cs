using Framework;
using MiniGames;
public class Program {
    public static void Main() {
        
        RockPaperScissors rps = new RockPaperScissors();
        Record player1 = rps.NewPlayer("Test","1");
        Record player2 = rps.NewPlayer("Test","2");
        Record match = rps.NewMatch(player1,player2);
        Console.WriteLine($"Game Instance Name: {Game.Instance.Name}");
        foreach(Record record in Game.Instance.SDataModel.Records) {
            Console.WriteLine($"Record Name: {record.Id}");
            Console.WriteLine($"Record Name: {record.Name}");
        }
    }
}
