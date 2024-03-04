using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "Equip/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("WeaponImage")]
    public Image weaponImage;

    [Header("WeaponStats")]
    public int level;
    public int damage;
    public float crit;
    public int speed;
}
