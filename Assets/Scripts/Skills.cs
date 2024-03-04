using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Skills : ScriptableObject
{
    [Header("ability icon")]
    public Image abilityIcon;

    [Header("Ability Stats")]
    public int damage;
    public int accuracy;
    public int healing;
    public int stressHealing;
}
