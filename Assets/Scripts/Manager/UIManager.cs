using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panel")]
    [SerializeField] private GameObject mainUI;
    [SerializeField] private Transform panelOpen;
    [SerializeField] private GameObject inventoryPanel;

    [Header("Menu Button")]
    [SerializeField] private Button inventoryButton;

    private enum Panel
    {
        None,
        Inventory
    }

    private GameObject panel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inventoryButton.onClick.AddListener(() => OpenPanel(Panel.Inventory));
    }

    public void OpenMainUI()
    {
        mainUI.SetActive(true);
    }

    public void CloseMainUI()
    {
        mainUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && panel == null)
        {
            panel = Instantiate(inventoryPanel, panelOpen);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && panel != null)
        {
            Destroy(panel);
        }
    }

    private void OpenPanel(Panel menuPanel)
    {
        switch (menuPanel)
        {
            case Panel.Inventory:
                panel = Instantiate(inventoryPanel, panelOpen);
                break;
        }
    }
}
