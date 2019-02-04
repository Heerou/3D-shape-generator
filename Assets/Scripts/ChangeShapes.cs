using UnityEngine;
using UnityEngine.UI;

public class ChangeShapes : MonoBehaviour
{
    public Slider ShapeSlider;
    public GameObject[] ShapeList;
    bool isCreated = true;

    GameObject shape;
    GameObject currentShape;
    
    public ModifyColor ShapeToColorize;

    private void Awake()
    {
        ShapeToColorize = GetComponent<ModifyColor>();
        ShapeSlider.maxValue = 2.0f;
        ShapeSlider.wholeNumbers = true;

        ShapeSlider.value = 0.0f;
        PoolObj(ShapeSlider.value, isCreated);
    }

    // Start is called before the first frame update
    void Start()
    {        
        ShapeSlider.onValueChanged.AddListener(delegate { ReInstatiate(ShapeSlider.value, true); });
    }

    void PoolObj(float number, bool created)
    {
        isCreated = created;
        for (int i = (int)number; i <= ShapeList.Length; i++)
        {
            if (isCreated)
            {
                shape = Instantiate(ShapeList[(int)number]);
                ShapeToColorize.GetShape(shape);
                shape.transform.SetParent(transform);
                isCreated = false;
            }
        }
    }

    void ReInstatiate(float number, bool created)
    {
        isCreated = created;
        currentShape = shape;

        if (currentShape != null)
        {
            Destroy(currentShape);
            shape = Instantiate(ShapeList[(int)number]);
            ShapeToColorize.GetShape(shape);
            shape.transform.SetParent(transform);
        }
        shape.transform.SetParent(transform);
        isCreated = false;
    }
}