using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSite : MonoBehaviour {

	// Use this for initialization
	public void Site(string url){
		Application.OpenURL(url.ToString());
	}
}
