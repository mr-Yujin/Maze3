using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class ViewEndGame
    {
        private Text _bonusLabel;

        public ViewEndGame(GameObject endGamePrefab)
        {
            _bonusLabel = endGamePrefab.GetComponent<Text>();
            _bonusLabel.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _bonusLabel.text = $"Game Over: Bonus Name: {name} Color {color}";
        }
    }
}