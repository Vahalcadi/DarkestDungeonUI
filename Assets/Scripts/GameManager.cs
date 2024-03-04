using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Party Info")]
    [SerializeField] private GameObject partyContainer;
    [SerializeField] private GameObject characterSlotPrefab;
    [SerializeField] private int partySize;
    private List<GameObject> partyList;

    [Header("Enemy Info")]
    [SerializeField] private GameObject enemiesContainer;
    [SerializeField] private GameObject enemySlotPrefab;
    [SerializeField] private int enemyPartySize;
    private List<GameObject> enemyPartyList;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && partyContainer.transform.childCount < partySize)
            partyList.Add(Instantiate(characterSlotPrefab, partyContainer.transform));

        if (Input.GetKeyDown(KeyCode.C) && enemiesContainer.transform.childCount < enemyPartySize)
            enemyPartyList.Add(Instantiate(enemySlotPrefab, enemiesContainer.transform));
    }
}
