using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymController : MonoBehaviour
{
    public Gym gym;

    public void Populate(Gym gym) {
        this.gym = gym;
        GameObject.Find("Name").GetComponent<Text>().text = gym.name;
    }
}
