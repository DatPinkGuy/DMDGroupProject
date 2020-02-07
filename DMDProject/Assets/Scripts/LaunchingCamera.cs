using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingCamera : MonoBehaviour
{
    public int forceModifier;
    public float gravityModifier;
    private Ray _ray;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private Rigidbody Rb => animalLaunching.GetComponent<Rigidbody>();
    private bool _launched;
    private bool _playState;
    private float AngleInDeg => Mathf.Atan2(_startPoint.y - _endPoint.y, _startPoint.x - _endPoint.x) * (180 / Mathf.PI);
    [SerializeField] private GameObject animalLaunching;
    [SerializeField] private new Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playState)
        {
            Rb.isKinematic = true;
            return;
        }
        if (!_launched)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) _startPoint = camera.ScreenToViewportPoint(Input.mousePosition);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            { _endPoint = camera.ScreenToViewportPoint(Input.mousePosition);
                LaunchObject(_startPoint, _endPoint);
            }
        }
        if (_launched)
        {
            animalLaunching.transform.position = Launched();
        }
    }

    private void LaunchObject(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 launchDirection = endPoint + startPoint;
        float angle = AngleInDeg;
        launchDirection.z = animalLaunching.transform.position.z;
        Rb.AddForce(launchDirection*forceModifier);
        _launched = true;
    }

    private Vector3 Launched()
    {
        Vector3 transformPosition = animalLaunching.transform.position;
        Rb.AddForce(0, -gravityModifier,0); // worked better than transform.position modification
        CameraFollow();
        if (transformPosition.y < 0) _playState = true;
        return transformPosition;
    }

    private void CameraFollow()
    {
        camera.transform.position = new Vector3(animalLaunching.transform.position.x, animalLaunching.transform.position.y, -10);; //needs z axis offset
    }
}
