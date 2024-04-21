public class RelatedList {
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},{"sobject",(string)("")},{"field",(string)("")}
    };

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public SObject SObject() {
        return GameManager.Instance().DataManager().SObjectByName(properties["sobject"]);
    }
    public Field Field() {
        return SObject().Fields().First(x => x.Name() == properties["field"]);
    }

    public RelatedList(string name, string label, string sobject) {
        properties["name"] = name;
        properties["label"] = label;
        properties["sobject"] = sobject;
    }

    public List<Record> Records(string recordId) {
        return GameManager.Instance().DataManager().RecordsFieldQuery(properties["sobject"],properties["field"],recordId);
    }
}