using UnityEngine;
using System.Collections;

public class EndStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(nextStage2());
	}

    IEnumerator nextStage2()
    {
        yield return new WaitForSeconds(5);
        ObjectManager x = GameObject.Find("object Manager").GetComponent<ObjectManager>();
        x.popUpChapter(7);
        Destroy(GameObject.Find("STAGE2"));
    }
}
