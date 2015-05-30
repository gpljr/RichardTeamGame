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
    private GameObject cameraObject1;
    [SerializeField]
    private GameObject cameraObject2;

    private Camera camera1;
    private Camera camera2;

    [SerializeField]
    private bool _isSingleCamera;

    [SerializeField]
    private Color _bgColor;

    [SerializeField]
    private AnimationCurve _fadeCurve;

    // Use this for initialization
    void Start()
    {
        camera1 = cameraObject1.GetComponent<Camera>();
        camera2 = cameraObject2.GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (_isSingleCamera)
        {
            float aspectRatio = Camera.main.pixelHeight / (float)Camera.main.pixelWidth;
            //print("Char1.transform.position "+Char1.transform.position);
            Vector2 vPos1 = Camera.main.WorldToViewportPoint(Char1.transform.position);
            //print("vPos1 "+vPos1);
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
        else
        {
            float aspectRatio1 = camera1.pixelHeight / (float)camera1.pixelWidth;
            //float aspectRatio2 = camera2.pixelHeight / (float)camera2.pixelWidth;
            Vector2 vPos1 = camera1.WorldToViewportPoint(Char1.transform.position);
            vPos1.y *= aspectRatio1;
            print("vPos1 "+vPos1);
            _shadowRenderer.material.SetVector("_Position1", vPos1);
            _shadowRenderer.material.SetVector("_Position2", vPos1);
            float radius = 0.05f;
            _shadowRenderer.material.SetFloat("_Radius", radius);

            _shadowRenderer.material.SetColor("_Color", _bgColor);
            //Vector2 vPos2 = camera2.WorldToViewportPoint(Char2.transform.position);
            //vPos2.y *= aspectRatio2;
        }
    }
}
