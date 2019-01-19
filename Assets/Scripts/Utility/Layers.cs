using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layers 
{
    public static LayerMask IgnoreLayersIsGrounded;

    static Layers()
    {
        IgnoreLayersIsGrounded = ~(1 << 3 | 1<< 4 | 1 << 8 | 1 << 9 | 1 << 11 | 1 << 12 | 1 << 15);
    }
}
