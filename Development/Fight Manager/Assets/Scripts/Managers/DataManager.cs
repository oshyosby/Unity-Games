using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataManager {
    private List<SObject> sobjects = new List<SObject>();
    public List<SObject> AllSObjects() {
        return sobjects;
    }
    public SObject SObjectByName(string name) {
        if(!sobjects.Any(x => x.Name() == name)) {
            return (SObject)null;
        }
        return sobjects.First(x => x.Name() == name);
    }
    public void AddSObject(SObject sobject) {
        if(sobjects.Any(x => x.Name() == sobject.Name())) {
            return;
        }
        sobjects.Add(sobject);
    }

    private List<Record> records = new List<Record>();
    public List<Record> AllRecords() {
        return records;
    }
    public List<Record> RecordsBySObject(string sobjectName) {
        return records.Where(x => x.SObject().Name() == sobjectName).ToList();
    }
    public Record RecordById(string recordId) {
        if(!records.Any(x => x.Id() == recordId)) {
            return (Record)null;
        }
        return records.First(x => x.Id() == recordId);
    }
    public Record RecordFieldQuery(string sobject, string field, object value) {
        return RecordsBySObject(sobject).First(x => x.data[field] == value);
    }
    public List<Record> RecordsFieldQuery(string sobject, string field, object value) {
        return RecordsBySObject(sobject).Where(x => x.data[field] == value).ToList();
    }

    public void AddRecord(Record record) {
        if(record.id == "" || record.id == null || record.id == "undefined") {
            RecordId(record);
        }
        Debug.Log("Record Id: "+record.id);
        records.Add(record);
    }

    private void GenerateId(Record record) {
        record.id = Guid.NewGuid().ToString();
        record.id = record.type + record.id.Substring(record.type.Length+1);
    }
    private void RecordId(Record record) {
        GenerateId(record);
        while(records.Any(x => x.id == record.id)) {
            GenerateId(record);
        }
    }
}