using UnityEngine;
using System.Collections;

public class ItemDialog : MonoBehaviour {

	public new string name;
	public string[] dialog;

	private GameObject obj;
	private ObjectManager manager;

	//캐릭터 또는 오브젝트에 맞는 대사를 배열에 저장.
	void Start () {

		obj = GameObject.Find ("object Manager");
		manager = obj.GetComponent<ObjectManager> ();
	}

	//클릭 시 대화가 나오게 한다.
	void OnMouseDown() {

		//챕터1 & 공원의 덴버와 레비
		if ((name.CompareTo ("덴버") ==0|| name.CompareTo ("레비")==0) && ObjectManager.onGoingChapter == 1) {
			manager.popUpChapter (1);
		}
		//챕터2 & 집에 돌아오면 실행
		if ((name.CompareTo("집")==0) && ObjectManager.onGoingChapter == 2) {
			manager.popUpChapter (2);
		}
		//챕터 4 & 공원의 티에리와 앨리스
		if ((name.CompareTo ("티에리")==0 || name.CompareTo ("앨리스")==0) && ObjectManager.onGoingChapter == 5) {
			SoundManager s = GameObject.Find ("_SoundsEmitter").GetComponent<SoundManager> ();
			StartCoroutine (s.fadeIn());
			manager.popUpChapter (5);
		}
		//챕터 5 & 헤일리, 덴버, 앨리스
		if ((name.CompareTo ("덴버") ==0|| name.CompareTo ("앨리스")==0|| name.CompareTo ("헤일리")==0) && ObjectManager.onGoingChapter == 6 ) {
			manager.popUpChapter (6);
		}
		//챕터 8 & 도서관 오른쪽 건물
		if ((name.CompareTo ("덴버집")==0) && ObjectManager.onGoingChapter == 10 ) {
			manager.popUpChapter (10);
		}

        //챕터 17 & 헤일리, 덴버, 앨리스
        if ((name.CompareTo("티에리") == 0 || name.CompareTo("이네스") == 0 || name.CompareTo("시드니") == 0) && ObjectManager.onGoingChapter == 19)
        {
            manager.popUpChapter(19);
        }

        VNK_PlayDialogOnStart v = null;
		v = this.GetComponent< VNK_PlayDialogOnStart > ();
		//건물인지 아닌지 체크 
		if ( v!= null) {//벨 벤인 경우
			v.enabled = true;
		} 
		else {
			//랜덤으로 문자열 선택.
			int rand = (int)Random.Range (0, dialog.Length);
			string str = (string)dialog [rand].Clone ();

			manager.popUpDialog (str,name);
		}

	}



}
