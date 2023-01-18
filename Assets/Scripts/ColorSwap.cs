using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    public MeshRenderer Cube;
    public Material[] colors = new Material[0];

    public void ChangeColor(int index)
    {
        Cube.material = colors[index];
    }
}
