using System.Collections.Generic;
using System;
using UnityEngine;

public class Character
{
    private string name;

    private PrimaryStat agility;
    private PrimaryStat might;
    private PrimaryStat stamina;
    private PrimaryStat knowledge;
    private PrimaryStat perception;
    private PrimaryStat willpower;

    private int unspentPoints;

    private int action;
    private int offensePoints;
    private int defensePoints;
    private int hitPoints;
    private int baseDefense;
    private int toughness;

    public Character()
    {
        name = "";

        agility = new PrimaryStat("Agility", 10, 0, 20);
        might = new PrimaryStat("Might", 10, 0, 20);
        stamina = new PrimaryStat("Stamina", 10, 0, 20);
        knowledge = new PrimaryStat("Knowledge", 10, 0, 20);
        perception = new PrimaryStat("Perception", 10, 0, 20);
        willpower = new PrimaryStat("Willpower", 10, 0, 20);

        unspentPoints = 15;

        calculateDerivedStats();
    }

    public void calculateDerivedStats()
    {
        action = (int) Math.Round((agility.getCurrentValueAsFloat() + stamina.getCurrentValueAsFloat() + perception.getCurrentValueAsFloat()) / 6.0f, 0, MidpointRounding.AwayFromZero);
        offensePoints = action;
        defensePoints = action;
        hitPoints = (int) Math.Round((might.getCurrentValueAsFloat() + stamina.getCurrentValueAsFloat()) / 2.0f, 0, MidpointRounding.AwayFromZero);
        baseDefense = action;
        toughness = (int) Math.Round((stamina.getCurrentValueAsFloat() + willpower.getCurrentValueAsFloat()) / 2.0f, 0, MidpointRounding.AwayFromZero);
    }

    public int getAction()
    {
        return action;
    }

    public int getBaseDefense()
    {
        return baseDefense;
    }

    public int getDefensePoints()
    {
        return defensePoints;
    }

    public int getHitPoints()
    {
        return hitPoints;
    }

    public string getName()
    {
        return name;
    }

    public int getOffensePoints()
    {
        return offensePoints;
    }

    public PrimaryStat getStat(string statName)
    {
        switch(statName.ToLower())
        {
            case "agility":
                return agility;
            case "might":
                return might;
            case "stamina":
                return stamina;
            case "knowledge":
                return knowledge;
            case "perception":
                return perception;
            case "willpower":
                return willpower;
            default:
                Debug.Log("ERROR: There is no primary stat named '" + statName + "'");
                return null;
        }
    }

    public int getToughness()
    {
        return toughness;
    }

    public int getUnspentPoints()
    {
        return unspentPoints;
    }

    public void setName(string newName)
    {
        name = newName;
    }

    public void setUnspentPoints(int newValue)
    {
        unspentPoints = newValue;
    }
}
