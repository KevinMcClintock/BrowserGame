using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameMiniProject
{
    public class GameObject
    {
        public Point3D Location = new Point3D(0, 0, 0);
        public Point3D size = new Point3D(20, 20, 20);
        public Point3D Speed = new Point3D(5, 5, 5);
        public double ActualSpeed = 0;
        public int Angle = 0;

        #region Acceleration and inertia
        public double Acceleration = 0.25;
        public double TargetSpeed = 0;

        public Point3D MaximumSpeed = new Point3D(0, 0, 0);
        public Point3D NewSpeed = new Point3D(0, 0, 0);
        public Point3D Inertia = new Point3D(0.1, 0.1, 0.1);

        #endregion

        #region constructor region
        public GameObject(double locX, double locY, double spd)
        {
            Location.X = Convert.ToDouble(locX);
            Location.Y = Convert.ToDouble(locY);
            TargetSpeed = spd;
            //size.X = Convert.ToDouble(siX);
            //size.Y = Convert.ToDouble(siY);
        }
        #endregion
        #region Collision Maths
        public void CalculateCollision(ref GameObject Object2)
        {
            //simple equations are

            // Velocity of this Object: ((mass1-mass2)*initialvelocity1)/(mass1+mass2)
            // Velocity of the other object: (2*mass1**initialvelocity1)/(mass1+mass2)
        }
        #endregion

        public Rectangle ToRectangle()
        {
            return new Rectangle(Location.ToPoint(), size.ToSize());
        }
        #region Motion Calculations

        #region Mathematics for Motion


        private double DegreesToRadians(int Degrees)
        {
            return (Math.PI / 180.0) * Convert.ToDouble(Degrees);
        }

        private int RadiansToDegrees(double Radians)
        {
            return Convert.ToInt32((180 / Math.PI) * Radians);
        }

        #endregion
        public static void Main(string[] args) { }

        public void Move()
        {
            SpeedCalc();
            Location.X += Speed.X;
            Location.Y += Speed.Y;
            Location.Z += Speed.Z;
        }

        private void MaximumSpeedCalc()
        {
            MaximumSpeed.X = TargetSpeed * Math.Sin(DegreesToRadians(Angle));
            MaximumSpeed.Y = -(TargetSpeed * Math.Cos(DegreesToRadians(Angle)));

        }
        private void SpeedCalc()
        {
            if (ActualSpeed < TargetSpeed)
                ActualSpeed += Acceleration;

            else if (ActualSpeed > TargetSpeed)
                ActualSpeed -= Acceleration;

            NewSpeed.X = ActualSpeed * Math.Sin(DegreesToRadians(Angle));
            NewSpeed.Y = -(ActualSpeed * Math.Cos(DegreesToRadians(Angle)));

            if (Speed.X < NewSpeed.X)
            {
                Speed.X += Inertia.X;
                if (Speed.X > NewSpeed.X)
                    Speed.X = NewSpeed.X;
            }

            if (Speed.X > NewSpeed.X)
            {
                Speed.X -= Inertia.X;
                if (Speed.X < NewSpeed.X)
                    Speed.X = NewSpeed.X;
            }

            if (Speed.Y < NewSpeed.Y)
            {
                Speed.Y += Inertia.Y;
                if (Speed.Y > NewSpeed.Y)
                    Speed.Y = NewSpeed.Y;
            }

            if (Speed.Y > NewSpeed.Y)
            {
                Speed.Y -= Inertia.Y;
                if (Speed.Y < NewSpeed.Y)
                    Speed.Y = NewSpeed.Y;
            }
        }

        #endregion
    }
}
