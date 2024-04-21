public class Field {
    private Dictionary<string,object> properties = new Dictionary<string,object>{
        {"name",(string)null},{"label",(string)null},{"type",(string)null},
        {"isRequired",(bool)false},{"defaultValue",null},
    };

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public string Type() {
        return (string)properties["type"];
    }
    public bool IsRequired() {
        return (bool)properties["isRequired"];
    }
    public object DefaultValue() {
        return properties["defaultValue"];
    }

    private Field(string name, string label, string type, bool isRequired, object defaultValue) {
        properties["name"] = name;
        properties["label"] = label;
        properties["type"] = type;
        properties["isRequired"] = isRequired;
        properties["defaultValue"] = defaultValue;
    }

    public Field StringField(string name, string label, bool isRequired, string defaultValue) {
        return new Field(name,label,"string",isRequired,(string)defaultValue);
    }
    public Field IntField(string name, string label, bool isRequired, int defaultValue) {
        return new Field(name,label,"int",isRequired,(int)defaultValue);
    }
    public Field BoolField(string name, string label, bool isRequired, bool defaultValue) {
        return new Field(name,label,"bool",isRequired,(bool)defaultValue);
    }
    public Field LookupField(string name, string label, bool isRequired, string defaultValue, string sobject, string listName, string listLabel) {
        Field field = new Field(name,label,"lookup",isRequired,(string)defaultValue);
        RelatedList list = new RelatedList(sobject,listName,listLabel);
        
    }
}