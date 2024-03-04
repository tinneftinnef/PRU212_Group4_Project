using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] lightningStrike;
    [SerializeField] Transform skillPosition;
    [SerializeField] Player_Information Player_Information;
    void Start()
    {

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
        GameObject lightning = FindAvailableSkill();
        if (lightning != null)
        {
            lightning.transform.position = skillPosition.position;
        }
        //Player_Information.useAbility(50f);

        yield return new WaitForSeconds(1.75f);

        if (lightning != null)
        {
            lightning.SetActive(false);
        }
    }
    private GameObject FindAvailableSkill()
    {
        foreach (GameObject suri in lightningStrike)
        {
            Debug.Log(suri.name);
            if (suri.activeSelf == false)
            {
                suri.SetActive(true);
                return suri;
            }
        }

        return null;
    }
}
