using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColl : MonoBehaviour
{
   void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag == "Agent")
            {
                Debug.Log("Blokkk");
            }
        }
}
