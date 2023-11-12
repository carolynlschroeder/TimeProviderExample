using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProviderExampleTests
{
    public class OfficeTest1
    {
        public class MondayAt8Provider : TimeProvider
        {
            public override DateTimeOffset GetUtcNow()
            {
                return new DateTimeOffset(2023, 11, 13, 14, 0, 0, TimeSpan.Zero);
            }

            public override TimeZoneInfo LocalTimeZone
            {
                get
                {
                    return TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                }


            }
        }
        [Fact]
        public void OfficeIsOpenMondayAt8()
        {
            var mondayProvider = new MondayAt8Provider();
            var office = new Office(mondayProvider);
            Assert.True(office.IsOpen());
        }
    }

    public class OfficeTest2
    {
        public class
            SaturdayProvider : TimeProvider
        {
            public override DateTimeOffset GetUtcNow()
            {
                return new DateTimeOffset(2023, 11, 11, 6, 0, 0, TimeSpan.Zero);
            }

            public override TimeZoneInfo LocalTimeZone
            {
                get
                {
                    return TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                }


            }
        }

            [Fact]
            public void OfficeIsNotOpenSaturday()
            {
                var saturdayProvider = new SaturdayProvider();
                var office = new Office(saturdayProvider);
                Assert.False(office.IsOpen());
            }

        }
}

