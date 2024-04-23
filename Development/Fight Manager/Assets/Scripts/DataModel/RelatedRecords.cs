using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class RelatedRecords {
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},{"dataObject",(string)("")},{"field",(string)("")}
    };

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public DataObject DataObject() {
        return GameManager.Instance().DataManager().ObjectByName((string)properties["dataObject"]);
    }
    public ObjectField Field() {
        return DataObject().Fields().First(x => x.Name() == (string)properties["field"]);
    }

    public RelatedRecords(string name, string label, string dataObject) {
        properties["name"] = name;
        properties["label"] = label;
        properties["dataObject"] = dataObject;
    }

    public List<ObjectRecord> Records(string recordId) {
        return GameManager.Instance().DataManager().RecordsDataQuery((string)properties["dataObject"],(string)properties["field"],recordId);
    }
}