using UnityEngine;
using UnityEngine.UI;

public class ModifyColor : MonoBehaviour
{
    public Slider Rslider, Gslider, Bslider;
    Color shapeColor;
    Material shapeMat;
    Renderer ShapeRend;
    GameObject shape;

    // Start is called before the first frame update
    void Start()
    {
        shape = GameObject.FindGameObjectWithTag("Shape");
        
        ShapeRend = shape.GetComponent<Renderer>();
        shapeMat = ShapeRend.material;
        shapeColor = shapeMat.color;
        Rslider.value = shapeColor.r;
        Gslider.value = shapeColor.g;
        Bslider.value = shapeColor.b;
    }

    void UpdateColor()
    {
        shapeColor.r = Rslider.value;
        shapeColor.g = Gslider.value;
        shapeColor.b = Bslider.value;

        shapeMat.color = shapeColor;
    }

    private void Update()
    {
        UpdateColor();
    }
}
