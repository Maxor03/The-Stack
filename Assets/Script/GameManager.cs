using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PrimitiveType primitiveToPlace;

    Vector3 nextShapePreviewPos = new Vector3 (-6, 0, 4);
    GameObject previewObject;
    private void Start()
    {
        GenerateNextShape();
    }
    void GenerateNextShape()
    {
        switch (Random.Range(0, 4))
        {
            case 0: primitiveToPlace = PrimitiveType.Cube; break;
            case 1: primitiveToPlace = PrimitiveType.Sphere; break;
            case 2: primitiveToPlace = PrimitiveType.Capsule; break;
            case 3: primitiveToPlace = PrimitiveType.Cylinder; break;
            default: primitiveToPlace = PrimitiveType.Cube; break;

        }
        if (previewObject) Destroy(previewObject);

        previewObject = GameObject.CreatePrimitive(primitiveToPlace);
        previewObject.name = "preview shape";
        previewObject.transform.position = nextShapePreviewPos;
    }

        
         void Update()    
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    GameObject go = GameObject.CreatePrimitive(primitiveToPlace);

                    go.transform.localScale = Vector3.one * 0.3f;
                    go.transform.position = hit.point + new Vector3(0, 1f, 0);
                    go.transform.rotation = Random.rotation;

                    go.AddComponent<Rigidbody>();

                    Color randomColor = Random.ColorHSV();

                    float H, S , V;
                    Color.RGBToHSV(randomColor, out H, out S, out V);

                    S = 0.8f;
                    V = 0.8f;

                    randomColor = Color.HSVToRGB(H, S, V);

                    go.GetComponent<MeshRenderer>().material.color = randomColor;

                    //go.GetComponent<MeshRenderer>().material.mainTexture = Texture;

                   go.AddComponent<DestroyOnFall>();

                   go.AddComponent<DragWithMouse>();

                    GenerateNextShape();    
                }
            }
         }
}
