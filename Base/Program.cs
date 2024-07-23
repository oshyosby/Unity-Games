using Framework;

public class Program {
    public static void Main() {
        SObject newObj = new SObject("account","Account","acc");
        newObj.Insert();
        SObject? accountObj = SDataModel.Instance().GetSObjectByName("account");
        if(accountObj == null) {
            return;
        }
        Record accountRecord1 = accountObj.NewRecord();
        Record accountRecord2 = accountObj.NewRecord();
        accountRecord1.SetDataValueByField("name","Test Account 1");
        accountRecord2.SetDataValueByField("name","Test Account 2");
        accountRecord1.Insert();
        accountRecord2.Insert();
        foreach(Record record in SDataModel.Instance().GetRecords()) {
            foreach(string fieldName in record.Data().Keys) {
                Console.WriteLine($"Field Name: {fieldName}");
                Console.WriteLine($"Field Value: {record.Data()[fieldName]}");
            }
        }
    }
}
