using NUnit.Framework;
using FluentAssertions;

namespace HundredDoors.Tests
{
    public class DoorTests
    {
        [TestCase(true, "@")]
        [TestCase(false, "#")]
        public void GivenDoorState_WhenOperatingDoor_ThenReturnCorrectState(bool state, string expectedResult)
        {
            // arrange
            var door = new Door();

            // act
            door.IsOpen = state;

            // assert
            door.GetState().Should().Be(expectedResult);
        }
    }
}