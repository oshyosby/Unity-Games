// Script Object

namespace SData;
public class SObject {

    private static List<Field> defaultFields = new List<Field>{
        new Field("id","Id","string",true),
        new Field("name","Name","string",true),
        new Field("sObjectName","SObject Name","string",true)
    }; 
    
    private string _name;
    public string Name() {
        return _name;
    } 
    public void SetName(string name) {
        _name = name;
    }

    private string _label;
    public string Label() {
        return _label;
    } 
    public void SetLabel(string label) {
        _label = label;
    }

    private List<Field> _fields;
    public List<Field> Fields() {
        return _fields;
    }
    public Field? GetField(string fieldName) {
        try {
            return _fields.First(x => x.Name() == fieldName);
        }
        catch {
            return null;
        }
    }

    public SObject(string name, string label) {
        _name = name;
        _label = label;
        _fields = defaultFields;
    }

    public void Insert() {
        SDataModel.Instance().AddSObject(this);
    }

    private List<Record> _records = new List<Record>();
    public List<Record> GetRecords() {
        return _records;
    }
    public void AddRecord(Record record) {
        _records.Add(record);
    }
    public Record NewRecord() {
        return new Record(this);
    }
}