using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private int life;
    private int maxLife = 3;

    [SerializeField] Image lifeOn;
    [SerializeField] Image lifeOff;

    [SerializeField] Image lifeOn2;
    [SerializeField] Image lifeOff2;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = maxLife;

    }

    void Update()
    {
        // Obt�m as entradas de movimento
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");

        // Define a dire��o do jogador
        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate()
    {
        // Move o jogador nas dire��es X e Y
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }

    


}
