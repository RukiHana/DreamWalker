using UnityEngine;
using System.Collections;

public class VNK_ResumeLastDialog : MonoBehaviour {

	public GameObject[] sceneDialogs;


	// Use this for initialization
	void Awake(){
		if(PlayerPrefs.HasKey("keyLastDialog") && sceneDialogs.Length > 0){
			string lastDialogName = PlayerPrefs.GetString("keyLastDialog");

			for(int i = 0; i < sceneDialogs.Length; i++){
				if(sceneDialogs[i].name == lastDialogName){
					sceneDialogs[i].SetActive(true);
				}
				else{
					sceneDialogs[i].SetActive(false);
				}
			}
		}
	}
}
