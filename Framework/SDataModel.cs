// Script Data Model

public class SDataModel {

    private static SDataModel _instance;
    public static SDataModel Instance {
        if(_instance == null) {
            _instance = new SDataModel();
        }
        return _instance;
    }
    public static void SetInstance(SDataModel sDataModel) {
        _instance = sDataModel;
    }

    private List<SObject> sObjects = new List<SObject>();
    public List<SObject> SObjects {
        return sObjects;
    }
    public SObject GetSObjectByName(string name) {
        try {
            return SObjects.First(x => x.Name() == name); 
        }
        catch (Exception e) {
            return e;
        }
    }
}