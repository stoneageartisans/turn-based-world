using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    public GameObject avatar;
    public InputField nameField;
    public Slider genderSlider;

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

    public Text arcaneValue;
    public Text athleticsValue;
    public Text barteringValue;
    public Text healingValue;
    public Text lockpickingValue;
    public Text meleeValue;
    public Text pickpocketValue;
    public Text projectilesValue;
    public Text ridingValue;
    public Text shieldValue;
    public Text stealthValue;
    public Text survivalValue;
    public Text trapsValue;
    public Text skillPointsValue;

    public int skillPoints = 5;
    public int statPoints = 15;

    public float avatarRotateSpeed = 20.0f;

    float avatarRotationStart;

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

    public void assignGender()
    {
        character.setGender((Constants.Gender) genderSlider.value);
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

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if(Input.GetMouseButtonDown(0))
            {
                avatarRotationStart = Input.GetAxis("Mouse X");
            }

            if(Input.GetMouseButton(0))
            {
                float avatarRotationDelta = (avatarRotationStart - Input.GetAxis("Mouse X"));

                avatarRotationDelta *= avatarRotateSpeed;

                if(avatarRotationDelta < -360.0f)
                {
                    avatarRotationDelta += 360.0f;
                }

                if(avatarRotationDelta > 360.0f)
                {
                    avatarRotationDelta -= 360.0f;
                }

                avatar.transform.Rotate(Vector3.up * avatarRotationDelta);
            }
        }
    }

    public void decreaseSkill(string skillName)
    {
        int newValue = character.getSkill(skillName).getPoints() - 1;

        if(newValue >= 0)
        {
            character.getSkill(skillName).setPoints(newValue);
            skillPoints ++;
            updateUI();
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

    public void increaseSkill(string skillName)
    {
        if(skillPoints > 0)
        {
            int newValue = character.getSkill(skillName).getPoints() + 1;
            character.getSkill(skillName).setPoints(newValue);
            skillPoints --;
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

        genderSlider.value = (int) character.getGender();

        arcaneValue.text = character.getSkillRating("Arcane").ToString();
        athleticsValue.text = character.getSkillRating("Athletics").ToString();
        barteringValue.text = character.getSkillRating("Bartering").ToString();
        healingValue.text = character.getSkillRating("Healing").ToString();
        lockpickingValue.text = character.getSkillRating("Lockpicking").ToString();
        meleeValue.text = character.getSkillRating("Melee").ToString();
        pickpocketValue.text = character.getSkillRating("Pickpocket").ToString();
        projectilesValue.text = character.getSkillRating("Projectiles").ToString();
        ridingValue.text = character.getSkillRating("Riding").ToString();
        shieldValue.text = character.getSkillRating("Shield").ToString();
        stealthValue.text = character.getSkillRating("Stealth").ToString();
        survivalValue.text = character.getSkillRating("Survival").ToString();
        trapsValue.text = character.getSkillRating("Traps").ToString();
        skillPointsValue.text = skillPoints.ToString();
    }
}
