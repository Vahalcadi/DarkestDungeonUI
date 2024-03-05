using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hero : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Character character;

    private void Start()
    {
        GetComponent<Image>().sprite = character.characterModel;
        character.currentHp = character.maxHp;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.character = character;
        CharacterPanel.Instance.ShowCharacterInfos(character);
    }
}
