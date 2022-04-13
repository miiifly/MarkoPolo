using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBoard : MonoBehaviour
{
    [Range(10,20)]
    public int length , width;


    public GameObject Tile;
    public GameObject CameraCenter;
    public Material white;
    public Material black;
    Color col = Color.white;
    bool whitefirst = true;

    

    //Tworzenie planszy
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
        Instantiate(CameraCenter,new Vector3(((float)length-1)/2, 0, ((float)width-1)/2), Quaternion.identity, transform);
    }


    //Niszczenie popszednie planszy 
    public void ClearChildren()
    {
        
        int i = 0;

        
        GameObject[] allChildren = new GameObject[transform.childCount];

        
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

       
    }

  

   
}
