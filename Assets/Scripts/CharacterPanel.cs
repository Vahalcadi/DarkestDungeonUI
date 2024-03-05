using Microsoft.Win32.SafeHandles;
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
        Hero hero = GameManager.Instance.hero;

        hero.hpSlider.maxValue = character.currentMaxHp;
        hero.hpSlider.value = character.currentHp;

        SetStressPip(hero, character);

        hp.text = $"{character.currentHp} / {character.currentMaxHp}";
        stress.text = $"{character.currentStress} / {character.currentMaxStress}";

        accuracyValue.text = $"{character.currentAccuracy}";
        critChanceValue.text = $"{character.currentCritChance.ToString("f1")}%";
        damageValues.text = $"{character.currentMinDamage}-{character.currentMaxDamage}";
        dodgeValue.text = $"{character.currentDodge}";
        protectionValue.text = $"{character.currentProtection}%";
        speedValue.text = $"{character.currentSpeed}";

        weaponLevel.text = $"{character.weapon.level}";
        armorLevel.text = $"{character.armor.level}";

        weaponIcon.sprite = character.weapon.weaponImage;
        armorIcon.sprite = character.armor.armorImage;
        talis1Icon.sprite = character.trinket1.trinketIcon;
        talis2Icon.sprite = character.trinket2.trinketIcon;
    }

    public void SetFirstCharacterValues(Character character)
    {
        character.currentMaxHp = character.maxHp + character.armor.maxHp;
        character.currentMaxStress = character.maxStress;

        character.currentHp = character.currentMaxHp;
        character.currentStress = 0;

        character.currentAccuracy = character.accuracy + character.trinket1.accuracy + character.trinket2.accuracy;
        character.currentCritChance = character.critChance + character.weapon.crit + character.trinket1.critChance + character.trinket2.critChance;
        character.currentMaxDamage = character.maxDamage + character.weapon.maxDamage;
        character.currentMinDamage = character.minDamage + character.weapon.minDamage;
        character.currentDodge = character.dodge + character.armor.dodge + character.trinket1.dodge + character.trinket2.dodge;
        character.currentProtection = character.protection + character.trinket1.protection + character.trinket2.protection;
        character.currentSpeed = character.speed + character.weapon.speed + character.trinket1.speed + character.trinket2.speed;

        UpdateCharacterStatsUI(character);
    }
    public void UpdateCharacterStatsValue(Character character)
    {
        character.currentMaxHp += character.maxHp + character.armor.maxHp;
        character.currentMaxStress += character.maxStress + 10;

        character.currentHp = character.currentMaxHp;
        character.currentStress = 0;

        character.currentAccuracy += character.accuracy + character.trinket1.accuracy + character.trinket2.accuracy;
        character.currentCritChance += character.critChance + character.weapon.crit + character.trinket1.critChance + character.trinket2.critChance;
        character.currentMaxDamage += character.maxDamage + character.weapon.maxDamage;
        character.currentMinDamage += character.minDamage + character.weapon.minDamage;
        character.currentDodge += character.dodge + character.armor.dodge + character.trinket1.dodge + character.trinket2.dodge;
        character.currentProtection += character.protection + character.trinket1.protection + character.trinket2.protection;
        character.currentSpeed += character.speed + character.weapon.speed + character.trinket1.speed + character.trinket2.speed;

        UpdateCharacterStatsUI(character);
    }

    public void IncreaseCurrentHpBy20(Character character)
    {
        if (character.currentHp + 20 > character.currentMaxHp)
            character.currentHp = character.currentMaxHp;
        else
            character.currentHp += 20;

        UpdateCharacterStatsUI(character);
    }

    public void DecreaseCurrentHpBy20(Character character)
    {
        if (character.currentHp - 20 < 0)
            character.currentHp = 0;
        else
            character.currentHp -= 20;

        UpdateCharacterStatsUI(character);
    }

    public void IncreaseCurrentStressBy20(Character character)
    {
        if (character.currentStress + 20 > character.currentMaxStress)
            character.currentStress = character.currentMaxStress;
        else
            character.currentStress += 20;

        UpdateCharacterStatsUI(character);
    }

    public void DecreaseCurrentStressBy20(Character character)
    {
        if (character.currentStress - 20 < 0)
            character.currentStress = 0;
        else
            character.currentStress -= 20;

        UpdateCharacterStatsUI(character);
    }

    public void SetStressPip(Hero hero, Character character)
    {
        if (character.currentStress >= 10 && character.currentStress < 20)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.emptyStressPip;
            hero.stressSlots[2].sprite = hero.emptyStressPip;
            hero.stressSlots[3].sprite = hero.emptyStressPip;
            hero.stressSlots[4].sprite = hero.emptyStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 20 && character.currentStress < 30)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.emptyStressPip;
            hero.stressSlots[3].sprite = hero.emptyStressPip;
            hero.stressSlots[4].sprite = hero.emptyStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 30 && character.currentStress < 40)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.emptyStressPip;
            hero.stressSlots[4].sprite = hero.emptyStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 40 && character.currentStress < 50)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.emptyStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 50 && character.currentStress < 60)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 60 && character.currentStress < 70)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 70 && character.currentStress < 80)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 80 && character.currentStress < 90)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 90 && character.currentStress < 100)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
        else if (character.currentStress >= 100 && character.currentStress < 110)
        {
            hero.stressSlots[0].sprite = hero.halfStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 110 && character.currentStress < 120)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.halfStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 120 && character.currentStress < 130)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.halfStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 130 && character.currentStress < 140)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.halfStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 140 && character.currentStress < 150)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.halfStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 150 && character.currentStress < 160)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.halfStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 160 && character.currentStress < 170)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.fullStressPip;
            hero.stressSlots[6].sprite = hero.halfStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 170 && character.currentStress < 180)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.fullStressPip;
            hero.stressSlots[6].sprite = hero.fullStressPip;
            hero.stressSlots[7].sprite = hero.halfStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 180 && character.currentStress < 190)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.fullStressPip;
            hero.stressSlots[6].sprite = hero.fullStressPip;
            hero.stressSlots[7].sprite = hero.fullStressPip;
            hero.stressSlots[8].sprite = hero.halfStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 190 && character.currentStress < 200)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.fullStressPip;
            hero.stressSlots[6].sprite = hero.fullStressPip;
            hero.stressSlots[7].sprite = hero.fullStressPip;
            hero.stressSlots[8].sprite = hero.fullStressPip;
            hero.stressSlots[9].sprite = hero.halfStressPip;
        }
        else if (character.currentStress >= 200)
        {
            hero.stressSlots[0].sprite = hero.fullStressPip;
            hero.stressSlots[1].sprite = hero.fullStressPip;
            hero.stressSlots[2].sprite = hero.fullStressPip;
            hero.stressSlots[3].sprite = hero.fullStressPip;
            hero.stressSlots[4].sprite = hero.fullStressPip;
            hero.stressSlots[5].sprite = hero.fullStressPip;
            hero.stressSlots[6].sprite = hero.fullStressPip;
            hero.stressSlots[7].sprite = hero.fullStressPip;
            hero.stressSlots[8].sprite = hero.fullStressPip;
            hero.stressSlots[9].sprite = hero.fullStressPip;
        }
        else
        {
            hero.stressSlots[0].sprite = hero.emptyStressPip;
            hero.stressSlots[1].sprite = hero.emptyStressPip;
            hero.stressSlots[2].sprite = hero.emptyStressPip;
            hero.stressSlots[3].sprite = hero.emptyStressPip;
            hero.stressSlots[4].sprite = hero.emptyStressPip;
            hero.stressSlots[5].sprite = hero.emptyStressPip;
            hero.stressSlots[6].sprite = hero.emptyStressPip;
            hero.stressSlots[7].sprite = hero.emptyStressPip;
            hero.stressSlots[8].sprite = hero.emptyStressPip;
            hero.stressSlots[9].sprite = hero.emptyStressPip;
        }
    }
}