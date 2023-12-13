using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bitgem.VFX.StylisedWater;

// WaterLevel = Y scale 1 -> 8 ALTERADO NO GAMEOBJECT FILHO DA AGUA

public class ControlWaterLevel : MonoBehaviour
{
    public GameObject waterChild;
    public GameObject MoonObject;
    public WaterVolumeTransforms originalWaterScript;
    // Start is called before the first frame update
    void Start()
    {
        waterChild.transform.localScale = new Vector3(waterChild.transform.localScale.x, 1.1f, waterChild.transform.localScale.z);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoonPos = MoonObject.transform.position;

        waterChild.transform.localScale = new Vector3(waterChild.transform.localScale.x, (float)CalculateScale(MoonPos), waterChild.transform.localScale.z);

    }

    double CalculateScale(Vector3 MoonPosition)
    {
        // top distance = 20
        // bottom distance = 0
        // new Value = 1 + 0.65 * (value) (converte de 0 a 20 para 1 a 14)

        float DistanceBetweenCurrentObjAndMoon = Vector3.Distance(waterChild.transform.position, MoonPosition);

        double newScale = 0;
        if (DistanceBetweenCurrentObjAndMoon <= 0)
        {
            newScale = 1;
        }
        else if (DistanceBetweenCurrentObjAndMoon > 20)
        {
            newScale = 14;
        }
        else
        {
            newScale = 1 + (0.65f * DistanceBetweenCurrentObjAndMoon);
        }

        Debug.Log(newScale.ToString());
        return newScale;
    }
}
