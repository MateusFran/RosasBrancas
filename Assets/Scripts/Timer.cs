using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private float time;
    private bool jaVerificou;
    public bool acabouTempo;

    [SerializeField]
    private GameObject hud;

    public Text tempoEmTexto;

    private void Start()
    {
        acabouTempo = true;
        jaVerificou = true;
    }
    public void ComecarTempo(float tempoDefinido)
    {
        time = tempoDefinido;
    }
    public void PararTempo()
    {
        time = 0;
    }
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            tempoEmTexto.text = time.ToString("00");
            acabouTempo = false;
        }
        
        if(time <= 0 && jaVerificou)
        {
            //PlayerPrefs.SetInt("rodarParte", 1);
            acabouTempo = true;
            hud.SetActive(false);

            jaVerificou = false;
        }
    }
}
