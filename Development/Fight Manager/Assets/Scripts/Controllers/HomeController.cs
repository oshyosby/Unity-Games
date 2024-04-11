using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
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
        GameManager.Instance().GetAnimatorController("MainMenu").Play("HomeToNewGame");
    }

    public void LoadGame() {
        Debug.Log("Load Game");
    }

    public void Settings() {
        Debug.Log("Settings");
    }
}
