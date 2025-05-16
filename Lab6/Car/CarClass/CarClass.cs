namespace CarClass
{
    public enum Gear
    {
        GearR = -1,
        GearN = 0,
        Gear1 = 1,
        Gear2 = 2,
        Gear3 = 3,
        Gear4 = 4,
        Gear5 = 5
    }

    public enum Direction
    {
        StandingStill,
        Forward,
        Backward
    }

    public class Car
    {
        private bool _engineStatus = false;
        private int _speed = 0;
        private Gear _gear = Gear.GearN;
        private Direction _direction = Direction.StandingStill;

        private static readonly Dictionary<Gear, (int Min, int Max)> speedRanges = new()
        {
            { Gear.GearR, (0, 20) },
            { Gear.GearN, (0, 150) },
            { Gear.Gear1, (0, 30) },
            { Gear.Gear2, (20, 50) },
            { Gear.Gear3, (30, 60) },
            { Gear.Gear4, (40, 90) },
            { Gear.Gear5, (50, 150) }
        };

        public Car()
        {
            _engineStatus = false;
            _speed = 0;
            _gear = Gear.GearN;
            _direction = Direction.StandingStill;
        }

        public bool IsTurnedOn() => _engineStatus;
        public int GetSpeed() => _speed;
        public Gear GetGear() => _gear;
        public Direction GetDirection() => _direction;

        public bool TurnOnEngine()
        {
            _engineStatus = true;
            return _engineStatus;
        }

        public bool TurnOffEngine()
        {
            if (!_engineStatus) return true;
            if (_gear == Gear.GearN && _speed == 0)
            {
                _engineStatus = false;
                _direction = Direction.StandingStill;
                return true;
            }

            return false;
        }

        public bool SetGear(int gear)
        {
            if (!IsTurnedOn() && gear != (int)Gear.GearN)
            {
                Console.WriteLine("Cannot change gear, engine is off.");
                return false;
            }
            
            if (!Enum.IsDefined(typeof(Gear), gear)) 
            {
                Console.WriteLine("Invalid gear.");
                return false;
            }

            if ((Gear)gear == Gear.GearN)
            {
                _gear = Gear.GearN;
                return true;
            }
            
            if (_gear != Gear.GearN && _speed > 0 && (Gear)gear == Gear.GearR) 
            {
                Console.WriteLine("Cannot shift to reverse while moving forward.");
                return false;
            }
            
            if (_gear == Gear.GearR && (Gear)gear != Gear.GearN && (Gear)gear != Gear.GearR)
            {
                Console.WriteLine("Cannot shift directly from reverse to forward gears.");
                return false;
            }

            var (minSpeed, maxSpeed) = speedRanges[(Gear)gear];
            if (_speed >= minSpeed && _speed <= maxSpeed)
            {
                _gear = (Gear)gear;
                _direction = _gear == Gear.GearR ? Direction.Backward : Direction.Forward;
                return true;
            }

            Console.WriteLine("Speed not in allowed range for selected gear.");
            return false;
        }

        public bool SetSpeed(int speed)
        {
            if (speed < 0)
            {
                Console.WriteLine("Speed cannot be negative.");
                return false;
            }

            if (!IsTurnedOn())
            {
                Console.WriteLine("Cannot change speed, engine is off.");
                return false;
            }

            if (_gear == Gear.GearN)
            {
                if (_speed <= speed)
                {
                    Console.WriteLine("Cannot accelerate in neutral gear.");
                    return false;
                }

                _speed = speed;
                return true;
            }

            var (minSpeed, maxSpeed) = speedRanges[_gear];
            if (speed >= minSpeed && speed <= maxSpeed)
            {
                _speed = speed;
                return true;
            }

            Console.WriteLine("Speed out of allowed range for current gear.");
            return false;
        }
    }
}


