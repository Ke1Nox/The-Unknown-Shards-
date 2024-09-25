using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Playermove : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerRb;
    [SerializeField] float Speed = 3;
    private Animator playerAnimator;

    Vector2 moveInput;

    private void Start()
    {
        transform.position = GameManager.instance.playerSpawnPosition;

        PlayerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
       // move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;



        playerAnimator.SetFloat(("Horizontal"), moveX);
        playerAnimator.SetFloat(("Vertical"), moveY);
        playerAnimator.SetFloat(("Speed"), moveInput.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        PlayerRb.MovePosition(PlayerRb.position + (moveInput * Speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.PlayerDied();
            Debug.Log("Jugador muerto");

            SceneManager.LoadScene(0);
        }
    }

}
