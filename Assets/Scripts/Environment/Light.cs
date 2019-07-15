using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField]
    Color color = new Color(1,1,1,1);

    // Start is called before the first frame update
    void Start()
    {
        /*Mesh mesh = new Mesh();
        Vector3[] verts = new Vector3[4]
        {
            new Vector3(1,1,0),
            new Vector3(1,-1,0),
            new Vector3(-1,1,0),
            new Vector3(-1,-1,0)
        };

        int[] triangles = new int[6]
        {
            0,1,2,1,2,3
        };

        mesh.vertices = verts;
        mesh.triangles = triangles;

        var meshFilter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        var meshRenderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        meshFilter.mesh = mesh;
        */
        var lightMaterial = new Material(Shader.Find("Unlit/LightShader"));
        lightMaterial.color = color;

        var meshRenderer = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        meshRenderer.material = lightMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
