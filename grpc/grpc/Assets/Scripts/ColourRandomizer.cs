using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRandomizer : MonoBehaviour
{
    public Material material;

    private readonly Color _defaultColor = Color.red;
    private ColorClient _colorClient;
    // Start is called before the first frame update
    void Start()
    {
        _colorClient = new ColorClient();
    }
    public void ChangeColor()
    {
        material.color = GetColor(material.color);
    }
    /*
    private Color GetColor(Color currentColor)
    {
        Debug.Log("Got a request to change the color");
        return _defaultColor;
    }
    */
    private UnityEngine.Color GetColor(Color currentColor)
    {
        var currentColorString = ColorUtility.ToHtmlStringRGBA(currentColor);

        var newColorString = _colorClient.GetRandomColor(currentColorString);

        if (ColorUtility.TryParseHtmlString(newColorString, out var newColor))
        {
            return newColor;
        }
        else
        {
            Debug.LogError("Error parsing the color string: " + currentColorString);
            Debug.LogWarning("Setting to default color: " + _defaultColor);
            return _defaultColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
