using AmbientContext.DateTimeService;

using Moq;

using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace MoqBug.Tests.Customizations
{
    public class DateTimeFixture
    {
        public readonly Mock<IDateTimeService> DateTimeMock = CreateDateTimeMock();

        private static Mock<IDateTimeService> CreateDateTimeMock()
        {
            IFixture fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());

            var dateTimeMock = fixture.Create<Mock<IDateTimeService>>();

            AmbientDateTimeService.Create = () => new AmbientDateTimeService() { Instance = dateTimeMock.Object };
            return dateTimeMock;
        }
    }
}