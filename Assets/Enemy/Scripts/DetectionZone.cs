using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
    
{
    [SerializeField] Transform detectPosition;
    [SerializeField] LayerMask playerLayer;
    // Start is called before the first frame update
    public bool IsDetected()
    {
        return Physics2D.OverlapBox(detectPosition.position, new Vector2(0.5f, 0.7f),0, playerLayer);
    }
}
