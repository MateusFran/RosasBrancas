using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCapitulo : MonoBehaviour {



    //Outros Códigos;
    public Datilografia datilografia;
    public InicioDatilografia inicioDatilografia;
    public ObjetoDatilografia objetoDatilografia;

    //cenários;
    public GameObject bedroom;
    public GameObject redroom;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Funções Importantes

    public void MudarCenario(string nomeCenario)
    {
        //hudTelaPreta.SetActive(true);

        if (nomeCenario == "Bedroom")
        {
            bedroom.SetActive(true);
            redroom.SetActive(false);
        }
        else if (nomeCenario == "Redroom")
        {
            bedroom.SetActive(false);
            redroom.SetActive(true);
        }
    }

    #endregion
}
