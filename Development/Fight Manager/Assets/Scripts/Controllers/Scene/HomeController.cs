using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public ScreenManager screenManager;
    public ButtonManager buttonManager;

    void Update() {
        if(GameManager.Instance().saves.Count == 0) {
            buttonManager.GetButtonByName("Resume").GetComponent<Button>().interactable = false;
            buttonManager.GetButtonByName("Load Game").GetComponent<Button>().interactable = false;
        }
    }

    public void Resume() {
        Debug.Log("Resume");
        GameManager.LoadScene("Game");
    }

    public void NewGame() {
        Debug.Log("New Game");
        gameObject.SetActive(false);
        screenManager.GetScreenByName("New Game").SetActive(true);
    }

    public void LoadGame() {
        Debug.Log("Load Game");
        gameObject.SetActive(false);
        screenManager.GetScreenByName("Load Game").SetActive(true);
    }

    public void Settings() {
        Debug.Log("Settings");
    }
}
