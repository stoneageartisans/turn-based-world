using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    public InputField nameField;

    public Text agilityValue;
    public Text mightValue;
    public Text staminaValue;
    public Text knowledgeValue;
    public Text perceptionValue;
    public Text willpowerValue;
    public Text hitPointsValue;
    public Text toughnessValue;
    public Text actionValue;
    public Text statPointsValue;

    public int skillPoints = 5;
    public int statPoints = 15;

    Character character;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Debug.Log("ERROR: An instance of " + gameObject.name + " already exists.");
            Destroy(gameObject);
        }
    }

	void Start()
    {
        character = new Character();

        updateUI();
    }
	
	void Update ()
    {
        handleInput();
	}

    public void exit()
    {
        Application.Quit();
    }

    void handleInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }
    }

    public void decreaseStat(string statName)
    {
        Constants.StatType statType = (Constants.StatType) Enum.Parse(typeof(Constants.StatType), statName);

        int newValue = character.getStat(statType).getBaseValue() - 1;

        if(newValue >= character.getStat(statType).getMinimum())
        {
            character.getStat(statType).setBaseValue(newValue);
            character.calculateDerivedStats();
            statPoints ++;
            updateUI();
        }
    }

    public void increaseStat(string statName)
    {
        if(statPoints > 0)
        {
            Constants.StatType statType = (Constants.StatType) Enum.Parse(typeof(Constants.StatType), statName);

            int newValue = character.getStat(statType).getBaseValue() + 1;

            if(newValue <= character.getStat(statType).getMaximum())
            {
                character.getStat(statType).setBaseValue(newValue);
                character.calculateDerivedStats();
                statPoints --;
                updateUI();
            }
        }
    }

    public void setName()
    {
        character.setName(nameField.text);
    }

    void updateUI()
    {
        nameField.text = character.getName();
        agilityValue.text = character.getStat(Constants.StatType.Agility).getBaseValue().ToString();
        mightValue.text = character.getStat(Constants.StatType.Might).getBaseValue().ToString();
        staminaValue.text = character.getStat(Constants.StatType.Stamina).getBaseValue().ToString();
        knowledgeValue.text = character.getStat(Constants.StatType.Knowledge).getBaseValue().ToString();
        perceptionValue.text = character.getStat(Constants.StatType.Perception).getBaseValue().ToString();
        willpowerValue.text = character.getStat(Constants.StatType.Willpower).getBaseValue().ToString();
        hitPointsValue.text = character.getHitPoints().ToString();
        toughnessValue.text = character.getToughness().ToString();
        actionValue.text = character.getAction().ToString();
        statPointsValue.text = statPoints.ToString();
    }
}
