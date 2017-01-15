using System;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Repository.Memory.Commands;
using NSubstitute;
using NUnit.Framework;

namespace LotteryDraw.Repository.UnitTests.Commands
{
    [TestFixture]
    public class CreateLotteryDrawCommandTests
    {
        [Test]
        public void CheckDefaultState()
        {
            var factory = Substitute.For<Func<ILotteryDrawWithResults>>();
            var command = new CreateLotteryDrawCommand(factory);

            Assert.That(command.HasError);
            Assert.That(command.ErrorMessage, Does.StartWith("Unable to convert data"));
            Assert.That(command.Value, Is.Null);
        }
    }
}
