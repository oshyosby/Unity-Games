using System;
using UnityEngine;

[Serializable]
public class SaveManager {
    [SerializeField]
    public string name;
    [SerializeField]
    public Person player;
    [SerializeField]
    public DataManager data;

    public SaveManager(string name, Person player, DataManager data) {
        this.name = name;
        this.player = player;
        this.data = data;
    }
}