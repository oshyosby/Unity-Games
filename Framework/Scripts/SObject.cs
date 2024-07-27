// Script Object

namespace Framework;
public class SObject {

    private static List<Field> defaultFields = new List<Field>{
        new Field("id","Id","string",true),
        new Field("name","Name","string",true),
        new Field("sObjectName","SObject Name","string",true)
    }; 
    
    private string _name;
    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }

    private string _label;
    public string Label {
        get {
            return _label;
        }
        set {
            _label = value;
        }
    }

    private string _prefix;
    public string Prefix {
        get {
            return _prefix;
        }
        set {
            _prefix = value; 
        }
    } 
    
    private List<Field> _fields;
    public List<Field> Fields {
        get {
            return _fields;
        }
        set {
            _fields = value;
        }
    }

    public Field this[string fieldName] {
        get {
            if(_fields.Any(x => x.Name == fieldName)) {
                return _fields.First(x => x.Name == fieldName);
            } else {
                throw new Exception($"Field named {fieldName} not found");
            }
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

    public Record NewRecord(Dictionary<string,object> fieldValues) {
        foreach(Field field in Fields) {
            if(!fieldValues.ContainsKey(field.Name) && field.Name != "sObjectName") {
                fieldValues.Add(field.Name,field.Name == "sObjectName" ? Name : "");
            }
        }
        return new Record(fieldValues);
    }
}