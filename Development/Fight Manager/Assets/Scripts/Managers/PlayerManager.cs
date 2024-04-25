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
        ObjectRecord affiliation = dataManager.RecordDataQuery("affiliation","individualId",player.Id());
        Debug.Log("Affiliation Id: "+affiliation.Id());
        string organisationId = (string)affiliation.GetField("organisationId");
        Debug.Log("Gym Id: "+organisationId);
        ObjectRecord gym = dataManager.RecordById(organisationId); 
        Debug.Log("Gym Name: "+gym.Name());
        return gym;
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