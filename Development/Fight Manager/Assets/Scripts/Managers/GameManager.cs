using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance() {
        return instance;
    }

    void Awake()
    {
        if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if(saves.Count > 0) {
                LoadSave(saves.OrderByDescending(x => x.lastModifiedDate).ToArray()[0]);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }   
    public PlayerManager playerManager = new PlayerManager();
    public DataManager DataManager() {
        return playerManager.dataManager;
    }

    public SaveManager currentSave = null;
    public List<SaveManager> saves;
    public void Save(string name) {
        SaveManager existingSave = saves.FirstOrDefault(x => x.name == name);
        if(existingSave == null) {
            SaveManager newSave = new SaveManager(name,playerManager);
            saves.Add(newSave);
            currentSave = newSave;
        } else {
            existingSave.Update(playerManager);
            currentSave = existingSave;
        }

    }
    public void LoadSave(SaveManager save) {
        currentSave = save;
        playerManager.LoadSave(save);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
