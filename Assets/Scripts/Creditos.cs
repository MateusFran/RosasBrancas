using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour {

	[SerializeField] private Animator creditos;

	void Start () {
		StartCoroutine("CreditosAnimacao");
	}
	private IEnumerator CreditosAnimacao(){
		creditos.SetTrigger("Subir");
		yield return new WaitForSeconds(0.5f);
	}
	
}
