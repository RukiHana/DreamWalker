using UnityEngine;
using System.Collections;

public class KeyDoorOpen : MonoBehaviour {

    public GameObject Player;
    public GameObject Door;
    public GameObject Key;
    public GameObject bgON;
    public GameObject bgOFF;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Key.GetComponent<Renderer>().enabled == true) {
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == Door)
                    {
                        Player.transform.position = new Vector3(-7, -2, 9);
                        bgON.SetActive(true);
                        bgOFF.SetActive(false);

                    }
                }

            }
        }

    }
}
