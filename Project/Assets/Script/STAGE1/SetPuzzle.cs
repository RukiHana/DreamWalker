using UnityEngine;
using System.Collections;

public class SetPuzzle : MonoBehaviour {

    public GameObject Stage;
    public GameObject Puzzle;
    public GameObject obj;
    public GameObject item;

    // Use this for initialization
    void Start () {
        //Puzzle=GameObject.Instantiate(Puzzle);
        //Puzzle.SetActive(false);
        //a.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (item.GetComponent<SpriteRenderer>().enabled == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        Stage.SetActive(false);
                        Puzzle.SetActive(true);
                    }
                }
            }
        }

        }
    }
