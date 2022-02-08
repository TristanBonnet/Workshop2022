using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;
using GSGD2;

public class CamZoo : MonoBehaviour
{
    [SerializeField] GameObject _camera = null;
    [SerializeField] InputActionMapWrapper _mapWrapper = null;
    [SerializeField] string _inputAxisHor = "Hor";
    [SerializeField] string _inputAxisVer = "Ver";
    [SerializeField] string _inputRightAxisVer = "RVer";


    private InputAction _inputAxisHorAction = null;
    private InputAction _inputAxisVerAction = null;
    private InputAction _inputRightAxisVerAction = null;

    [SerializeField] float _camSpeed = 1f;



    public float HorizontalAxis => _inputAxisHorAction.ReadValue<float>();
    public float VerticalAxis => _inputAxisVerAction.ReadValue<float>();

    public float RightVerticalAxis => _inputRightAxisVerAction.ReadValue<float>();

    private void OnEnable()
    {
        _mapWrapper.TryFindAction(_inputAxisHor, out _inputAxisHorAction, true);
        _mapWrapper.TryFindAction(_inputAxisVer, out _inputAxisVerAction, true);
        _mapWrapper.TryFindAction(_inputRightAxisVer, out _inputRightAxisVerAction, true);



    }

    private void Update()
    {

        transform.position += new Vector3(_camSpeed * Time.deltaTime * HorizontalAxis, _camSpeed * Time.deltaTime * VerticalAxis, 0);

        float newRotation = _camera.transform.rotation.x + Time.deltaTime * RightVerticalAxis * _camSpeed;

        Quaternion.Euler(newRotation, 0, 0);
        

    }
}
