using UnityEngine;
using System.Collections;

public class DialogActive : MonoBehaviour {

    public GameObject gui;
    public GameObject dialog;
    public GameObject NextButton;
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
                if (hit.collider.gameObject == obj)
                {
                    gui.SetActive(true);
                    dialog.SetActive(true);

                }

            }

            if (hit.collider == null || hit.collider.gameObject != obj)
            {
                gui.SetActive(false);
                dialog.SetActive(false);
            }

        }

    }
}
