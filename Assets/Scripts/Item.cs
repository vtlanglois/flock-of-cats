using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Grabbable
{
    private bool isGrabbable = true;
    private bool isPlaced = false;
    [SerializeField] public float speed;
    private Rigidbody2D rigidbody2d;

    public GameObject LureManager;

    public string type;

    /*
    private void OnEnable()
    {
        GameplaySettings.onUpdatedConveyerBeltSpeed += UpdateSpeed;
    }



    private void OnDisable()
    {
        GameplaySettings.onUpdatedConveyerBeltSpeed -= UpdateSpeed;
    }
    */
    private void Start()
    {
        LureManager = GameObject.Find("LureManager");
        speed = gameSettings.gameplaySettings.conveyerBeltSpeed;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(Vector3.right * speed, ForceMode2D.Force);
    }



    public override void Update() {

        if (isBeingHeld)
        {

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }

        if (isPlaced) {
            var LureController = LureManager.GetComponent<LureManager>();
            LureController.SendInfo(transform.position, type);
        }
    }



    public override void OnMouseDown()
    {
        //if the object can be grabbed and is currently not being held
        if (Input.GetMouseButtonDown(0) && isBeingHeld == false && isGrabbable)
        {

            Debug.Log("grab!");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
        //if the object is being held and the click and hold setting is disabled
        else if (gameSettings.controlSettings.isClickAndHoldEnabled == false && Input.GetMouseButtonDown(0) && isBeingHeld)
        {
            Release();

        }

    }

    public override void OnMouseUp()
    {
        //if click and hold is enabled  and the object can be grabbed
        if (gameSettings.controlSettings.isClickAndHoldEnabled && isGrabbable)
        {
            Release();
        }

    }

    void Release()
    {
        // the object is no longer being held, nor grabbable
        isBeingHeld = false;
        isGrabbable = false;
        BeginCountdown();
    }

    void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (isGrabbable)
        {
            StopMovement();
            rigidbody2d.AddForce(Vector3.right * speed, ForceMode2D.Force);
            
        }
    }
    void BeginCountdown()
    {
        StopMovement();
        StartCoroutine(Countdown());
    }

    void StopMovement()
    {
        rigidbody2d.velocity = Vector3.zero;
        rigidbody2d.angularVelocity = 0f;
    }

    IEnumerator Countdown()
    {
        isPlaced = true;

        yield return new WaitForSeconds(gameSettings.gameplaySettings.itemTimeDuration);

        isPlaced = false;

        var LureController = LureManager.GetComponent<LureManager>();
        LureController.RemoveInfo(transform.position, type);
        Debug.Log("dead");
        Destroy(gameObject);
    }

   
}
