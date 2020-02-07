using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingCamera : MonoBehaviour
{
    public int forceModifier;
    public float gravityModifier;
    public float maxPower;
    public float powerMeterSpeed;
    public float _launchPower;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private Vector3 _launchDirection;
    private Rigidbody Rb => animalLaunching.GetComponent<Rigidbody>();
    public bool _launched;
    public bool _gotDirection;
    public bool _playState;
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
        MiniGame();
    }

    private void LaunchObject(float power)
    {
        Rb.AddForce(power*forceModifier*_launchDirection);
        _launched = true;
    }

    private Vector3 GetDirection(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 launchDirection = endPoint + startPoint;
        float angle = AngleInDeg;
        launchDirection.z = animalLaunching.transform.position.z;
        _gotDirection = true;
        return launchDirection;
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
        camera.transform.position = new Vector3(animalLaunching.transform.position.x, animalLaunching.transform.position.y, -5);; //needs z axis offset
    }

    private void MiniGame()
    {
        if (!_gotDirection)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) _startPoint = camera.ScreenToViewportPoint(Input.mousePosition);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _endPoint = camera.ScreenToViewportPoint(Input.mousePosition);
                _launchDirection = GetDirection(_startPoint, _endPoint);
                return;
            }
        }
        if (!_launched && _gotDirection)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) _launchPower = 0;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                 if (_launchPower < maxPower) _launchPower += powerMeterSpeed * Time.deltaTime; //add bar lowering
            }
            if (Input.GetKeyUp(KeyCode.Mouse0)) LaunchObject(_launchPower);
        }
        if (_launched)
        {
            animalLaunching.transform.position = Launched();
        }
    }
}
