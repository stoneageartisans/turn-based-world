using System;
using System.Collections.Generic;

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

    private HashSet<Skill> skills;

    public Character()
    {
        name = "";

        agility = new PrimaryStat(Constants.StatType.Agility, 10, 0, 20);
        might = new PrimaryStat(Constants.StatType.Might, 10, 0, 20);
        stamina = new PrimaryStat(Constants.StatType.Stamina, 10, 0, 20);
        knowledge = new PrimaryStat(Constants.StatType.Knowledge, 10, 0, 20);
        perception = new PrimaryStat(Constants.StatType.Perception, 10, 0, 20);
        willpower = new PrimaryStat(Constants.StatType.Willpower, 10, 0, 20);

        unspentPoints = 0;

        calculateDerivedStats();
        initializeSkills();
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

    public Skill getSkill(string skillName)
    {
        Skill skill = null;

        foreach(Skill _skill in skills)
        {
            if(_skill.getName().Equals(skillName))
            {
                skill = _skill;
                break;
            }
        }

        return skill;
    }

    public int getSkillRating(string skillName)
    {
        Skill skill = getSkill(skillName);

        int statTotal = 0;
        
        foreach(Constants.StatType statType in skill.getStats())
        {
            switch(statType)
            {
                case Constants.StatType.Agility:
                    statTotal += agility.getCurrentValue();
                    break;
                case Constants.StatType.Might:
                    statTotal += might.getCurrentValue();
                    break;
                case Constants.StatType.Stamina:
                    statTotal += stamina.getCurrentValue();
                    break;
                case Constants.StatType.Knowledge:
                    statTotal += knowledge.getCurrentValue();
                    break;
                case Constants.StatType.Perception:
                    statTotal += perception.getCurrentValue();
                    break;
                case Constants.StatType.Willpower:
                    statTotal += willpower.getCurrentValue();
                    break;
                default:
                    break;
            }
        }

        return ((int) Math.Round(((float) statTotal / 3.0f), 0, MidpointRounding.AwayFromZero) + skill.getPoints() - 4);
    }

    public PrimaryStat getStat(Constants.StatType statType)
    {
        switch(statType)
        {
            case Constants.StatType.Agility:
                return agility;
            case Constants.StatType.Might:
                return might;
            case Constants.StatType.Stamina:
                return stamina;
            case Constants.StatType.Knowledge:
                return knowledge;
            case Constants.StatType.Perception:
                return perception;
            case Constants.StatType.Willpower:
                return willpower;
            default:
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

    private void initializeSkills()
    {
        skills = new HashSet<Skill>();

        skills.Add(new Skill("Arcane", Constants.StatType.Knowledge, Constants.StatType.Knowledge, Constants.StatType.Knowledge));
        skills.Add(new Skill("Athletics", Constants.StatType.Agility, Constants.StatType.Might, Constants.StatType.Stamina));
        skills.Add(new Skill("Bartering", Constants.StatType.Knowledge, Constants.StatType.Perception, Constants.StatType.Willpower));
        skills.Add(new Skill("Healing", Constants.StatType.Knowledge, Constants.StatType.Knowledge, Constants.StatType.Perception));
        skills.Add(new Skill("Lockpicking", Constants.StatType.Agility, Constants.StatType.Knowledge, Constants.StatType.Perception));
        skills.Add(new Skill("Melee", Constants.StatType.Agility, Constants.StatType.Agility, Constants.StatType.Stamina));
        skills.Add(new Skill("Pickpocket", Constants.StatType.Agility, Constants.StatType.Agility, Constants.StatType.Perception));
        skills.Add(new Skill("Projectiles", Constants.StatType.Agility, Constants.StatType.Agility, Constants.StatType.Perception));
        skills.Add(new Skill("Riding", Constants.StatType.Agility, Constants.StatType.Perception, Constants.StatType.Stamina));
        skills.Add(new Skill("Shield", Constants.StatType.Agility, Constants.StatType.Might, Constants.StatType.Stamina));
        skills.Add(new Skill("Stealth", Constants.StatType.Agility, Constants.StatType.Perception, Constants.StatType.Stamina));
        skills.Add(new Skill("Survival", Constants.StatType.Knowledge, Constants.StatType.Perception, Constants.StatType.Stamina));
        skills.Add(new Skill("Traps", Constants.StatType.Agility, Constants.StatType.Knowledge, Constants.StatType.Perception));
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
