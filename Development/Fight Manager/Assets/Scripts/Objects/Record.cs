using System.Collections.Generic;

public class Record {
    public string id;
    public string name;
    public string type;
    public Dictionary<string,object> data;

    public Record(string name, string type, Dictionary<string,object> data) {
        id = "undefined";
        this.name = name;
        this.type = type;
        this.data = data;
    }

    public void Push() {
        GameManager.Instance().DataManager().Add(this);
    }
} 