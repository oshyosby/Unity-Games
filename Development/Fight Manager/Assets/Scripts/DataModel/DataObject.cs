using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataObject {
    private static List<ObjectField> DefaultFields() {
        Debug.Log("Data Object Default Fields");
        return new List<ObjectField>{
        ObjectField.String("id","Record Id",true,(string)("")),
        ObjectField.String("name","Record Name",true,(string)("")),
        ObjectField.String("dataObject","Data Object",true,(string)(""))
    };
    }
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},
        {"fields",new List<ObjectField>()},
        {"relatedLists",new List<RelatedRecords>()}
    };

    public string Name() {
        Debug.Log("Get Object Name");
        return (string)properties["name"];
    }
    public string Label() {
        Debug.Log("Get Object Label");
        return (string)properties["label"];
    }
    public List<ObjectField> Fields() {
        Debug.Log($"Get Object Fields");
        return (List<ObjectField>)properties["fields"];
    }
    public void AddFields(List<ObjectField> fields) {
        Debug.Log("Add Object Fields");
        Fields().AddRange(fields);
    }
    public List<RelatedRecords> RelatedLists() {
        return (List<RelatedRecords>)properties["relatedLists"];
    }
    public void AddRelatedLists(List<RelatedRecords> lists) {
        Debug.Log("Add Related Lists");
        RelatedLists().AddRange(lists);
    }

    public DataObject(string name, string label) {
        properties["name"] = name;
        properties["label"] = label;
        properties["fields"] = DefaultFields();
        properties["relatedLists"] = new List<RelatedRecords>();
    }

    public void Insert() {
        if(GameManager.Instance().DataManager().AllObjects().Any(x => x.Name() == Name())) {
            return;
        }
        Debug.Log("Insert Data Object");
        GameManager.Instance().DataManager().AddObject(this);
    }

    public List<ObjectRecord> Records() {
        Debug.Log($"Get Records: {Name()}");
        return GameManager.Instance().DataManager().RecordsByObject(Name());
    }
}