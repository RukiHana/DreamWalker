﻿using UnityEngine;
using System.Collections;

public class EventDialogTest : MonoBehaviour
{

    public GameObject gui;
    public GameObject obj;
    public string name;
    public string[] dialog;
    private GameObject dialogUI;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == obj)
                {
                    int rand = (int)Random.Range(0, dialog.Length);
                    string str = (string)dialog[rand].Clone();

                    popUpDialog(str, name);
                }
            }

        }

    }

    public void popUpDialog(string dialog, string nam)
    {//npc, 물건 선택시 대화창

        GameObject body = GameObject.Find("TextBackground_Body");
        TextMesh txtBody = body.GetComponent<TextMesh>();
        GameObject name = GameObject.Find("TextBackground_Name");
        TextMesh txtName = name.GetComponent<TextMesh>();
        txtBody.text = dialog;//대사 변경 
        txtName.text = nam;
        //현재 상태를 저장해야함.
        //다음 행동 실행 
    }

}
