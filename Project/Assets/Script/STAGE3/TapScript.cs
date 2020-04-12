using UnityEngine;
using System.Collections;

public class TapScript : MonoBehaviour {

    public GameObject gui;
    public GameObject dialog;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject obj;    // 상호작용하는 오브젝트


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if(Item1.GetComponent<Renderer>().enabled == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        Item1.GetComponent<Renderer>().enabled = false;
                        Item2.GetComponent<Renderer>().enabled = true;
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

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                gui.SetActive(false);
                dialog.SetActive(false);
            }
        }


    }

       
}
