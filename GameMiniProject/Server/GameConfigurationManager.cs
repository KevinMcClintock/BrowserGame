using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMiniProject
{
    public class GameConfigurationManager
    {
        public GameConfigurationManager()
        {

            gameConfig = new GameConfiguration();
        }



        // Game Configurations
        public GameConfiguration gameConfig { get; set; }

    }
}