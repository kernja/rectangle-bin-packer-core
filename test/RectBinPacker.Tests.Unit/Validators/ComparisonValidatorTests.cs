using Moq;
using RectBinPacker.Interfaces;
using RectBinPacker.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace RectBinPacker.Tests.Unit.Validators
{
    public class ComparisonValidatorTests
    {
        protected string errorMessage;
        protected string parameterName;

        protected const int ConstNormalNumber = 5;
        protected const int ConstLargeNumber = 8;
        protected const int ConstSmallNumber = 3;

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

        private IAtlas<IItem> MockNormalAtlas()
        {
            return CreateMockAtlas(ConstNormalNumber, ConstNormalNumber, ConstNormalNumber, ConstNormalNumber, ConstNormalNumber, ConstNormalNumber, ConstNormalNumber);
        }

        #region EQUAL
        protected bool EqualTo_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {
            validator.Comparison = ECompareType.EQUAL;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool EqualTo_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {
            validator.Comparison = ECompareType.EQUAL;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool EqualTo_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {
            validator.Comparison = ECompareType.EQUAL;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

        #region NOTEQUAL
        protected bool NotEqualTo_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.NOTEQUAL;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool NotEqualTo_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.NOTEQUAL;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool NotEqualTo_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.NOTEQUAL;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

        #region LESSTHAN
        protected bool LessThan_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHAN;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool LessThan_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHAN;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool LessThan_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHAN;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

        #region LESSTHANEQUALTO
        protected bool LessThanEqualTo_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHANEQUALTO;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool LessThanEqualTo_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHANEQUALTO;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool LessThanEqualTo_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.LESSTHANEQUALTO;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

        #region GREATERTHAN
        protected bool GreaterThan_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHAN;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool GreaterThan_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHAN;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool GreaterThan_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHAN;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

        #region GREATERTHANEQUALTO
        protected bool GreaterThanEqualTo_SameValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHANEQUALTO;
            validator.Value = ConstNormalNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool GreaterThanEqualTo_GreaterValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHANEQUALTO;
            validator.Value = ConstLargeNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }

        protected bool GreaterThanEqualTo_SmallerValue<T>(T validator, out string parameterName, out string errorMessage) where T : ComparisonValidator, IValidator
        {

            validator.Comparison = ECompareType.GREATERTHANEQUALTO;
            validator.Value = ConstSmallNumber;

            return validator.Validate(MockNormalAtlas(), out parameterName, out errorMessage);
        }
        #endregion

       
    }
}
