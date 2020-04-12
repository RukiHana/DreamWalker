using UnityEngine;
using System.Collections;

public class VNK_PlayDialogOnStart : MonoBehaviour {

	// This script plays a dialog when the game start 

	public VNK_DialogCreator dialog;


	// Use this for initialization
	void Start(){
		dialog.SendMessage("Play");
		VNK_DialogManager.currentDialog = gameObject;
	}
}
