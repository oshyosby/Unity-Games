using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager {
    public Person player;
    public DataManager dataManager = new DataManager();

    public Gym MyGym() {
        List<Record> gyms = dataManager.RecordsByType("gym");
        Debug.Log("Number Of Gyms: "+gyms.Count);
        Record record = dataManager.RecordDataQuery(gyms,"ownerId",(object)player.id); 
        Debug.Log("My Gym Id: "+record.id);
        return Gym.Get(record);
    }

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