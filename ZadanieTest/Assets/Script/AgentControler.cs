using System.Collections;
using UnityEngine;
 
public class AgentControler : MonoBehaviour {
    [SerializeField] private float rollSpeed = 5;
    private bool _isMoving;
    private int direction;
    public int health = 3;

    
    
    private int length, width;

    bool _damage = true;
    bool _active = true;

    public bool _agentselect = false;


 
    //Otrzymanie rozmiarów planszy
    public void BoardSettings(int l , int w)
    {
        length = l;
        width = w;
    }


 
    private void Update() 
    {
        //Usuń agenta gdy zostanie odznaczony
        if(health <= 0 && _agentselect == false)
        {   
            gameObject.SetActive(true);
            Destroy(gameObject);
        }

        //Gdy Agent jest zaznaczony ale staric już wszystkie zycia zostaje wyłączony do momentu odznaczenia
        if(health <= 0 && _active)
        {
            gameObject.SetActive(false);
            _active = false;
            return;
        }
        
        //Gdy Agent jest w trakcie obrotu czekaj
        if (_isMoving ) return;

        direction = Random.Range(1, 5);
        

        //Psewdolosowa generacja kierunku ruchu
        switch(direction)
        {
            case 1:
            Assemble(Vector3.left);
            break;

            case 2:
            Assemble(Vector3.right);
            break;

            case 3:
            Assemble(Vector3.forward);
            break;

            case 4:
            Assemble(Vector3.back);
            break;
        }
       
    }


    void Assemble(Vector3 dir) 
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        
        //Sprawdzenie poruszania się w przedziale planszy
        if((transform.position + dir).x > length - 1 || (transform.position + dir).x <0 || (transform.position + dir).z > width - 1 || (transform.position + dir).z < 0)
        {   
             // Debug.Log("->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+(transform.position+dir));
            // Debug.Log("from >>>>>>>>>>>>>>>>>>>>>>>>>>>> " + transform.position);
            return;
        }
        if(Valid(dir))
        {
            StartCoroutine(Roll(anchor, axis));
        }
                
            
          
            
    }

     


    bool Valid(Vector3 dir)
    {
        
        RaycastHit hit;
        
        //Sprawdzenie czy obok Agentu niema innego objektu poprzez kastowanie promiena.
        if(Physics.Raycast(transform.position, Vector3.left, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && _damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                _damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && _damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                _damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.forward, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && _damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                _damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && _damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                _damage = false;                
            }
        }

        //Sprawdzenie czy jest mozliwy wykonany ruch w danym kierunku
        if(Physics.Raycast(transform.position, dir, out hit, 1.5f))
        {   

            //Debug.DrawRay(transform.position, dir, Color.green);
            if(hit.collider.tag == "Agent")
            {   

                return false;
                
            }

            
        }
        _damage = true;
        return true;
    }
    

    //Ruch poprzez obrotu dookoła krawędzi
    private IEnumerator Roll(Vector3 anchor, Vector3 axis) 
    {
        _isMoving = true;
        for (var i = 0; i < 90 / rollSpeed; i++) 
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        _isMoving = false;
    }
}