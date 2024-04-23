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
    private List<ObjectRecord> records = new List<ObjectRecord>();
    public List<ObjectRecord> AllRecords() {
        return records;
    }
    public List<ObjectRecord> RecordsByObject(string sobjectName) {
        return records.Where(x => x.DataObject().Name() == sobjectName).ToList();
    }
    public ObjectRecord RecordById(string recordId) {
        if(!records.Any(x => x.Id() == recordId)) {
            return (ObjectRecord)null;
        }
        return records.First(x => x.Id() == recordId);
    }
    public ObjectRecord RecordDataQuery(string dataObject, string field, object value) {
        return RecordsByObject(dataObject).First(x => x.GetField(field) == value);
    }
    public List<ObjectRecord> RecordsDataQuery(string dataObject, string field, object value) {
        return RecordsByObject(dataObject).Where(x => x.GetField(field) == value).ToList();
    }

    public void AddRecord(ObjectRecord record) {
        if(record.Id() == "" || record.Id() == null || record.Id() == "undefined") {
            RecordId(record);
        }
        Debug.Log("Record Id: "+record.Id());
        records.Add(record);
    }

    private void GenerateId(ObjectRecord record) {
        string id = Guid.NewGuid().ToString();
        string dataObject = record.DataObject().Name();
        id = dataObject + id.Substring(dataObject.Length+1);
        record.SetField("id",id);
    }
    private void RecordId(ObjectRecord record) {
        GenerateId(record);
        while(records.Any(x => x.Id() == record.Id())) {
            GenerateId(record);
        }
    }
}