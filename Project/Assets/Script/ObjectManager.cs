using UnityEngine;
using System.Collections;


public class ObjectManager : MonoBehaviour
{

    public static int onGoingChapter = 0;//현재 챕터 진행상황
    public GameObject[] chapter = new GameObject[21];
    public GameObject gui;

    public GameObject ground;
    public GameObject player;
    private GameObject camera;
    private CameraController cM;
    private GameObject dialogUI;

    //for popUpCity
    private GameObject bgmObject;//bgm 바꾸기
    private AudioSource bgm;
    private GameObject backObject;//배경 이미지
    private SpriteRenderer backGround;
    public GameObject[] charPrefab = new GameObject[10];
    public Sprite cityImage;//city image
    public AudioClip street;//dw_street
    private bool isCityPopUp = false;//현재 마을이 화면에 떠있는가?
    private PlayerMoving p;//움직일 수 있는 공간 조절
    public GameObject building;//배경 건물
    public GameObject cameraTarget;
    public GameObject crow;

    public Sprite park;
    public Sprite resta;
    public Sprite house;
    public Sprite forest;
    public Sprite denRoom;
    public Sprite crowd;
    public Sprite hospi;
    public Sprite hospi2;
    public Sprite moon;
    public Sprite st;
    

    public GameObject[] stage = new GameObject[4];

    public GameObject[] b = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        bgmObject = GameObject.Find("Background_Music");
        bgm = bgmObject.GetComponent<AudioSource>();

        backObject = GameObject.Find("Background01");
        backGround = backObject.GetComponent<SpriteRenderer>();

        camera = GameObject.Find("-Main Camera");
        cM = camera.GetComponent<CameraController>();

        //dialogUI = GameObject.Find("DialogUI");
        p = player.GetComponent<PlayerMoving>();

        popUpChapter(onGoingChapter);
        //popUpCity(1);
    }

    public void popUpChapter(int chapterNum)
    {
        //		VNK_FadeCamera fade = GameObject.Find ("_GameManager").GetComponent<VNK_FadeCamera> ();
        //		fade.FadeIn ();


        Debug.Log("chapter" + onGoingChapter);

        camera.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            b[i].SetActive(true);
        }

        GameObject.Find("Background01").SetActive(true);
        GameObject.Find("Background02").SetActive(true);
        GameObject.Find("Background03").SetActive(true);

        if (isCityPopUp)
        {
            pushCity();
            isCityPopUp = false;
        }

        if (chapterNum == 1 || chapterNum == 5 || chapterNum == 6)
        {
            backGround.sprite = park;
        }
        if (chapterNum == 2 || chapterNum == 4 || chapterNum == 8 || chapterNum == 12 || chapterNum == 14)
        {
            backGround.sprite = house;
        }

        if (chapterNum == 3 || chapterNum == 13)
        {
            backGround.sprite = forest;
        }
        if (chapterNum == 7)
        {
            backGround.sprite = moon;
        }
        if (chapterNum == 10)
        {
            backGround.sprite = denRoom;
        }

        if (chapterNum == 11)
        {
            backGround.sprite = crowd;
        }

        if (chapterNum == 15)
        {
            backGround.sprite = hospi;
        }
        if (chapterNum == 19)
        {
            backGround.sprite = st;
        }

        if (chapterNum == 20)
        {
            backGround.sprite = resta;
        }

        //현재 스토리가 어디까지 진행됐나를 체크해야함
        gui.SetActive(true);//UI가 뜨게 해야 함.
        GameObject.Instantiate(chapter[chapterNum]);
        //배경을 바꿔야 함 
        onGoingChapter += 1;


    }

    public void popUpDialog(string dialog, string nam)
    {//npc, 물건 선택시 대화창

        gui.SetActive(true);//UI가 뜨게 해야 함.

        GameObject body = GameObject.Find("TextBackground_Body");
        TextMesh txtBody = body.GetComponent<TextMesh>();
        GameObject name = GameObject.Find("TextBackground_Name");
        TextMesh txtName = name.GetComponent<TextMesh>();
        txtBody.text = dialog;//대사 변경 
        txtName.text = nam;
        //현재 상태를 저장해야함.
        //다음 행동 실행 
        //gui.SetActive(false);

    }


    public void detailCity(int num)
    {//세부 내용


        isCityPopUp = true;

        VNK_FadeCamera fade = GameObject.Find("_GameManager").GetComponent<VNK_FadeCamera>();
        fade.FadeIn();

        //alice, amelia, ben, denver, haley, innes, liam, revy, sydney, thiery,
        double[,] pos =  {
            {78.41,37.7,0.22,71.79,0.0f,28.3,63.6,73.53,0.0f,26.7},//1,2 
			{75.29,37.7,0.22,78.3,0.0f,28.3,63.6,0.0f,0.0f,71.79},//3,4
			{73.29,37.7,0.22,74.79,71.79,28.3,63.6,0.0f,0.0f,0.0f},//5
			{0.0f,37.7,4.22,0.0f,0.0f,73.29,63.6,0.0f,0.0f,71.79},//6,7,8 인파는 빠짐 
			{78.41,37.7,0.22,0.0f,0.0f,28.3,63.6,0.0f,73.00,26.7},//9,10
			{77.00,37.7,10.22,71.00,69.50,0.22,63.6,75.00,1.72,-1.72}};//11~16

        bgm.clip = street;//브금 바뀜. 
                          //bgm.volume=1;
        bgm.Play();
        SoundManager s = GameObject.Find("_SoundsEmitter").GetComponent<SoundManager>();
        StartCoroutine(s.fadeIn());
        backGround.sprite = cityImage;//배경 이미지 바뀜
        backGround.transform.localScale = new Vector3(4.5f, 4.5f, 1);//배경크기 조정
        backGround.transform.localPosition = new Vector3(35.4f, 1, backGround.transform.localPosition.z);

        player.SetActive(true);
        ground.SetActive(true);

        cM.target = cameraTarget;//카메라 조정 
        cM.enabled = true;

        // dialogUI.SetActive(false);

        p.rangeLeft = 3;//플레이어가 움직일 수 있는 범위 조정
        p.rangeRight = 62.7f;

        building.SetActive(true);

        //캐릭터들을 띠운다.
        //캐릭터들의 위치를 지정해준다.
        for (int i = 0; i < 10; i++)
        {
            if (pos[num, i] != 0)
            {
                charPrefab[i].SetActive(true);
                charPrefab[i].transform.localPosition =
                    new Vector3((float)pos[num, i], charPrefab[i].transform.localPosition.y, 10.0f);
            }
        }

        building.SetActive(true);//건물을 보이게 한다.
    }

    public void popUpCity(int num)
    {//배경이 도시로 바뀐 경우, 마을 캐릭터를 재배치 
        Debug.Log("popup city " + num);


        switch (num)
        {
            case 1:
            case 2:
                detailCity(0);
                break;
            case 3:
            case 4:
                detailCity(1);
                break;
            case 5:
                detailCity(2);
                break;
            case 6:
            case 7:
            case 8:
                crow.SetActive(true);
                detailCity(3);
                break;
            case 9:
            case 10:
                detailCity(4);
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
                detailCity(5);
                break;
            default://예비, 쓸일이 없길 바람 
                detailCity(5);
                break;
        }
    }

    public void pushCity()//화면 초기화 및 스토리 진행을 위해 구성을 바꾼다.
    {
        SoundManager s = GameObject.Find("_SoundsEmitter").GetComponent<SoundManager>();
        StartCoroutine(s.fadeOut());

        //		VNK_FadeCamera fade = GameObject.Find ("_GameManager").GetComponent<VNK_FadeCamera> ();
        //		fade.FadeOut ();

        building.SetActive(false);//건물을 안보이게 한다.
        player.transform.localPosition = new Vector3(5, player.transform.localPosition.y, player.transform.localPosition.z);//캐릭터 위치 초기화
        player.SetActive(false);//캐릭터 및 다른 npc를 끈다.

        backGround.transform.localScale = new Vector3(2, 2, 1);//배경크기 조정
        backGround.transform.localPosition = new Vector3(0, 1, backGround.transform.localPosition.z);

        for (int i = 0; i < 10; i++)
        {
            charPrefab[i].SetActive(false);
        }
        camera.transform.localPosition = new Vector3(0, 1, 0);//카메라 위치 초기화
        cM.target = player;
        cM.enabled = false;//카메라 컨트롤러 끔

        p.rangeLeft = -14;//플레이어가 움직일 수 있는 범위 조정
        p.rangeRight = 14;

        //UI 대화 초기화

    }

    public void popUpStage(int num)
    {
        camera.SetActive(false);
        for(int i = 0; i < 3; i++)
        {
            b[i].SetActive(false);
        }

        stage[num].SetActive(true);
    }

}
