using System.Collections.Generic;

public class Coach {
    public string id;
    public string name;
    public string personId;
    public string gymId;

    public Record RecordVersion() {
        Dictionary<string,object> data = new Dictionary<string,object>{
            {"name",name},{"personId",personId},{"gymId",gymId}
        };
        Record record = new Record(name,"coach",data);
        record.id = id;
        return record;
    }

    public static Coach Get(Record record) {
        if(record.type != "coach") {
            return null;
        } else {
            Coach coach = new Coach(
                (string)record.data["name"],
                (string)record.data["personId"],
                (string)record.data["gymId"]
            );
            coach.id = record.id;
            return coach;
        }
    } 

    public Coach(string name, string personId, string gymId) {
        this.name = name;
        this.personId = personId;
        this.gymId = gymId;
    }

    public void Push() {
        Record record = RecordVersion();
        GameManager.Instance().DataManager().Add(record);
        id = record.id;
    }
}