/* MinMaxRangeDrawer.cs
* by Eddie Cameron – For the public domain
* ———————————————————–
* — EDITOR SCRIPT : Place in a subfolder named ‘Editor’ —
* ———————————————————–
* Renders a MinMaxRange field with a MinMaxRangeAttribute as a slider in the inspector
* Can slide either end of the slider to set ends of range
* Can slide whole slider to move whole range
* Can enter exact range values into the From: and To: inspector fields
*
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(MinMaxRange))]
public class MinMaxRangeDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 16;
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Now draw the property as a Slider or an IntSlider based on whether it’s a float or integer.
        if (property.type != "MinMaxRange")
            Debug.LogWarning("Use only with MinMaxRange type");
        else
        {
            var range = attribute as MinMaxRangeAttribute;
            var minValue = property.FindPropertyRelative("rangeStart");
            var maxValue = property.FindPropertyRelative("rangeEnd");
            var newMin = minValue.floatValue;
            var newMax = maxValue.floatValue;

            var xDivision = position.width * 0.33f;
            var yDivision = position.height * 0.5f;
            EditorGUI.LabelField(new Rect(position.x, position.y, xDivision, yDivision)
            , label);

            EditorGUI.LabelField(new Rect(position.x, position.y + yDivision, position.width, yDivision)
            , range.minLimit.ToString("0.##"));
            EditorGUI.LabelField(new Rect(position.x + position.width - 28f, position.y + yDivision, position.width, yDivision)
            , range.maxLimit.ToString("0.##"));
            EditorGUI.MinMaxSlider(new Rect(position.x + 24f, position.y + yDivision, position.width - 48f, yDivision)
            , ref newMin, ref newMax, range.minLimit, range.maxLimit);

            EditorGUI.LabelField(new Rect(position.x + xDivision, position.y, xDivision, yDivision)
            , "From: ");
            newMin = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + xDivision + 30, position.y, xDivision -30, yDivision)
            , newMin)
            , range.minLimit, newMax);
            EditorGUI.LabelField(new Rect(position.x + xDivision * 2f, position.y, xDivision, yDivision)
            , "To: ");
            newMax = Mathf.Clamp(EditorGUI.FloatField(new Rect(position.x + xDivision * 2f + 24, position.y, xDivision - 24, yDivision)
            , newMax)
            , newMin, range.maxLimit);

            minValue.floatValue = newMin;
            maxValue.floatValue = newMax;
        }
    }
}
