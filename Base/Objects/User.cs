using DataModel;

namespace Objects;
public class User : ObjectRecord {
    
    public User(string name, string firstName, string lastName) : base("user") {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName {
        get => (string)this["firstName"] ?? "";
        set {
            if(data.ContainsKey("firstName")) {
                this["firstName"] = value;
            } else {
                data.Add("firstName",value);
            }
        }
    }

    public string LastName {
        get => (string)this["lastName"] ?? "";
        set {
            if(data.ContainsKey("lastName")) {
                this["lastName"] = value;
            } else {
                data.Add("lastName",value);
            }
        }
    }

    public override ObjectType ObjectType {
        get => DataModel.User.Info;
    }
}