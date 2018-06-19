using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
	
	public void Playpause(){

		if (AudioListener.pause) {
			AudioListener.pause = false;	
		} 
		else {
			AudioListener.pause = true;
		}

	}//fimvoid:
}
