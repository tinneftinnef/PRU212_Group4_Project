using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private List<GameObject> listWeapon;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(camera);
    }
    private static SceneChanger instance;
    public static SceneChanger Instance{
        get
        {
            // Nếu chưa có thể hiện nào, tạo mới một thể hiện
            if (instance == null)
            {
                instance = new SceneChanger();
            }
            // Trả về thể hiện hiện tại
            return instance;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        //Debug.Log("SceneChange");
        SceneManager.LoadScene("PlayScence");
        //DontDestroyOnLoad(player);
        //DontDestroyOnLoad(gameObject);
    }
}
