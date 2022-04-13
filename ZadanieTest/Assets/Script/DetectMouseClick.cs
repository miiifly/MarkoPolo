using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectMouseClick : MonoBehaviour
{   

    Ray ray;
    RaycastHit hit;
    GameObject agent;
    bool _agentselect = false;

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
                    if(_agentselect)
                    {   
                        agent.GetComponent<AgentControler>()._agentselect = false;
                        agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                        if(agent.GetComponent<AgentControler>().health <= 0)
                        {   
                            
                            agent.SetActive(true);
                            Destroy(agent);
                        }  
                    }
                                  
                    agent = hit.transform.gameObject;
                    agent.GetComponent<AgentControler>()._agentselect = true;
                    changeText.ChangeName(agent.name);
                    changeText.ChangeHealth(agent.GetComponent<AgentControler>().health.ToString());
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.blue;
                    _agentselect = agent.GetComponent<AgentControler>()._agentselect;
                    
               
                    
                }

                else if(agent)
                {   
                    changeText.SetDefault();
                    agent.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.red;
                    _agentselect = false;
                    agent.GetComponent<AgentControler>()._agentselect = false;
                    if(agent.GetComponent<AgentControler>().health<=0)
                        {   
                            agent.SetActive(true);
                            Destroy(agent);
                        } 
                }
                else
                {
                    return;
                }
                
                 
            }
             
             
        }

        if(_agentselect)
        {
            changeText.ChangeHealth(agent.GetComponent<AgentControler>().health.ToString());
        }
        
       
    }
 
}
