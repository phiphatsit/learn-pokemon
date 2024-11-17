using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : BasePanel
{
    [SerializeField] private GameObject pokemonSlot;
    [SerializeField] private Transform content;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void OnEnable()
    {
        OpenPanel();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        for (int i = 0; i < 10; i++)
        {
            Instantiate(pokemonSlot, content);
        }
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        Destroy(gameObject);
    }
}
