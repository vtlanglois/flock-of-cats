using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public float fixedRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + transform.position.z, transform.position.y - transform.position.z, 0);
        transform.eulerAngles = new Vector3 (fixedRotation, fixedRotation, fixedRotation);
    }
}
