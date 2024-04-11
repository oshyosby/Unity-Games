using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance() {
        if (instance == null) {
        }
        return instance;
    }

    private List<Animator> animatorControllers;
    public Animator GetAnimatorController(string name) {
        return animatorControllers.First(x => x.runtimeAnimatorController.name == name);
    }

    private void Awake() {
        animatorControllers = GameObject.FindObjectsOfType<Animator>().ToList();
        Debug.Log("Animator Controller Count:" + animatorControllers.Count);
        foreach(Animator anim in animatorControllers) {
            Debug.Log(anim.runtimeAnimatorController.name);
        }
        instance = this; 
    }

    public DataManager data;

    public GameManager() {
        data = new DataManager();
    }
}
