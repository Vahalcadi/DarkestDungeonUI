using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Armor", menuName = "Equip/Armor")]
public class Armor : ScriptableObject
{
    [Header("ArmorImage")]
    public Image armorImage;

    [Header("ArmorStats")]
    public int maxHp;
    public int dodge;
}
