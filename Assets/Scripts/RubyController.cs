using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RubyController : MonoBehaviour
{
    public float speed = 4;

    public static bool dead;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    
    public GameObject projectilePrefab;

    public AudioClip hitSound;
    public AudioClip shootingSound;
    
    public int health
    {
        get { return currentHealth; }
    }
    public GameObject loseText;
    
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;

    int currentHealth;
    float invincibleTimer;
    bool isInvincible;

    public TextMeshProUGUI ammoText;
    public int ammoCount;
    //public GameObject ammoPack;

    // public int ammo;
    //public int levelNumber = BotFixCount.level;
    // public TextMeshProUGUI bulletCount;


    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    
    AudioSource audioSource;
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
                
        invincibleTimer = -1.0f;
        currentHealth = maxHealth;
        dead = false;
        
        animator = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();

        loseText.SetActive(false);

        ammoCount = 4;
        ammoText.text = "Ammo: " + ammoCount.ToString();

        //bulletCount = GetComponent<TextMeshProUGUI>;

        /*if (BotFixCount.level == 1)
        {
            ammo = 4;
            bulletCount.text = "Ammo: " + ammo.ToString();
        }
        if (BotFixCount.level == 2)
        {
            ammo = 6;
            bulletCount.text = "Ammo: " + ammo.ToString();
            Debug.Log("Working");
        }*/
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;



        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                    if (BotFixCount.continueActive == true)
                    {
                        SceneManager.LoadScene("Level2");
                    }
                }  
            }
        }
        //Restarting the scene
        if (currentHealth==0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }
        }

        if(BotFixCount.winActive == true)
        {
            Freeze();

            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }
        }
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        { 
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        if(currentHealth == 0)
        {
            loseText.SetActive(true);
            dead = true;
            Freeze();
        }
                   
        UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
    }
    
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("Restarting scene");
        //ChangeHealth(maxHealth);
        //transform.position = respawnPosition.position;
    }
    
    void LaunchProjectile()
    {//============================================================================================================================
        //checks to see if ruby has the required ammo. Am commenting for now in order to pass off challenge 3, un-comment on final.
        //============================================================================================================================
        //if (ammoCount >= 1)
      //  {
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);

            animator.SetTrigger("Launch");
            audioSource.PlayOneShot(shootingSound);
           // ammoCount -= 1;
       // }
       // else if(ammoCount<=0)
      //  {
      //      return;
      //  }
       // ammoText.text = "Ammo: " + ammoCount.ToString();
            
    }
    
    void Freeze()
    {
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        isInvincible = true;
        invincibleTimer = 1000f;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    
}
