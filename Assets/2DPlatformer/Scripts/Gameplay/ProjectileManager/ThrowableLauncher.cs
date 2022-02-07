using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Gameplay;
using GSGD2.Player;
using GSGD2;

public class ThrowableLauncher : MonoBehaviour
{
    [SerializeField] SpecialInput _sepcialInput = null;

    [SerializeField] ThrowableNewTest _projectile = null;
    [SerializeField] float RotateSpeed = 80f;
    [SerializeField] Transform _startTransform = null;
    [SerializeField] float _launchForceAxisSpeed = 1f;
    [SerializeField] float _minLaunchForce = 5;
    [SerializeField] float _maxLaunchForce = 20;
    [SerializeField] LayerMask _layers;
    [SerializeField] Transform _refTransform = null;
    [SerializeField] float _speedMultiplier = 8.5f;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private AudioSource _audioSource = null;
    

    [SerializeField] float _minXRange = -15f;
    [SerializeField] float _maxXRange = 15;
    public float LaunchForce = 10;

    [SerializeField] GameObject _pointRef = null;
    
    [SerializeField] int _numberOfPoints = 40;
    private GameObject[] _listpointsRef = null;
    
     private bool _active = false;
     private float _lastZRotation = 0;
    



    private float XRotation = 0;
   





   private void Start()
    {

        _listpointsRef = new GameObject[_numberOfPoints];

        for (int i = 0; i < _numberOfPoints; i++)
        {
            _listpointsRef[i] = Instantiate(_pointRef, _startTransform.position, Quaternion.identity);
        }


    }


   private void Update()
   {
        if (_refTransform.transform.rotation.eulerAngles.y > 90)
        {
            if (_lastZRotation < 90)
            {
                _launchForceAxisSpeed = -_launchForceAxisSpeed;
            }
            

        }

        else
        {
            if (_lastZRotation > 90)
            {

                _launchForceAxisSpeed = -_launchForceAxisSpeed;

            }



        }
        float newLaunchForce = Mathf.Clamp(LaunchForce + (_sepcialInput.HorizontalAxis * Time.deltaTime * _launchForceAxisSpeed * _speedMultiplier),_minLaunchForce, _maxLaunchForce);


        _lastZRotation = _refTransform.transform.rotation.eulerAngles.y; 


        LaunchForce = newLaunchForce;

        

        XRotation += -_sepcialInput.VerticalAxis * Time.deltaTime * RotateSpeed;
        XRotation = Mathf.Clamp(XRotation, _minXRange, _maxXRange);    

       
        
        transform.localEulerAngles = new Vector3(XRotation,0,0);
        int _mark = _listpointsRef.Length - 1;
        for (int i = 0; i < _listpointsRef.Length; i++)
        {
            
            
            _listpointsRef[i].transform.position = PointPosition(i * 0.05f);

            if (i > _mark)
            {
                _listpointsRef[i].gameObject.SetActive(false);
            }

            else
            {
                _listpointsRef[i].gameObject.SetActive(true);
            }

            if (Physics.OverlapSphere(_listpointsRef[i].transform.position, 0.5f, _layers).Length > 0)
            {
                Collider[] _list = Physics.OverlapSphere(_listpointsRef[i].transform.position, 0f, _layers);

                _mark = i;

                Debug.Log("HIT");

            }

           
        }

    }    


    public void Fire()
    {

        _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(12);
        _audioSource.Play();
        _animator.SetTrigger("Throw");
       ThrowableNewTest projectile =   Instantiate(_projectile, _startTransform.position, transform.rotation);
        projectile.SetNewGravity(_speedMultiplier);
        projectile._rigibody.velocity = projectile.transform.forward * LaunchForce;

        
    }

     Vector3 PointPosition(float t)
    {

        //Vector3 currentPosition = (Vector3)_startTransform.position + (transform.forward *  LaunchForce * t) + Physics.gravity /2 * (t * t);
        Vector3 currentPosition = (Vector3)_startTransform.position + (transform.forward * LaunchForce * t) + (Physics.gravity * _speedMultiplier) / 2 * (t * t);

        return currentPosition;
    }

    public void SetActive(bool active)
    {
        for (int i = 0; i < _listpointsRef.Length; i++)
        {
            _listpointsRef[i].SetActive(active);
        }
        _active = active;
        

    }
}
