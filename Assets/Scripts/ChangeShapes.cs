using UnityEngine;
using UnityEngine.UI;

public class ChangeShapes : MonoBehaviour
{
    public Slider ShapeSlider;
    public Button SaveBtn;
    public GameObject[] Shapes;
    bool isCreated = true;
    
    public GameObject gridFather;
    public Image sampleImg;

    GameObject shape;
    GameObject currentShape;
    GameObject savedShape;

    [HideInInspector]
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
        SaveBtn.onClick.AddListener(delegate { SaveShape(); });
    }

    void PoolObj(float number, bool created)
    {
        isCreated = created;
        for (int i = (int)number; i <= Shapes.Length; i++)
        {
            if (isCreated)
            {
                shape = Instantiate(Shapes[(int)number]);
                ShapeToColorize.GetShape(shape);
                shape.transform.SetParent(transform, false);
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
            shape = Instantiate(Shapes[(int)number]);
            ShapeToColorize.GetShape(shape);
            shape.transform.SetParent(transform, false);
        }
        shape.transform.SetParent(transform, false);
        isCreated = false;
    }

    void SaveShape()
    {
        Image img = Instantiate(sampleImg);
        img.transform.SetParent(gridFather.transform, false);
        img.transform.localPosition = Vector3.zero;

        savedShape = Instantiate(shape);
        savedShape.transform.SetParent(img.transform);
        savedShape.transform.position = img.transform.position;
    }
}