using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataManager {
    
    [SerializeField]
    public List<Person> people = new List<Person>();

    private string GenerateId() {
        return Guid.NewGuid().ToString();
    }
    private string PrefixId(string id, string prefix) {
        return prefix + id.Substring(prefix.Length-1);
    }

    public string GetUniqueId(string idPrefix, List<Record> records) {
        string id = PrefixId(GenerateId(),idPrefix);
        while(records.Any(x => x.id == id)) {
            id = PrefixId(GenerateId(),idPrefix);
        }
        return id;
    }
}