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

    // Start is called before the first frame update
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

    private void Update()
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        shapeColor.r = Rslider.value;
        shapeColor.g = Gslider.value;
        shapeColor.b = Bslider.value;

        shapeMat.color = shapeColor;
    }
}
