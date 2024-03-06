using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightPanel : MonoBehaviour
{
    [Header("EnemyPopUpPanel")]
    [SerializeField] private GameObject panel;

    [Header("EnemyInfos")]
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI enemyType;
    [SerializeField] private TextMeshProUGUI enemyhealthValue;
    [SerializeField] private TextMeshProUGUI dodgeValue;
    [SerializeField] private TextMeshProUGUI speedValue;

    [Header("EnemyResistances")]
    [SerializeField] private TextMeshProUGUI stunValue;
    [SerializeField] private TextMeshProUGUI blightValue;
    [SerializeField] private TextMeshProUGUI bleedValue;
    [SerializeField] private TextMeshProUGUI debuffValue;
    [SerializeField] private TextMeshProUGUI moveValue;

    [Header("MapAndInventory")]
    [SerializeField] private Image map;
    [SerializeField] private Image inventory;

    public static RightPanel Instance;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    public void SwitchMapAndInventory()
    {
        if (map.IsActive())
        {
            inventory.gameObject.SetActive(true);
            map.gameObject.SetActive(false);
        }
        else
        {
            inventory.gameObject.SetActive(false);
            map.gameObject.SetActive(true);
        }
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public void ShowEnemyInfos(Enemy enemy) // enemy as param
    {
        if (enemy == null)
            return;

        enemyName.text = enemy.enemyName;
        enemyType.text = enemy.enemyType;

        UpdateEnemyStatsUI(enemy);
    }

    public void SetFirstEnemyValues(Enemy enemy)
    {
        enemy.currentMaxHp = enemy.maxHp;
        enemy.currentHp = enemy.currentMaxHp;
        enemy.currentDodge = enemy.dodge;
        enemy.currentSpeed = enemy.speed;

        enemy.currentStun = enemy.stun;
        enemy.currentBlight = enemy.blight;
        enemy.currentBleed = enemy.bleed;
        enemy.currentDebuff = enemy.debuff;
        enemy.currentMove = enemy.move;
    }

    private void UpdateEnemyStatsUI(Enemy enemy)
    {
        EnemyCreature creature = GameManager.Instance.creature;

        creature.hpSlider.maxValue = enemy.currentMaxHp;
        creature.hpSlider.value = enemy.currentHp;

        enemyhealthValue.text = $"HP: {enemy.currentHp}/{enemy.currentMaxHp}";
        dodgeValue.text = $"DODGE: {enemy.currentDodge}";
        speedValue.text = $"SPD: {enemy.currentSpeed}";

        stunValue.text = $"{enemy.currentStun}%";
        blightValue.text = $"{enemy.currentBlight}%";
        bleedValue.text = $"{enemy.currentBleed}%";
        debuffValue.text = $"{enemy.currentDebuff}%";
        moveValue.text = $"{enemy.currentMove}%";
    }


    //---------------------------------------------------//

    public void IncreaseCurrentHpBy20(Enemy enemy)
    {
        if (enemy.currentHp + 20 > enemy.currentMaxHp)
            enemy.currentHp = enemy.currentMaxHp;
        else
            enemy.currentHp += 20;

        UpdateEnemyStatsUI(enemy);
    }

    public void DecreaseCurrentHpBy20(Enemy enemy)
    {
        if (enemy.currentHp - 20 < 0)
            enemy.currentHp = 0;
        else
            enemy.currentHp -= 20;

        UpdateEnemyStatsUI(enemy);
    }

    public void DecreaseEnemyStatsBy10(Enemy enemy)
    {
        if (enemy.currentMaxHp - 10 < 0)
            enemy.currentMaxHp = 0;
        else
            enemy.currentMaxHp -= 10;

        enemy.currentHp = enemy.currentMaxHp;
        enemy.currentDodge -= 10;
        enemy.currentSpeed -= 10;

        enemy.currentStun -= 10;
        enemy.currentBlight -= 10;
        enemy.currentBleed -= 10;
        enemy.currentDebuff -= 10;
        enemy.currentMove -= 10;

        UpdateEnemyStatsUI(enemy);
    }

    public void IncreaseEnemyStatsBy10(Enemy enemy)
    {
        enemy.currentMaxHp += 10;
        enemy.currentHp = enemy.currentMaxHp;
        enemy.currentDodge += 10;
        enemy.currentSpeed += 10;

        enemy.currentStun += 10;
        enemy.currentBlight += 10;
        enemy.currentBleed += 10;
        enemy.currentDebuff += 10;
        enemy.currentMove += 10;

        UpdateEnemyStatsUI(enemy);
    }
}
