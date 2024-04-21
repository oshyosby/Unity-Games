using System.Collections.Generic;

public class Record {
    private Dictionary<string,object> properties = new Dictionary<string,object>{
        {"id","undefined"},{"name",(string)("")},{"sobject",(string)("")},#
        {"fields",new Dictionary<string,object>()}
    }
    public string Id() {
        return (string)properties["id"];
    }
    public string Name() {
        return (string)properties["name"];
    }
    public string SObject() {
        return GameManager.Instance().DataManager().SObjectByName((string)properties["sobject"]);
    }
    public Dictionary<string,object> Fields() {
        return (Dictionary<string,object>)properties["fields"];
    }

    public Record(string name, string type, Dictionary<string,object> fields) {
        properties["id"] = "undefined";
        properties["name"] = name;
        properties["sobject"] = sobject;
        properties["fields"] = fields;
    }

    public void Push() {
        GameManager.Instance().DataManager().AddRecord(this);
    }
} 