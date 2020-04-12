using UnityEngine;
using System.Collections;

public class DestroyBGM : MonoBehaviour {

    public GameObject obj;
    public GameObject Music;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(Music);
        Destroy(obj);

    }
}
