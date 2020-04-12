using UnityEngine;
using System.Collections;

public class DestroyPassword : MonoBehaviour {

    public GameObject Me;
    public GameObject GUI;
    public GameObject Password;
    public GameObject Dialog;
    public GameObject Door;

    // Use this for initialization
    void Start () {

        GUI.SetActive(false);
        Destroy(Password);
        Destroy(Dialog);
        Door.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

       
        Destroy(Me);
	
	}
}
