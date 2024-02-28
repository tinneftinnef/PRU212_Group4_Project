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
    int totalStrike = 3;
    void Start()
    {
        listLightningStrike = createObject(totalStrike, lightningStrike);
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
        //UseSkill();
    }
    public void UseSkill()
    {
        StartCoroutine(SpawnLightning());
    }
    private IEnumerator SpawnLightning()
    {
        GameObject lightning = FindAvailableSkill(listLightningStrike);
        if (lightning != null)
        {
            lightning.transform.position = skillPosition.position;
        }
        Player_Information.useAbility(50f);

        yield return new WaitForSeconds(2f);

        if (lightning != null)
        {
            lightning.SetActive(false);
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
