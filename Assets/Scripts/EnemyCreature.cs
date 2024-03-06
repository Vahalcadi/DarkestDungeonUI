using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyCreature : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Enemy enemy;
    public Slider hpSlider;
    public Image popupIndicator;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponentInChildren<Image>().sprite = enemy.characterModel;
        RightPanel.Instance.SetFirstEnemyValues(enemy);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //RightPanel.Instance.HidePanel();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (enemy == null)
            return;

        GameManager.Instance.enemy = enemy;
        GameManager.Instance.creature = this;

        
        RightPanel.Instance.ShowEnemyInfos(enemy);

        popupIndicator.gameObject.SetActive(true);
        RightPanel.Instance.ShowPanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (enemy == null)
            return;

        popupIndicator.gameObject.SetActive(false);
        RightPanel.Instance.HidePanel();

        GameManager.Instance.enemy = null;
        GameManager.Instance.creature = null;
    }
}
