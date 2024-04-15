using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataManager {
    
    public List<Record> records = new List<Record>();

    private string GenerateId() {
        return Guid.NewGuid().ToString();
    }
    private string PrefixId(string id, string prefix) {
        return prefix + id.Substring(prefix.Length-1);
    }
    public string GetUniqueId(string idPrefix) {
        string id = PrefixId(GenerateId(),idPrefix);
        while(records.Any(x => x.id == id)) {
            id = PrefixId(GenerateId(),idPrefix);
        }
        return id;
    }
    public void Add(Record record) {
        record.id = record.id == null || record.id == "undefined" ? GetUniqueId(record.type) : record.id;
        records.Add(record);
    }
}