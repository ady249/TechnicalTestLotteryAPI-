using System;
using LotteryDraw.Models;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Models;
using LotteryDraw.Repository.Memory.Commands;
using LotteryDraw.Repository.Memory.Interfaces.Commands;
using NUnit.Framework;

namespace LotteryDraw.Repository.Integration.Commands
{
    [TestFixture]
    public class CreateLotteryDrawCommandTests
    {
        private ICreateLotteryDrawCommand _command;

        [SetUp]
        public void Setup()
        {
            _command = new CreateLotteryDrawCommand(() => new LotteryDrawWithResults());
        }

        [TestCase(null)]
        [TestCase(123)]
        [TestCase("BillyWasHere")]
        public void Execute_WorksAsExpected_With_BadData(object value)
        {
            Assert.DoesNotThrow(() => _command.Execute(value));
            Assert.That(_command.HasError);
        }

        [Test]
        public void Execute_WorksAsExpected()
        {
            var lotteryData = new Models.Models.LotteryDraw(new RangePrimary {Minimum = 1, Maximum = 49},
                new RangeSecondary {Minimum = 1, Maximum = 10})
            {
                Name = "49s",
                Description = "49s Lottery",
                DateOfDraw = new DateTime(2016, 11, 23),
                TotalPrimaryNumbers = 5,
                TotalSecondaryNumbers = 2
            };

            _command.Execute(lotteryData);

            Assert.That(_command.Value, Is.Not.Null);
            Assert.That(_command.HasError, Is.False);

            Assert.IsInstanceOf<ILotteryDrawWithResults>(_command.Value);
        }
    }
}
