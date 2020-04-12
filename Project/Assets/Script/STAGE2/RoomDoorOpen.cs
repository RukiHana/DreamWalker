using UnityEngine;
using System.Collections;

public class RoomDoorOpen : MonoBehaviour {

    public GameObject Player;
    public GameObject Door;
    public GameObject bgON;
    public GameObject bgOFF;
    public GameObject obj;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == Door)
                {
                    Player.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - 1.5f, Player.transform.position.z);
                    bgON.SetActive(true);
                    bgOFF.SetActive(false);

                }
            }

        }

    }
}
