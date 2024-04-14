using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameController : MonoBehaviour
{
    public ScreenManager screenManager;
    public ButtonManager buttonManager;
    private List<SaveManager> saves;
    public SaveManager selectedSave;

    private List<RadioButton> CreateSaveButtons() {
        List<RadioButton> buttons = new List<RadioButton>();
        Debug.Log("Number of Saves: "+saves.Count);
        foreach(SaveManager save in saves) {
            buttons.Add(
                new RadioButton(save.name,save.name,280,30)
            );  
        }
        return buttons;
    }

    public void SelectSave(string name) {
        selectedSave = saves.First(x => x.name == name);
        buttonManager.GetButtonByName("Load").GetComponent<Button>().interactable = true;
    }

    void Awake()
    {
        saves = GameManager.Instance().saves;
        RadioButtonGroup buttonGroup = GameObject.Find("Saves").GetComponent<RadioButtonGroup>();
        buttonGroup.radioButtons = CreateSaveButtons();
        buttonGroup.PopulateButtons();
        foreach(Button button in buttonGroup.buttonMap.Values) {
            button.onClick.AddListener(delegate { SelectSave(button.name); });
        }
    }

    public void Home() {
        Debug.Log("Home");
        gameObject.SetActive(false);
        screenManager.GetScreenByName("Home").SetActive(true);
    }

    public void Load() {
        Debug.Log("Load");
    }
}
