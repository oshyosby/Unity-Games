namespace DataModel;
public class ObjectField {
    
    public ObjectField() {}

    public ObjectField(string name, string label, string description, Type type, bool isRequired) {
        this.name = name;
        this.label = label;
        this.description = description;
        this.type = type;
        this.isRequired = isRequired;
    }

    private string? name;
    public string Name {
        get => name ?? "";
        set => name = value;
    }

    private string? label;
    public string Label {
        get => label ?? "";
        set => label = value;
    }

    private string? description;
    public string Description {
        get => description ?? "";
        set => description = value;
    }

    private Type? type;
    public Type Type {
        get => type ?? typeof(Nullable);
        set => type = value;
    }

    private bool isRequired = false;
    public bool IsRequired {
        get => isRequired;
        set => isRequired = value;
    }
}