using System.Collections;
using UnityEngine;
 
public class AgentControler : MonoBehaviour {
    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;
    private int direction;
    public int health = 3;
    string nameA ;
    GameObject tempObject;
    
    private int length, width;

    bool damage = true;
    bool active = true;

    public bool agentselect = false;


    void Start()
    {
        nameA = gameObject.name;
    }
  

    public void BoardSettings(int l , int w)
    {
        length = l;
        width = w;
    }
 
    private void Update() {

        if(health<=0 && agentselect == false)
        {   
            gameObject.SetActive(true);
            Destroy(gameObject);
        }

         if(health<=0 && active)
         {
            gameObject.SetActive(false);
            active = false;
            return;
        }
        
        if (_isMoving || health <= 0) return;

        direction = Random.Range(1,5);
        
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

    void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
           
           
            
            if((transform.position+dir).x > length-1 || (transform.position+dir).x <0 || (transform.position+dir).z > width-1 || (transform.position+dir).z <0)
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
        
        if(Physics.Raycast(transform.position, Vector3.left, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.forward, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                damage = false;                
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hit, 1f))
        {
            if(hit.collider.tag == "Agent" && damage)
            {   
                health--;
                hit.collider.gameObject.GetComponent<AgentControler>().health--;
                //Debug.Log(gameObject.name +" : -1 health");
                damage = false;                
            }
        }
        if(Physics.Raycast(transform.position, dir, out hit, 1.5f))
        {   

            //Debug.DrawRay(transform.position, dir, Color.green);
            if(hit.collider.tag == "Agent")
            {   

                return false;
                
            }

            
        }
        damage = true;
        return true;
    }
 
    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        _isMoving = false;
    }
}