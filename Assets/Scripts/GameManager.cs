using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Character character;
    [HideInInspector] public Hero hero;

    [HideInInspector] public int random;
    [HideInInspector] public List<int> checkExtractedInts = new List<int>();

    [Header("Party Info")]
    [SerializeField] private GameObject partyContainer;
    [SerializeField] private List<GameObject> characterSlotPrefabs;
    [SerializeField] private int partySize;
    private List<GameObject> partyList = new();

    [Header("Enemy Info")]
    [SerializeField] private GameObject enemiesContainer;
    [SerializeField] private GameObject enemySlotPrefab;
    [SerializeField] private int enemyPartySize;
    private List<GameObject> enemyPartyList = new();

    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && partyContainer.transform.childCount < partySize)
        {
            CheckExtractedCharacters();
            partyList.Add(Instantiate(characterSlotPrefabs[random], partyContainer.transform));
        }

        if (Input.GetKeyDown(KeyCode.C) && enemiesContainer.transform.childCount < enemyPartySize)
            enemyPartyList.Add(Instantiate(enemySlotPrefab, enemiesContainer.transform));

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
    }

    public void CheckExtractedCharacters()
    {
        random = Random.Range(0, characterSlotPrefabs.Count);

        if(checkExtractedInts.Contains(random))
            CheckExtractedCharacters();
        else
            checkExtractedInts.Add(random);
    }
}
