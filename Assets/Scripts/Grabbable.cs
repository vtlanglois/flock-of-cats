using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Grabbable : MonoBehaviour
{
    public GameSettings gameSettings;
    protected float startPosX;
    protected float startPosY;
    protected bool isBeingHeld = false;
    // Update is called once per frame
    public virtual void Update()
    {

        if (isBeingHeld)
        {

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    public virtual void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && isBeingHeld == false)
        {

            Debug.Log("grab!");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
        else if (gameSettings.controlSettings.isClickAndHoldEnabled == false && Input.GetMouseButtonDown(0) && isBeingHeld)
        {
            Debug.Log("release!");
            isBeingHeld = false;

        }

    }

    public virtual void OnMouseUp()
    {
        if (gameSettings.controlSettings.isClickAndHoldEnabled)
        {
            isBeingHeld = false;
        }

    }
}
