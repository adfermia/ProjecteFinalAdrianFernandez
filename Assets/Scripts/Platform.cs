using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PlatformEffector2D effector2D;
    public float startWaitTime;
    private float waitedTime;
   
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp("down") || Input.GetKeyUp("s")) {
            waitedTime = startWaitTime;
        }
        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
        {
            if(waitedTime <= 0){
                effector2D.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }else {
                waitedTime -= Time.deltaTime;
            }
            
        }
        if(Input.GetKey("up") || Input.GetKey("space") || Input.GetKey("w")){
            effector2D.rotationalOffset = 0;
        }
    }
}
