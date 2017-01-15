using System.Collections.Generic;
using System.Diagnostics;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.BusinessLogic.WinningNumberRules.Secondary;
using LotteryDraw.Models.Interfaces.Attributes.Invariant;
using LotteryDraw.Models.Interfaces.Models;
using NSubstitute;
using NUnit.Framework;

namespace LotteryDraw.BusinessLogic.UnitTests.WinningNumberRules.Secondary
{
    [TestFixture]
    public class IsPrimaryWithinBoundsTests
    {
        private IWinningNumbersRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new IsSecondaryWithinBounds();
        }

        [Test]
        public void CheckDefaultState()
        {
            Assert.That(_rule.Sequence, Is.EqualTo(6));
            Assert.That(_rule.HasError, Is.False);
            Assert.That(_rule.ErrorMessage, Is.Null);
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithNullData()
        {
            _rule.Execute(null, null);

            Assert.That(_rule.HasError);
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithWinningDataNull()
        {
            _rule.Execute(Substitute.For<ILotteryDrawWithResults>(), null);
            Assert.That(_rule.HasError);
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithNoData()
        {
            _rule.Execute(Substitute.For<ILotteryDrawWithResults>(), Substitute.For<IWinningNumbers>());
        }

        [TestCase(0, 1, 2, ExpectedResult = true)]
        [TestCase(0, 0, 2, ExpectedResult = false)]
        [TestCase(1, 1, 10, ExpectedResult = false)]
        [TestCase(9, 1, 10, ExpectedResult = false)]
        [TestCase(10, 1, 10, ExpectedResult = false)]
        [TestCase(11, 1, 10, ExpectedResult = true)]
        [TestCase(0, 1, 11, ExpectedResult = true)]
        [TestCase(5, 1, 10, ExpectedResult = false)]
        public bool Check_Execute_WorksAsExpected_WithData(int winningNumber, int min, int max)
        {
            var range = Substitute.For<IRangeInvariant>();
            range.Minimum.Returns(min);
            range.Maximum.Returns(max);

            var data = Substitute.For<ILotteryDrawWithResults>();
            data.RangeSecondary.Returns(range);

            var winningNumbers = Substitute.For<IWinningNumbers>();
            winningNumbers.WinningSecondaryNumbers.Returns(new List<int> { winningNumber });

            _rule.Execute(data, winningNumbers);

            Trace.WriteLine(_rule.ErrorMessage);

            return _rule.HasError;
        }
    }
}
