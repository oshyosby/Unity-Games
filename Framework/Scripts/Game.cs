namespace Framework;
public class Game {

    private static Game instance;
    public static Game Instance {
        get {
            if (instance == null) {
                instance = new Game("PlaceHolder",new List<SObject>());
            }
            return instance;
        }
        set {
            instance = value;
        }
    }
    
    private string name;
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    private SDataModel sDataModel;
    public SDataModel SDataModel {
        get {
            return sDataModel;
        }
    }

    public Game(string name, List<SObject> sObjects) {
        this.name = name;
        sDataModel = new SDataModel(sObjects);
        Instance = this;
    }
}