using UnityEngine;
using System.Collections;

public class PasswordLoadScene : MonoBehaviour {

    public string passwordToEdit = string.Empty;
    public string Answer;
    public GameObject Player;

    void OnGUI()
    {
        passwordToEdit = GUI.PasswordField(new Rect(540, 330, 200, 30), passwordToEdit, "*"[0], 25);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (passwordToEdit == Answer)
        {
            ObjectManager a = GameObject.Find("object Manager").GetComponent<ObjectManager>();
            a.popUpChapter(13);
            Destroy(GameObject.Find("STAGE3"));
        }


    }
}
