using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shuriken_Scripts : MonoBehaviour
{
    [Header("Throw")]
    //L Throw - Normal
    [SerializeField] GameObject[] shuriken;
    [SerializeField] Transform shurikenDirection;
    //------
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement Player_Movement;
    [SerializeField] Player_Information Player_Information;
    [Header("SKill")]
    //Skill WInd
    [SerializeField] GameObject[] skillShuriken;
    [SerializeField] public int isSelectWind;
    //Skill Flame
    [SerializeField] GameObject[] SkillFlame;
    [SerializeField] public int isSelectFlame;
    void Start()
    {
        //skill
        isSelectWind = 1;
        isSelectFlame = 2;
    }

    // Update is called once per frame
    void Update()
    {
        SingleShoot();
        if (Player_Information.currentEP >= 50f)
        {
            if (Player_Movement.isCanUseQ == true)
            {
                SkillShuriken();
            }
        }
    }

    protected void SingleShoot()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Throw();
            animator.SetTrigger("Throw");
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
    public void ReleaseSkillFlame()
    {
        GameObject availableShuriken = FindAvailableSkillFlame();
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
    private GameObject FindAvailableSkillShuriken()
    {
        foreach (GameObject suri in skillShuriken)
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
        foreach (GameObject bullet in shuriken)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
    private GameObject FindAvailableSkillFlame()
    {
        foreach (GameObject bullet in SkillFlame)
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
