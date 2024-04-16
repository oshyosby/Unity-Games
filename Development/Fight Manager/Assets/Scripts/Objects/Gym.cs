using System.Collections.Generic;

public class Gym {
    public string id;
    public string name;
    public string ownerId;
    public Record recordVersion;

    public Record RecordVersion() {
        Dictionary<string,object> data = new Dictionary<string,object>{
            {"name",name},{"ownerId",ownerId}
        };
        Record record = new Record(name,"gym",data);
        record.id = id;
        return record;
    }

    public static Gym Get(Record record) {
        if(record.type != "gym") {
            return null;
        } else {
            Gym gym = new Gym(
                record.name,
                (string)record.data["ownerId"]
            );
            gym.id = record.id;
            return gym;
        }
    } 

    public Gym(string name, string ownerId) {
        this.name = name;
        this.ownerId = ownerId;
    }

    public void Push() {
        Record record = RecordVersion();
        GameManager.Instance().DataManager().Add(record);
        id = record.id;
    }
}