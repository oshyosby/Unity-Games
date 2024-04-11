using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class HomeController : MonoBehaviour
{
    public List<GameObject> screens;

    private GameObject GetScreen(string name) {
        return screens.First(x => x.gameObject.name == name);
    }

    public void Awake() {
        if(GameManager.Instance().data.records.Count > 0) {
            Button resumeButton = GameObject.Find("Resume").GetComponent<Button>();
            if(resumeButton) {
                resumeButton.interactable = true;
            }
            Button loadButton = GameObject.Find("Load Game").GetComponent<Button>();
            if(resumeButton) {
                loadButton.interactable = true;
            }
        }
    }

    public void Resume() {
        Debug.Log("Resume");
    }

    public void NewGame() {
        Debug.Log("New Game");
        gameObject.SetActive(false);
        GetScreen("New Game").SetActive(true);
    }

    public void LoadGame() {
        Debug.Log("Load Game");
    }

    public void Settings() {
        Debug.Log("Settings");
    }
}
