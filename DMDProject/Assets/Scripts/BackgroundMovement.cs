using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public enum Background
    {
        BackgroundGrass,
        BackroundSky
    }
    public Background background;
    public float textureSpeed;
    private Material Material => GetComponent<MeshRenderer>().material;
    private float yMin;
    private float lerpY = 12;
    private float timer;
    private PlayerScore launchable;
    private LaunchingCamera launchingCamera;
    private Vector3 LaunchablePosition => launchable.transform.position;
    // Start is called before the first frame update
    void Start()
    {
        yMin = transform.position.y;
        launchingCamera = FindObjectOfType<LaunchingCamera>();
        launchable = FindObjectOfType<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launchingCamera.launched) return;
        if (background == Background.BackgroundGrass) MoveGrass();
        else MoveClouds();
    }

    private void MoveGrass()
    {
        var transformPosition = transform.position;
        var materialMainTextureOffset = Material.mainTextureOffset;
        transformPosition.x = LaunchablePosition.x;
        materialMainTextureOffset.x = LaunchablePosition.x / textureSpeed;
        transform.position = transformPosition;
        Material.mainTextureOffset = materialMainTextureOffset;
    }

    private void MoveClouds()
    {
        var transformPosition = transform.position;
        var materialMainTextureOffset = Material.mainTextureOffset;
        transformPosition = new Vector3(LaunchablePosition.x, LaunchablePosition.y, transform.position.z);
        materialMainTextureOffset.x = LaunchablePosition.x / textureSpeed;
        if (transform.position.y < lerpY)
        {
            timer += Time.deltaTime;
            materialMainTextureOffset.y = Mathf.Lerp(materialMainTextureOffset.y, 0, timer*2);
        }
        else
        {
            materialMainTextureOffset.y = LaunchablePosition.y / textureSpeed;
            timer = 0;
        }
        if (transformPosition.y < yMin)
        {
            transformPosition.y = yMin;
        }
        transform.position = transformPosition;
        Material.mainTextureOffset = materialMainTextureOffset;
    }
}
