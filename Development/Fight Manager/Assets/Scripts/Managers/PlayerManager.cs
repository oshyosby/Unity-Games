public class PlayerManager {
    public Person player;
    public DataManager dataManager;

    public PlayerManager() {}

    public PlayerManager(Person player, DataManager dataManager) {
        this.player = player;
        this.dataManager = dataManager;
    }

    public void LoadSave(SaveManager save) {
        player = save.player;
        dataManager = save.data;
    }
}