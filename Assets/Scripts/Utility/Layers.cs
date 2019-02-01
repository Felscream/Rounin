using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layers 
{
    public static LayerMask IgnoreLayersIsGrounded;
    public static LayerMask GroundLayers;
    public static int UntargetableLayer;
    public static int HurtBoxLayer;

    static Layers()
    {
        IgnoreLayersIsGrounded = ~(1 << 3 | 1<< 4 | 1 << 8 | 1 << 9 | 1 << 11 | 1 << 12 | 1 << 15);
        GroundLayers = (1 << 10 | 1 << 11);
        UntargetableLayer = 2;
        HurtBoxLayer = 16;
    }
}
