namespace DataModel;
public class ObjectValidation {

    public ObjectValidation() {}

    public ObjectValidation(string name, string type, string? fieldName, List<Func<ObjectRecord, bool>> criteria) {
        this.name = name;
        this.type = type;
        location = fieldName ?? "objectRecord";
        this.criteria = criteria;
    }

    private string? name;
    public string Name {
        get => name ?? "";
        set => name = value;
    }

    private string? type;
    public string Type {
        get => type ?? "";
        set => type = value;
    }

    private string? location;
    public string Location {
        get => location ?? "";
        set => location = value;
    }

    private List<Func<ObjectRecord, bool>> criteria = new List<Func<ObjectRecord, bool>>();
    public List<Func<ObjectRecord, bool>> Criteria {
        get => criteria;
        set => criteria = value;
    }

    public bool Valid(ObjectRecord record) {
        // Check Logic against record
        bool allCriteriaMet = criteria.All(rule => {
            return rule(record);
        });
        return true;
    }
}