using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    
    //vectores para limitar el movimiento de la camara en los ejes X e Y
    public Vector2 limitX;

    public Vector2 limitY; 

    public float interpolationRatio;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Mario_0").GetComponent<Transform>();
        Debug.Log(target.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //posicion deseada de la camara
        Vector3 desiredPosition = target.position + offset;

        //limitamos la posicion en la x
        float clampX = Mathf.Clamp(desiredPosition.x, limitX.x , limitX.y);
        //limitamos la posicion en la y
        float clampY = Mathf.Clamp(desiredPosition.y, limitX.x , limitX.y);

        //posicion limitada en X e Y
        Vector3 clamedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        Vector3 lerpedPosition = Vector3.Lerp(transform.position, clamedPosition, interpolationRatio);

        transform.position = clamedPosition;
    }
}
