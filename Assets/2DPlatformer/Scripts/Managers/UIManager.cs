namespace GSGD2.UI
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using TMPro;
	using UnityEngine.UI;

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
		[SerializeField] GameObject _inputDialogue = null;
		[SerializeField] TextMeshProUGUI _textInput = null;
		[SerializeField] Image _inputDialogueImage = null;
		[SerializeField] List<Sprite> _listSprite = null;
		[SerializeField] List<string> _listText = null;

		public PlayerHUD PlayerHUD2 => _playerHUD2;
		public DialogueUI DialogueUI => _dialogueUI;

		public TextMeshProUGUI TextInput => _textInput;

		public Image InputDialogueImage => _inputDialogueImage;

		public GameObject InputDialogue => _inputDialogue;

		public List<Sprite> ListSprite => _listSprite;

		public List<string> ListText => _listText;



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

		public void SetInputDialogueActive(bool active)
		{

			_inputDialogue.SetActive(active);


		}


		public void SetTextAndSprite(string text, Sprite sprite)
        {
			_inputDialogueImage.sprite = sprite;
			_textInput.SetText(text);


        }
	}

	
}