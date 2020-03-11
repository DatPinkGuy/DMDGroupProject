using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaunchingCamera : MonoBehaviour
{
    [Header("Modifiers")]
    public int forceModifier;
    public float gravityModifier;
    [Tooltip("Max power of power meter, depending on size may need adjustments to speed")]
    public float maxPower;
    public float powerMeterSpeed;
    private float _launchPower;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private Vector3 _launchDirection;
    private Rigidbody Rb => animalLaunching.GetComponent<Rigidbody>();
    public Rigidbody rb => Rb;
    [HideInInspector] public bool launched;
    private bool _gotDirection;
    [HideInInspector] public bool playState;
    private Ray _ray;
    private RaycastHit _hit;
    private PlayerScore playerScore;
    //Power bar bools for repeating the filling
    private bool _powerBarTop;
    private bool _powerBarBottom;
    //
    private Vector3 _oldPosition;
    private Vector3 AnimalPosition
    {
        get => animalLaunching.transform.position;
        set => animalLaunching.transform.position = value;
    }
    [Header("Main Objects")]
    [SerializeField] private GameObject animalLaunching;
    [SerializeField] private new Camera camera;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Image powerBarImage;
    [SerializeField] private Collider planeCollider;
    [Header("Game Ending Objects")]
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        powerBarImage.enabled = false;
        lineRenderer.enabled = false;
        playerScore = FindObjectOfType<PlayerScore>();
        gameEndPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playState)
        {
            Rb.isKinematic = true;
            gameEndPanel.SetActive(true);
            score.text = playerScore.Score.ToString();
            highScore.text = playerScore.HighScore.ToString();
            return;
        }
        MiniGame();
    }

    private void LaunchObject(float power)
    {
        Rb.AddForce(power*forceModifier*_launchDirection);
        launched = true;
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
        if (_oldPosition != AnimalPosition)
        {
            Vector3 transformPosition = AnimalPosition;
            Rb.AddForce(0, -gravityModifier,0);
            animalLaunching.transform.Rotate(0,0,-180*Time.deltaTime);
            _oldPosition = AnimalPosition; 
            if (transformPosition.y < 0) playState = true;
            CameraFollow();
            return transformPosition;
        }
        else
        {
            _oldPosition = AnimalPosition;
            Vector3 transformPosition = AnimalPosition;
            Rb.AddForce(0, -gravityModifier,0);
            if (transformPosition.y < 0) playState = true;
            CameraFollow();
            return transformPosition;
        }
    }

    private void CameraFollow()
    {
        var position = new Vector3(AnimalPosition.x, AnimalPosition.y, -5);
        position.y = Mathf.Clamp(position.y, 1.5f, AnimalPosition.y);
        camera.transform.position = position;
    }

    private void MiniGame()
    {
        if (!_gotDirection)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;
                }
                lineRenderer.enabled = true;
                _startPoint = _hit.point;
                lineRenderer.SetPosition(0, _hit.point);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;
                }
                lineRenderer.SetPosition(1, _hit.point);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit)) _endPoint = _hit.point;
                if (_startPoint == Vector3.zero || _endPoint == Vector3.zero)
                {
                    lineRenderer.enabled = false;
                    return;
                }
                _launchDirection = GetDirection(_startPoint, _endPoint);
                return;
            }
        }
        if (!launched && _gotDirection)
        {
            _ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                if (EventSystem.current.IsPointerOverGameObject()) return;
            }
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
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                LaunchObject(_launchPower);
                lineRenderer.enabled = false;
            }
        }
        if (launched)
        {
            AnimalPosition = Launched();
        }
    }
}
