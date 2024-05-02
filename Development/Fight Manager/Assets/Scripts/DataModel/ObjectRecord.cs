using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ObjectRecord {
    [SerializeField]
    private Dictionary<string,object> properties = new Dictionary<string,object>{
        {"fields",new Dictionary<string,object>()}
    };

    private void SetDefaultFields(string dataObject) {
        Debug.Log($"Default Fields: {dataObject}");
        Dictionary<string,object> fields = new Dictionary<string,object>();
        foreach (ObjectField field in GameManager.Instance().DataManager().ObjectByName(dataObject).Fields()) {
            fields.Add(field.Name(),field.DefaultValue());
        }
        properties["fields"] = fields;
    }

    private Dictionary<string,object> Fields() {
        Debug.Log("Record Field Map");
        return (Dictionary<string,object>)properties["fields"];
    }
    public object GetField(string fieldName) {
        Debug.Log($"Get Field: {fieldName}");
        return Fields()[fieldName];
    }
    public void SetField(string fieldName, object value) {
        Debug.Log($"Set Field: {fieldName} = {value}");
        Fields()[fieldName] = value;
    }

    [SerializeField]
    public string Id() {
        Debug.Log("Get Record Id");
        return (string)GetField("id");
    }
    public string Name() {
        Debug.Log("Get Record Name");
        return (string)GetField("name");
    }
    public DataObject DataObject() {
        Debug.Log("Get Record Object");
        return (DataObject)GameManager.Instance().DataManager().ObjectByName((string)GetField("dataObject"));
    }

    public List<ObjectRecord> GetRelatedList(string name) {
        RelatedRecords list = DataObject().RelatedLists().FirstOrDefault(x => x.Name() == name);
        if(list == null) {
            return new List<ObjectRecord>();
        }
        return list.Records(Id());
    }

    public ObjectRecord(string name, string dataObject, Dictionary<string,object> fields) {
        SetDefaultFields(dataObject);
        Fields()["name"] = name;
        Fields()["dataObject"] = dataObject;
        foreach(string field in fields.Keys) {
            Fields()[field] = fields[field];
        }
    }

    public void Push() {
        Debug.Log("Push Record");
        GameManager.Instance().DataManager().AddRecord(this);
    }
}