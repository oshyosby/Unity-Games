using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonGroup : MonoBehaviour
{
    public GameObject radioButtonPrefab;
    private Transform buttonGroup;
    public Dictionary<string,Button> buttonMap;
    public List<RadioButton> radioButtons;
    public string selectedOption;

    private void SelectButton(string name) {
        selectedOption = name;
        foreach(string button in buttonMap.Keys) {
            buttonMap[button].interactable = button == name ? false : true;
        }
    }

    public void PopulateButtons() {
        buttonMap = new Dictionary<string, Button>();
        foreach(RadioButton radioButton in radioButtons) {
            GameObject buttonObj = Instantiate(radioButtonPrefab, gameObject.transform);
            RectTransform rect = buttonObj.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(radioButton.width, radioButton.height);
            buttonObj.name = radioButton.name;
            buttonObj.transform.Find("Label").GetComponent<Text>().text = radioButton.label;
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(delegate { SelectButton(radioButton.name); });
            buttonMap.Add(radioButton.name,button);
        }
    }
}

[Serializable]
public class RadioButton {
    [SerializeField]
    public string name;
    [SerializeField]
    public string label;
    [SerializeField]
    public int width;
    [SerializeField]
    public int height;

    public RadioButton(string name, string label, int width, int height) {
        this.name = name;
        this.label = label;
        this.width = width;
        this.height = height;
    }
}
