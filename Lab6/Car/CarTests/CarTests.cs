using CarClass;

namespace CarTests;

[TestClass]
public class CarTests
{
    // dotnet test /p:CollectCoverage=true
    [TestMethod]
    public void Car_Initial_Values()
    {
        // Arrange
        Car car = new Car();

        // Act

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid initial speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid initial gear");
        Assert.IsFalse(car.IsTurnedOn(), "Invalid initial engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid initial direction");
    }
    
    [TestMethod]
    public void Switching_Off_Engine_When_Engine_Off()
    {
        // Arrange
        Car car = new Car();
        
        // Act
        car.TurnOffEngine();

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed when engine just started");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear when engine just started");
        Assert.IsFalse(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction when engine just started");
    }
    
    [TestMethod]
    public void Switching_On_Engine_When_Engine_Off()
    {
        // Arrange
        Car car = new Car();
        
        // Act
        car.TurnOnEngine();

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed when engine just started");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear when engine just started");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction when engine just started");
    }
    
    [TestMethod]
    public void Switching_On_Engine_When_Engine_On()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        
        // Act
        car.TurnOnEngine();

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed when engine just started");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear when engine just started");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction when engine just started");
    }
    
    [TestMethod]
    public void Switching_Gear_When_Engine_Off()
    {
        // Arrange
        Car car = new Car();
        
        // Act
        car.SetGear(1);

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear");
        Assert.IsFalse(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Switching_Gear_When_Engine_On()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        
        // Act
        car.SetGear(1);

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    
    [TestMethod]
    public void Turn_Off_Engine_When_Engine_On_And_Gear_N_And_Speed_Not_0()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(10);
        car.SetGear(0);

        // Act
        car.TurnOffEngine();

        // Assert
        Assert.AreEqual(10, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Turn_Off_Engine_When_Engine_On_And_Gear_Not_N()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        
        // Act
        car.TurnOffEngine();

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    
    [TestMethod]
    public void Set_Speed_When_Engine_Off()
    {
        // Arrange
        Car car = new Car();
        
        // Act
        car.SetSpeed(10);

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear");
        Assert.IsFalse(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Speed_When_Engine_On_And_Gear_N()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        
        // Act
        car.SetSpeed(10);

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.StandingStill, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Speed_When_Engine_On_And_Gear_1()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        
        // Act
        car.SetSpeed(10);

        // Assert
        Assert.AreEqual(10, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Negative_Speed()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
    
        // Act
        car.SetSpeed(-10);
    
        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearR, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Backward, car.GetDirection(), "Invalid direction");
    }
    
    
    [TestMethod]
    public void Set_Invalid_Speed_For_Current_Gear()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        
        // Act
        car.SetSpeed(31);

        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Reverse_Gear()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        
        // Act
        car.SetGear(-1);
        
        // Assert
        Assert.AreEqual(0, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearR, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Backward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Invalid_Gear()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();

        // Act
        bool result1 = car.SetGear(6);
        bool result2 = car.SetGear(-2);

        // Assert
        Assert.IsFalse(result1, "Gear 6 not allowed");
        Assert.IsFalse(result2, "Gear -2 not allowed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Gear should remain neutral");
    }
    
    [TestMethod]
    public void Set_Max_Speed()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(20);
        car.SetGear(2);
        car.SetSpeed(50);
        car.SetGear(3);
        car.SetSpeed(60);
        car.SetGear(4);
        car.SetSpeed(90);
        car.SetGear(5);

        // Act
        car.SetSpeed(150);
        
        // Assert
        Assert.AreEqual(150, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear5, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set__Invalid_Max_Speed()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(20);
        car.SetGear(2);
        car.SetSpeed(50);
        car.SetGear(3);
        car.SetSpeed(60);
        car.SetGear(4);
        car.SetSpeed(90);
        car.SetGear(5);

        // Act
        car.SetSpeed(151);
        
        // Assert
        Assert.AreEqual(90, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear5, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }

    
    [TestMethod]
    public void Set_Forward_Geare_While_Moving_Backward()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(10);

        // Act
        car.SetGear(1);

        // Assert
        Assert.AreEqual(10, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearR, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Backward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Set_Reverse_Gear_While_Moving_Forward()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(10);

        // Act
        car.SetGear(-1);

        // Assert
        Assert.AreEqual(10, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Reduce_Speed_For_Current_Gear()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(10);

        // Act
        car.SetSpeed(5);

        Assert.AreEqual(5, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.Gear1, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Forward, car.GetDirection(), "Invalid direction");
    }
    
    [TestMethod]
    public void Reduce_Speed_When_Gear_N()
    {
        // Arrange
        Car car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(10);
        car.SetGear(0);

        // Act
        car.SetSpeed(5);

        Assert.AreEqual(5, car.GetSpeed(), "Invalid speed");
        Assert.AreEqual(Gear.GearN, car.GetGear(), "Invalid gear");
        Assert.IsTrue(car.IsTurnedOn(), "Invalid engine status");
        Assert.AreEqual(Direction.Backward, car.GetDirection(), "Invalid direction");
    }
}