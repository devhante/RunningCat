using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningCat.GameScene
{
    public enum PlayerStatus
    {
        Running,
        Jumping,
        Crawling
    }
    
    public class Player : MonoBehaviour
    {
        private static Player instance = null;

        public static Player Instance
        {
            get
            {
                return instance;
            }
        }
        
        [SerializeField] private float speed = 10;
        [SerializeField] private float gravityScale = 6;
        [SerializeField] private int jumpPower = 16;
        [SerializeField] private bool hittable = true;
        [SerializeField] private PlayerStatus status = PlayerStatus.Running;
        [SerializeField] private Transform dest;
        [SerializeField] private Vector3 step = new Vector3(0.5f, 0f, 0f);
        
        private Rigidbody2D rb2d;
        private Animator animator;

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            
            rb2d = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            rb2d.gravityScale = gravityScale;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.S))
            {
                StartCrawl();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                EndCrawl();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Hit();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Eat();
            }
            
            
            animator.SetBool("Jump", status == PlayerStatus.Jumping);
            animator.SetBool("Crawl", status == PlayerStatus.Crawling);

            if (transform.position != dest.position)
            {
                float value = Mathf.Min(Time.deltaTime * 2f, Mathf.Abs(transform.position.x - dest.position.x));
                if (transform.position.x > dest.position.x)
                {
                    value *= -1;
                }
                transform.Translate(new Vector3(value, 0f, 0f));
            }
        }

        public void Jump()
        {
            if (status != PlayerStatus.Jumping)
            {
                status = PlayerStatus.Jumping;
                rb2d.gravityScale = gravityScale;
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        public void StartCrawl()
        {
            if (status != PlayerStatus.Crawling)
            {
                status = PlayerStatus.Crawling;
                rb2d.gravityScale = 100;
                rb2d.velocity = Vector2.zero;
            }
        }
        
        public void EndCrawl()
        {
            if (status == PlayerStatus.Crawling)
            {
                status = PlayerStatus.Running;
                rb2d.gravityScale = gravityScale;
                rb2d.velocity = Vector2.zero;
            }
        }

        public void Hit()
        {
            if (hittable)
            {
                MainCamera.Instance.Vibrate(0.2f, 0.3f);
                // UIController.Instance.PlayHitEffect();
                StartCoroutine(HitCoroutine());
                dest.position = transform.position - step;
            }
        }

        public void Eat()
        {
            dest.position = transform.position + step;
        }

        private IEnumerator HitCoroutine()
        {
            hittable = false;
            
            animator.SetTrigger("Hit");
            yield return new WaitForSeconds(2f);
            
            hittable = true;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (status == PlayerStatus.Jumping)
            {
                status = PlayerStatus.Running;
            }
        }
    }
}