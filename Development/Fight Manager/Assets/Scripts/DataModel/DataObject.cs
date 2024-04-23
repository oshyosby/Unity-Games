using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class DataObject {
    private static List<ObjectField> DefaultFields() {
        return new List<ObjectField>{
        ObjectField.String("id","Record Id",true,(string)("")),
        ObjectField.String("name","Record Name",true,(string)("")),
        ObjectField.String("dataObject","Data Object",true,(string)(""))
    };
    }
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},
        {"fields",new List<ObjectField>()}
        //{"relatedLists",new List<RelatedRecords>()}
    };

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public List<ObjectField> Fields() {
        return (List<ObjectField>)properties["fields"];
    }
    public void AddFields(List<ObjectField> fields) {
        Fields().AddRange(fields);
    }
    /*
    public List<RelatedRecords> RelatedRecordss() {
        return (List<RelatedRecords>)properties["relatedLists"];
    }*/

    public DataObject(string name, string label) {
        properties["name"] = name;
        properties["label"] = label;
        properties["fields"] = DefaultFields();
        //properties["relatedLists"] = new List<RelatedRecords>();
    }

    public void Insert() {
        if(GameManager.Instance().DataManager().AllObjects().Any(x => x.Name() == Name())) {
            return;
        }
        GameManager.Instance().DataManager().AddObject(this);
    }

    public List<ObjectRecord> Records() {
        return GameManager.Instance().DataManager().RecordsByObject(Name());
    }
}