using UnityEngine;
using System.Collections;

public class movepiece : MonoBehaviour {

    public string pieceStatus = "idle";

    public KeyCode placePiece;

    public GameObject Success;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (pieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if((other.gameObject.name == gameObject.name))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            Success.SetActive(true);

        }

    }

    void OnMouseDown()
    {
        if (pieceStatus == "pickedup")
        {
            pieceStatus = "idle";

        }
        else
        {
            pieceStatus = "pickedup";
        }
        
    }
}
