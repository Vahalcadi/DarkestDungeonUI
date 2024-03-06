using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    [Header("EnemyInfos")]
    public Sprite characterModel;
    public string enemyName;
    public string enemyType;
    public int minHp;
    public int maxHp;
    public int dodge;
    public int speed;

    [Header("EnemyResistances")]
    public int stun;
    public int blight;
    public int bleed;
    public int debuff;
    public int move;

    [Header("CurrentStats")]
    [HideInInspector] public int currentHp;
    [HideInInspector] public int currentMaxHp;
    [HideInInspector] public int currentDodge;
    [HideInInspector] public int currentSpeed;
    [HideInInspector] public int currentStun;
    [HideInInspector] public int currentBlight;
    [HideInInspector] public int currentBleed;
    [HideInInspector] public int currentDebuff;
    [HideInInspector] public int currentMove;
}
