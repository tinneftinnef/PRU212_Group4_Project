using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Information information;
    [SerializeField] EnemyTestTakeHit takeHit;
    Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomNumber = UnityEngine.Random.Range(1, 3);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            takeHit.TakeDamage(information.ATK);
            switch(randomNumber)
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
