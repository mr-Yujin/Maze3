//using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Maze
{

    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;
        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;

        private int _bonusCount;

        [SerializeField] private BadBonus badBonus;

        [SerializeField] private GameObject _player;
        [SerializeField] private Button _restartButton;

        void Awake()
        {
            _reference = new Reference();
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);

           foreach (var item in _interactiveObject)
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoint += AddBonus;
                }

                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayer += _viewEndGame.GameOver;
                    badBonus.OnCaughtPlayer += CaughtPlayer;
                }
            }
            //badBonus.OnCaughtPlayer += GameOver;
        }

        private void CaughtPlayer (string value, Color args)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void GameOver(string name, Color color)
        {
            Debug.Log(name + "color: " + color);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus (int value)
        {
            _bonusCount+= value;
            _viewBonus.Display(_bonusCount);
        }

        void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }
        }
    }
}
