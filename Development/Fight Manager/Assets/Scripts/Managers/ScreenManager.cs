using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ScreenManager {
    [SerializeField]
    public List<GameObject> screens;
    public string currentScreenName;

    public GameObject GetScreenByName(string name) {
        GameObject screen = screens.First(x => x.gameObject.name == name);
        return screen;
    }

    public GameObject GetScreenByIndex(int index) {
        GameObject screen = screens[index];
        Debug.Log("Screen Name: " + screen.name);
        return screen;
    }
}