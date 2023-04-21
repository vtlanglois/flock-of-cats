using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpotController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject boid;
    private BoidController bc;
    public string dir;
    private Animator anim;

    private string[] triggers = { "walkLeft", "walkRight", "walkLeftFront", "walkRightFront", "walkLeftBack", "walkRightBack", "walkBack", "walkFront" };

    void Start()
    {
        //boid = GameObject.GetComponentInParent(typeof(Boid)) as Boid;
        bc = gameObject.GetComponentInParent(typeof(BoidController)) as BoidController;
        dir = bc.directionText;
        anim = GetComponent<Animator>();
        setAnim();
    }

    // Update is called once per frame
    void Update()
    {
        if(dir != bc.directionText)
        {
            dir = bc.directionText;
            setAnim();
        }
        
    }

    void setAnim()
    {
        Debug.Log("setting direction: " + dir);

        resetTriggers(dir);

        if (dir == "E")
        {
            anim.SetTrigger("walkLeft");
        }
        else if(dir == "W")
        {
            anim.SetTrigger("walkRight");
        }
        else if (dir == "NE")
        {
            anim.SetTrigger("walkLeftFront");
        }
        else if (dir == "NW")
        {
            anim.SetTrigger("walkRightFront");
        }
        else if (dir == "SE")
        {
            anim.SetTrigger("walkLeftBack");
        }
        else if (dir == "SW")
        {
            anim.SetTrigger("walkRightBack");
        }
        else if (dir == "S")
        {
            anim.SetTrigger("walkBack");
        }
        else
        {
            anim.SetTrigger("walkFront");
        }

    }

    void resetTriggers(string ts)
    {
        if(ts == "E")
        {
            triggerIterator(0);
        }
        else if(ts == "W")
        {
            triggerIterator(1);
        }
        else if (ts == "NE")
        {
            triggerIterator(2);
        }
        else if (ts == "NW")
        {
            triggerIterator(3);
        }
        else if (ts == "SE")
        {
            triggerIterator(4);
        }
        else if (ts == "SW")
        {
            triggerIterator(5);
        }
        else if (ts == "S")
        {
            triggerIterator(6);
        }
        else
        {
            triggerIterator(7);
        }
    }

    void triggerIterator(int x)
    {
        for(int i = 0; i < 8; i++)
        {
            if(i != x)
            {
                    anim.ResetTrigger(triggers[i]);
            }
        }
    }
}
