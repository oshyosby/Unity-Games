namespace DataModel;
public class ObjectRecord {

    public ObjectRecord(string objectName) {
        Id = "";
        ObjectName = objectName;
    }

    public ObjectRecord(Dictionary<string,object> data) {
        this.data = data; 
    }
    
    public string Id {
        get => (string)this["id"];
        set => this["id"] = value;
    }

    public virtual string Name {
        get => (string)this["name"];
        set => this["name"] = value;
    }

    public string ObjectName {
        get => (string)this["objectName"];
        set {
            if(data.ContainsKey("objectName")) {
                this["objectName"] = value;
            } else {
                data.Add("objectName",value);
            }
        }
    }

    public virtual ObjectType ObjectType {
        get => new ObjectType();
    }

    protected Dictionary<string,object> data = new Dictionary<string,object>();
    public Dictionary<string,object> Data {
        get => data;
    }

    public object this[string fieldName] {
        get => data[fieldName] ?? typeof(Nullable);
        set {
            data[fieldName] = value;
        } 
    } 

    public void Insert() {
        ObjectType.DML(this,DML_TYPES.INSERT);
    }
    public void Update() {
        ObjectType.DML(this,DML_TYPES.UPDATE);
    }
    public void Delete() {
        ObjectType.DML(this,DML_TYPES.DELETE);
    }
}