using UnityEngine;
using System.Collections;


public class GetItem2 : MonoBehaviour
{

    public GameObject PopUp;
    public GameObject obj;
    public GameObject Inven;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //아이템 획득 이후 이벤트 비활성화를 위해 Get 변수 설정
        if (Inven.GetComponent<Renderer>().enabled == false)
        {

            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        PopUp.SetActive(true);
                        Inven.GetComponent<Renderer>().enabled = true;
                    }
                }

                if (hit.collider == null || hit.collider.gameObject != obj)
                {
                    PopUp.SetActive(false);
                }

            }

        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                PopUp.SetActive(false);  // 아이템 얻었을 시 이벤트 생성
                obj.SetActive(false);
            }
        }

    }
}
