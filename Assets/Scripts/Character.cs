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
    [HideInInspector] public int currentHp;
    [HideInInspector] public int currentStress;

    [Header("Stats")]
    public string characterName;
    public CharacterType characterType;
    public int accuracy;
    public float critChance;
    public int minDamage;
    public int maxDamage;
    public int dodge;
    public int protection;
    public int speed;

    [Header("Resistances")]
    public int stunRes;
    public int blightRes;
    public int diseaseRes;
    public int deathBlowRes;
    public int moveRes;
    public int bleedRes;
    public int trapRes;

    [Header("Skills")]
    public List<Skills> skills;

    [Header("Equip and Trinkets")]
    public Weapon weapon;
    public Armor armor;

    public void SetHp(int newCurrentHp) => currentHp = newCurrentHp; 
    public void SetStress(int newCurrentStress) => currentStress = newCurrentStress;
    public int GetHp() => currentHp;
    public int GetStress() => currentStress;
}
