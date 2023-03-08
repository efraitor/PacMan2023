using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variable para controlar el tiempo en el que MsPacman es invencible
    public float invincibleCounter = 0.0f;

    //Creamos un Singleton
    public static GameManager sharedInstance;

    private void Awake()
    {
        if(sharedInstance == null)
            sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Hacemos que el contador de tiempo vaya decreciendo hasta que se vacíe
        if(invincibleCounter > 0)
        {
            //Usando el Time.deltaTime le restamos 1 cada segundo al contador, porque le restamos las partes proporcionales de ese segundo dividido en frames
            invincibleCounter -= Time.deltaTime;
        }
    }

    //Este método es para inicializar el contador de tiempo de invencibilidad. Al llamarlo le pasamos ese tiempo por parámetro
    public void MakeInvincibleFor(float numberOfSeconds)
    {
        //Inicializamos el contador de tiempo de invencibilidad
        invincibleCounter += numberOfSeconds;
    }
}
