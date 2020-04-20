using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RestartBtn : MonoBehaviour
{
    private SphereMovement sphereMovementScript;
    public GameObject prefab;
    public GameObject newObj;

    void Start()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
        prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Sphere.prefab", typeof(GameObject));
        newObj = GameObject.Find("Sphere");
    }

    public void restoreNewInstance()
    {
        if (prefab && !newObj)
        {
            newObj = Instantiate(prefab, sphereMovementScript.getStartPos(), Quaternion.identity);
            int oldPoints = sphereMovementScript.getPoints();
            sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
            sphereMovementScript.setPoints(oldPoints);
        }
    }
}
