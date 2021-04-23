using Microsoft.Extensions.Logging;
using Moq;
using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver;
using RectBinPacker.Validators;
using System.Collections.Generic;
using Xunit;

namespace RectBinPacker.Tests.Integration
{
    public class SolverServiceTests
    {
        private IItem CreateNewMockIItem(int width, int height)
        {
            var item = new Mock<IItem>();
            item.SetupGet(x => x.Height).Returns(height);
            item.SetupGet(x => x.Width).Returns(width);
            return item.Object;
        }

        private IList<IItem> CreateMockIItems()
        {
            // generate our test data
            var mockItems = new List<IItem>
            {
                CreateNewMockIItem(32, 32),
                CreateNewMockIItem(32, 32),
                CreateNewMockIItem(32, 32),
                CreateNewMockIItem(32, 32)

            };

            return mockItems;
        }

        [Fact]
        public void FourItems_NoValidators_SuccessResult()
        {
            // configure our validators
            // there are none
            var moqValidators = new Mock<IDefaultValidators>();
            moqValidators.Setup(m => m.GetValidators()).Returns(new List<IValidator>());

            // configure our logging
            var moqLogging = new Mock<ILogger<ISolverService>>();

            // create our system
            var sut = new SolverService(moqLogging.Object, moqValidators.Object);

            // solve
            IAtlas<IItem> sutAtlas;
            bool sutResult = sut.Solve<IItem>(64, 64, CreateMockIItems(), out sutAtlas);

            // ensure we have an atlas
            Assert.True(sutResult);
            Assert.NotNull(sutAtlas);

            // get our asset items
            var sutAtlasItems = sutAtlas.GetConfiguredItems();

            // ensure we have a count of 4
            Assert.Equal(4, sutAtlasItems.Count);

            // compare the item placement
            // items 0 - 3
            Assert.Equal(0, sutAtlasItems[0].X);
            Assert.Equal(0, sutAtlasItems[0].Y);
            Assert.Equal(1, sutAtlasItems[0].Scale);
            Assert.Equal(32, sutAtlasItems[0].Width);
            Assert.Equal(32, sutAtlasItems[0].Height);

            Assert.Equal(32, sutAtlasItems[1].X);
            Assert.Equal(0, sutAtlasItems[1].Y);
            Assert.Equal(1, sutAtlasItems[1].Scale);
            Assert.Equal(32, sutAtlasItems[1].Width);
            Assert.Equal(32, sutAtlasItems[1].Height);

            Assert.Equal(0, sutAtlasItems[2].X);
            Assert.Equal(32, sutAtlasItems[2].Y);
            Assert.Equal(1, sutAtlasItems[2].Scale);
            Assert.Equal(32, sutAtlasItems[2].Width);
            Assert.Equal(32, sutAtlasItems[2].Height);

            Assert.Equal(32, sutAtlasItems[3].X);
            Assert.Equal(32, sutAtlasItems[3].Y);
            Assert.Equal(1, sutAtlasItems[3].Scale);
            Assert.Equal(32, sutAtlasItems[3].Width);
            Assert.Equal(32, sutAtlasItems[3].Height);
        }

        [Fact]
        public void NoItems_ItemCountValidator_GreaterThanZero_FailureResult()
        {
            // configure our validators
            // there are none
            var moqValidators = new Mock<IDefaultValidators>();
            moqValidators.Setup(m => m.GetValidators()).Returns(new List<IValidator> { new ItemCountValidator { Comparison = ECompareType.GREATERTHAN, Value = 0 } });

            // configure our logging
            var moqLogging = new Mock<ILogger<ISolverService>>();

            // create our system
            var sut = new SolverService(moqLogging.Object, moqValidators.Object);

            // solve
            IAtlas<IItem> sutAtlas;
            bool sutResult = sut.Solve<IItem>(64, 64, new List<IItem>(), out sutAtlas);

            Assert.False(sutResult);
            Assert.Null(sutAtlas);
        }
    }
}
