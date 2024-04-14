using System;
using UnityEngine;

[Serializable]
public class SaveManager {
    [SerializeField]
    public string name;
    [SerializeField]
    public Person player;
    [SerializeField]
    public DataManager data = new DataManager();
    [SerializeField]
    public DateTime createdDate;
    [SerializeField]
    public DateTime lastModifiedDate;

    public SaveManager(string name) {
        this.name = name;
        createdDate = DateTime.Now;
        lastModifiedDate = createdDate;
    }
    public SaveManager(string name, Person player, DataManager data) {
        this.name = name;
        this.player = player;
        this.data = data;
    }
}