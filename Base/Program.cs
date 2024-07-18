using SData;
public class Program {
    public static void Main() {
        SObject newObj = new SObject("account","Account");
        Console.WriteLine($"Inputted Name: {newObj.Name()}");
        Console.WriteLine($"Inputted Label: {newObj.Label()}");
        newObj.Insert();
        SObject? accountObj = SDataModel.Instance().GetSObjectByName("account");
        if(accountObj == null) {
            return;
        }
        Console.WriteLine($"Account Object Name: {accountObj.Name()}");
        Console.WriteLine($"Account Object Label: {accountObj.Label()}");
        Record accountRecord = accountObj.NewRecord();
        accountRecord.SetDataValueByField("name","Test Account");
        foreach(string fieldName in accountRecord.Data().Keys) {
            Console.WriteLine($"Field Name: {fieldName}");
            Console.WriteLine($"Field Value: {accountRecord.Data()[fieldName]}");
        }
    }
}
