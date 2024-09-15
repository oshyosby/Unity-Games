using Objects;

public class Program {
    public static void Main() {
        User newUser = new User("oscar-shen","Oscar","Shanagher");
        Console.WriteLine($"User Name: {newUser.Name}");
        newUser.Insert();
        Console.WriteLine($"User Id: {newUser.Id}");
    }
}
