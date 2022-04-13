using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectMouseClick : MonoBehaviour
{   

    Ray ray;
    RaycastHit hit;
    GameObject agent ;
    bool agentsel = false;

    ChangeText changeText;
    
    void Start()
    {   
      changeText = gameObject.GetComponent<ChangeText>();
      
    }

    void Update()
    { 
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             
             if(Input.GetMouseButtonDown(0))
             {   
                 if(hit.transform.tag == "Agent")
                { 
                    if(agentsel)
                    {   
                        agent.GetComponent<AgentControler>().agentselect = false;
                        agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                        if(agent.GetComponent<AgentControler>().health<=0)
                        {   
                            
                            agent.SetActive(true);
                            Destroy(agent);
                        }  
                    }
                                  
                    agent = hit.transform.gameObject;
                    agent.GetComponent<AgentControler>().agentselect = true;
                    changeText.ChangeName(agent.name);
                    changeText.ChangeHealth(agent.GetComponent<AgentControler>().health.ToString());
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.blue;
                    agentsel =agent.GetComponent<AgentControler>().agentselect;
                    
               
                    
                }
                else
                {   
                    changeText.SetDefault();
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                    agentsel = false;
                    agent.GetComponent<AgentControler>().agentselect = false;
                    if(agent.GetComponent<AgentControler>().health<=0)
                        {   
                            agent.SetActive(true);
                            Destroy(agent);
                        } 
                }
                
                 
            }
             
             
        }
        if(agentsel)
        {
            changeText.ChangeHealth(agent.GetComponent<AgentControler>().health.ToString());
        }
        
       
    }
 


 
}
