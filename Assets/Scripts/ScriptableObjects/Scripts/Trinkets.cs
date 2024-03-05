using UnityEngine;

[CreateAssetMenu(fileName = "Trinkets", menuName = "Equip/Trinkets")]
public class Trinkets : ScriptableObject
{
    [Header("TrinketInfos")]
    public string trinketName;
    public Sprite trinketIcon;

    [Header("TrinketModifiers")]
    public int accuracy;
    public float critChance;
    public int dodge;
    public int protection;
    public int speed;
    public int stunRes;
    public int blightRes;
    public int diseaseRes;
    public int deathBlowRes;
    public int moveRes;
    public int bleedRes;
    public int trapRes;
}
