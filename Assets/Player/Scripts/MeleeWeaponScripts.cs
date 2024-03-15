using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Information information;
    Audio_Manager audioManager;
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
        FiredamageAmplified = 20f;
        LightningdamageAmplified = 25f;
        WaterdamageAmplified = 28f;
        damageAmplified.Add(FiredamageAmplified);
        damageAmplified.Add(LightningdamageAmplified);
        damageAmplified.Add(WaterdamageAmplified);
    }
    // Update is called once per frame
    void Update()
    {

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
                    float ampdmg = information.ATK * damageAmplified[i] / 100;
                    string enemyName = collision.name;
                    switch (enemyName)
                    {
                        case "Goblin(Clone)":
                            Debug.Log("Goblin");
                            collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(information.ATK + ampdmg);
                            break;
                        case "Mushroom(Clone)":
                            Debug.Log("Mushroom");
                            collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(information.ATK + ampdmg);
                            break;
                        case "Skeleton(Clone)":
                            Debug.Log("Skeleton");
                            collision.gameObject.GetComponent<Health>().TakeDamage(information.ATK + ampdmg);
                            break;
                        case "Eye(Clone)":
                            Debug.Log("Eye");
                            collision.gameObject.GetComponent<HealthEye>().TakeDamage(information.ATK + ampdmg);
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
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(information.ATK);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(information.ATK);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(information.ATK);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(information.ATK);
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
