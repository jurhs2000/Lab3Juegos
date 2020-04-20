using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeEnemy : MonoBehaviour
{

    private SphereMovement sphereMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !sphereMovementScript.getIsProtected())
            Destroy(other.gameObject);

    }

}
