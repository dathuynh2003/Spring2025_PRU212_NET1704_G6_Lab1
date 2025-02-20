using System;
﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    public float health;
    public int scoreValue;
    private float minY;
    private Rigidbody2D myBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject explosionEffect; // Assign explosion effect in Unity
    private AudioManager audioManager;
    private int isFollowingPlayer;
    [SerializeField]private Plane player;
    public AudioClip blowSound;
    private AudioSource audioSource;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        int currentLevel = GameManager.Instance.GetLevel();

        health = UnityEngine.Random.Range(3, 6) + currentLevel * 2; // random hp if not set in unity
        if (!player)
        {
            player = GameObject.FindAnyObjectByType<Plane>();
        }
        if (isFollowingPlayer == 0)
        {
            isFollowingPlayer = UnityEngine.Random.Range(-3, 5);
        }

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        minY = screenBounds.y;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    void Start()
    {
        int currentLevel = GameManager.Instance.GetLevel();
        enemySpeed += currentLevel * 0.7f; // Increase enemy speed by 0.7 each level
        myBody.linearVelocity = new Vector2(0f, -enemySpeed);
        
    }

    void Update()
    {
        if (isFollowingPlayer >0)
        {
            if (player != null)
            {
                FollowPlayer();
            }
        }
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //myBody.linearVelocity = new Vector2 (0f, -enemySpeed);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.explosion);
            Die();
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = player.transform.position - transform.position; // Calculate the direction to the player
        Vector2 moveDirection = new Vector2(direction.x, -1).normalized; // Normalize the direction, horizontal and vertical movement
        Vector2 targetPosition = (Vector2)transform.position + moveDirection * enemySpeed * Time.deltaTime; // Calculate the target position

        transform.position = targetPosition; // Move the enemy to the target position
    }

    void Die()
    {
        // Spawn explosion effect
        if (explosionEffect != null)
        {
            var explosion =  Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f); // Destroy explosion effect after 1 second
        }

        Destroy(gameObject); // Destroy enemy

        //PolygonCollider2D boxCollider = GetComponent<PolygonCollider2D>();
        //float sizeX = boxCollider.size.x;
        //float sizeY = boxCollider.size.y;

        //int scoreValue = 1; // Default score value

        //if (sizeX == 1.06f && sizeY == 0.96f)
        //{
        //    scoreValue = 2;
        //}

        GameManager.Instance.AddScore(scoreValue);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship1") || collision.CompareTag("Ship2") )
        {
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            if (blowSound != null)
            {
                StartCoroutine(PlayBlowSoundThenGameOver(collision.gameObject));
                Destroy(collision.gameObject);
            }
            else
            {
                GameOver(collision.gameObject);
            }
            //audioManager.PlaySFX(audioManager.gameOver);
            //Destroy(collision.gameObject);
            //PlayerPrefs.SetString("PlayerScore", GameManager.Instance.scoreText.text);
            //SceneManager.LoadScene("GameOverScene");

        }
    }



    // Coroutine chờ âm thanh nổ phát xong rồi mới phát âm thanh gameOver
    IEnumerator PlayBlowSoundThenGameOver(GameObject playerShip)
    {
        audioSource.clip = blowSound;
        audioSource.volume = 3.0f;
        audioSource.Play();

        // Chờ đúng thời gian của âm thanh
        yield return new WaitForSeconds(1);

        // Sau khi âm thanh phát xong, mới vào màn hình Game Over
        GameOver(playerShip);
    }

    // Hàm xử lý Game Over
    void GameOver(GameObject playerShip)
    {
        //Destroy(playerShip); // Hủy tàu người chơi
        PlayerPrefs.SetString("PlayerScore", GameManager.Instance.scoreText.text);
        SceneManager.LoadScene("GameOverScene"); // Chuyển màn hình Game Over
    }


    void OnGUI()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position); // Convert world position to screen
        GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 50, 20), "HP: " + health); // Display HP
    }
}
