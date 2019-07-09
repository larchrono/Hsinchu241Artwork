using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfExtension
{
    public static float Map(this float value, float input_min, float input_max, float output_min, float output_max){
        return (value - input_min)/(input_max - input_min) * (output_max - output_min) + output_min;
    }
}
