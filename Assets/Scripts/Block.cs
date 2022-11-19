using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public int Value;
    public TextMeshPro PointsText;
    [SerializeField] private MeshRenderer _blockRenderer;
    Color lerpedColor = Color.white;

    void Start()
    {
        PointsText.SetText(Value.ToString());
        lerpedColor = Color.Lerp(Color.white, Color.red, (float)Value / 20f);
        _blockRenderer.material.color = lerpedColor;
    }
}
