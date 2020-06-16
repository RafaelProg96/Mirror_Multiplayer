using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    string nameTeam;//nome do time
    public string NameTeam//construtor
    {
        get { return nameTeam;}
        set { nameTeam = value;}
    }
    int points;
    public int Points
    {
        get { return points;}
        set { points = value;}
    }

    public Team(string NameTeam)
    {
        this.NameTeam = NameTeam;
    }
}
