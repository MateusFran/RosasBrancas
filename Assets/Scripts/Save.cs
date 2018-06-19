/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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