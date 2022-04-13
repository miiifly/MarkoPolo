using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text changingName;
    public Text changingHealth;
    public Text markopolo;
    public GameObject panel;
    bool activ = false;

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

    public void MarkoPolo()
    {   
        if(activ)
        {
            panel.SetActive(false);
            activ = false;
        }
        else
        {
            panel.SetActive(true);
            activ = true;
            markopolo.text = "";
            for(int i = 1; i <= 100; i++)
            {
                if(i%3 == 0 && i%5 == 0)
                {   
                    markopolo.text += " MarkoPolo ";
                    Debug.Log("MarkoPolo");
                }
                else if(i%3 == 0)
                {   
                    markopolo.text += " Marko ";
                    Debug.Log("Marko");
                }
                else if(i%5 == 0)
                {   
                    markopolo.text += " Polo ";
                    Debug.Log("Polo");
                }
                else
                {   
                    markopolo.text += " " + i + " ";
                    Debug.Log(i);
                }
            }  
        }
        
    }

}
