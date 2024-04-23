using System;
using System.Collections.Generic;

[Serializable]
public class DataField {
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

    private DataField(string name, string label, string type, bool isRequired, object defaultValue) {
        properties["name"] = name;
        properties["label"] = label;
        properties["type"] = type;
        properties["isRequired"] = isRequired;
        properties["defaultValue"] = defaultValue;
    }

    public static DataField String(string name, string label, bool isRequired, string defaultValue) {
        return new DataField(name,label,"string",isRequired,(string)defaultValue);
    }
    public static DataField Int(string name, string label, bool isRequired, int defaultValue) {
        return new DataField(name,label,"int",isRequired,(int)defaultValue);
    }
    public static DataField Bool(string name, string label, bool isRequired, bool defaultValue) {
        return new DataField(name,label,"bool",isRequired,(bool)defaultValue);
    }
    public static DataField Lookup(string name, string label, bool isRequired, string defaultValue, string dataObject, string listName, string listLabel) {
        DataField field = new DataField(name,label,"lookup",isRequired,(string)defaultValue);
        //RelatedList list = new RelatedList(dataObject,listName,listLabel);
        // Add Related list to DataObject
        return field;
    }
}