using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewGameController : MonoBehaviour
{
    public GameObject statInputPrefab;
    private GameObject availablePoints;
    private Transform statsContainer; 

    public List<InputController> inputs;
    private InputController GetInputByName(string name) {
        return inputs.First(x => x.name == name);
    }
    public ScreenManager screenManager;

    private int StatPoints() {
        int total = statsContainer.childCount * 10;
        Debug.Log("Total:"+total);
        int used = 0;
        for(int i=0; i<statsContainer.childCount; i++) {
            int statInput;
            string statName = statsContainer.GetChild(i).name;
            if(!int.TryParse(statsContainer.GetChild(i).Find(statName).Find("Input").GetComponent<Text>().text, out statInput)) {
                statInput = 0;
            }
            Debug.Log("Input:"+statInput);
            used += statInput;
        }
        Debug.Log("Used:"+used);
        int value = total - used;
        Debug.Log("Value:"+value);
        return value;
    }

    private void UpdateAvailablePoints() {
        availablePoints.SetActive(true);
        int value = StatPoints();
        availablePoints.transform.Find("Value").GetComponent<Text>().text = value.ToString();
    }

    private void PopulateStats() {
        Role role = Roles.GetRoleByName("Coach");
        foreach(string stat in role.Stats()) {
            GameObject statInput = Instantiate(statInputPrefab, statsContainer);
            statInput.name = stat;
            statInput.transform.Find("Label").GetComponent<Text>().text = stat;
            InputField inputField = statInput.transform.Find("Value").GetComponent<InputField>();
            if(inputField != null) {
                Debug.Log("InputField component found.");
                inputField.onEndEdit.AddListener(delegate { UpdateAvailablePoints(); });
                Debug.Log("Event listener added to InputField.");
                statInput.transform.Find("Value").name = statInput.name;
            } else {
                Debug.Log("Input not Found");
            } 
        }
    }

    void Awake() {
        availablePoints = GameObject.Find("StatPoints");
        statsContainer = GameObject.Find("Stats").GetComponent<Transform>();
        PopulateStats();
        UpdateAvailablePoints();
        inputs = gameObject.GetComponentsInChildren<InputController>().ToList();
    }

    public List<Stat> GetStats() {
        List<Stat> stats = new List<Stat>();
        List<InputController> inputs = statsContainer.GetComponentsInChildren<InputController>().ToList();
        if(inputs.Count > 0) {
            foreach(InputController input in inputs) {
                Debug.Log("Input Name: "+input.name);
                Debug.Log("Input Value: "+input.GetValue());
                Stat stat = new Stat(
                    input.name,
                    "Coach",
                    int.Parse(input.GetValue())
                );
                stats.Add(stat);
            }
        }
        return stats;
    }

    public void Home() {
        Debug.Log("Home");
        gameObject.SetActive(false);
        screenManager.GetScreenByName("Home").SetActive(true);
    }

    public void Submit() {
        Debug.Log("Submit");
        Person player = new Person(
            GetInputByName("firstName").GetValue(),
            GetInputByName("lastName").GetValue(),
            GetInputByName("location").GetValue(),
            "Coach",
            GetStats()
        );
        player.Push();
        Gym gym = new Gym("Test Gym Creation",player.id);
        gym.Push();
        GameManager.Instance().playerManager.player = player;
        GameManager.Instance().Save(player.FullName());
        GameManager.LoadScene("Game");
    }
}
