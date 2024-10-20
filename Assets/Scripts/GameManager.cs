using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Pokemon pokemon;
    public int item = 0;
    public int food = 0;

    private string combatScene = "CombatScene";

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
    }

    public void OpenCombatScene()
    {
        SceneManager.LoadScene(combatScene, LoadSceneMode.Additive);
    }

    public void CloseCombatScene()
    {
        SceneManager.UnloadSceneAsync(combatScene);
    }
}
