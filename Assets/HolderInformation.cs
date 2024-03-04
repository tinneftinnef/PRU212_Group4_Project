using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HolderInformation : MonoBehaviour
{
    // Start is called before the first frame update
    private static HolderInformation instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject holder;
    public static HolderInformation Instance
    {
        get
        {
            // Nếu chưa có thể hiện nào, tạo mới một thể hiện
            if (instance == null)
            {
                instance = new HolderInformation();
            }
            // Trả về thể hiện hiện tại
            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(holder);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
