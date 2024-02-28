using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject lightningStrike;
    [SerializeField] Transform skillPosition;
    List<GameObject> listLightningStrike;
    [SerializeField] Player_Information Player_Information;
    private float duration;
    private bool isSpawn;
    int totalStrike = 3;
    void Start()
    {
        listLightningStrike = createObject(totalStrike, lightningStrike);
        duration = 2f;
    }
    private List<GameObject> createObject(int total, GameObject objective)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < total; i++)
        {
            GameObject single = Instantiate(objective);
            list.Add(single);
            single.SetActive(false);
        }
        return list;
    }
    // Update is called once per frame
    void Update()
    {
        UseSkill();

    }
    private void UseSkill()
    {
        
        if (Input.GetKeyDown(KeyCode.T) && Player_Information.currentEP >= 50f)
        {
            isSpawn = true;
            GameObject lightning = FindAvailableSkill(listLightningStrike);
            existDuration(lightning);
            if (lightning != null)
            {
                lightning.transform.position = skillPosition.position;
            }
            Player_Information.useAbility(50f);
        }
    }
    private void existDuration(GameObject lightning)
    {
        if (isSpawn)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                lightning.SetActive(false);
                isSpawn = false;
            }
        }
    }
    private GameObject FindAvailableSkill(List<GameObject> listSKill)
    {
        foreach (GameObject suri in listSKill)
        {
            if (suri.activeSelf == false)
            {
                suri.SetActive(true);
                return suri;
            }
        }
        
        return null;
    }
}
