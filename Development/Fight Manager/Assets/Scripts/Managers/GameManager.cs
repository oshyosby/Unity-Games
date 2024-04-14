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

    void Awake() {
        GameManager.instance = this;
        if(saves.Count > 0) {
            Load(saves[0]);
        }
    }

    public SaveManager currentSave = null;
    public List<SaveManager> saves;
    public void Save(string name) {
        saves.Add(
            new SaveManager(
                name,
                currentSave.player,
                currentSave.data
            )
        );
    }
    public void Load(SaveManager save) {
        currentSave = save;
    }
}
