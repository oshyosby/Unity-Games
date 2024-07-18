// Script Object

public class SObject {
    
    private string _name;
    public string Name() {
        return _name;
    } 
    public void SetName(string name) {
        _name = name;
    }

    private string _label;
    public string Label() {
        return _label;
    } 
    public void SetLabel(string label) {
        _label = label;
    }

    public SObject(string name, string label) {
        _name = name;
        _label = label;
    }
}