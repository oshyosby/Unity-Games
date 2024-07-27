// Script Object

namespace Framework;
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

    private string _prefix;
    public string Prefix() {
        return _prefix;
    } 
    public void SetPrefix(string prefix) {
        _prefix = prefix;
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
    public void NewField(Field field) {
        _fields.Add(field);
    }
    public void NewFields(List<Field> fields) {
        _fields.AddRange(fields);
    }

    public SObject(string name, string label, string prefix) {
        _name = name;
        _label = label;
        _fields = defaultFields;
        _prefix = prefix;
    }

    public void Insert() {
        Game.Instance.SDataModel.AddSObject(this);
    }

    public Record NewRecord() {
        return new Record(this);
    }
}