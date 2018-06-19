using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Read_Txt : MonoBehaviour {

	public string TextoArquivo;

	// Use this for initialization
	void Start () {
		TextoArquivo = File.ReadAllText("Assets\\Dialogo\\Falas.txt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
