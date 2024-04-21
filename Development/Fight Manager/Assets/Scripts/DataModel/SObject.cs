public class SObject {
    private Dictionary<string,object> properties = new Dictionary<string, object>{
        {"name",(string)("")},{"label",(string)("")},{"fields",new List<Field>()},
        {"relatedLists",new List<RelatedList>()}
    }

    public string Name() {
        return (string)properties["name"];
    }
    public string Label() {
        return (string)properties["label"];
    }
    public List<Field> Fields() {
        return (List<Fields>)properties["fields"];
    }
    // Get Default Values
    public List<RelatedList> RelatedLists() {
        return (List<RelatedList>)properties["relatedLists"];
    }

    public SObject(string name, string label) {
        properties["name"] = name;
        properties["label"] = label;
        properties["fields"] = new List<Field>();
        properties["relatedLists"] = new List<RelatedList>();
    }

    public void Insert() {
        if(GameManager.Instance().DataManager().AllSObjects().Any(x => x.Name() == Name())) {
            return;
        }
        GameManager.Instance().DataManager().AddSObject(this);
    }

    public List<Record> Records() {
        return GameManager.Instance().DataManager().RecordsBySObject(Name());
    }
}