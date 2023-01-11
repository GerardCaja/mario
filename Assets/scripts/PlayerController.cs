using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerHealth = 3;
    float playerSpeed = 5.5f;
    string texto = "Hello World";
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
    Debug.Log("texto");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * playerSpeed * Time.deltaTime;
    }
}
