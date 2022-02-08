namespace GSGD2.UI
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using TMPro;

	/// <summary>
	/// Manager class that handle global functionnality around UI. It is a proxy to UI subsystem and can enable or disable them.
	/// </summary>
	public class UIManager : MonoBehaviour
	{
		[SerializeField]
		private Canvas _mainCanvas = null;

		[SerializeField]
		private PlayerHUDMenu _playerHUD = null;

		[SerializeField] PlayerHUD _playerHUD2 = null;

		public Canvas MainCanvas => _mainCanvas;
		public PlayerHUDMenu PlayerHUD => _playerHUD;

		[SerializeField] TextMeshProUGUI _gold = null;
		[SerializeField] List<TextMeshProUGUI> _listPrice  = null;
		[SerializeField] List<GameObject> _listUpgrade = null;
		[SerializeField] TextMeshProUGUI _currentPebbleText = null;
		[SerializeField] TextMeshProUGUI _maxPebbleText = null;
		[SerializeField] DialogueUI _dialogueUI = null;

		public PlayerHUD PlayerHUD2 => _playerHUD2;
		public DialogueUI DialogueUI => _dialogueUI;

		public void ShowPlayerHUD(bool isActive)
		{
			_playerHUD.SetActive(isActive);
		}

		public void UpdateText(int gold)
        {


			_gold.SetText(gold.ToString());


        }

		public void SetPrice (List<int> listPrices)
        {

            for (int i = 0; i < listPrices.Count; i++)
            {

				_listPrice[i].SetText(listPrices[i].ToString());

            }

        }

		public void SetUpgradeVisibility(int indexList, bool visible)
        {

			_listUpgrade[indexList].SetActive(visible);


        }

		public void UpdatePebbleText(int index, string text)
        {
            if (index == 0)
            {
				_currentPebbleText.SetText(text);
            }

            else if (index == 1)
            {
				_maxPebbleText.SetText(text);
			}
            
        }
	}
}