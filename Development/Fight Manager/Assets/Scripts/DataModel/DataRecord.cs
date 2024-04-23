using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataRecord {
    [SerializeField]
    private Dictionary<string,object> properties = new Dictionary<string,object>{
        {"fields",new Dictionary<string,object>()}
    };

    private void SetDefaultFields(string dataObject) {
        Dictionary<string,object> fields = new Dictionary<string,object>();
        foreach (DataField field in GameManager.Instance().DataManager().ObjectByName(dataObject).Fields()) {
            fields.Add(field.Name(),field.DefaultValue());
        }
        properties["fields"] = fields;
    }

    private Dictionary<string,object> Fields() {
        return (Dictionary<string,object>)properties["fields"];
    }
    public object GetField(string fieldName) {
        return Fields()[fieldName];
    }
    public void SetField(string fieldName, object value) {
        Fields()[fieldName] = value;
    }

    public string Id() {
        return (string)GetField("id");
    }
    public string Name() {
        return (string)GetField("name");
    }
    public DataObject DataObject() {
        return (DataObject)GameManager.Instance().DataManager().ObjectByName((string)GetField("dataObject"));
    }

    public DataRecord(string name, string dataObject, Dictionary<string,object> fields) {
        SetDefaultFields(dataObject);
        Fields()["name"] = name;
        Fields()["dataObject"] = dataObject;
        foreach(string field in fields.Keys) {
            Fields()[field] = fields[field];
        }
    }

    public void Push() {
        GameManager.Instance().DataManager().AddRecord(this);
    }
}