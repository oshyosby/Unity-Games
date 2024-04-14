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
                LoadSave(saves[0]);
            }
        }
        else
        {
            Destroy(gameObject);
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
    public void LoadSave(SaveManager save) {
        currentSave = save;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
