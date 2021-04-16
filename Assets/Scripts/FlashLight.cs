using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    public EyeTracking et;
    Vector2 aimDirection;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void Update()
    {
        Vector3 crossPosition = new Vector3();
        if (!et.isActivated) { crossPosition = Input.mousePosition; }
        else { crossPosition = new Vector3(et.newX, et.newY, 0); }
        crossPosition = Camera.main.ScreenToWorldPoint(crossPosition);
        aimDirection = new Vector2(crossPosition.x - transform.position.x,
               crossPosition.y - transform.position.y);
        SetAimDirection(aimDirection);
        origin = Vector3.zero;


        fov = 75f;
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 4f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];


        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {

            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        /*vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;*/

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        
    
        
    }

    

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov/2 + 75;
    }
}
