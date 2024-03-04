using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public enum CharacterType
    {
        ARBALEST,
        BOUNTY_HUNTER,
        HIGHWAYMAN,
        PLAGUE_DOCTOR
    }

    [Header("CharacterImageAndModel")]
    public Image characterImage;
    public Image characterModel;

    [Header("Hp and Stress")]
    public int maxHp;
    public int maxStress;
    private int currentHp;
    private int currentStress;

    [Header("Stats")]
    public string characterName;
    public CharacterType characterType;
    public int accuracy;
    public float critChance;
    public int damage;
    public int dodge;
    public int protection;
    public int speed;

    //[Header("Skills")]
    /*skills*/

    //[Header("Equip and Trinkets")]
    /*stuff*/

    public void SetHp(int newCurrentHp) => currentHp = newCurrentHp; 
    public void SetStress(int newCurrentStress) => currentStress = newCurrentStress;
    public int GetHp() => currentHp;
    public int GetStress() => currentStress;
}
