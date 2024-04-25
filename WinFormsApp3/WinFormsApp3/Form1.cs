namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Robot currentRobot = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentRobot = new Robot(new JakobsRobot());
            MessageBox.Show("Jakobs Robot Created");
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (currentRobot != null)
        //    {
        //        MessageBox.Show("Current Robot Stats:\nRange: " + currentRobot.weapon + "\nDamage: " + equippedWeapon.Damage);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Create a robot");
        //    }
        //}
        private void BuyBow_Click(object sender, EventArgs e)
        {
            currentRobot = new Robot(new MaliwanRobot());
            MessageBox.Show("Maliwan Robot Created!");
        }
        abstract class Weapon
        {
            public abstract int Range { get; }
            public abstract int Damage { get; }
            public abstract int Fire_Rate { get; }
            public abstract string Manufacturer { get; }
        }

        abstract class Body
        {
            public abstract int Health { get; }
            public abstract string Manufacturer { get; }
        }

        abstract class Legs
        {
            public abstract int Movement_Speed { get; }
            public abstract string Manufacturer { get; }
        }

        class JakobsTurret : Weapon
        {

            public override int Range
            {
                get { return 20; }
            }
            public override int Damage
            {
                get { return 10; }
            }
            public override int Fire_Rate
            {
                get { return 5; }
            }
            public override string Manufacturer
            {
                get { return "Jakobs"; }
            }
        }
        class MaliwanLaser : Weapon
        {

            public override int Range
            {
                get { return 100; }
            }

            public override int Damage
            {
                get { return 25; }
            }
            public override int Fire_Rate
            {
                get { return 1; }
            }
            public override string Manufacturer
            {
                get { return "Maliwan"; }
            }
        }
        class TorgueRPG : Weapon
        {

            public override int Range
            {
                get { return 40; }
            }

            public override int Damage
            {
                get { return 20; }
            }
            public override int Fire_Rate
            {
                get { return 3; }
            }
            public override string Manufacturer
            {
                get { return "Torgue"; }
            }
        }

        class JakobsBody : Body
        {
            public override int Health
            {
                get { return 500; }
            }
            public override string Manufacturer
            {
                get { return "Jakobs"; }
            }
        }
        class MaliwanBody : Body
        {
            public override int Health
            {
                get { return 300; }
            }
            public override string Manufacturer
            {
                get { return "Maliwan"; }
            }
        }
        class TorgueBody : Body
        {
            public override int Health
            {
                get { return 750; }
            }
            public override string Manufacturer
            {
                get { return "Torgue"; }
            }
        }


        class JakobsLegs : Legs
        {
            public override int Movement_Speed
            {
                get { return 30; }
            }
            public override string Manufacturer
            {
                get { return "Jakobs"; }
            }
        }
        class MaliwanLegs : Legs
        {
            public override int Movement_Speed
            {
                get { return 20; }
            }
            public override string Manufacturer
            {
                get { return "Maliwan"; }
            }
        }
        class TorgueLegs : Legs
        {
            public override int Movement_Speed
            {
                get { return 15; }
            }
            public override string Manufacturer
            {
                get { return "Torgue"; }
            }
        }

        abstract class RobotFactory
        {
            public abstract Body CreateBody();
            public abstract Weapon CreateWeapon();
            public abstract Legs CreateLegs();
        }

        class JakobsRobot : RobotFactory
        {
            public override Body CreateBody()
            {
                return new JakobsBody();
            }
            public override Weapon CreateWeapon()
            {
                return new JakobsTurret();
            }
            public override Legs CreateLegs()
            {
                return new JakobsLegs();
            }

        }

        class MaliwanRobot : RobotFactory
        {
            public override Body CreateBody()
            {
                return new MaliwanBody();
            }
            public override Weapon CreateWeapon()
            {
                return new MaliwanLaser();
            }
            public override Legs CreateLegs()
            {
                return new MaliwanLegs();
            }
        }
        class TorgueRobot : RobotFactory
        {
            public override Body CreateBody()
            {
                return new TorgueBody();
            }
            public override Weapon CreateWeapon()
            {
                return new TorgueRPG();
            }
            public override Legs CreateLegs()
            {
                return new TorgueLegs();
            }
        }
        class Robot
        {
            private Weapon weapon;
            private Body body;
            private Legs legs;
            public Robot(RobotFactory factory)
            { weapon = factory.CreateWeapon();
              body = factory.CreateBody();
              legs = factory.CreateLegs();
            }
        }
    }
}
