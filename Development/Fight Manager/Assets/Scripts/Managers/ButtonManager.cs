using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ButtonManager {
    [SerializeField]
    public List<GameObject> buttons;

    public GameObject GetButtonByName(string name) {
        GameObject button = buttons.First(x => x.gameObject.name == name);
        return button;
    }
}