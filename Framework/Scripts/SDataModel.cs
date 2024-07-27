// Script Data Model
using System.Linq;

namespace Framework;
public class SDataModel {
    
    private List<SObject> sObjects = new List<SObject>();
    public List<SObject> SObjects {
        get {
            return sObjects;
        }
        set {
            sObjects = value;
        }
    }

    public SDataModel(List<SObject> sObjects) {
        SObjects = sObjects;
    }

    public SObject? GetSObjectByName(string name) {
        try {
            return SObjects.First(x => x.Name() == name); 
        }
        catch {
            return null;
        }
    }
    public void AddSObject(SObject sObject) {
        if(SObjects.Any(x => x.Name() == sObject.Name())) {
            return;
        }
        SObjects.Add(sObject);
    }

    private List<Record> _records = new List<Record>();
    public List<Record> Records {
        get {
            return _records;
        }
    }
    public List<Record> GetRecordsBySObjectName(string sObjectName) {
        return _records.Where(x => x.SObjectName == sObjectName).ToList();
    }
    public Record? GetRecordById(string recordId) {
        return _records.FirstOrDefault(x => x.Id == recordId);
    }
    public void AddRecord(Record record) {
        GuidGenerator.SetRecordId(record);
        _records.Add(record);
    }
}