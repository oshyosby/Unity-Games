// Script Object Field

namespace Framework;
public class Field {
    private string _name;
    public string Name() {
        return _name;
    }
    private string _label;
    public string Label() {
        return _label;
    }
    private string _type;
    public string Type() {
        return _type;
    }
    private bool _required;
    public bool Required() {
        return _required;
    }

    public Field(string name, string label, string type, bool isRequired) {
        _name = name;
        _label = label;
        _type = type;
        _required = isRequired;
    }

    public void Insert(SObject sObject) {
        if (sObject == null) {
            return;
        }
        sObject.NewField(this);
    }
}