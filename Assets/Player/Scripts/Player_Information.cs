using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Information : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] public int levelHP = 1;
    [SerializeField] public int levelATK = 1;
    [SerializeField] public int levelEP = 1;
    [SerializeField] public float currentHealth;
    [SerializeField] Image healthBar;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentEP;
    [SerializeField] Image epBar;
    [SerializeField] public float maxEP;
    [SerializeField] public float ATK;



    [SerializeField] public int player_coin;
    [SerializeField] public int player_bottleHealth;
    [SerializeField] public int player_bottleMana;
    [SerializeField] Text currentCoin;
    [SerializeField] Text currentBottleHealth;
    [SerializeField] Text currentBottleMana;
    [SerializeField] Text textLevelHP;
    [SerializeField] Text textLevelATK;
    [SerializeField] Text textLevelEP;

    [SerializeField] GameObject BuyQButton;
    [SerializeField] GameObject BuyKButton;


    [SerializeField] Animator animator;
    [SerializeField] Player_Movement player_Movement;
    [Header("NockBack")]
    [SerializeField] public float KBForce = 2f;
    [SerializeField] public float KBCounter = 0.1f;
    [SerializeField] public float KBTotalTime = 0.7f;
    [SerializeField] public bool knockFromRight = false;
    [SerializeField] public bool isCanUseSkillK;
    public GameObject[] listKSkill;
    Rigidbody2D rb;
    //Enemy List
    [SerializeField] EnemyTestTakeHit takeHit;
    //private static Player_Information instance;
    //public static Player_Information Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new Player_Information();
    //        }
    //        return instance;
    //    }
    //}
    private void Awake()
    {
        isCanUseSkillK = false;
        ATK = 10;
    }
    void Start()
    {
        currentHealth = maxHealth;
        currentEP = maxEP;
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        this.player_coin = PlayerPrefs.GetInt("CoinEarn");
        levelHP = PlayerPrefs.GetInt("LvHP");
        levelEP = PlayerPrefs.GetInt("LvEP");
        levelATK = PlayerPrefs.GetInt("LvATK");

        currentHealth = maxHealth = PlayerPrefs.GetFloat("Health");
        currentEP = maxEP = PlayerPrefs.GetFloat("EP");
        ATK = PlayerPrefs.GetFloat("ATK");
        if (PlayerPrefs.GetInt("KUnlock") == 1)
        {
            isCanUseSkillK = true;
            listKSkill[PlayerPrefs.GetInt("Active")].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        KnockBack();
        bindingText();
        checkActiveSKill();
        PlayerPrefs.SetInt("CoinEarn", player_coin);
    }
    public void bindingText()
    {
        currentCoin.text = player_coin.ToString();
        currentBottleHealth.text = player_bottleHealth.ToString();
        currentBottleMana.text = player_bottleMana.ToString();
        if(textLevelHP != null)
        {
            textLevelHP.text = (levelHP * 100).ToString();
        }
        if(textLevelATK != null)
        {
            textLevelATK.text = (levelATK * 100).ToString();
        }
        if(textLevelEP != null)
        {
            textLevelEP.text = (levelEP * 100).ToString();
        }
    }
    public void usingCoin(int coin)
    {
        player_coin -= coin; 
    }
    public void usingBottleHealth(int health)
    {
        player_bottleHealth -= health;
    }
    public void usingBottleMana(int mana)
    {
        player_bottleMana -= mana;
    }
    public void BuySKillK()
    {
        if(player_coin >= 5000)
        {
            player_coin -= 5000;
            isCanUseSkillK = true;
        }
        else
        {
            Debug.Log($"Need {5000 - player_coin} more coin to unlock");
        }
    }
    public void BuySKillQ()
    {
        if (player_coin >= 5000)
        {
            player_coin -= 5000;
            player_Movement.isCanUseQ = true;
            PlayerPrefs.SetInt("UseQ", 1);
        }
        else
        {
            Debug.Log($"Need {5000 - player_coin} more coin to unlock");
        }
    }
    private void checkActiveSKill()
    {
        if (isCanUseSkillK == true)
        {
            if(BuyKButton != null)
            {
                BuyKButton.SetActive(false);
            }
        }
        if (player_Movement.isCanUseQ == true)
        {
            if(BuyQButton != null)
            {
                BuyQButton.SetActive(false);
            }
        }
    }
    public void upgradeHP(int health)
    {
        int requireCoin = levelHP * 100;
        if(player_coin >= requireCoin)
        {
            maxHealth += health;
            levelHP++;
            player_coin -= requireCoin;
        }
        else
        {
            Debug.Log($"Need {requireCoin - player_coin} more coin to upgrade");
        }
    }
    public void upgradeEP(int EP)
    {
        int requireCoin = levelEP * 100;
        if (player_coin >= requireCoin)
        {
            maxEP += EP;
            levelEP++;
            player_coin -= requireCoin;
        }
        else
        {
            Debug.Log($"Need {requireCoin - player_coin} more coin to upgrade");
        }
    }
    public void upgradeATK(int ATKPlus)
    {
        int requireCoin = levelATK * 100;
        if (player_coin >= requireCoin)
        {
            ATK += ATKPlus;
            levelATK++;
            player_coin -= requireCoin;
        }
        else
        {
            Debug.Log($"Need {requireCoin - player_coin} more coin to upgrade");
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if(currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            SceneManager.LoadScene("EndGame");
        }
    }
    public void useAbility(float mana)
    {
        currentEP -= mana;
        if(epBar != null)
        {
            epBar.fillAmount = currentEP / maxEP;
        }
    }
    protected void KnockBack()
    {
        if (KBCounter <= 0.2f)
        {
            player_Movement.canMove = true;
            player_Movement.canJump = true;
            animator.SetBool("IsHurt", false);
        }
        else
        {
            player_Movement.canMove = false;
            player_Movement.canJump = false;
            animator.SetBool("IsHurt", true);
            if (knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (knockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

}
