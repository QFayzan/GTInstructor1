using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    public float turnSpeed = 6.0f;
    public float scaleChange = 2.0f;
   
    // Start is called before the first frame update
    //void Start(){}

    // Update is called once per frame
    void Update()
    {
        //Entire Spin Logic
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Rotating in Z axis Using vertical controls
        transform.Rotate(Vector3.left, turnSpeed * verticalInput * Time.deltaTime, Space.Self);
        //Rotating in Y axis using horizontal controls
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime, Space.Self);
        //increses size on hold space
        if (Input.GetKey(KeyCode.Space))
        {
           transform.localScale = transform.localScale + (new Vector3(1,1,1) * Time.deltaTime);

        }

    }
    //Basically we set a scale where if object was ever increased the game would slowly send it back to where it should be
    //inspiration for this was the input limits in that cow project 2.2
    private void LateUpdate()
    {
        if(transform.localScale.x > 1)
        {
            transform.localScale = transform.localScale - (new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime);
        }
    }
}
