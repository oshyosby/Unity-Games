using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance() {
        if (instance == null) {
        }
        return instance;
    }

    private void Awake() {
        instance = this; 
    }

    public Person player;
    public DataManager data;
    public List<SaveManager> saves;
    public void Save(string name) {
        saves.Add(
            new SaveManager(name,player,data)
        );
    }

    public GameManager() {
        data = new DataManager();
        saves = new List<SaveManager>();
    }
}
