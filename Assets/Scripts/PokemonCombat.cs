using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonCombat : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private Button catchButton;
    [SerializeField] private Button feedButton;
    [SerializeField] private Button changeButton;

    private float successRate;

    private void OnEnable()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = GameManager.Instance.pokemon.sp.sprite;
        successRate = GameManager.Instance.pokemon.successRate;

        catchButton.onClick.AddListener(CatchPokemom);
        feedButton.onClick.AddListener(IncreaseRate);
        changeButton.onClick.AddListener(ChangeRate);

        UpadateUI();
    }

    private void UpadateUI()
    {
        int item = GameManager.Instance.item;
        int food = GameManager.Instance.food;
        itemText.text = $"Item: {item}";
        foodText.text = $"Food: {food}";
        if (item > 0) changeButton.interactable = true;
        if (food > 0) feedButton.interactable = true;
    }

    private void CatchPokemom()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= successRate)
        {
            Destroy(GameManager.Instance.pokemon.gameObject);
            Debug.Log("Catch successfully!");
        }
        else
        {
            Debug.Log("Pokemom Escaped...");
        }

        GameManager.Instance.CloseCombatScene();
    }
    private void IncreaseRate()
    {
        successRate += 20f;
        GameManager.Instance.food -= 1;
        UpadateUI();
        feedButton.interactable = false;
    }

    private void ChangeRate()
    {
        successRate = 100f;
        GameManager.Instance.item -= 1;
        UpadateUI();
        changeButton.interactable = false;
    }

    private void OnDisable()
    {
        catchButton.onClick.RemoveAllListeners();
        feedButton.onClick.RemoveAllListeners();
        changeButton.onClick.RemoveAllListeners();
    }
}
