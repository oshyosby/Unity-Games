using System.Collections.Generic;

public class Gym {
    public string id;
    public string name;
    public string ownerId;
    public Record recordVersion;

    public void PrepareRecord() {
        Dictionary<string,object> data = new Dictionary<string,object>{
            {"name",name},{"ownerId",ownerId}
        };
        Record record = new Record(name,"gym",data);
        record.id = id;
        recordVersion = record;
    }

    public Gym(string name, Person owner) {
        this.name = name;
        ownerId = owner.id;
        PrepareRecord();
    }

    public void Push() {
        GameManager.Instance().DataManager().Add(recordVersion);
    }
}