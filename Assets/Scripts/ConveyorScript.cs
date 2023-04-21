using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    /* Scipt Notes: 
       conveyorSlice gets set outside of the script in the unity scene for each instance of the prefab
       conveyorSlice defaults at 0, the middle slice, with 1 being the left edge and 2 being the right edge.
       the animator gets pulled and will set the trigger to shift into the correct animation state at the start of the scene
     */

    public int conveyorSlice;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (conveyorSlice == 1)
        {
            anim.SetTrigger("LeftSlice");
        }
        else if (conveyorSlice == 2)
        {
            anim.SetTrigger("RightSlice");
        }
        else
        {
            anim.SetTrigger("MiddleSlice");
        }

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
