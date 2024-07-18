// Script Data Model
using System.Linq;

namespace SData;
public class SDataModel {
    public SDataModel() {}

    private static SDataModel _instance = new SDataModel();
    public static SDataModel Instance() {
        if(_instance == null) {
            _instance = new SDataModel();
        }
        return _instance;
    }
    public static void SetInstance(SDataModel sDataModel) {
        _instance = sDataModel;
    }

    private List<SObject> sObjects = new List<SObject>();
    public List<SObject> SObjects() {
        return sObjects;
    }
    public SObject? GetSObjectByName(string name) {
        try {
            return SObjects().First(x => x.Name() == name); 
        }
        catch {
            return null;
        }
    }
    public void AddSObject(SObject sObject) {
        if(SObjects().Any(x => x.Name() == sObject.Name())) {
            return;
        }
        SObjects().Add(sObject);
    }
}