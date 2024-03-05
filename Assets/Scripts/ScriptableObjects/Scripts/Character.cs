using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Sprite characterImage;
    public Sprite characterModel;

    [Header("Hp and Stress")]
    public int maxHp;
    public int maxStress;
    

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

    [Header("CurrentStats")]
    public int currentMaxHp = 0;
    public int currentMaxStress = 0;
    public int currentHp = 0;
    public int currentStress = 0;
    public int currentAccuracy = 0;
    public float currentCritChance = 0;
    public int currentMinDamage = 0;
    public int currentMaxDamage = 0;
    public int currentDodge = 0;
    public int currentProtection = 0;
    public int currentSpeed = 0;
    public int currentStunRes = 0;
    public int currentBlightRes = 0;
    public int currentDiseaseRes = 0;
    public int currentDeathBlowRes = 0;
    public int currentMoveRes = 0;
    public int currentBleedRes = 0;
    public int currentTrapRes = 0;

    [Header("Skills")]
    public List<Skills> skills;

    [Header("Equip and Trinkets")]
    public Weapon weapon;
    public Armor armor;
    public Trinkets trinket1;
    public Trinkets trinket2;
 
}
