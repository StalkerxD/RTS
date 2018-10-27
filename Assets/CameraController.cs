using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public float panSpeed = 200f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;


    public Vector2 panLimit;


    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            pos.z += panSpeed * Time.deltaTime;
        }
        if ((Input.GetKey("s") || Input.mousePosition.y < panBorderThickness ))
        {

            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {

            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x < panBorderThickness)
        {

            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, 0, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, 0, panLimit.y);
        transform.position = pos;


	}
}
