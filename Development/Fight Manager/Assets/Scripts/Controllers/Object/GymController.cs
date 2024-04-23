using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymController : MonoBehaviour
{
    public ObjectRecord gym;

    public void Populate(ObjectRecord gym) {
        this.gym = gym;
        GameObject.Find("Name").GetComponent<Text>().text = gym.Name();
    }
}
