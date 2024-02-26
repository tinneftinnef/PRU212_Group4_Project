using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject lightningStrike;
    [SerializeField] Transform skillPosition;
    List<GameObject> listLightningStrike;
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
        if(Input.GetKeyDown(KeyCode.T))
        {
            GameObject lightning = FindAvailableSkill(listLightningStrike);
            if (lightning != null)
            {
                lightning.transform.position = skillPosition.position;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit!" + collision.name);
        }
    }
}
