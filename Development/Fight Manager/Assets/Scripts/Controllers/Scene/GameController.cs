using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ScreenManager screenManager;
    public ButtonManager buttonManager;

    void Awake() {
        screenManager.currentScreenName = "Home";
        screenManager.GetScreenByName("Home").SetActive(true);
    }

    public void MyGym() {
        Debug.Log("My Gym");
        screenManager.GetScreenByName(screenManager.currentScreenName).SetActive(false);
        screenManager.GetScreenByName("My Gym").SetActive(true);
        GameObject.Find("My Gym").GetComponent<GymController>().Populate(GameManager.Instance().playerManager.MyGym());
    }
}
