using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class WinningLine : MaskableGraphic
{
    [SerializeField]
    private Vector2[] _points = new Vector2[2];

    [Range(0.1f,20f)]
    public float Thickness = 10f;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;
        
        Quaternion beginPointRotation = Quaternion.Euler(0, 0, GetPointAngle(_points[0], _points[1]) + 90);
        vertex.position = beginPointRotation * new Vector3(-Thickness / 2, 0);
        vertex.position += (Vector3)_points[0];
        vh.AddVert(vertex);
        vertex.position = beginPointRotation * new Vector3(Thickness / 2, 0);
        vertex.position += (Vector3)_points[0];
        vh.AddVert(vertex);

        Quaternion endPointRotation = Quaternion.Euler(0, 0, GetPointAngle(_points[1], _points[0]) - 90);
        vertex.position = endPointRotation * new Vector3(-Thickness / 2, 0);
        vertex.position += (Vector3)_points[1];
        vh.AddVert(vertex);
        vertex.position = beginPointRotation * new Vector3(Thickness / 2, 0);
        vertex.position += (Vector3)_points[1];
        vh.AddVert(vertex);

        vertex.position = (Vector3)_points[1];
        vh.AddVert(vertex);

        vh.AddTriangle(0, 1, 3);
        vh.AddTriangle(3, 2, 0);
    }


    private float GetPointAngle(Vector2 vertex, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - vertex.y, target.x - vertex.x) * (180 / Mathf.PI));
    }

    /// <summary>
    /// Рисует линию из точки start в точку end заданного цвета
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public void CreateLine(Vector2 start, Vector2 end, Color color)
    {
        _points[0] = start;
        _points[1] = end;
        this.color = color;
        gameObject.SetActive(true);
    }
}
