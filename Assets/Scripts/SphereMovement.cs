using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    private Vector3 startPos;
    private int force = 10;
    private int jumpForce = 6;
    private bool isFalling;
    private Rigidbody rb;
    public GameObject prefab;
    public GameObject newObj;
    public int points = 0;
    public bool isProtected;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        rb = GetComponent<Rigidbody>();
        prefab = Resources.Load("Prefabs/Sphere", typeof(GameObject)) as GameObject;
        newObj = GameObject.Find("Sphere");
        isProtected = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (die)
        {
            transform.localPosition = startPos;
            velocity = 10;
        }*/
        if (Input.GetButtonDown("Jump") && !isFalling)
        {
            Jump();
            isFalling = true;
        }
        /*if (Input.GetKey(KeyCode.Return) && prefab && !newObj)
            restoreNewInstance();*/

    }

    // Detect when collision with something (Ground)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plain"))
            isFalling = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Spawner") && prefab && !newObj)
            newObj = Instantiate(prefab, new Vector3(10, 3, 10), Quaternion.identity);*/

        if (other.gameObject.CompareTag("Enemy") && isProtected)
        {
            isProtected = false;
            Destroy(other.gameObject);
            GetComponent<MeshRenderer>().material = Resources.Load("Materials/Colors/Red", typeof(Material)) as Material;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            isProtected = true;
            GetComponent<MeshRenderer>().material = Resources.Load("Materials/Colors/LightRed", typeof(Material)) as Material;
            points++;
        }
    }

    private void FixedUpdate()
    {
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
    }

    private void Jump()
    {
        if (rb && Input.GetButtonDown("Jump"))
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    public int getPoints()
    {
        return points;
    }

    public void setPoints(int newPoints)
    {
        points = newPoints;
    }

    public bool getIsProtected()
    {
        return isProtected;
    }

    public void restoreNewInstance()
    {
        newObj = Instantiate(prefab, startPos, Quaternion.identity);
    }

    public Vector3 getStartPos()
    {
        return startPos;
    }
}
