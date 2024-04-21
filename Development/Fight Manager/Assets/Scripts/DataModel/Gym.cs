using System.Collections.Generic;

public class Gym {
    public string id;
    public string name;
    public string ownerId;

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
                (string)record.data["name"],
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

    public Person GetOwner() {
        return Person.Get(GameManager.Instance().DataManager().RecordDataQuery("person","id",ownerId));
    }
    public void TrainingCoach() {
        Person person = GetOwner();
        Coach coach = new Coach(person.FullName(), person.id, id);
        coach.Push();
    }

    public List<Coach> GetCoaches() {
        List<Coach> coaches = new List<Coach>();
        foreach(Record coach in GameManager.Instance().DataManager().RecordsDataQuery("coach","gymId",id)) {
            coaches.Add(Coach.Get(coach));
        }
        return coaches;
    }

    public List<Fighter> GetFighters() {
        List<Fighter> fighters = new List<Fighter>();
        foreach(Record fighter in GameManager.Instance().DataManager().RecordsDataQuery("fighter","gymId",id)) {
            fighters.Add(Fighter.Get(fighter));
        }
        return fighters;
    }
}