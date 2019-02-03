using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShapes : MonoBehaviour
{
    public Slider ShapeSlider;
    public GameObject[] ShapeList;
    bool isCreated = true;

    // Start is called before the first frame update
    void Start()
    {
        ShapeSlider.maxValue = 2.0f;
        ShapeSlider.wholeNumbers = true;

        ShapeSlider.value = 0.0f;
        PoolObj(ShapeSlider.value, isCreated);
    
        ShapeSlider.onValueChanged.AddListener(delegate { PoolObj(ShapeSlider.value, isCreated); });
    }

    void PoolObj(float number, bool created)
    {
        GameObject shape;
        for (int i = (int)number; i <= ShapeList.Length; i++)
        {
            if (isCreated)
            {
                Debug.Log(ShapeSlider.value);
                shape = Instantiate(ShapeList[(int)number]);
                shape.transform.SetParent(transform);
                isCreated = false;
            }
        }
    }
}