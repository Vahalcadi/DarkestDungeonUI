using UnityEngine;

[CreateAssetMenu]
public class Skills : ScriptableObject
{
    [Header("ability infos")]
    public string abilityName;
    public Sprite skillIcon;

    [Header("Ability Stats")]
    public int damage;
    public int accuracy;
    public int healing;
    public int stressHealing;
}
