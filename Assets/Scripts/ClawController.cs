using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public float horizSpeed = 5f;
    public float vertSpeed = 5f;
    public float liftSpeed= 2f;
    private int spaceCounter = 0;
    public bool isHorizontally = true;
    private bool isLifting = false; 

    // private GameObject grabbedObject = null;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void Update()
   {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Action();
        }
        Debug.Log("-------------------------" + spaceCounter);
    }
    void FixedUpdate()
{
    if (isHorizontally)
    {
        MoveHorizontally();
    }
    else
    {
        MoveVertically();
    }
    if (isLifting)
        {
            LiftObject();
        }

}

void MoveHorizontally()
{
    float move = Input.GetAxis("Horizontal") * horizSpeed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + new Vector2(move, 0));
}

void MoveVertically()
{
    float move = Input.GetAxis("Vertical") * vertSpeed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + new Vector2(0, move));
}

public void ToggleMovementDirection()
{
    isHorizontally = !isHorizontally;
}

private void OpenClaw()
    {
        rb.transform.Find("ClawL_root").gameObject.transform.rotation = Quaternion.Euler(0,0,-35);
        rb.transform.Find("ClawR_root").gameObject.transform.rotation = Quaternion.Euler(0,0,35);
    }

private void CloseClaw()
    {
        rb.transform.Find("ClawL_root").gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        rb.transform.Find("ClawR_root").gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

private void LiftObject()
{
        Vector3 liftPosition = gameObject.transform.position + Vector3.up * liftSpeed* Time.fixedDeltaTime;
        rb.MovePosition(liftPosition);
}

private void Action()
{        

    switch (spaceCounter)
    {
        case 0:
            OpenClaw();
            ToggleMovementDirection();
            break;
        case 1:
            CloseClaw();
            ToggleMovementDirection();
            break;
        case 2:
            isLifting = true; 
            spaceCounter = 0;
            break;
    }
        spaceCounter++;
}

// private void OnTriggerEnter2D(Collider2D other) 
// {
//     if (isOpen && other.CompareTag("Collectible"))
//     {
//         if (grabbedObject==null)
//         {
//             grabbedObject=other.gameObject;
//         }
//     }
// }
// private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.gameObject == grabbedObject)
//         {
//             grabbedObject = null;
//         }
//     }

}
