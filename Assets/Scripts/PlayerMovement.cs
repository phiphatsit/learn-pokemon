using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (SceneManager.sceneCount < 2)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.sceneCount > 1)
        {
            GameManager.Instance.CloseCombatScene();
        }

        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }*/
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pokemon") && SceneManager.sceneCount < 2)
        {
            GameManager.Instance.pokemon = collision.gameObject.GetComponent<Pokemon>();
            GameManager.Instance.OpenCombatScene();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            GameManager.Instance.item += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            GameManager.Instance.food += 1;
            Destroy(collision.gameObject);
        }
    }
}
