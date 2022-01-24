namespace GSGD2.Gameplay

{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Shop : MonoBehaviour
    {
        [SerializeField] GameObject _startShopUI = null;
        [SerializeField] GameObject _shopUI = null;
        [SerializeField] List<GameObject> _list = null;
        private GameObject _currentPickUpInstantiate = null;
        [SerializeField] Transform _transform = null;
        private bool playerInShop = false;
        private bool shopOpen = false;
        [SerializeField] private List<bool> _listBool = null;
        [SerializeField] private TESTUPDPAD _testInput = null;
        [SerializeField] private List<int> _listPrice = null;
         

        private void Start()
        {
            LevelReferences.Instance.UIManager.SetPrice(_listPrice);
        }

        public void SetPlayerInShop(bool inShop)
        {

            playerInShop = inShop;
            _startShopUI.gameObject.SetActive(inShop);

        }



        public bool GetPlayerInShop()
        {


            return playerInShop;
        }

        public void SetShopOpen(bool open)
        {
            if (playerInShop)
            {
                shopOpen = open;
                _shopUI.SetActive(open);

                

                    //_testInput.enabled = open;
                    

                
            }



        }

        public bool GetShopOpen()
        {
            return shopOpen;


        }

        public void InstantiateObject(int index)
        {
            int currentLoot =   LevelReferences.Instance.LootManager.CurrentLoot;

            if (_currentPickUpInstantiate == null)
            {
                if (index == 0)
                {
                    if (_listBool[0] == false && currentLoot >= _listPrice[0])
                    {
                        _currentPickUpInstantiate = Instantiate<GameObject>(_list[index]);
                        _currentPickUpInstantiate.transform.position = _transform.position;
                        _listBool[0] = false;
                        LevelReferences.Instance.UIManager.SetUpgradeVisibility(0, false);
                        LevelReferences.Instance.LootManager.RemoveLoot(_listPrice[0]);
                    }
                }

                if (index == 1 && currentLoot >= _listPrice[1])
                {
                    if (_listBool[1] == false)
                    {
                        _currentPickUpInstantiate = Instantiate<GameObject>(_list[index]);
                        _currentPickUpInstantiate.transform.position = _transform.position;
                        _listBool[1] = false;
                        LevelReferences.Instance.UIManager.SetUpgradeVisibility(1, false);
                        LevelReferences.Instance.LootManager.RemoveLoot(_listPrice[1]);
                    }
                }

                if (index == 2 && currentLoot >= _listPrice[2])
                {   
                  ;
                    if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable player))
                    {
                        if (player.CurrentHealth < player.MaxHealth)
                        {
                            _currentPickUpInstantiate = Instantiate<GameObject>(_list[index]);
                            _currentPickUpInstantiate.transform.position = _transform.position;
                            LevelReferences.Instance.LootManager.RemoveLoot(_listPrice[2]);

                        }
                    }
                    
                }

                if (index == 3 && currentLoot >= _listPrice[3])
                {
                    if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable player))
                    {

                    }
                    if (_listBool[2] == false)
                    {
                        _currentPickUpInstantiate = Instantiate<GameObject>(_list[index]);
                        _currentPickUpInstantiate.transform.position = _transform.position;
                        _listBool[2] = false;
                        LevelReferences.Instance.UIManager.SetUpgradeVisibility(3, false);
                        LevelReferences.Instance.LootManager.RemoveLoot(_listPrice[3]);
                    }

                }

            }





        }

    }
}
