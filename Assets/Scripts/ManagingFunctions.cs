using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagingFunctions
{
    public static int BoolToInt(bool boolean)
    {
        if (boolean)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
