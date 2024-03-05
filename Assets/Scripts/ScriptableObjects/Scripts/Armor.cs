using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Equip/Armor")]
public class Armor : ScriptableObject
{
    [Header("ArmorInfos")]
    public string armorName;
    public Sprite armorImage;

    [Header("ArmorStats")]
    public int level;
    public int maxHp;
    public int dodge;
}
