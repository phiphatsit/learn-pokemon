using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public SpriteRenderer sp;
    public float successRate = 70f;

    public void Init()
    {
        sp = GetComponent<SpriteRenderer>();
    }
}
