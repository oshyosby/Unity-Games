using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerManager {
    public ObjectRecord player;
    [SerializeField]
    public DataManager dataManager = new DataManager();

    public ObjectRecord MyGym() {
        ObjectRecord record = dataManager.RecordDataQuery("organisation","ownerId",player.Id()); 
        Debug.Log("My Gym Id: "+record.Id());
        return record;
    }

    public PlayerManager() {}

    public PlayerManager(ObjectRecord player, DataManager dataManager) {
        this.player = player;
        this.dataManager = dataManager;
    }

    public void LoadSave(SaveManager save) {
        player = save.player;
        dataManager = save.data;
    }
}