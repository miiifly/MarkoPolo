using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseClick : MonoBehaviour
{   
   
 
 
     Ray ray;
     RaycastHit hit;
     GameObject agent ;
     bool agentsel = false;
     
     void Update()
     {
         
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             
             if(Input.GetMouseButtonDown(0))
             {   if(hit.transform.tag == "Agent")
                { 
                    if(agentsel)
                    {
                        agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                        if(agent.GetComponent<AgentControler>().health<=0)
                        {
                            agent.SetActive(true);
                            Destroy(agent);
                        }  
                    }
                                  
                    agent = hit.transform.gameObject;
                    agent.GetComponent<AgentControler>().agentselect = true;
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.white;
                    agentsel =agent.GetComponent<AgentControler>().agentselect;
                    Debug.Log(agent.name);
               
                    
                }
                else
                {
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                    agentsel = false;
                }
                 
             }
             
             
         }
        
       
     }
 


 
}
