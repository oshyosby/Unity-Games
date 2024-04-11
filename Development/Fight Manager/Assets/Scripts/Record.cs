using System;
using System.Collections.Generic;
using System.Linq;

public class Record {
    public string id;
    private string GenerateId() {
        return Guid.NewGuid().ToString();
    }
    private string PrefixId(string id, string prefix) {
        return prefix + id.Substring(prefix.Length-1);
    }
    public string name;
    public string type;

    public Record(string name, string type, string idPrefix) {
        string id = PrefixId(GenerateId(),idPrefix);
        while(GameManager.Instance().data.records.Any(x => x.id == id)) {
            id = PrefixId(GenerateId(),idPrefix);
        }
        this.name = name;
        this.type = type;
        GameManager.Instance().data.records.Add(this);
    }
} 