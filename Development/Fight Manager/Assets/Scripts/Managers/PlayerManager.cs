using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerManager {
    public DataRecord player;
    [SerializeField]
    public DataManager dataManager = new DataManager();

    public DataRecord MyGym() {
        DataRecord record = dataManager.RecordDataQuery("organisation","ownerId",player.Id()); 
        Debug.Log("My Gym Id: "+record.Id());
        return record;
    }

    public PlayerManager() {}

    public PlayerManager(DataRecord player, DataManager dataManager) {
        this.player = player;
        this.dataManager = dataManager;
    }

    public void LoadSave(SaveManager save) {
        player = save.player;
        dataManager = save.data;
    }
}