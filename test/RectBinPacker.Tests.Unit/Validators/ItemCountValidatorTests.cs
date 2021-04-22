using RectBinPacker.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using RectBinPacker.Interfaces;

namespace RectBinPacker.Tests.Unit.Validators
{
    public class ItemCountValidatorTests : ComparisonValidatorTests
    {

        #region EQUAL
        [Fact]
        public void EqualTo_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.EqualTo_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void EqualTo_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.EqualTo_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void EqualTo_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.EqualTo_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion

        #region NOTEQUAL
        [Fact]
        public void NotEqualTo_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.NotEqualTo_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void NotEqualTo_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.NotEqualTo_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void NotEqualTo_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.NotEqualTo_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion

        #region LESSTHAN
        [Fact]
        public void LessThan_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.LessThan_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void LessThan_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.LessThan_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void LessThan_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.LessThan_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion

        #region LESSTHANEQUALTO
        [Fact]
        public void LessThanEqualTo_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.LessThanEqualTo_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void LessThanEqualTo_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.LessThanEqualTo_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void LessThanEqualTo_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.LessThanEqualTo_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion

        #region GREATERTHAN
        [Fact]
        public void GreaterThan_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.GreaterThan_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void GreaterThan_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.GreaterThan_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void GreaterThan_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.GreaterThan_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion

        #region GREATERTHANEQUALTO
        [Fact]
        public void GreaterThanEqualTo_SameValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.GreaterThanEqualTo_SameValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void GreaterThanEqualTo_GreaterValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.False(base.GreaterThanEqualTo_GreaterValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.False(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }

        [Fact]
        public void GreaterThanEqualTo_SmallerValueTest()
        {
            string parameterName;
            string errorMessage;

            Assert.True(base.GreaterThanEqualTo_SmallerValue<ItemCountValidator>(new ItemCountValidator(), out parameterName, out errorMessage));
            Assert.True(string.IsNullOrWhiteSpace(errorMessage));
            Assert.NotNull(parameterName);
        }
        #endregion


    }
}
