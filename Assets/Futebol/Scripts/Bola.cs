using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 Spawn;//local onde a bola spawna quando é feito um ponto.
    public Points points; //refêrencia do script de pontos.

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gol Amarelo")//caso o objeto em colisão seja o gol amarelo, a função de adicionar pontos é chamada.
        {
            points.AddPoint(points.yellowTeam);
        }
        else if (other.tag == "Gol Rosa")
        {
            points.AddPoint(points.pinkTeam);
        }
        transform.position = Spawn;//retorna a bola para o centro do campo.
    }
}
