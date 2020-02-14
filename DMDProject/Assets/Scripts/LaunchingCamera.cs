using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool _launched;
    private bool _gotDirection;
    private bool _playState;
    private Ray _ray;
    private RaycastHit _hit;
    //
    private bool _powerBarTop;
    private bool _powerBarBottom;
    //
    [SerializeField] private GameObject animalLaunching;
    [SerializeField] private new Camera camera;
    [SerializeField] private Image powerBarImage;
    // Start is called before the first frame update
    void Start()
    {
        powerBarImage.enabled = false;
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
        powerBarImage.enabled = false;
    }

    private Vector3 GetDirection(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 launchDirection = endPoint + startPoint;
        launchDirection.z = animalLaunching.transform.position.z;
        _gotDirection = true;
        powerBarImage.enabled = true;
        powerBarImage.fillAmount = 0;
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit)) _startPoint = _hit.point;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit)) _endPoint = _hit.point;
                _launchDirection = GetDirection(_startPoint, _endPoint);
                return;
            }
        }
        if (!_launched && _gotDirection)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) _launchPower = 0;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (!_powerBarTop)
                {
                    if (_launchPower < maxPower)
                    {
                        _launchPower += powerMeterSpeed * Time.deltaTime; //add bar lowering
                        powerMeterSpeed += Time.deltaTime;
                        powerBarImage.fillAmount = _launchPower / maxPower;
                    }
                    else
                    {
                        _powerBarTop = true;
                        _powerBarBottom = false;
                    }
                }
                else if (!_powerBarBottom)
                {
                    if (_launchPower > 0)
                    {
                        _launchPower -= powerMeterSpeed * Time.deltaTime;
                        powerMeterSpeed -= Time.deltaTime;
                        powerBarImage.fillAmount = _launchPower / maxPower;
                    }
                    else
                    {
                        _powerBarBottom = true;
                        _powerBarTop = false;
                    }
                }
               
                
            }
            if (Input.GetKeyUp(KeyCode.Mouse0)) LaunchObject(_launchPower);
        }
        if (_launched)
        {
            animalLaunching.transform.position = Launched();
        }
    }
}
