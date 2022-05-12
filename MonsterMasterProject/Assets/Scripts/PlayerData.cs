using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int numMonster;
    public string[] monsters;
    public string[] species;
    public int[] allStrength;
    public int[] allIntell;
    public int[] allDext;
    public int[] allAgile;
    public float[] allHappy;
    public float[] allHunger;
    public float[] maxHealth;
    public float[] curHealth;
    public float[] allClean;
    public int[] statCap;
    public int money;
    public int towerProgress;
    public MonsterStats[] party;

    public PlayerData (PlayerInfo player)
    {
        MonsterStats [] party = player.getMonsterParty();
        numMonster = party.Length;
        monsters = new string[numMonster];
        species = new string[numMonster];
        allStrength = new int[numMonster];
        allIntell = new int[numMonster];
        allDext = new int[numMonster];
        allAgile = new int[numMonster];
        allHappy = new float[numMonster];
        allHunger = new float[numMonster];
        allClean = new float[numMonster];
        maxHealth = new float[numMonster];
        curHealth = new float[numMonster];
        statCap = new int[numMonster];
        money = player.getMoney();
        towerProgress = player.getTowerProgress();
        Debug.Log(party[0].getMonsterSpecies());
        for (int i = 0; i < numMonster; i++)
        {
            monsters[i] = party[i].getMonsterName();
            species[i] = party[i].getMonsterSpecies();
            allStrength[i] = party[i].getVigor();
            allIntell[i] = party[i].getIntelligence();
            allDext[i] = party[i].getDexterity();
            allAgile[i] = party[i].getAgility();
            allHappy[i] = party[i].getHappinessStat();
            allClean[i] = party[i].getCleanlinessStat();
            allHunger[i] = party[i].getHungerStat();
            maxHealth[i] = party[i].getMaxHealth();
            curHealth[i] = party[i].getCurHealth();
            statCap[i] = party[i].getStatCap();
    }
    }
}
