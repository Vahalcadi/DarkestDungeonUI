using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hero : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Character character;
    public Sprite emptyStressPip;
    public Sprite halfStressPip;
    public Sprite fullStressPip;
    public Slider hpSlider;
    public List<Image> stressSlots;

    private void Start()
    {
        GetComponent<Image>().sprite = character.characterModel; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.character = character;
        GameManager.Instance.hero = this;

        CharacterPanel.Instance.SetFirstCharacterValues(character);
        CharacterPanel.Instance.ShowCharacterInfos(character);

    }
}
