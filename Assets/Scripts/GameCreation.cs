using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Core.Classes;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameCreation : MonoBehaviour
    {
        public Game Game;
        private GameManager _gameManager;

        void Awake()
        {
             Game = new Game(); 
        }
        void Update()
        {

        }
    }
}
