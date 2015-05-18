using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowController : MonoBehaviour
{
    [SerializeField]
    private Image _shadowRenderer;

    [SerializeField]
    private GameObject Char1;
    [SerializeField]
    private GameObject Char2;

    [SerializeField]
    private Color _bgColor;

    [SerializeField]
    private AnimationCurve _fadeCurve;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void LateUpdate()
    {
        float aspectRatio = Camera.main.pixelHeight / (float)Camera.main.pixelWidth;
        print("Char1.transform.position "+Char1.transform.position);
        Vector2 vPos1 = Camera.main.WorldToViewportPoint(Char1.transform.position);
        print("vPos1 "+vPos1);
        vPos1.y *= aspectRatio;
        Vector2 vPos2 = Camera.main.WorldToViewportPoint(Char2.transform.position);
        vPos2.y *= aspectRatio;
	
        _shadowRenderer.material.SetVector("_Position1", vPos1);
        _shadowRenderer.material.SetVector("_Position2", vPos2);
        float fDistance = Vector2.Distance(vPos1, vPos2);
        float radius = _fadeCurve.Evaluate(fDistance);
        _shadowRenderer.material.SetFloat("_Radius", radius);

        _shadowRenderer.material.SetColor("_Color", _bgColor);

    }
}
