using UnityEngine;
using UnityEngine.UI;


public class HomeController : MonoBehaviour
{
    public ScreenManager screenManager;

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
        screenManager.GetScreenByName("New Game").SetActive(true);
    }

    public void LoadGame() {
        Debug.Log("Load Game");
    }

    public void Settings() {
        Debug.Log("Settings");
    }
}
