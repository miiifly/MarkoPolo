using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBoard : MonoBehaviour
{
    [Range(10,20)]
    public int length , width;


    public GameObject Tile;
    public Material white;
    public Material black;
    Color col = Color.white;
    bool whitefirst = true;

    


  public  void GenerateBoard()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                
                GameObject go = Instantiate(Tile, new Vector3((float)i, 0, (float)j), Quaternion.Euler(90f, 0, 0), transform); 
                go.GetComponent<MeshRenderer>().material = whitefirst == true ? white : black;
                whitefirst = whitefirst == true ? false : true;
            }

            whitefirst = width % 2 == 0 ? !whitefirst : whitefirst;
        }
    }



    public void ClearChildren()
    {
        //Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

       // Debug.Log(transform.childCount);
    }

  

   
}
