using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        Destroy(gameObject);
    }
}
