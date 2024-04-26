using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Robot redRobot = null;
        Robot blueRobot = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void CRR_click(object sender, EventArgs e)
        {
            string RModel = RedRobotType.SelectedItem.ToString();
            if (RModel == "Jakobs")
                redRobot = new Robot(new JakobsRobot());
            else if (RModel == "Maliwan")
                redRobot = new Robot(new MaliwanRobot());
            else if (RModel == "Torgue")
                redRobot = new Robot(new TorgueRobot());
            else if (RModel == "Custom")
            {
                redRobot = new Robot(new JakobsRobot());
                string RWeapon=comboBox1.SelectedItem.ToString();
                string RArmor=comboBox2.SelectedItem.ToString();
                string RLegs=comboBox3.SelectedItem.ToString();
                if (RWeapon == "TorgueRPG") { redRobot.eqweapon = new TorgueRPG(); }
                if (RWeapon == "MaliwanLaser") { redRobot.eqweapon = new MaliwanLaser(); }
                if (RArmor=="TorgueArmor") { redRobot.eqbody = new TorgueBody(); }
                if (RArmor == "MaliwanArmor") { redRobot.eqbody = new MaliwanBody(); }
                if (RLegs== "TorgueLegs") { redRobot.eqlegs = new TorgueLegs(); }
                if (RLegs == "MaliwanLegs") { redRobot.eqlegs = new MaliwanLegs(); }
            }
            MessageBox.Show("Red Robot Created");
        }


        private void CBR_click(object sender, EventArgs e)
        {
            string RModel = BlueRobotType.SelectedItem.ToString();
            if (RModel == "Jakobs")
                blueRobot = new Robot(new JakobsRobot());
            else if (RModel == "Maliwan")
                blueRobot = new Robot(new MaliwanRobot());
            else if (RModel == "Torgue")
                blueRobot = new Robot(new TorgueRobot());
            else if (RModel == "Custom")
            {
                blueRobot = new Robot(new JakobsRobot());
                string BWeapon = comboBox6.SelectedItem.ToString();
                string BArmor = comboBox5.SelectedItem.ToString();
                string BLegs = comboBox4.SelectedItem.ToString();
                if (BWeapon == "TorgueRPG") { blueRobot.eqweapon = new TorgueRPG(); }
                if (BWeapon == "MaliwanLaser") { blueRobot.eqweapon = new MaliwanLaser(); }
                if (BArmor == "TorgueArmor") { blueRobot.eqbody = new TorgueBody(); }
                if (BArmor == "MaliwanArmor") { blueRobot.eqbody = new MaliwanBody(); }
                if (BLegs == "TorgueLegs") { blueRobot.eqlegs = new TorgueLegs(); }
                if (BLegs == "MaliwanLegs") { blueRobot.eqlegs = new MaliwanLegs(); }
            }
            MessageBox.Show("Blue Robot Created");
        }
        private void CheckStats_Click(object sender, EventArgs e)
        {
            if ((redRobot != null) && (blueRobot != null))
            {
                //int rdmg = redRobot.smth();
                //string rwpnName = redRobot.smth2();
                //int bdmg = blueRobot.smth();
                //string bwpnName = blueRobot.smth2();
                WeaponVisitor Rvisitor = new WeaponVisitor();
                WeaponVisitor Bvisitor = new WeaponVisitor();
                redRobot.Weapon.Accept(Rvisitor);
                blueRobot.Weapon.Accept(Bvisitor);
                MessageBox.Show("Red Robot \n Weapon: " + Rvisitor.Name + "\n Weapon damage: " + Rvisitor.Damage + "\n Weapon Range: " + Rvisitor.Range + "\n Weapon Fire_Rate: " + Rvisitor.Fire_Rate  "\n \n Blue robot \n Weapon: " + Bvisitor.Name + "\n Weapon damage: " + Bvisitor.Damage + "\n Weapon Range: " + Bvisitor.Range + "\n Weapon Fire_Rate: " + Bvisitor.Fire_Rate);
            }
            else
            {
                MessageBox.Show("Create a robot");
            }
        }
        abstract class IVisitor
        {
         public abstract void VisitWeapon(Weapon weapon);
        }
        
        class WeaponVisitor: IVisitor
        {
         public int Range { get; private set;}
         public int Damage { get; private set;}
         public int Fire_Rate { get; private set;}
         public string Name { get; private set;}
        public override void VisitWeapon(Weapon weapon)
        {
        Range = weapon.Range;
        Damage = weapon.Damage;
        Fire_Rate = weapon.Fire_Rate;
        Name = string.Name;              
        }
        }
        
        abstract public class Weapon
        {
            public abstract int Range { get; }
            public abstract int Damage { get; }
            public abstract int Fire_Rate { get; }
            public abstract string Name { get; }
            public abstract void Accept(Ivisitor visitor);
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

       public class JakobsTurret : Weapon
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
            public override string Name
            {
                get { return "JakobsTurret"; }
            }
            public override void Accept(Ivisitor visitor);
            {
                visitor.Visit(this);
            }
        }
       public class MaliwanLaser : Weapon
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
            public override string Name
            {
                get { return "MaliwanLaser"; }
            }
            public override void Accept(Ivisitor visitor);
            {
                visitor.Visit(this);
            }
        }
      public  class TorgueRPG : Weapon
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
            public override string Name
            {
                get { return "TorgueRPG"; }
            }
            public override void Accept(Ivisitor visitor);
            {
                visitor.Visit(this);
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
            public Weapon eqweapon;
            public Body eqbody;
            public Legs eqlegs;
            public Robot(RobotFactory factory)
            {
                eqweapon = factory.CreateWeapon();
                eqbody = factory.CreateBody();
                eqlegs = factory.CreateLegs();


            }
            public int smth()
            {
                return eqweapon.Damage;
            }
            public string smth2()
            {
                return eqweapon.Name;
            }
        }

        private void RedRobotModel_SelectedValueChanged(object sender, EventArgs e)
        {
            string RModel = RedRobotType.SelectedItem.ToString();
            if (RModel == "Custom")
            {
                comboBox1.Show();
                comboBox2.Show();
                comboBox3.Show();
                label5.Show();
                label6.Show();
                label7.Show();
            }
            else
            {
                label5.Hide();
                label6.Hide();
                label7.Hide();
            }
        }


        private void BlueRobotType_SelectedValueChanged(object sender, EventArgs e)
        {
            string BModel = BlueRobotType.SelectedItem.ToString();
            if (BModel == "Custom")
            {
                comboBox4.Show();
                comboBox5.Show();
                comboBox6.Show();
                label8.Show();
                label9.Show();
                label10.Show();
            }
            else
            {
                comboBox4.Hide();
                comboBox5.Hide();
                comboBox6.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
            }
        }
        private void Battle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress sorry :p");
        }

    }
}
