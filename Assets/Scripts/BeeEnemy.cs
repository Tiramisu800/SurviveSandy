using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : Trap
{
    public float speed;
    public float distance = 2f;
    public Transform groundDetection;

    private bool movingLeft = true;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, new Vector3(0, -0.5f, 0), distance);
        if(!groundInfo.collider)
        {
            if(movingLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
}
