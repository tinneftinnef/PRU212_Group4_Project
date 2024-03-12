using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    // Start is called before the first frame update
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUniSizeX;
    private float textureUniSizeY;
    [SerializeField] float offsetY;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUniSizeX = texture.width / sprite.pixelsPerUnit;
        textureUniSizeY= texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
            deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
        if(Math.Abs(cameraTransform.position.x - transform.position.x) >= textureUniSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x + transform.position.x) % textureUniSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        if (Math.Abs(cameraTransform.position.y - transform.position.y) >= textureUniSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y + transform.position.y) % textureUniSizeY;
            transform.position = new Vector3(transform.position.y,cameraTransform.position.y + offsetPositionY );
        }
    }
}
