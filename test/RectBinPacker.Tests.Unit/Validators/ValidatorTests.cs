using Moq;
using RectBinPacker.Interfaces;
using RectBinPacker.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace RectBinPacker.Tests.Unit.Validators
{
    public class ValidatorTests
    {
        /*
         *   EQUAL,
        NOTEQUAL,
        LESSTHAN,
        LESSTHANEQUALTO,
        GREATERTHAN,
        GREATERTHANEQUALTO
        */
        private IAtlas<IItem> CreateMockAtlas(int stepCount, int atlasWidth, int atlasHeight, int itemWidth, int itemHeight, int itemCount, int ciScale)
        {
            // configure our item
            var moqItem = new Mock<IItem>();
            moqItem.Setup(it => it.Width).Returns(itemWidth);
            moqItem.Setup(it => it.Height).Returns(itemHeight);

            // configure our CI
            var moqCI = new Mock<IConfiguredItem<IItem>>();
            moqCI.Setup(ci => ci.Width).Returns(itemWidth);
            moqCI.Setup(ci => ci.Height).Returns(itemHeight);
            moqCI.Setup(ci => ci.Scale).Returns(ciScale);
            moqCI.Setup(ci => ci.OriginalItem).Returns(moqItem.Object);

            // create our child list
            IList<IConfiguredItem<IItem>> configuredItems = new List<IConfiguredItem<IItem>>();
            for (int i = 0; i < itemCount; i++)
            {
                configuredItems.Add(moqCI.Object);
            }

            // configure our atlas
            var moqAtlas = new Mock<IAtlas<IItem>>();
            moqAtlas.Setup(at => at.StepCount).Returns(stepCount);
            moqAtlas.Setup(at => at.Width).Returns(atlasWidth);
            moqAtlas.Setup(at => at.Height).Returns(atlasHeight);
            moqAtlas.Setup(at => at.GetConfiguredItems()).Returns(configuredItems);

            return moqAtlas.Object;
        }

        [Fact]
        public void Validator_Equal_Pass()
        {
            string parameterName;
            string errorMessage;

            var sutHeightValidator = new ItemHeightValidator { Comparison = ECompareType.EQUAL, Value = 1 };
            var sutWidthValidator = new ItemWidthValidator { Comparison = ECompareType.EQUAL, Value = 1 };
            var sutScaleValidator = new ItemScaleValidator { Comparison = ECompareType.EQUAL, Value = 1 };
            var sutStepCountValidator = new StepCountValidator { Comparison = ECompareType.EQUAL, Value = 1 };
            var sutItemCountValidator = new ItemCountValidator { Comparison = ECompareType.EQUAL, Value = 1 };
        }
    }
}
