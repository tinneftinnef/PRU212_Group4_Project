using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private static ScreenManager instance;
    public static ScreenManager Instance
    {
        get
        {
            if(instance == null)
                instance = new ScreenManager();
            return instance;
        }
    }
    [SerializeField] GameObject player;
    [SerializeField] GameObject audio;
    [SerializeField] GameObject holder;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject camera;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this as ScreenManager;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(audio);
            DontDestroyOnLoad(holder);
            DontDestroyOnLoad(UI);
            DontDestroyOnLoad(camera);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnMap1Data();
    }
    public void spawnMap1Data()
    {
        PlayerPrefs.SetFloat("PlayerPosX", -21.71561f);
        PlayerPrefs.SetFloat("PlayerPosY", -6.522159f);
    }
}
