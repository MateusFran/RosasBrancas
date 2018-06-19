using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public GameObject objeto1;

	void Awake(){
		DontDestroyOnLoad (objeto1);
	}

}
