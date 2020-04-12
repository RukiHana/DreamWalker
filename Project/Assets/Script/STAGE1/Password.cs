using UnityEngine;
using System.Collections;

public class Password : MonoBehaviour {

    public string passwordToEdit = string.Empty;
    public string Answer;
    public GameObject Player;
    public GameObject Stage;
    public GameObject NextStage;

    void OnGUI()
    {
        passwordToEdit = GUI.PasswordField(new Rect(540, 330, 200, 30), passwordToEdit, "*"[0], 25);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(passwordToEdit == Answer)
        {
            Player.transform.position = new Vector3(-8, -2, 9);
            NextStage.SetActive(true);
            //16.08.21 수정부분,꽃이 계속 보이길래 수정함
            GameObject.Find("GamePopUp").SetActive(false);
            Stage.SetActive(false);
        }


    }
}
