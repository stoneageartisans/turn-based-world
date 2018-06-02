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
    public Text unspentPointsValue;

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
        int newValue = character.getStat(statName).getBaseValue() - 1;

        if(newValue >= character.getStat(statName).getMinimum())
        {
            character.getStat(statName).setBaseValue(newValue);
            character.calculateDerivedStats();
            character.setUnspentPoints(character.getUnspentPoints() + 1);
            updateUI();
        }
    }

    public void increaseStat(string statName)
    {
        int points = character.getUnspentPoints();

        if(points > 0)
        {
            int newValue = character.getStat(statName).getBaseValue() + 1;

            if(newValue <= character.getStat(statName).getMaximum())
            {
                character.getStat(statName).setBaseValue(newValue);
                character.calculateDerivedStats();
                character.setUnspentPoints(points - 1);
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
        agilityValue.text = character.getStat("Agility").getBaseValue().ToString();
        mightValue.text = character.getStat("Might").getBaseValue().ToString();
        staminaValue.text = character.getStat("Stamina").getBaseValue().ToString();
        knowledgeValue.text = character.getStat("Knowledge").getBaseValue().ToString();
        perceptionValue.text = character.getStat("Perception").getBaseValue().ToString();
        willpowerValue.text = character.getStat("Willpower").getBaseValue().ToString();
        hitPointsValue.text = character.getHitPoints().ToString();
        toughnessValue.text = character.getToughness().ToString();
        actionValue.text = character.getAction().ToString();
        unspentPointsValue.text = character.getUnspentPoints().ToString();
    }
}
