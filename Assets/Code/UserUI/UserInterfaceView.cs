using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserUI
{
    public class UserInterfaceView :
        MonoBehaviour,
        IUserInterface
    {
        public event Action<Vector2> OnPauseOpen;
        public event Action OnPauseClose;

        [SerializeField] private GameObject _pnlPause;
        [SerializeField] private Button _btnPauseOpen;
        [SerializeField] private Button _btnPauseClose;
        [SerializeField] private TMP_Text _txtGOName;

        public void Initialize()
        {
            _btnPauseOpen.onClick.AddListener(PauseOpen);
            _btnPauseClose.onClick.AddListener(PauseClose);

            _pnlPause.SetActive(false);

            OnPauseOpen = context => { };
            OnPauseClose = () => { };
        }

        public void SetText(string text)
        {
            _txtGOName.text = text;
        }

        private void PauseOpen()
        {
            _btnPauseOpen.image.enabled = false;
            _btnPauseOpen.enabled = false;

            _pnlPause.SetActive(true);

            OnPauseOpen.Invoke(_btnPauseOpen.transform.position);
        }

        private void PauseClose()
        {
            _btnPauseOpen.image.enabled = true;
            _btnPauseOpen.enabled = true;

            _pnlPause.SetActive(false);

            OnPauseClose.Invoke();
        }
    }
}