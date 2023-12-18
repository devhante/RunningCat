using System;
using System.Collections;
using UnityEngine;

namespace RunningCat.GameScene
{
    public enum PlayerStatus
    {
        Running,
        Jumping,
        Crawling
    }
    
    public class Player : Singleton<Player>
    {
        public float energyTime = 0f;
        
        [SerializeField] private float speed;
        [SerializeField] private float gravityScale;
        [SerializeField] private int jumpPower;
        [SerializeField] private bool hittable;
        [SerializeField] private PlayerStatus status = PlayerStatus.Running;
        [SerializeField] private Transform dest;
        [SerializeField] private Vector3 step;
        
        private Rigidbody2D rb2d;
        private Animator animator;

        protected override void Awake()
        {
            base.Awake();
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

            if (transform.position != dest.position)
            {
                float value = Mathf.Min(Time.deltaTime * 2f, Mathf.Abs(transform.position.x - dest.position.x));
                if (transform.position.x > dest.position.x)
                {
                    value *= -1;
                }
                transform.Translate(new Vector3(value, 0f, 0f));
            }

            if (energyTime > 0f)
            {
                energyTime -= Time.deltaTime;
                if (energyTime <= 0f)
                {
                    animator.SetBool("Energy", false);
                }
            }
        }

        public void Jump()
        {
            if (status != PlayerStatus.Jumping)
            {
                status = PlayerStatus.Jumping;
                animator.SetTrigger("Jump");
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
                animator.SetTrigger("Crawl");
                rb2d.gravityScale = 10;
                rb2d.velocity = Vector2.zero;
            }
        }
        
        public void EndCrawl()
        {
            if (status == PlayerStatus.Crawling)
            {
                status = PlayerStatus.Running;
                animator.SetTrigger("Run");
                rb2d.gravityScale = gravityScale;
                rb2d.velocity = Vector2.zero;
            }
        }

        public void Hit()
        {
            if (hittable)
            {
                MainCamera.Instance.Vibrate(0.05f, 0.3f);
                StartCoroutine(HitCoroutine());
                dest.position = transform.position - step;
            }
        }

        public void Eat()
        {
            animator.SetBool("Energy", true);
            energyTime = 10f;
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
            if (collision.collider.CompareTag("Ground"))
            {
                if (status == PlayerStatus.Jumping)
                {
                    status = PlayerStatus.Running;
                    animator.SetTrigger("Run");
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Hit();
                other.GetComponent<ObstacleMove>().isHit = true;
            }
            else if (other.CompareTag("Churus"))
            {
                GameManager.instance.churu++;
                Eat();
                Destroy(other.gameObject);
            }
        }

        public void Idle()
        {
            // animator.SetTrigger("Idle");
        }
    }
}