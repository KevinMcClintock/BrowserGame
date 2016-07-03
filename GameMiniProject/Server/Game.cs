using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Drawing;
using System.ComponentModel;
using System.Data;
namespace GameMiniProject
{
    public class Game
    {
        private HighFrequencyTimer _gameLoop;
        public GameConfiguration gameConfig;
        private Game() {
            _gameLoop = new HighFrequencyTimer(1000 / gameConfig.UPDATE_INTERVAL, id => Update(id));
            _gameLoop.Start();
        }

        private long Update(long id)
        {
           {                          
                return id;
            }
        }

        public object initializeClient()
        {
            Character chara;
            chara = new Character("test", CharClass.Warrior, 100, 100, 5);

            return chara;
        }
    }
}