using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum State
{
    COMBAT,
    SWAPPING
}

public class GameManager : MonoBehaviour
{
    [HideInInspector] public State state;

    [HideInInspector] public Character character;
    [HideInInspector] public Hero hero;

    [HideInInspector] public Enemy enemy;
    [HideInInspector] public EnemyCreature creature;

    [HideInInspector] public int random;
    [HideInInspector] public List<int> checkExtractedCharacters = new List<int>();
    [HideInInspector] public List<int> checkExtractedEnemies = new List<int>();

    [SerializeField] private TextMeshProUGUI turnCounter;
    private int turn = 1;

    [Header("Party Info")]
    public GameObject partyContainer;
    [SerializeField] private List<GameObject> characterSlotPrefabs;
    [SerializeField] private int partySize;
    [HideInInspector] public List<GameObject> partyList = new();

    [Header("Enemy Info")]
    public GameObject enemiesContainer;
    [SerializeField] private List<GameObject> enemySlotPrefabs;
    [SerializeField] private int enemyPartySize;
    private List<GameObject> enemyPartyList = new();

    [Header("AbilityButtons")]
    [SerializeField] private List<Image> abilities;

    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        state = State.COMBAT;
    }

    private void Update()
    {
        //----------Player Debug Commands--------------

        if (Input.GetKeyDown(KeyCode.C) && partyContainer.transform.childCount < partySize)
        {
            CheckExtractedCharactersOrMonsters(checkExtractedCharacters,characterSlotPrefabs);
            partyList.Add(Instantiate(characterSlotPrefabs[random], partyContainer.transform));
        }

        if (Input.GetKeyDown(KeyCode.P) && character != null)
            CharacterPanel.Instance.UpdateCharacterStatsValue(character);
        if (Input.GetKeyDown(KeyCode.Q) && character != null)
            CharacterPanel.Instance.IncreaseCurrentStressBy20(character);
        if (Input.GetKeyDown(KeyCode.E) && character != null)
            CharacterPanel.Instance.DecreaseCurrentStressBy20(character);
        if (Input.GetKeyDown(KeyCode.A) && character != null)
            CharacterPanel.Instance.IncreaseCurrentHpBy20(character);
        if (Input.GetKeyDown(KeyCode.D) && character != null)
            CharacterPanel.Instance.DecreaseCurrentHpBy20(character);



        //----------Enemy Debug Commands---------------

        if (Input.GetKeyDown(KeyCode.C) && enemiesContainer.transform.childCount < enemyPartySize)
        {
            CheckExtractedCharactersOrMonsters(checkExtractedEnemies, enemySlotPrefabs);
            enemyPartyList.Add(Instantiate(enemySlotPrefabs[random], enemiesContainer.transform));
        }
        if (Input.GetKeyDown(KeyCode.F) && enemy != null)
            RightPanel.Instance.IncreaseCurrentHpBy20(enemy);
        if(Input.GetKeyDown(KeyCode.G) && enemy != null)
            RightPanel.Instance.DecreaseCurrentHpBy20(enemy);
        if (Input.GetKeyDown(KeyCode.H) && enemy != null)
            RightPanel.Instance.IncreaseEnemyStatsBy10(enemy);
        if (Input.GetKeyDown(KeyCode.I) && enemy != null)
            RightPanel.Instance.DecreaseEnemyStatsBy10(enemy);

        //----------Other Debug Commands---------------
        if (Input.GetKeyDown(KeyCode.Tab))
            RightPanel.Instance.SwitchMapAndInventory();
        if (Input.GetKeyDown(KeyCode.J) && turn < 10)
        {
            turn++;
            turnCounter.text = $"{turn}";
        }
        if (Input.GetKeyDown(KeyCode.K) && turn > 1)
        {
            turn--;
            turnCounter.text = $"{turn}";
        }
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void PassTurn()
    {
        if(hero != null)
            CharacterPanel.Instance.IncreaseCurrentStressBy20(character);
    }

    public void PrepareSwap()
    {
        if(hero != null)
            state = State.SWAPPING;
    }

    public void GreyOutOtherAbilities()
    {
        foreach (var ability in abilities)
        {
            if (ability.gameObject == EventSystem.current.currentSelectedGameObject)
            {
                ability.color = Color.white;
                continue;
            }

            ability.color = Color.grey;
        }
    }

    public void CheckExtractedCharactersOrMonsters(List <int> extractedInts, List<GameObject> prefabs)
    {
        random = Random.Range(0, prefabs.Count);

        if(extractedInts.Contains(random))
            CheckExtractedCharactersOrMonsters(extractedInts,prefabs);
        else
            extractedInts.Add(random);
    }
}
