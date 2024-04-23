using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymController : MonoBehaviour
{
    public DataRecord gym;

    public void Populate(DataRecord gym) {
        this.gym = gym;
        GameObject.Find("Name").GetComponent<Text>().text = gym.Name();
    }
}
