using UnityEngine;
using System.Collections;


public class GetItem : MonoBehaviour
{

    public GameObject PopUp;
    public GameObject obj;
    public GameObject Inven1;
    public GameObject Inven2;
    public bool Get;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 서랍장, 수레 등에서 아이템을 얻는 경우, 아이템 획득 이후 이벤트 비활성화를 위해 Get 변수 설정
        if (Get == false)
        {
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        PopUp.SetActive(true);
                        Inven1.GetComponent<Renderer>().enabled = true;
                        Inven2.GetComponent<Renderer>().enabled = true;
                    }
                }

                if (hit.collider == null || hit.collider.gameObject != obj)
                {
                    PopUp.SetActive(false);
                }

            }

        }

        if(Inven1.GetComponent<Renderer>().enabled == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Get = true;
                PopUp.SetActive(false);
            }
        }
  

       

    }
}
