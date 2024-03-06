using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hero : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Character character;
    [SerializeField] private Image selectionSprite;
    public Sprite emptyStressPip;
    public Sprite halfStressPip;
    public Sprite fullStressPip;
    public Slider hpSlider;
    public List<Image> stressSlots;

    private void Start()
    {
        GetComponent<Image>().sprite = character.characterModel;
        CharacterPanel.Instance.SetFirstCharacterValues(character);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance.hero != null)
            GameManager.Instance.hero.selectionSprite.gameObject.SetActive(false);

        selectionSprite.gameObject.SetActive(true);

        if (GameManager.Instance.state == State.SWAPPING)
        {
            GameManager.Instance.state = State.COMBAT;
            int index1 = GameManager.Instance.hero.transform.parent.GetSiblingIndex();
            int index2 = transform.parent.GetSiblingIndex();

            GameManager.Instance.hero.transform.parent.SetSiblingIndex(index2);
            transform.parent.SetSiblingIndex(index1);
        }

        GameManager.Instance.character = character;
        GameManager.Instance.hero = this;

        CharacterPanel.Instance.ShowCharacterInfos(character);
    }
}
