using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoidController : MonoBehaviour
{
    public int SwarmIndex { get; set; }
    public float NoClumpingRadius { get; set; }
    public float LocalAreaRadius { get; set; }
    public float Speed { get; set; }
    public float SteeringSpeed { get; set; }
    public Vector2 Direction;

    public List<Vector3> targetPoints;
    public GameObject lureManager;

    public string[] typeList = {"mouse", "yarn", "fish", "none", "all"};

    public TextMeshProUGUI directionUI;

    public string directionText;

    public void Start() {
        lureManager = GameObject.Find("LureManager");

        int randomIndex = Random.Range(0, 5);
        string tag = typeList[randomIndex];
        transform.gameObject.tag = tag;
        Debug.Log("My tag is: " + tag);

        directionText = "";
    }

    public void SimulateMovement(List<BoidController> other, float time)
    {
        //default vars
        var steering = Vector3.zero;

        var separationDirection = Vector3.zero;
        var separationCount = 0;
        var alignmentDirection = Vector3.zero;
        var alignmentCount = 0;
        var cohesionDirection = Vector3.zero;
        var cohesionCount = 0;

        var leaderBoid = other[0];
        var leaderAngle = 180f;
    

        foreach (BoidController boid in other)
        {
            //skip self
            if (boid == this)
                continue;

            var distance = Vector3.Distance(boid.transform.position, this.transform.position);

            //identify local neighbour
            if (distance < NoClumpingRadius)
            {
                separationDirection += boid.transform.position - transform.position;
                separationCount++;
            }

            //identify local neighbour
            if (distance < LocalAreaRadius && boid.SwarmIndex == this.SwarmIndex)
            {
                alignmentDirection += boid.transform.forward;
                alignmentCount++;

                cohesionDirection += boid.transform.position - transform.position;
                cohesionCount++;

                //identify leader
                var angle = Vector3.Angle(boid.transform.position - transform.position, transform.forward);
                if (angle < leaderAngle && angle < 90f)
                {
                    leaderBoid = boid;
                    leaderAngle = angle;
                }
            }



        }

        if (separationCount > 0)
            separationDirection /= separationCount;

        //flip
        separationDirection = -separationDirection;

        if (alignmentCount > 0)
            alignmentDirection /= alignmentCount;

        if (cohesionCount > 0)
            cohesionDirection /= cohesionCount;

        //get direction to center of mass
        cohesionDirection -= transform.position;

        //weighted rules
        steering += separationDirection.normalized;
        steering += alignmentDirection.normalized;
        steering += cohesionDirection.normalized;

        //Lure attraction
        Vector3 targetPosition = Vector3.zero;

        if (!(targetPoints == null)) {
            float shortestDistance = 1000;

            foreach (Vector3 point in targetPoints) {
                if (shortestDistance >= Distance(transform.position, point)) {
                    shortestDistance = Distance(transform.position, point);
                    targetPosition = point;
                }
            }
        }

        steering += (targetPosition - transform.position).normalized;

        //local leader
        if (leaderBoid != null)
            steering += (leaderBoid.transform.position - transform.position).normalized;

        //obstacle avoidance
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, LocalAreaRadius, LayerMask.GetMask("Default")))
            steering = ((hitInfo.point + hitInfo.normal) - transform.position).normalized;

        //apply steering
        if (steering != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(steering), SteeringSpeed * time);

        //move 
        transform.position += transform.TransformDirection(new Vector3(0, 0, Speed)) * time;
        transform.position = new Vector3(transform.position.x + transform.position.z, transform.position.y - transform.position.z, 0);
        Direction = new Vector2(steering.normalized.x, steering.normalized.y);
        //Debug.Log("direction:" + Direction.ToString());
        displayDirection(Direction);
    }

    public void SetTargetPoint(Vector3 targetPoint) {
        if (!targetPoints.Contains(targetPoint))
            targetPoints.Add(targetPoint);
    }

    public void RemoveTargetPoint(Vector3 targetPoint) {
        while (targetPoints.Contains(targetPoint)) {
            targetPoints.Remove(targetPoint);
        }
    }

    public float Distance(Vector3 pos1, Vector3 pos2) {
        float xDiff = pos2.x - pos1.x;
        float yDiff = pos2.y - pos1.y;

        return Mathf.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
    }

    public void displayDirection(Vector3 direction) {
        //string directionText = "";
        directionText = "";

        if (Mathf.Round(direction.y) == -1) {
            directionText += "N";          
        } else if (Mathf.Round(direction.y) == 1){
            directionText += "S";   
        } else {
            directionText += "";
        }

        if (Mathf.Round(direction.x) == -1) {
            directionText += "E";          
        } else if (Mathf.Round(direction.x) == 1){
            directionText += "W";   
        } else {
            directionText += "";
        }

        directionUI.text = directionText;
    }

    public string getDirectionText()
    {
        return directionText;
    }
}