using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public float horizSpeed = 5f;
    public float vertSpeed = 5f;

    private bool isHorizontally = true;

    
    void Update()
    {
        if (isHorizontally)
        {
            MoveHorizontally();
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isHorizontally = false;
            }
        }
        else 
        {
            MoveVertically();
        }

    }

    private void MoveHorizontally()
    {
        float moveInput  = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput*horizSpeed, 0);
        transform.Translate(movement*Time.deltaTime);
    }

    private void MoveVertically()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0,moveInput*vertSpeed);
        transform.Translate(movement*Time.deltaTime);
    }
}
