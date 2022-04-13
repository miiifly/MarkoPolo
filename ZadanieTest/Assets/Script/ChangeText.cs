using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text changingName;
    public Text changingHealth;

    public void ChangeName(string name)
    {   
        Debug.Log(name);
        changingName.text = "Name : " + name;
    }

    public void ChangeHealth(string health)
    {
        changingHealth.text = "Health : " + health;
    }
    public void SetDefault()
    {
        changingName.text = "Name : ";
        changingHealth.text = "Health : " ;
    }
    public void Hel()
    {
        Debug.Log("aagagagagag");
    }
}
