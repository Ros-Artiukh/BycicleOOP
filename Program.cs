using System;
using System.Threading;

namespace BicycleOOP
{
    public enum MatEnum : int
    {
        Steel,
        Carbon
    }
    public enum ColEnum : int
    {
        Black,
        White
    }
    public class PhisicalObject
    {
        public int Price { get; private set; }
        public int Weigth { get; private set; }
        public string Brand { get; private set; }
        public string Material { get; private set; }
        public string Color { get; private set; }
        public PhisicalObject(int price, int weight, string brand, MatEnum material, ColEnum color)
        {
            Price = price;
            Weigth = weight;
            Brand = brand;

            WhichColor(color);
            WhichMaterial(material);
        }
        private string WhichColor(ColEnum color) =>

            color switch
            {
                ColEnum.Black => Color = "Цвет черный",
                ColEnum.White => Color = "Цвет белый",
            };

        private string WhichMaterial(MatEnum material) =>

            material switch
            {
                MatEnum.Steel => Material = " Материал Cталь",
                MatEnum.Carbon => Material = "Материал Карбон",
            };
    }
    public class Frame : PhisicalObject//Рама
    {
        public string Form { get; private set; }
        public bool IsBroken { get; private set; }
        public Frame(string form, int price, int weigth, string brand, bool isBroken, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Form = form;
            IsBroken = isBroken;
        }
    }
    public class Wheel : PhisicalObject //Колесо
    {
        public int Spokes { get; private set; } // кол-спиц колеса.
        public int Speculum { get; private set; } // кол-во отражателей на спицах.
        public int CountWheels { get; private set; } = 2; // кол-во колес
        public bool IsBroken { get; private set; }

        public Wheel(int spokes, int speculum, int count, int price, int weigth, string brand, bool isBroken, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Spokes = spokes;
            Speculum = speculum;
            CountWheels = count;
            IsBroken = isBroken;
        }
    }
    public class HandleBar : PhisicalObject //Руль
    {
        public string Form { get; private set; }
        public bool HandBrakes { get; private set; }
        public bool Bell { get; private set; }
        public int Height { get; private set; }
        public bool IsBroken { get; private set; }
        public bool IsPuttedKey { get; set; }// вставлен ли ключ.
        public bool IsSpidometerExist { get; private set; }// есть ли спидометр.
        public bool IsUsbChargeForMobExist { get; private set; } // есть ли зарядка для мобильного

        public HandleBar(string form, bool handBrakes, bool bell, int price, int weigth, int height, string brand,
                            bool isBroken, bool isPuttedKey, bool isSpidometer, bool isUsbChargeForMob, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Form = form;
            HandBrakes = handBrakes;
            Bell = bell;
            Height = height;
            IsBroken = isBroken;
            IsPuttedKey = isPuttedKey;
            IsSpidometerExist = isSpidometer;
            IsUsbChargeForMobExist = isUsbChargeForMob;
        }
    }
    public class Pedal : PhisicalObject // педаль
    {
        public bool Speculum { get; private set; } // отражатели на педалях
        public string IsBrakes { get; private set; } // вид тормоза
        public bool IsBroken { get; private set; }

        public Pedal(bool speculum, string isBrakes, int price, int weigth, string brand, bool isBroken, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Speculum = speculum;
            IsBrakes = isBrakes;
            IsBroken = isBroken;
        }
    }
    public class Seat : PhisicalObject // сидение
    {
        public string Form { get; private set; }
        public int Length { get; private set; }
        public bool IsBroken { get; private set; }

        public Seat(string form, int length, int price, int weigth, string brand, bool isBroken, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Form = form;
            Length = length;
            IsBroken = isBroken;
        }
    }
    public class Battery : PhisicalObject // Батарея
    {
        public string Type { get; private set; } // тип батаерии
        public int Power { get; private set; } // можность
        public bool IsFuel { get; set; } // заряжена ли батарея
        public int PowerReserve { get; private set; } // запас хода
        public int MaxSpeed { get; private set; } // макс скорость
        public bool IsBroken { get; private set; }

        public Battery(string type, int power, bool isFuel, int powerReserve, int maxSpeed, int price, int weigth, string brand, bool isBroken, MatEnum material, ColEnum color)
            : base(price, weigth, brand, material, color)
        {
            Type = type;
            Power = price;
            IsFuel = isFuel;
            PowerReserve = weigth;
            MaxSpeed = maxSpeed;
            IsBroken = isBroken;
        }
    }
    abstract class Bicycle
    {
        //private string _formChassis; // форма раммы.
        public Frame Frame { get; private set; }
        public Wheel Wheel { get; private set; }
        public HandleBar HandleBar { get; private set; }
        public Pedal Pedal { get; private set; }
        public Seat Seat { get; private set; }
        private string _color; // цвет.
        public int Price { get; protected set; }
        public int Weight { get; protected set; }
        public string Appointment { get; private set; } // назначение.
        private string _brand; // бренд
        public Bicycle(Frame frame, Wheel wheel, HandleBar handleBar,
                       Pedal pedal, Seat seat, string appointment, string color, string brand)
        {
            //_formChassis = formChassis;
            Frame = frame;
            Wheel = wheel;
            HandleBar = handleBar;
            Pedal = pedal;
            Seat = seat;
            Appointment = appointment;
            _color = color;
            _brand = brand;
            Frame = frame;
            Wheel = wheel;
            HandleBar = handleBar;
            Pedal = pedal;
            Seat = seat;
            Price = Frame.Price + Wheel.Price + HandleBar.Price + Pedal.Price + Seat.Price;
            Weight = Frame.Weigth + Wheel.Weigth + HandleBar.Weigth + Pedal.Weigth + Seat.Weigth;
        }
        public abstract void Ride();
        public abstract void Brake();
    }
    class Bmx : Bicycle
    {
        private bool _leg; // ножка велосипеда
        private string _absorber; // амортизаторы
        public bool IsBraking { get; private set; }
        public Bmx(Frame frame, Wheel wheel, HandleBar handleBar,
                  Pedal pedal, Seat seat,
                  string color,
                  string appointment, string brand, bool leg, string absorber)
                  : base(
                             frame, wheel, handleBar, pedal,
                             seat, color, appointment, brand
                         )
        {
            _leg = leg;
            _absorber = absorber;
        }
        public override void Ride()
        {
            if (!Frame.IsBroken && !Wheel.IsBroken && !HandleBar.IsBroken && !Pedal.IsBroken && !Seat.IsBroken && !IsBraking)
            {
                Console.WriteLine("Велик полностю исправен тормоза отпущены - можно двигатся");
            }
            else
            {
                Console.WriteLine("Придется передвигатся пешком пока не устраните поломку или отпустите тормоз вызвав ещё раз метод Riding");
                IsBraking = false;
            }
        }
        public override void Brake()
        {
            IsBraking = true;
            Console.WriteLine("нажат тормоз");
        }
        public void Jump()
        {
            if (Appointment == "велотриал")
            {
                Console.WriteLine("Можем попрыгать по бордюрах, лавочках, побеспределить вообщем");
            }
        }
        public void Beep()
            => Console.WriteLine($"Дергаем колокольчик дзен дзелинь");
        public void GearShift(int num)
            => Console.WriteLine($"Выбрали передачу {num} прокатимся с ветерком");
    }
    class ElectroBicycle : Bicycle
    {
        public Battery Battery { get; private set; }
        private bool _leg; // ножка велосипеда.
        private string _absorber; // амортизаторы.
        public bool IsBraking { get; private set; }

        public ElectroBicycle(Frame frame, Wheel wheel, HandleBar handleBar,
                  Pedal pedal, Seat seat, Battery battery, string color,
                   string appointment, string brand, bool leg, string absorber, bool isPutted, bool isSpeedmtr, bool isUsbChrg)
                   : base(
                              frame, wheel, handleBar, pedal,
                              seat, color, appointment, brand
                          )
        {
            _leg = leg;
            _absorber = absorber;
            Battery = battery;
            Price += Battery.Price;
            Weight += Battery.Weigth;
        }
        public override void Ride()
        {
            if (!Frame.IsBroken && !Wheel.IsBroken && !HandleBar.IsBroken && !Pedal.IsBroken && !Seat.IsBroken && !IsBraking)
            {
                Console.WriteLine("Электровелик полностю исправен тормоза отпущены - можно двигатся");
                if (!Battery.IsFuel || !HandleBar.IsPuttedKey)
                {
                    Console.WriteLine("Придется педальки только покрутить)");
                }
            }
            else
            {
                Console.WriteLine("Придется передвигатся пешком пока не устраните поломку или отпустите тормоз вызвав ещё раз метод Riding");
                IsBraking = false;
            }
        }
        public override void Brake()
        {
            IsBraking = true;
            Console.WriteLine("нажат тормоз");
        }
        public void Charge()
        {
            if (!Battery.IsFuel)
            {
                Console.WriteLine("Батарея пустая поставили на зарядку");
                Thread.Sleep(3000);
                Console.WriteLine("Батарея зарядилась - приятного пути");
                Battery.IsFuel = true;
            }
        }
        public void PutKey()
        {
            if (!Battery.IsFuel)
            {
                Console.WriteLine("Пока не зарядем ключом можно только в зубах поковырятся но не завести велик");
            }
            else
            {
                Console.WriteLine("ключ вставили велик завелся можно насладится поездкой без усилий");
                HandleBar.IsPuttedKey = true;
            }
        }
        public void Beep()
            => Console.WriteLine($"Дергаем колокольчик - дзен дзелинь");
        public void GearShift(int num)
            => Console.WriteLine($"Выбрали передачу {num} прокатимся с ветерком");
    }
    class Program
    {
        static void Main(string[] args)
        {
            var frameBmx = new Frame("треугольно-приплюснутая", 199, 9, "залупянский завод имени какогото хера", false, MatEnum.Steel, ColEnum.Black);
            var wheelBmx = new Wheel(24, 2, 2, 599, 6, "залупянский завод имени какогото хера", false, MatEnum.Steel, ColEnum.Black);
            var handleBarBmx = new HandleBar("прямая и ровная", true, true, 699, 2, 70, "залупянский завод имени какогото хера", false, false, false, false, MatEnum.Steel, ColEnum.Black);
            var pedalBmx = new Pedal(true, "дисковой поддерживают", 99, 1, "залупянский завод имени какогото хера", false, MatEnum.Carbon, ColEnum.Black);
            var seatBmx = new Seat("обтекаемая-загнутая", 31, 59, 1, "залупянский завод имени какогото хера", false, MatEnum.Steel, ColEnum.Black);

            Bicycle bmx = new Bmx(frameBmx, wheelBmx, handleBarBmx, pedalBmx, seatBmx, "темный", "Для трюков", "Stolen", true, "спереди и сзади");
            Console.WriteLine(bmx.Price);
            Console.WriteLine(bmx.Weight);
            Console.WriteLine($"Педаль {bmx.Pedal.Material}");
            Console.WriteLine($"Педаль {bmx.Pedal.Color}");
            bmx.Ride();
            bmx.Brake();
            bmx.Ride();
            bmx.Ride();
            Bmx letDoIt = (Bmx)bmx;
            letDoIt.Jump();
            letDoIt.GearShift(7);
            letDoIt.Beep();

            var frameElectro = new Frame("треугольно-приплюснутая", 199, 9, "залупянский завод имени Елона Макса", false, MatEnum.Steel, ColEnum.Black);
            var wheelElectro = new Wheel(24, 2, 2, 599, 6, "залупянский завод имени какогото хера", false, MatEnum.Steel, ColEnum.Black);
            var handleBarElectro = new HandleBar("прямая и ровная", true, true, 699, 2, 70, "залупянский завод какогото  Елона Макса", false, true, true, true, MatEnum.Steel, ColEnum.White);
            var pedalElectro = new Pedal(true, "дисковой поддерживают", 99, 1, "залупянский завод какогото  Елона Макса", false, MatEnum.Carbon, ColEnum.Black);
            var seatElectro = new Seat("обтекаемая-загнутая", 31, 59, 1, "залупянский завод имени какогото  Елона Макса", false, MatEnum.Steel, ColEnum.White);
            var batteryElectro = new Battery("Литий", 500, false, 30, 45, 999, 5, "залупянский завод имени какогото  Елона Макса", false, MatEnum.Steel, ColEnum.Black);

            ElectroBicycle electro = new ElectroBicycle(frameElectro, wheelElectro, handleBarElectro, pedalElectro, seatElectro, batteryElectro,
                                     "бело-черный", "электровелосипед", "Stolen", true, "только сзади", true, true, true);
            Console.WriteLine(electro.Price);
            Console.WriteLine(electro.Weight);
            Console.WriteLine($"Рама {electro.Frame.Material}");
            Console.WriteLine($"Рама {electro.Frame.Color}");
            electro.Brake();
            electro.Ride();
            electro.Charge();
            electro.PutKey();
            electro.Ride();
            electro.GearShift(7);
            electro.Beep();
        }
    }
}
