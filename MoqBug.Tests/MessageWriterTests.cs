using AmbientContext.DateTimeService;

using Moq;

using MoqBug.Tests.Customizations;

using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

using Xunit;

namespace MoqBug.Tests
{
    public class MessageWriterTests
    {
        [Theory, AutoMoqData]
        public void Write_Always_CallsDateTimeService(
            DateTimeFixture dateTimeFixture,
            MessageWriter sut,
            string message)
        {
            sut.Write(message);

            dateTimeFixture.DateTimeMock.Verify(dt => dt.Now, Times.Once());
        }

        [Theory, AutoData]
        public void Write_Always_CallsDateTimeService_Manual(
            string message)
        {
            IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());
            Mock<IDateTimeService> dateTimeServiceMock = fixture.Freeze<Mock<IDateTimeService>>();

            MessageWriter sut = fixture.Create<MessageWriter>();
            sut.DateTimeProvider.Instance = dateTimeServiceMock.Object;

            sut.Write(message);

            dateTimeServiceMock.Verify(m => m.Now, Times.Once());
        }
    }
}
