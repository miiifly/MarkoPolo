using System.Collections;
using UnityEngine;
 
public class AgentControler : MonoBehaviour {
    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;
    private int direction;
    public int health = 3;

 

    int length, width;

  

    public void BoardSettings(int l , int w)
    {
        length = l;
        width = w;
    }
 
    private void Update() {
        if (_isMoving) return;

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
    
 
        void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
           
           
            
            if((transform.position+dir).x > length-1 || (transform.position+dir).x <0 || (transform.position+dir).z > width-1 || (transform.position+dir).z <0)
            {   
                Debug.Log("->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+(transform.position+dir));
                Debug.Log("HUJ   from >>>>>>>>>>>>>>>>>>>>>>>>>>>> " + transform.position);
                return;
            }
            StartCoroutine(Roll(anchor, axis));
        }
    }


    void MoveControl(Vector3 dir)
    {}
 
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