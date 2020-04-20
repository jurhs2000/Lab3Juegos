using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class UI : MonoBehaviour
{

    private SphereMovement sphereMovementScript;
    private TMP_Text coins_text;

    // Start is called before the first frame update
    void Start()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
        coins_text = GetComponentInChildren<TMP_Text>();
    }

    private void FixedUpdate()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
        coins_text.text = "COINS: " + sphereMovementScript.getPoints();
    }

    
}
