// Script Object Record

namespace Framework;
public class Record {

    private Dictionary<string,object> _data;
    public Dictionary<string,object> Data() {
        return _data;
    }
    
    public Record(Dictionary<string,object> fieldValues) {
        _data = fieldValues;
    }
    
    public object this[string fieldName] {
        get {
            if(_data.ContainsKey(fieldName)) {
                return _data[fieldName];
            } else {
                throw new Exception($"Field named {fieldName} not found");
            }
        }
        set {
            if(_data.ContainsKey(fieldName)) {
                _data[fieldName] = value;
            } else {
                _data.Add(fieldName, value);
            }
        }
    }
    
    public Dictionary<string,object> this[List<string> fieldNames] {
        get {
            Dictionary<string,object> result = new Dictionary<string,object>();
            foreach(string fieldName in fieldNames) {
                if(_data.ContainsKey(fieldName)) {
                    result.Add(fieldName,_data[fieldName]);
                } else {
                    throw new Exception($"Field named {fieldName} not found");
                }
            }
            return result;
        }
        set {
            foreach(string fieldName in fieldNames) {
                if(_data.ContainsKey(fieldName)) {
                    _data[fieldName] = value[fieldName];
                } else {
                    _data.Add(fieldName, value[fieldName]);
                }
            }
        }
    }

    public string Id {
        get {
            return (string)this["id"];
        }
        set {
            this["id"] = value;
        }
    }
    public string Name {
        get {
            return (string)this["name"];
        }
        set {
            this["name"] = value;
        }
    }

    public string SObjectName {
        get {
            return (string)this["sObjectName"];
        }
        set {
            this["sObjectName"] = value;
        }
    }

    public void Insert() {
        if(!string.IsNullOrEmpty(Id)) {return;}
        Game.Instance.SDataModel.AddRecord(this);
    }
}