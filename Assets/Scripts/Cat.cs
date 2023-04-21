using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static ShaderApplier;

public class Cat : MonoBehaviour
{
    public UnityEvent onGameOver;
    public PaletteItem paletteItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.layer == 7)
        {
            Debug.Log("end!");
            onGameOver.Invoke();
            Time.timeScale = 0;
        }
    }
}
