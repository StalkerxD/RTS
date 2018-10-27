using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

  
    public float speed = 100F;
    public float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    public float maxShift = 1000.0f; //Maximum speed when holdin gshift
    public float minFov = 15f;
    public float maxFov = 100f;
    public float sensitivity = 10f;

    int boundary = 1;
    int width;
    int height;
    private new Camera camera;
    float totalRun = 1.0f;
    
    //Move Camera with Right Click 
    //void Update()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        if (Input.GetAxis("Mouse X") > 0)
    //        {
    //            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
    //                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
    //        }

    //        else if (Input.GetAxis("Mouse X") < 0)
    //        {
    //            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
    //                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
    //        }
    //    }
    //}

    void Update()
        //Move the Camera with the Mouse move only
        {
            camera = GetComponent<Camera>();
            width = Screen.width;
            height = Screen.height;
            //Keyboard commands
            float f = 0.0f;
            Vector3 p = GetBaseInput();
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

            // Use the Scroll Wheel to zoom in and out. 
            float fov = camera.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            camera.fieldOfView = fov;

            //if (!screenRect.Contains(Input.mousePosition))
            //    return;
            //else
            //{
           

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    totalRun += Time.deltaTime;
                    p = p * totalRun * shiftAdd;
                    p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                    p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                    p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
                }
                else
                {
                    totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                    p = p * speed;
                }

                p = p * Time.deltaTime;
                Vector3 newPosition = transform.position;
                if (Input.GetKey(KeyCode.Space))
                { //If player wants to move on X and Z axis only
                    transform.Translate(p);
                    newPosition.x = transform.position.x;
                    newPosition.z = transform.position.z;
                    transform.position = newPosition;
                }
                else
                {
                    transform.Translate(p);
                }


                // Mouse Controll 
                Vector3 newPosition2 = transform.position;
                if (Input.mousePosition.x > width - boundary)
                    transform.Translate(p);
                {
                    transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                               0.0f, 0.0f);
                }

                if (Input.mousePosition.x < 0 + boundary)
                {
                    transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                               0.0f, 0.0f);
                    //newPosition2.x = transform.position.x;
                    //    newPosition2.z = transform.position.z;
                    //    transform.position = newPosition;
                }
                if (Input.mousePosition.y > height - boundary) //&& Mathf.Clamp(Input.mousePosition.y, 0, 500) == Input.mousePosition.y)
                {
                    transform.position += new Vector3(0.0f, 0.0f,
                                               Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
                }

                if (Input.mousePosition.y < 0 + boundary)
                {
                    transform.position += new Vector3(0.0f, 0.0f,
                                               Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);

                }
                

            
        //}
    }
    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
