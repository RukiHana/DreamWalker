using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    public GameObject Inven;
    public GameObject obj;
    public GameObject Sound;
    /*
        // Use this for initialization
        void Start()
        {

        }
        */
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && Inven.GetComponent<SpriteRenderer>().enabled)
            {
                if (hit.collider.gameObject == obj)
                {
                    Sound.SetActive(true);
                    Destroy(obj);

                    //16.08.20 수정부분
                    if (ObjectManager.onGoingChapter == 3 && gameObject.name == "Vine")
                    {
                        ObjectManager x = GameObject.Find("object Manager").GetComponent<ObjectManager>();
                        x.popUpChapter(3);
                        Destroy(GameObject.Find("STAGE1"));
                    }


                }
            }

        }

        else { }
    }
}
