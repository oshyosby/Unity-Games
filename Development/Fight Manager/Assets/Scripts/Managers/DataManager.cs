using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DataManager {

    [SerializeField]
    private List<DataObject> sobjects = new List<DataObject>();
    public List<DataObject> AllObjects() {
        return sobjects;
    }
    public DataObject ObjectByName(string name) {
        if(!sobjects.Any(x => x.Name() == name)) {
            return (DataObject)null;
        }
        return sobjects.First(x => x.Name() == name);
    }
    public void AddObject(DataObject sobject) {
        if(sobjects.Any(x => x.Name() == sobject.Name())) {
            return;
        }
        sobjects.Add(sobject);
    }

    [SerializeField]
    private List<DataRecord> records = new List<DataRecord>();
    public List<DataRecord> AllRecords() {
        return records;
    }
    public List<DataRecord> RecordsByObject(string sobjectName) {
        return records.Where(x => x.DataObject().Name() == sobjectName).ToList();
    }
    public DataRecord RecordById(string recordId) {
        if(!records.Any(x => x.Id() == recordId)) {
            return (DataRecord)null;
        }
        return records.First(x => x.Id() == recordId);
    }
    public DataRecord RecordDataQuery(string dataObject, string field, object value) {
        return RecordsByObject(dataObject).First(x => x.GetField(field) == value);
    }
    public List<DataRecord> RecordsDataQuery(string dataObject, string field, object value) {
        return RecordsByObject(dataObject).Where(x => x.GetField(field) == value).ToList();
    }

    public void AddRecord(DataRecord record) {
        if(record.Id() == "" || record.Id() == null || record.Id() == "undefined") {
            RecordId(record);
        }
        Debug.Log("Record Id: "+record.Id());
        records.Add(record);
    }

    private void GenerateId(DataRecord record) {
        string id = Guid.NewGuid().ToString();
        string dataObject = record.DataObject().Name();
        id = dataObject + id.Substring(dataObject.Length+1);
        record.SetField("id",id);
    }
    private void RecordId(DataRecord record) {
        GenerateId(record);
        while(records.Any(x => x.Id() == record.Id())) {
            GenerateId(record);
        }
    }
}