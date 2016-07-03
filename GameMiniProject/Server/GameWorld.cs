using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameMiniProject
{
    public class GameWorld
    {
        public ArrayList GameObjects = new ArrayList();
        public event SendObjects Collision;

        public void CheckCollisions()
        {
            int StartCounter = 0;
            int CurrentCounter = 1;
            GameObject Object1;
            GameObject Object2;
            while (StartCounter < GameObjects.Count)
            {
                Object1 = ((GameObject)GameObjects[StartCounter]);
                while (CurrentCounter < GameObjects.Count)
                {
                    Object2 = ((GameObject)GameObjects[CurrentCounter]);
                    if (Object1.ToRectangle().IntersectsWith(Object2.ToRectangle()))
                    {
                        if (Collision != null)
                            Collision(ref Object1, ref Object2);
                    }
                    CurrentCounter++;
                }

                StartCounter++;
                CurrentCounter = StartCounter + 1;
            }

        }
    }
}
