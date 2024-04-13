using UnityEngine;
using UnityEngine.UI;


public class HomeController : MonoBehaviour
{
    public ScreenManager screenManager;
    public ButtonManager buttonManager;

    public void Awake() {
        if(GameManager.Instance().player.id == null) {
            buttonManager.GetButtonByName("Resume").GetComponent<Button>().interactable = false;
        }
        if(GameManager.Instance().saves.Count == 0) {
            buttonManager.GetButtonByName("Load Game").GetComponent<Button>().interactable = false;
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
