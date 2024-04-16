using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataManager {
    
    public List<Record> records = new List<Record>();

    public List<Record> RecordsByType(string type) {
        return records.Where(x => x.type == type).ToList();
    }
    public Record GetRecordById(string id) {
        return records.First(x => x.id == id);
    }
    public Record RecordDataQuery(List<Record> records, string field, object value) {
        return records.First(x => x.data[field] == value);
    }

    private void GenerateId(Record record) {
        record.id = Guid.NewGuid().ToString();
        record.id = record.type + record.id.Substring(record.type.Length+1);
    }
    public void GetUniqueId(Record record) {
        GenerateId(record);
        while(records.Any(x => x.id == record.id)) {
            GenerateId(record);
        }
    }
    public void Add(Record record) {
        if(record.id == null || record.id == "undefined") {
            GetUniqueId(record);
        }
        Debug.Log("Record Id: "+record.id);
        records.Add(record);
    }
}