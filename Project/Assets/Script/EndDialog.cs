using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndDialog : MonoBehaviour
{

    private GameObject manObject;
    private ObjectManager ob;
    private bool isPuzzle = false;

    public AudioClip bgm;
    public Sprite end;

    // Use this for initialization
    void Start()
    {

        manObject = GameObject.Find("object Manager");
        ob = manObject.GetComponent<ObjectManager>();
    }

    public void callAnything()
    {
        Debug.Log(ObjectManager.onGoingChapter);

        switch (ObjectManager.onGoingChapter)
        {
            case 1:
                ob.popUpCity(1);
                break;
            case 2:
                ob.popUpCity(2);
                break;
            case 3:
                ob.popUpStage(0);
                break;
            case 4:
                ob.popUpChapter(4);
                break;
            case 5:
                ob.popUpCity(4);
                break;
            case 6:
                ob.popUpCity(5);
                //ob.popUpChapter(6);
                break;
            case 7:
                ob.popUpStage(2);
                break;
            case 8:
                ob.popUpChapter(8);
                break;
            case 9:
                ob.popUpChapter(9);
                break;
            case 10:
                ob.popUpCity(9);
                break;
            case 11:
                ob.popUpChapter(11);
                break;
            case 12:
                ob.popUpChapter(12);
                break;
            case 13:
                ob.popUpStage(3);
                break;
            case 14:
                ob.popUpChapter(14);
                break;
            case 15:
                ob.popUpChapter(15);
                break;
            case 16:
                ob.popUpChapter(16);
                break;
            case 17:
                ob.popUpChapter(17);
                break;
            case 18:
                ob.popUpChapter(18);
                break;
            case 19:
                ob.popUpCity(17);
                break;
            case 20:
                ob.popUpChapter(20);
                break;
            case 21:
                StartCoroutine(ending());
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }

    public IEnumerator ending()
    {
        AudioSource a = GameObject.Find("Gamplay_FX").GetComponent<AudioSource>();
        a.clip = bgm;
        a.Play();

        GameObject x = GameObject.Find("Background01");
        SpriteRenderer xx = x.GetComponent<SpriteRenderer>();
        x.transform.localScale= new Vector3(4.2f, 4.2f, 0);
        xx.sprite = end;

        SoundManager s = GameObject.Find("_SoundsEmitter").GetComponent<SoundManager>();
        s.fadeOut();

        GameObject.Find("DialogUI").SetActive(false);

        VNK_FadeCamera fade = GameObject.Find("_GameManager").GetComponent<VNK_FadeCamera>();
        fade.FadeOut();


        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(1);
    }
    /*
    public IEnumerator nextStage1()
    {
        yield return new WaitForSeconds(5);
        ObjectManager x = GameObject.Find("object Manager").GetComponent<ObjectManager>();
        x.popUpChapter(3);
        
        Destroy(GameObject.Find("STAGE1"));

        yield return null;
    }*/
}
