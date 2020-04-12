using UnityEngine;
using System.Collections;

public class SetStage : MonoBehaviour {

    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;
    public GameObject S5;
    public GameObject S6;
    public GameObject S7;
    public GameObject S8;

    public GameObject STAGE;
    public GameObject Puzzle;

    public GameObject Set;
    public GameObject After;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (S1.activeSelf == true && S2.activeSelf == true && S3.activeSelf == true && S4.activeSelf == true && S5.activeSelf == true && S6.activeSelf == true && S7.activeSelf == true && S8.activeSelf == true)
        {
            Puzzle.SetActive(false);
            Set.SetActive(false);
            STAGE.SetActive(true);
            After.SetActive(true);
        }


    }
}
