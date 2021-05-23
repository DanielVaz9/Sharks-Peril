using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControls : MonoBehaviour
{
    public static bool blockcontrols;

    public static bool Block(bool block)
    {
        blockcontrols = block;
        return blockcontrols;
    }
}