using System;
using System.Collections.Generic;

[Serializable]
public class ObjectField {
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

    private ObjectField(string name, string label, string type, bool isRequired, object defaultValue) {
        properties["name"] = name;
        properties["label"] = label;
        properties["type"] = type;
        properties["isRequired"] = isRequired;
        properties["defaultValue"] = defaultValue;
    }

    public static ObjectField String(string name, string label, bool isRequired, string defaultValue) {
        return new ObjectField(name,label,"string",isRequired,(string)defaultValue);
    }
    public static ObjectField Int(string name, string label, bool isRequired, int defaultValue) {
        return new ObjectField(name,label,"int",isRequired,(int)defaultValue);
    }
    public static ObjectField Bool(string name, string label, bool isRequired, bool defaultValue) {
        return new ObjectField(name,label,"bool",isRequired,(bool)defaultValue);
    }
    public static ObjectField Lookup(string name, string label, bool isRequired, string defaultValue, string dataObject, string listName, string listLabel) {
        ObjectField field = new ObjectField(name,label,"lookup",isRequired,(string)defaultValue);
        //RelatedRecords list = new RelatedRecords(dataObject,listName,listLabel);
        // Add Related list to DataObject
        return field;
    }
}