using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Team yellowTeam;//times amarelo e rosa.
    public Team pinkTeam; 

    private void Awake()
    {
        yellowTeam = new Team("Amarelo");
        pinkTeam = new Team("Rosa");
    }
    public void AddPoint(Team team) //Adiciona um ponto para um time e verifica se ele ganhou a partida.
    {
        team.Points += 1;//adiciona um ponto.
        Debug.LogError("O time " + team.NameTeam + " fez mais um ponto.");
        Debug.LogError("Seus pontos atuais são " + team.Points);
        if(team.Points >= 5)//caso o ponto de algum time chegue a 5, esse time ganha.
        {
            Debug.LogError("O time " + team.NameTeam + "Venceu.");
        }
    }
}
