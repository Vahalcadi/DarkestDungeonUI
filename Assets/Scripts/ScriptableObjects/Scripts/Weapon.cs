using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Equip/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("WeaponInfos")]
    public string weaponName;
    public Sprite weaponImage;

    [Header("WeaponStats")]
    public int level;
    public int minDamage;
    public int maxDamage;
    public float crit;
    public int speed;
}
