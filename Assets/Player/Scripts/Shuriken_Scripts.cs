using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shuriken_Scripts : MonoBehaviour
{
    List<GameObject> listShuriken;
    [Header("Throw")]
    [SerializeField] GameObject shuriken;
    [SerializeField] int magazine = 3;
    [SerializeField] Transform shurikenDirection;
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement Player_Movement;
    [SerializeField] Player_Information Player_Information;
    [Header("SKill")]
    List<GameObject> listSkillShuriken;
    [SerializeField] GameObject skillShuriken;
    [SerializeField] int skillAmount = 10;
    [Header("ChargeFlame")]
    List<GameObject> listChargeFlame;
    [SerializeField] GameObject chargeFlame;
    [SerializeField] int chargeFlameAmount = 2;
    [SerializeField] internal float chargeTime;
    [SerializeField] float chargeSpeed;
    [SerializeField] bool isCharging;
    [SerializeField] bool isCanUseChargeFlame;
    void Start()
    {
        isCanUseChargeFlame = true;
        chargeSpeed = 2f;
        chargeTime = 0;
        listShuriken = new List<GameObject>();
        for(int i = 0; i < magazine; i++)
        {
            GameObject singleShuriken = Instantiate(shuriken);
            listShuriken.Add(singleShuriken);
            singleShuriken.SetActive(false);
        }

        listSkillShuriken = new List<GameObject>();
        for(int i = 0; i < skillAmount; i++)
        {
            GameObject singleSKillShuriken = Instantiate(skillShuriken);
            listSkillShuriken.Add(singleSKillShuriken);
            singleSKillShuriken.SetActive(false);
        }
        listChargeFlame = new List<GameObject>();
        for (int i = 0; i < chargeFlameAmount; i++)
        {
            GameObject single = Instantiate(chargeFlame);
            listChargeFlame.Add(single);
            single.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SingleShoot();
        if(Player_Information.currentEP >= 50f)
        {
            if (Player_Movement.isCanUseQ == true)
            {
                SkillShuriken();
            }
        }
    }

    protected void SingleShoot()
    {
        if (Input.GetKey(KeyCode.L))
        {
            if (!isCharging)
            {
                isCharging = true;
            }
            chargeTime += chargeSpeed * Time.deltaTime;
        } else
        {
            if (isCharging)
            {
                if(chargeTime >= 2 && isCanUseChargeFlame && Player_Information.currentEP >= 50f)
                {
                    ChargeFlame();
                    animator.SetTrigger("Throw");
                } else
                {
                    Throw();
                    animator.SetTrigger("Throw");
                }
                isCharging = false;
                chargeTime = 0;
            }
        }
    }
    protected void Throw()
    {
        GameObject availableShuriken = FindAvailableShuriken();
        Vector3 scale = shurikenDirection.localScale;
        if (availableShuriken != null)
        {
            availableShuriken.transform.position = shurikenDirection.position;
            if (scale.x < 0)
            {
                availableShuriken.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if (scale.x > 0)
            {
                availableShuriken.transform.rotation = shurikenDirection.rotation;
            }
        }
    }
    protected void SkillShuriken()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Player_Movement.IsGrounded() == true)
            {
                animator.SetTrigger("Skill");
                Player_Information.useAbility(50f);
            }
        }
    }
    public void ReleaseSkill()
    {
        GameObject availableShuriken = FindAvailableSkillShuriken();
        Vector3 scale = shurikenDirection.localScale;
        if (availableShuriken != null)
        {
            availableShuriken.transform.position = shurikenDirection.position;
            if (scale.x < 0)
            {
                availableShuriken.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if (scale.x > 0)
            {
                availableShuriken.transform.rotation = shurikenDirection.rotation;
            }
        }
    }
    public void ChargeFlame()
    {
        GameObject availableShuriken = FindAvailableChargeFlame();
        Vector3 scale = shurikenDirection.localScale;
        if (availableShuriken != null)
        {
            availableShuriken.transform.position = shurikenDirection.position;
            if (scale.x < 0)
            {
                availableShuriken.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if (scale.x > 0)
            {
                availableShuriken.transform.rotation = shurikenDirection.rotation;
            }
            Player_Information.useAbility(50f);
        }
    }
    private GameObject FindAvailableSkillShuriken()
    {
        foreach (GameObject suri in listSkillShuriken)
        {
            if (suri.activeSelf == false)
            {
                suri.SetActive(true);
                return suri;
            }
        }
        return null;
    }
    private GameObject FindAvailableShuriken()
    {
        foreach (GameObject bullet in listShuriken)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
    private GameObject FindAvailableChargeFlame()
    {
        foreach (GameObject bullet in listChargeFlame)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
}
