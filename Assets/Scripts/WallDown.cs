using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDown : MonoBehaviour
{
    private float velocity = -1;
    private Vector3 startPos;
    private SphereMovement sphereMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
    }

    // Update is called once per frame
    void Update()
    {
        if (sphereMovementScript.getPoints() == 9 && velocity == -1)
        {
            moveDown();
        }
    }

    private void FixedUpdate()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
    }

    void moveDown()
    {
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime, Space.World);
        if (transform.localPosition.y < 0.25)
        {
            velocity = 0;
        }
    }

}
