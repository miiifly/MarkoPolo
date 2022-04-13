using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnAgent : MonoBehaviour
{
    public GameObject Agent;
    private AgentControler agentControler;
    public int numAgent;
    
    public GameObject board;
    private GameBoard gameboard;
    
   

    string nameAgent;
    int sec;
    float spawnTime;
    Vector3 position ;
    int x;
    void Start()
    {   
        gameboard = board.GetComponent<GameBoard>();
        
        spawnTime = GetRandomSec();
    }

   void Update()
   {
       if (spawnTime <= 0 && numAgent > 0) 
       {
            position = GetFreePosition();
            

            GameObject agent = Instantiate(Agent, position, Quaternion.identity);
            agentControler = agent.GetComponent<AgentControler>();
            agentControler.BoardSettings(gameboard.length, gameboard.width);
            spawnTime = GetRandomSec();
            numAgent--;
       }
       else
       {
           spawnTime -= Time.deltaTime;
       }
   }

   public float GetRandomSec()
   {
        sec = Random.Range(2,10);
        Debug.Log(sec);
        return (float)sec;
   }

   public Vector3 GetFreePosition()
   {    
        Vector3 pos = new Vector3 (0,0.5f,0);
        
        pos.x = Random.Range(0, gameboard.length);
        
        pos.z = Random.Range(0, gameboard.width);

        if(!Physics.CheckBox(pos, new Vector3(0.5f,0.2f,0.5f)))
        {   
            Debug.Log("ThisWasFree -------------->" + pos);
            return pos;
        }
        else
        {   
            Debug.Log("ThisPlaceisTaken -------------->" + pos);
            return GetFreePosition();
        }
   }
  

    // IEnumerator Spawn(string nameAgent, float sec , int l , int w) 
    // {   
         
    //     position.x = Random.Range(0,l);
    //     position.z = Random.Range(0, w);
       
      
    //     yield return new WaitForSeconds(sec);
    //      Instantiate(Agent, position, Quaternion.identity);
         
    // }
}
