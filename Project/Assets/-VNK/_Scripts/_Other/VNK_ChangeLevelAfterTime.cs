﻿using UnityEngine;
using System.Collections;

public class VNK_ChangeLevelAfterTime : MonoBehaviour {

	public string levelToLoad;
	public float startChangeLevelAfter;

	private bool calledChange;


	// Use this for initialization
	void Start(){
		calledChange = false;
		StartCoroutine("ChangeLevelWithDelay", startChangeLevelAfter);
	}
	
	// Update is called once per frame
	void Update(){
		if(calledChange && gameObject.GetComponent<VNK_FadeCamera>().alpha >= 1.0f){
			Application.LoadLevel(levelToLoad);
		}
	}

	IEnumerator ChangeLevelWithDelay(float delay){
		yield return new WaitForSeconds(delay);

		gameObject.GetComponent<VNK_FadeCamera>().FadeOut();
		calledChange = true;
	}
}