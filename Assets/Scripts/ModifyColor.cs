using UnityEngine;
using UnityEngine.UI;

public class ModifyColor : MonoBehaviour
{
    public Slider Rslider, Gslider, Bslider;
    Color shapeColor;
    Material shapeMat;
    Renderer ShapeRend;

    [HideInInspector]
    public GameObject shape;

    private void Update()
    {
        UpdateColor();
    }

    public void GetShape(GameObject theShape)
    {
        shape = theShape;
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
}
