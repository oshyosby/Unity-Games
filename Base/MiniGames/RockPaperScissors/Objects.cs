using Framework;
public class Objects {
    private static SObject Match() {
        SObject sObject = new SObject("match","Match","mat");
        List<Field> fields = new List<Field>{
            new Field("player1","Player 1","lookup",true),
            new Field("player2","Player 2","lookup",true),
            new Field("winner","Winner","string",true),
            new Field("winningMove","Winning Move","string",false)
        };
        sObject.NewFields(fields);
        return sObject;
    }
    
}