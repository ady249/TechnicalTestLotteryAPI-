using System;
using System.Collections.Generic;
using System.Diagnostics;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.BusinessLogic.WinningNumberRules.Primary;
using LotteryDraw.Models.Interfaces.Models;
using LotteryDraw.Models.Models;
using LotteryDraw.Repository.Memory.Commands;
using LotteryDraw.Repository.Memory.Interfaces.Commands;
using LotteryDraw.Tracer.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace LotteryDraw.Repository.Integration.Commands
{
    [TestFixture]
    public class UpdateSpecificLotteryDrawCommandTests
    {
        private IUpdateSpecificLotteryDrawCommand _command;
        private ITracer _tracer;

        [SetUp]
        public void Setup()
        {
            _tracer = Substitute.For<ITracer>();
            _tracer.WriteLine(Arg.Do<string>(x => Trace.WriteLine(x)));

            _command = new UpdateSpecificLotteryDrawCommand(_tracer, new List<IWinningNumbersRule> {new IsPrimaryWithinBounds(), new IsPrimaryWithinRange(), new PrimaryHasData()});
        }

        [Test]
        public void Execute_WorksAsExpected_With_NullData()
        {
            var rule = Substitute.For<IWinningNumbersRule>();
            rule.HasError.Returns(true);

            var command = new UpdateSpecificLotteryDrawCommand(_tracer, new List <IWinningNumbersRule> {rule});

            Assert.DoesNotThrow(() => command.Execute(Substitute.For<ILotteryDrawWithResults>(), null));
        }

        [Test]
        public void Execute_WorksAsExpected()
        {
            var lotteryDataWithResults = new LotteryDrawWithResults
            {
                Name = "49s",
                Description = "49s Lottery",
                DateOfDraw = new DateTime(2016, 11, 23),
                TotalPrimaryNumbers = 5,
                RangePrimary = new RangePrimary { Minimum = 1, Maximum = 49},
                TotalSecondaryNumbers = 2,
                RangeSecondary = new RangeSecondary { Minimum = 1, Maximum = 10}
            };

            var winningPrimaryNumbersList = new List<int> {7, 23, 5, 12, 49};
            var winningSecondaryNumbersList = new List<int> {4, 8};

            var results = new WinningNumbers
            {
                WinningPrimaryNumbers = winningPrimaryNumbersList,
                WinningSecondaryNumbers = winningSecondaryNumbersList
            };

            _command.Execute(lotteryDataWithResults, results);

            CollectionAssert.AreEquivalent(winningPrimaryNumbersList, lotteryDataWithResults.WinningPrimaryNumbers);
            CollectionAssert.AreEquivalent(winningSecondaryNumbersList, lotteryDataWithResults.WinningSecondaryNumbers);
        }

        [Test]
        public void Execute_WorksAsExpected_WithBadData()
        {
            var lotteryDataWithResults = new LotteryDrawWithResults
            {
                Name = "49s",
                Description = "49s Lottery",
                DateOfDraw = new DateTime(2016, 11, 23),
                TotalPrimaryNumbers = 5,
                RangePrimary = new RangePrimary { Minimum = 1, Maximum = 49 },
                TotalSecondaryNumbers = 2,
                RangeSecondary = new RangeSecondary { Minimum = 1, Maximum = 10 }
            };

            var winningPrimaryNumbersList = new List<int> { 7, 23, 5, 12, 50 };
            var winningSecondaryNumbersList = new List<int> { 4, 8 };

            var results = new WinningNumbers
            {
                WinningPrimaryNumbers = winningPrimaryNumbersList,
                WinningSecondaryNumbers = winningSecondaryNumbersList
            };

            _command.Execute(lotteryDataWithResults, results);

            Assert.That(_command.HasError);
        }
    }
}
