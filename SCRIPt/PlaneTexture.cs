using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTexture : MonoBehaviour
{
    public Texture2D mainTexture;
    public int mainTextureheight;
    public int mainTextureWidth;

    // Start is called before the first frame update
    void Start()
    {
        SetMainTextureSize();
        CreatePattern();
    }

    void SetMainTextureSize()
    {
        //设置材质的宽与高
        mainTexture = new Texture2D(mainTextureWidth, mainTextureheight);
    }

    void CreatePattern()
    {
        //用循环设置每一个像素格的颜色
        for (int i = 0; i < mainTextureWidth; i++)
        {
            for (int j = 0; j < mainTextureheight; j++)
            {
                if (((i + j) % 2) == 1)
                {
                    mainTexture.SetPixel(i, j, Color.black);
                }
                else
                {
                    mainTexture.SetPixel(i, j, Color.white);
                }
            }
        }
        mainTexture.Apply();//应用当前SetPixel方法
        GetComponent<Renderer>().material.mainTexture = mainTexture;
        mainTexture.wrapMode = TextureWrapMode.Clamp;//将包装方法换为“紧凑”
        mainTexture.filterMode = FilterMode.Point;//Point filtering - texture pixels become blocky up close.素材的像素块状紧凑
    }

    // Update is called once per frame
    void Update()
    {

    }
}