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
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
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
            collision.gameObject.GetComponent<EnemyTestTakeHit>().TakeDamage(information.ATK);
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
