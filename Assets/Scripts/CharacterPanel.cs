using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [Header("CharacterTopInfos")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterType;
    [SerializeField] private Image characterImage;
    [SerializeField] private List<Image> skills;

    [Header("CharacterHpAndStress")]
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI stress;

    [Header("CharacterStats")]
    [SerializeField] private TextMeshProUGUI accuracyValue;
    [SerializeField] private TextMeshProUGUI critChanceValue;
    [SerializeField] private TextMeshProUGUI damageValues;
    [SerializeField] private TextMeshProUGUI dodgeValue;
    [SerializeField] private TextMeshProUGUI protectionValue;
    [SerializeField] private TextMeshProUGUI speedValue;

    [Header("EquipmentLevel")]
    [SerializeField] private TextMeshProUGUI weaponLevel;
    [SerializeField] private TextMeshProUGUI armorLevel;

    [Header("Equip")]
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Image armorIcon;
    [SerializeField] private Image talis1Icon;
    [SerializeField] private Image talis2Icon;


    public static CharacterPanel Instance;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    public void ShowCharacterInfos(Character character)
    {
        if (character == null)
            return;

        characterName.text = character.characterName;

        string[] strings = character.characterType.ToString().Split(new char[] { ' ', '_' });

        if (strings.Count() == 2)
        {
            char[] chars1 = strings[0].ToLower().ToCharArray();
            chars1[0] = char.ToUpper(chars1[0]);
            char[] chars2 = strings[1].ToLower().ToCharArray();
            chars2[0] = char.ToUpper(chars2[0]);
            characterType.text = $"{chars1.ArrayToString()} {chars2.ArrayToString()}";
        }
        else
        {
            char[] chars = character.characterType.ToString().ToLower().ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            characterType.text = $"{chars.ArrayToString()}";
        }

        characterImage.sprite = character.characterImage;
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].sprite = character.skills[i].skillIcon;
        }

        UpdateCharacterStatsUI(character);
    }

    private void UpdateCharacterStatsUI(Character character)
    {
        hp.text = $"{character.currentHp} / {character.maxHp}";
        stress.text = $"{character.currentStress} / {character.maxStress}";

        accuracyValue.text = $"{character.accuracy}";
        critChanceValue.text = $"{character.critChance.ToString("f1")}%";
        damageValues.text = $"{character.minDamage}-{character.maxDamage}";
        dodgeValue.text = $"{character.dodge}";
        protectionValue.text = $"{character.protection}%";
        speedValue.text = $"{character.speed}";

        weaponLevel.text = $"{character.weapon.level}";
        armorLevel.text = $"{character.armor.level}";

        weaponIcon.sprite = character.weapon.weaponImage;
        armorIcon.sprite = character.armor.armorImage;
        talis1Icon.sprite = character.trinket1.trinketIcon;
        talis2Icon.sprite = character.trinket2.trinketIcon;
    }

    public void UpdateCharacterStatsValue(Character character)
    {
        character.maxHp += character.armor.maxHp;
        character.maxStress += 10;

        character.accuracy += character.trinket1.accuracy + character.trinket2.accuracy;
        character.critChance += character.weapon.crit + character.trinket1.critChance + character.trinket2.critChance;
        character.maxDamage += character.weapon.maxDamage;
        character.minDamage += character.weapon.minDamage;
        character.dodge += character.armor.dodge + character.trinket1.dodge + character.trinket2.dodge;
        character.protection += character.trinket1.protection + character.trinket2.protection;
        character.speed += character.weapon.speed + character.trinket1.speed + character.trinket2.speed;

        UpdateCharacterStatsUI(character);
    }
}