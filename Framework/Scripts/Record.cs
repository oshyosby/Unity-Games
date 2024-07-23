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
    public string Id() {
        return (string)GetDataByField("id");
    }
    public string Name() {
        return (string)GetDataByField("name");
    }
    public string SObjectName() {
        return (string)GetDataByField("sObjectName");
    }

    public void Insert() {
        if(!string.IsNullOrEmpty(Id())) {return;}
        SDataModel.Instance().AddRecord(this);
    }
}