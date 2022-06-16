using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnAgent : MonoBehaviour
{
    public GameObject Agent;
    private AgentControler agentControler;
    public int numAgent;
    public int lowTime = 2 , hightTime = 10;
    
    public GameObject board;
    private GameBoard gameboard;

    int numName = 1;
    int sec;
    float spawnTime;
    Vector3 position;
    
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

            //Pojawienie się Agentów z przypisanie Nazwy oraz przekazaniu rozmiarów planszy
            GameObject agent = Instantiate(Agent, position, Quaternion.identity, transform);
            agentControler = agent.GetComponent<AgentControler>();
            agentControler.BoardSettings(gameboard.length, gameboard.width);
            agent.name = "Agent" + numName;

            numName++;
            spawnTime = GetRandomSec();
            numAgent--;
        }
        else
        {
           spawnTime -= Time.deltaTime;
        }
    }


    //Sekundy w zakresie (lowTime, hightTime) otrzymane pseudolosowo
    public float GetRandomSec()
    {
        sec = Random.Range(lowTime,hightTime);
        //Debug.Log(sec);
        return (float)sec;
    }

    //Sprawdzenie miejsca gdzie ma się pojawić Agent na dostępność
    public Vector3 GetFreePosition()
    {    
        Vector3 pos = new Vector3 (0, 0.5f ,0);
        
        pos.x = Random.Range(0, gameboard.length);
        
        pos.z = Random.Range(0, gameboard.width);

        if(!Physics.CheckBox(pos, new Vector3(0.5f, 0.2f, 0.5f)))
        {   
           // Debug.Log("ThisWasFree -------------->" + pos);
            return pos;
        }
        else
        {   
            //Debug.Log("ThisPlaceisTaken -------------->" + pos);
            return GetFreePosition();
        }
    }
  
}
