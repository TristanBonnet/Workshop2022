using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;
using GSGD2.Utilities;


public class CamZoo : MonoBehaviour
{
    [SerializeField] GameObject _camera = null;
    [SerializeField] InputActionMapWrapper _mapWrapper = null;
    [SerializeField] string _inputAxisHor = "Hor";
    [SerializeField] string _inputAxisVer = "Ver";
    [SerializeField] string _inputRightAxisVer = "RVer";
    [SerializeField] string _mainMenu = "M";
    [SerializeField] float _rotateSpeed = 30f;
    [SerializeField] LoadSceneComponent _loadSceneComponent = null;

    [SerializeField] float _minRange = -45;
    [SerializeField] float _maxRange = 45;


    private InputAction _inputAxisHorAction = null;
    private InputAction _inputAxisVerAction = null;
    private InputAction _inputRightAxisVerAction = null;
    private InputAction _mainMenuAction = null;
    private float XRotation = 0;

    [SerializeField] float _camSpeed = 1f;



    public float HorizontalAxis => _inputAxisHorAction.ReadValue<float>();
    public float VerticalAxis => _inputAxisVerAction.ReadValue<float>();

    public float RightVerticalAxis => _inputRightAxisVerAction.ReadValue<float>();

    private void OnEnable()
    {
        _mapWrapper.TryFindAction(_inputAxisHor, out _inputAxisHorAction, true);
        _mapWrapper.TryFindAction(_inputAxisVer, out _inputAxisVerAction, true);
        _mapWrapper.TryFindAction(_inputRightAxisVer, out _inputRightAxisVerAction, true);

        if (_mapWrapper.TryFindAction(_mainMenu, out _mainMenuAction, true) == true)
        {
            _mainMenuAction.performed -= _mainMenuBack;
            _mainMenuAction.performed += _mainMenuBack;


        }  



    }

    private void Update()
    {

        transform.position += new Vector3(_camSpeed * Time.deltaTime * HorizontalAxis, 0, 0);



        XRotation = Mathf.Clamp(XRotation + (Time.deltaTime * -RightVerticalAxis * _rotateSpeed),_minRange,_maxRange);

        _camera.transform.localEulerAngles =  new Vector3(XRotation, 0, 0);

        
    }

    private void _mainMenuBack(InputAction.CallbackContext obj)
    {




        _loadSceneComponent.LoadScene();





    }
}
