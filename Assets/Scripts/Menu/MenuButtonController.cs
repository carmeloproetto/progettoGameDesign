using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetAxis ("Vertical") != 0){
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
			if(!keyDown){
				//if(Input.GetAxis ("Vertical") < 0){
				if (Input.GetKeyDown(KeyCode.S)) {
					Debug.Log("Premo giù");
					if(index < maxIndex){
						index++;
					}else{
						index = 0;
					}
				} 
				//else if(Input.GetAxis ("Vertical") > 0){
				else if(Input.GetKeyDown(KeyCode.W)){
					Debug.Log("Premo su");
					if(index > 0){
						index --; 
					}else{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
	}

}
