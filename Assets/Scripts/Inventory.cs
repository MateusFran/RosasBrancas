using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("chave", 0);

	}
	void Update () {
	}

}
/*
if (Input.GetKeyDown (KeyCode.Q)) {
	if (hud_inventory.activeSelf) {
		hud_inventory.SetActive (false);
		//animacao.SetBool ("closeInventory", true);


	} else {
		hud_inventory.SetActive (true);
		//animacao.SetBool ("openInventory", true);

	}
}
	if (hud_inventory.activeSelf) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				//animacao.SetBool ("openIventory", true);
				hud_inventory.SetActive (true);
				state = true;
			}
		}
		else if(hud_inventory.active == false) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				state = false;
				//animacao.SetBool ("closeInventory", true);
				hud_inventory.SetActive (false);
				state = false;
			}
		}	*/