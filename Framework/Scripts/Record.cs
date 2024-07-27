// Script Object Record

namespace Framework;
public class Record {

    private Dictionary<string,object> _data;
    public Dictionary<string,object> Data() {
        return _data;
    }
    
    public Record(SObject sObject) {
        _data = new Dictionary<string,object>();
        foreach(Field field in sObject.Fields()) {
            _data.Add(field.Name(),field.Name() == "sObjectName" ? sObject.Name() : "");
        }
    }
    
    public object GetDataByField(string field) {
        return _data[field];
    }
    public void SetDataValueByField(string field, object value) {
        _data[field] = value;
    }

    public string Id {
        get {
            return (string)GetDataByField("id");
        }
        set {
            SetDataValueByField("id", value);
        }
    }
    public string Name {
        get {
            return (string)GetDataByField("name");
        }
        set {
            SetDataValueByField("name",value);
        }
    }

    public string SObjectName {
        get {
            return (string)GetDataByField("sObjectName");
        }
        set {
            SetDataValueByField("sObjectName",value);
        }
    }

    public void Insert() {
        if(!string.IsNullOrEmpty(Id)) {return;}
        Game.Instance.SDataModel.AddRecord(this);
    }
}