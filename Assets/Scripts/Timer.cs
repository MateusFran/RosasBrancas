using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private float time;

    public bool acabouTempo;

    [SerializeField]
    private GameObject hud;

    public Text tempoEmTexto;


    public void ComecarTempo(float tempoDefinido)
    {
        time = tempoDefinido;
    }
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            tempoEmTexto.text = time.ToString("00");
        }
        
        if(time <= 0)
        {
            acabouTempo = true;
            hud.SetActive(false);
        }
    }
}
