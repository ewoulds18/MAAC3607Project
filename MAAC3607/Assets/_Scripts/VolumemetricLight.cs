using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Light))]

public class VolumemetricLight : MonoBehaviour{
    private MeshFilter meshFilter;
    private Light light;
    private Mesh mesh;
    public float opacity = 0.5f;
    void Start(){
        meshFilter = GetComponent<MeshFilter>();
        light = GetComponent<Light>();
        if(light.type != LightType.Spot){
            Debug.LogError("Light must be a Spot light");
        }else{
            mesh = BuildMesh();
            meshFilter.mesh = mesh;
        }
    }
    void Update(){
        
    }

    private Mesh BuildMesh(){
        mesh = new Mesh();
        //build a cone mesh
        float farPos = Mathf.Tan(light.spotAngle * Mathf.Deg2Rad * 0.5f) * light.range;
        mesh.vertices = new Vector3[]{
            new Vector3(0,0,0),
            new Vector3(farPos,farPos,light.range),
            new Vector3(-farPos,farPos,light.range),
            new Vector3(-farPos,-farPos,light.range),
            new Vector3(farPos,-farPos,light.range)
        };
        mesh.colors = new Color[]{
            new Color(light.color.r, light.color.g, light.color.b,light.color.a * opacity),
            new Color(light.color.r, light.color.g, light.color.b,0),
            new Color(light.color.r, light.color.g, light.color.b,0),
            new Color(light.color.r, light.color.g, light.color.b,0),
            new Color(light.color.r, light.color.g, light.color.b,0)
        };
        mesh.triangles = new int[]{
            0,1,2,
            0,2,3,
            0,3,4,
            0,4,1
        };

        return mesh;
    }
}
