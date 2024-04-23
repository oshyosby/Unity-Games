using System;
using UnityEngine;

[Serializable]
public class SaveManager {
    [SerializeField]
    public string name;
    [SerializeField]
    public ObjectRecord player;
    [SerializeField]
    public DataManager data = new DataManager();
    [SerializeField]
    public DateTime createdDate;
    [SerializeField]
    public DateTime lastModifiedDate;

    public SaveManager(string name, PlayerManager playerManager) {
        this.name = name;
        this.player = playerManager.player;
        this.data = playerManager.dataManager;
    }

    public void Update(PlayerManager playerManager) {
        player = playerManager.player;
        data = playerManager.dataManager;
        lastModifiedDate = DateTime.Now;
    }
}