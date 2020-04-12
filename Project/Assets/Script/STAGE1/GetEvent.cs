using UnityEngine;
using System.Collections;

public class GetEvent : MonoBehaviour {


    public GameObject PopUp;  // 팝업
    public GameObject obj;    // 상호작용하는 오브젝트

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
                    PopUp.SetActive(true);

                }
            }

            if (hit.collider == null || hit.collider.gameObject != obj)
            {
                PopUp.SetActive(false);  // 팝업창 활성화
            }
        }


    }
}
