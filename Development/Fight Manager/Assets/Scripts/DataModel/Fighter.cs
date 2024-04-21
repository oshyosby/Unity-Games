using System.Collections.Generic;

public class Fighter {
    public string id;
    public string name;
    public string personId;
    public string gymId;
    public FightRecord fightRecord = new FightRecord();

    public Record RecordVersion() {
        Dictionary<string,object> data = new Dictionary<string,object>{
            {"name",name},{"personId",personId},{"gymId",gymId},{"fightRecord",fightRecord}
        };
        Record record = new Record(name,"fighter",data);
        record.id = id;
        return record;
    }

    public static Fighter Get(Record record) {
        if(record.type != "fighter") {
            return null;
        } else {
            Fighter fighter = new Fighter(
                (string)record.data["name"],
                (string)record.data["personId"],
                (string)record.data["gymId"]
            );
            fighter.fightRecord = (FightRecord)record.data["fightRecord"];
            fighter.id = record.id;
            return fighter;
        }
    } 

    public Fighter(string name, string personId, string gymId) {
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

public class FightRecord {
    public Dictionary<string,int> stats = new Dictionary<string,int>{
        {"wins",0},{"draws",0},{"losses",0},{"nc",0},{"dq",0}
    };

    public void AddResults(List<string> results) {
        foreach(string result in results) {
            stats[result] += 1;
        }
    } 
    public void ReverseResults(List<string> results) {
        foreach(string result in results) {
            stats[result] -= 1;
        }
    } 
}