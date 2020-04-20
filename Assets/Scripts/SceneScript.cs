using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneScript : MonoBehaviour
{

    private SphereMovement sphereMovementScript;
    public GameObject prefab;
    public GameObject newObj;

    // Start is called before the first frame update
    void Start()
    {
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
        prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Sphere.prefab", typeof(GameObject));
        newObj = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && prefab && !newObj)
        {
            restoreNewInstance();
        }
    }

    public void restoreNewInstance()
    {
        newObj = Instantiate(prefab, sphereMovementScript.getStartPos(), Quaternion.identity);
        int oldPoints = sphereMovementScript.getPoints();
        sphereMovementScript = FindObjectOfType(typeof(SphereMovement)) as SphereMovement;
        sphereMovementScript.setPoints(oldPoints);
    }
}
