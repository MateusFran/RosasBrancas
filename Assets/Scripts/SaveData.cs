using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveData : MonoBehaviour{

	[SerializeField] List<int> escolhas = new List<int>();

	[SerializeField] private Capitulo_1 capitulo_1;

	public void SalvarEscolhas(){
		escolhas.Add(capitulo_1.EscolhaAtual);
	}
}

/*
public class salvamento : MonoBehaviour {

	public static void SavePlayer(Player player)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

		PlayerData data = new PlayerData (player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static int[] LoadPlayer(){
		
		if (File.Exists(Application.persistentDataPath + "/player.sav")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Create);

			PlayerData data = bf.Serialize (stream) as PlayerData;

			stream.Close ();
			return data.stats;
		}

	}

}

[Serializable]
public class PlayerData {

	public int[] stats;

	public int[] contagemObjetos;

	public PlayerData(Player player){
		
	}
}
*/