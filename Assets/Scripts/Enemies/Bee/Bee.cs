using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
     public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    private float waitTime;

    public float startWaitTime = 2;

    private int i = 0;

    private Vector2 actualPos;
    public Transform[] moveSpots;

    private void Start() {
        waitTime = startWaitTime;
    }

    private void Update() {

       
        //Hacer que se mueva de un punto a otro. Se multiplica el speed por el delta Time para evitar
        // que nuestro enemigo se mueva mas rapido o mas lento dependiendo de los fps de nuestro dispositivo
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed*Time.deltaTime);

        // Obtenemos la distancia entre los dos puntos 
        if(Vector2.Distance(transform.position, moveSpots[i].transform.position)<0.1f) {
            // Comprobamos si el tiempo de espera se ha cumplido
            if(waitTime<=0){
                // Si ya ha superado el tiempo de espera nos movemos al siguiente punto del array moveSpots
                if(moveSpots[i]!= moveSpots[moveSpots.Length-1]) {
                    i++;
                }
                else {
                    // En caso de que el punto al que hemos llegado sea el ultimo volvemos al principio
                    i = 0;
                }
                // Volvemos a setear el valor del tiempo de espera
                waitTime = startWaitTime;

            }
            else {
                waitTime -= Time.deltaTime;
            } 
        }

    }


}
