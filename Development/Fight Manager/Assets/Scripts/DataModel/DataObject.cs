using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class DataObject {
    private static List<DataField> DefaultFields() {
        return new List<DataField>{
        DataField.String("id","Record Id",true,(string)("")),
        DataField.String("name","Record Name",true,(string)("")),
        DataField.String("dataObject","Data Object",true,(string)(""))
    };
    }
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},
        {"fields",new List<DataField>()}
        //{"relatedLists",new List<RelatedList>()}
    };

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public List<DataField> Fields() {
        return (List<DataField>)properties["fields"];
    }
    public void AddFields(List<DataField> fields) {
        Fields().AddRange(fields);
    }
    /*
    public List<RelatedList> RelatedLists() {
        return (List<RelatedList>)properties["relatedLists"];
    }*/

    public DataObject(string name, string label) {
        properties["name"] = name;
        properties["label"] = label;
        properties["fields"] = DefaultFields();
        //properties["relatedLists"] = new List<RelatedList>();
    }

    public void Insert() {
        if(GameManager.Instance().DataManager().AllObjects().Any(x => x.Name() == Name())) {
            return;
        }
        GameManager.Instance().DataManager().AddObject(this);
    }

    public List<DataRecord> Records() {
        return GameManager.Instance().DataManager().RecordsByObject(Name());
    }
}