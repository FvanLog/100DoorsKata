using NUnit.Framework;
using FluentAssertions;

namespace HundredDoors.Tests
{
    public class DoorControllerTests
    {
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void GivenInvalidNumDoors_WhenInitializingDoorController_ThenThrowArgumentOutOfRangeException(int numDoors)
        {
            // arrange
            const string expectedParam = "numDoors";

            // act
            var sut = () => new DoorController(numDoors);

            // assert
            sut.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be(expectedParam);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void GivenValidNumDoors_WhenIntializingDoorController_ThenCreateDoorControllerWithCorrectNumDoors(int numDoors)
        {
            // arrange

            // act
            var doorController = new DoorController(numDoors);

            // assert
            doorController.Doors.Count.Should().Be(numDoors);
        }

        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void GivenInvalidNumPasses_WhenRunningPass_ThenThrowArgumentOutOfRangeException(int numPasses)
        {
            // arrange
            const string expectedParam = "numPasses";
            const int numDoors = 1;
            var doorController = new DoorController(numDoors);

            // act
            var sut = () => doorController.RunPass(numPasses);

            sut.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be(expectedParam);
        }

        [TestCase(6)]
        [TestCase(100)]
        public void GivenSomeDoorsBeforeRunningPass_WhenGettingDoorState_ThenReturnClosedDoors(int numDoors)
        {
            // arrange
            var doorController = new DoorController(numDoors);
            var expectedResult = "";
            
            for (int i = 0; i < numDoors; i++)
            {
                expectedResult = $"{expectedResult}#"; 
            }

            // act
            var actual = doorController.GetDoorStates();

            // assert
            actual.Length.Should().Be(numDoors);
            actual.Should().Be(expectedResult);
        }

        [Test]
        public void GivenOneDoorAndOnePass_WhenRunningPass_ShouldOpenDoor()
        {
            // arrange
            const int numDoors = 1;
            const int numPasses = 1;
            const string expectedResult = "@";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }

        [TestCase(6)]
        [TestCase(100)]
        public void GivenSomeDoorsAndOnePass_WhenRunningPass_ShouldOpenAllDoors(int numDoors)
        {
            // arrange 
            const int numPasses = 1;
            var doorController = new DoorController(numDoors);
            var expectedResult = "";

            for (int i = 0; i < numDoors; i++)
            {
                expectedResult = $"{expectedResult}@";
            }

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);

        }

        [Test]
        public void GivenSixDoorsAndTwoPasses_WhenRunningPass_ShouldToggleAllDoorStates()
        {
            // arrange
            const int numDoors = 6;
            const int numPasses = 2;
            const string expectedResult = "@#@#@#";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }

        [Test]
        public void GivenSixDoorsAndThreePasses_WhenRunningPass_ShouldToggleAllDoorStates()
        {
            // arrange
            const int numDoors = 6;
            const int numPasses = 3;
            const string expectedResult = "@###@@";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }

        [Test]
        public void GivenSixDoorsAndFourPasses_WhenRunningPass_ShouldToggleAllDoorStates()
        {
            // arrange
            const int numDoors = 6;
            const int numPasses = 4;
            const string expectedResult = "@##@@@";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }

        [Test]
        public void GivenSixDoorsAndFivePasses_WhenRunningPass_ShouldToggleAllDoorStates()
        {
            // arrange
            const int numDoors = 6;
            const int numPasses = 5;
            const string expectedResult = "@##@#@";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }

        [Test]
        public void GivenSixDoorsAndSixPasses_WhenRunningPass_ShouldToggleAllDoorStates()
        {
            // arrange
            const int numDoors = 6;
            const int numPasses = 6;
            const string expectedResult = "@##@##";
            var doorController = new DoorController(numDoors);

            // act
            var actual = doorController.RunPass(numPasses);

            // assert
            actual.Should().Be(expectedResult);
        }
    }
}
