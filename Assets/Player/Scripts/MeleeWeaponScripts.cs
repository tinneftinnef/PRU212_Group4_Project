using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Information information;
    Audio_Manager audioManager;
    [SerializeField] float NonedamageAmp;
    [SerializeField] float FiredamageAmplified;
    [SerializeField] float LightningdamageAmplified;
    [SerializeField] float WaterdamageAmplified;
    private List<float> damageAmplified = new List<float>();
    bool buff = false;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    private void Start()
    {
        buff = false;
        NonedamageAmp = 0f;
        FiredamageAmplified = 20f;
        LightningdamageAmplified = 25f;
        WaterdamageAmplified = 28f;
        damageAmplified.Add(NonedamageAmp);
        damageAmplified.Add(FiredamageAmplified);
        damageAmplified.Add(LightningdamageAmplified);
        damageAmplified.Add(WaterdamageAmplified);

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player_Information.ATK);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int randomNumber = UnityEngine.Random.Range(1, 3);
            for (int i = 0; i < information.listKSkill.Length; i++)
            {
                if (information.listKSkill[i].activeSelf == true)
                {
                    buff = true;
                    float ampdmg = Player_Information.ATK * damageAmplified[i] / 100;
                    string enemyName = collision.name;
                    switch (enemyName)
                    {
                        case "Goblin(Clone)":
                            Debug.Log("Goblin");
                            collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                        case "Mushroom(Clone)":
                            Debug.Log("Mushroom");
                            collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                        case "Skeleton(Clone)":
                            Debug.Log("Skeleton");
                            collision.gameObject.GetComponent<Health>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                        case "Eye(Clone)":
                            Debug.Log("Eye");
                            collision.gameObject.GetComponent<HealthEye>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                        case "Boss_Bring(Clone)":
                            collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                        case "FireWorm(Clone)":
                            collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                    }
                }
            }
            if (buff == false)
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        Debug.Log("Goblin");
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(Player_Information.ATK);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(Player_Information.ATK);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(Player_Information.ATK);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(Player_Information.ATK);
                        break;
                    case "Boss_Bring(Clone)":
                        collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(Player_Information.ATK);
                        break;
                    case "FireWorm(Clone)":
                        collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(Player_Information.ATK);
                        break;
                }
            }
            switch (randomNumber)
            {
                case 1:
                    audioManager.PlaySFX(audioManager.slashHitted1);
                    break;
                case 2:
                    audioManager.PlaySFX(audioManager.slashHitted2);
                    break;
                case 3:
                    audioManager.PlaySFX(audioManager.slashHitted3);
                    break;
            }
        }

        if (collision.CompareTag("GruzMother"))
        {
            int randomNumber = UnityEngine.Random.Range(1, 3);
            for (int i = 0; i < information.listKSkill.Length; i++)
            {
                if (information.listKSkill[i].activeSelf == true)
                {
                    buff = true;
                    float ampdmg = Player_Information.ATK * damageAmplified[i] / 100;
                    string enemyName = collision.name;
                    switch (enemyName)
                    {
                        case "GruzMother(Clone)":
                            collision.gameObject.GetComponent<HealthGruz>().TakeDamage(Player_Information.ATK + ampdmg);
                            break;
                    }
                }
            }
            if (buff == false)
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(Player_Information.ATK);
                        break;
                }
            }
            switch (randomNumber)
            {
                case 1:
                    audioManager.PlaySFX(audioManager.slashHitted1);
                    break;
                case 2:
                    audioManager.PlaySFX(audioManager.slashHitted2);
                    break;
                case 3:
                    audioManager.PlaySFX(audioManager.slashHitted3);
                    break;
            }
        }
    }
}
