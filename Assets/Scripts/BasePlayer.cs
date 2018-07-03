using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePlayer : MonoBehaviour {

    #region Variáveis

    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float speed;

    public float speed_natural;

    public bool mover;

    protected bool facingright = true;

    protected Animator animacao;

    //variaveis de vez dos objetos;
    public int armarioVez,
                portaBedroomVez,
                tapeteVez,
                relogioVez;

    public int mesaVez,
               portaRedroomVez,
               cameraVez,
               quadroVez;


    //variaveis tecla E;
    public Image imagemTecla;
    public Sprite[] teclaE;

    public bool vasculhando,
                apertarTeclaE,
                podeApertarE;

    public int cenaObjetos;

    //outros script;
    public Datilografia datilografia;
    public InicioDatilografia inicioDatilografia;
    public ObjetoDatilografia objetoDatilografia;

    //Capitulos;
    public Capitulo_1 capitulo1;

    //gameobjects;
    public GameObject hudDialogo;


    #endregion 

    void Start () {
		
	}
	
	void Update () {
		
	}

    #region Funções Importantes

    #endregion
}
