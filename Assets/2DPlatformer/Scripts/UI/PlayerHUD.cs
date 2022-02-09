using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GSGD2;
using GSGD2.Gameplay;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteForLifePoints = null;
    [SerializeField] private RectTransform _refRecTransform = null;
    [SerializeField] private Image _refImage = null;
    [SerializeField] private float _spaceBetweenIcon = 25f;
    [SerializeField] private List<Image> _listImage = null;



    private void Start()
    {


        UpdateLife();
    }


    public void UpdateLife()
    {
        
        if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable playerDamageable))
        {
            
            int currentMark = Mathf.RoundToInt(playerDamageable.MaxHealth);
            int maxLifeNumber = Mathf.RoundToInt(playerDamageable.MaxHealth);

            
            int lifeNumber = Mathf.RoundToInt(playerDamageable.CurrentHealth);

            for (int i = 1; i <= maxLifeNumber; i++)
            {

                _listImage[i].sprite = _spriteForLifePoints[0];
               

            }

            for (int i = 1; i <= _listImage.Count; i++)
            {
                if (i > maxLifeNumber)
                {
                    _listImage[i-1].gameObject.SetActive(false);
                }

                else
                {
                    _listImage[i - 1].gameObject.SetActive(true);
                }


            }

            for (int i = 0; i < Mathf.RoundToInt(playerDamageable.CurrentHealth); i++)
            {

                _listImage[i].sprite = _spriteForLifePoints[1];

            }
        }
    }
}
