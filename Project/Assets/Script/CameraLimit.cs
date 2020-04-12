using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour {

    public GameObject Camera;
    public float Left;
    public float Right;
    public float Up;
    public float Down;
       

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Camera.transform.position.x > Right)
        {
            Camera.transform.position = new Vector3(Right, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (transform.position.x < Left)
        {
            Camera.transform.position = new Vector3(Left, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (transform.position.y > Up)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Up, Camera.transform.position.z);
        }
        if (transform.position.y < Down)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Down, Camera.transform.position.z);
        }

    }
}
