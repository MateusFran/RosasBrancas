using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {

	public void escolhaEsquerda(){

		PlayerPrefs.SetInt ("escolha", 1);
	}
	public void escolhaDireita(){
	
		PlayerPrefs.SetInt ("escolha", 2);
	}
}
