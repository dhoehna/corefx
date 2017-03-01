using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Resources;
namespace System.Configuration
{
    public class SRTests
    {
        [Fact]
        public void GetResourceString_ResourceKeyNull()
        {
            /*
             *System.Resources.ResourceManager.GetString throws an ArgumentNullException if name is null.
             * In this case, name is ResourceKey
             */
            Assert.Throws<ArgumentNullException>(() => SR.GetResourceString(null, ""));
        }

        [Fact]
        public void GetResourceString_ResourceDoesNotExist()
        {
            Assert.Equal(null, SR.GetResourceString("Hello", "Hi"));
        }

        [Fact]
        public void Format_NullArgs_NoPlaceholders()
        {
            Assert.Equal("Hello", SR.Format("Hello", null));
        }

        [Fact]
        public void Format_NullArgsWithPlaceHolders()
        {
            Assert.Equal("Hello {0}", SR.Format("Hello {0}", null));
        }

        [Fact]
        public void Format_NotNullArgs()
        {
            Assert.Equal("Hello, my name is Joe McCool McAwesome McSenior", SR.Format("Hello, my name is {0} {1} {2} {3}", "Joe", "McCool", "McAwesome", "McSenior"));
        }

        [Fact]
        public void Format_OneObjectAsString()
        {
            Assert.Equal("Hello wonderful", SR.Format("Hello {0}", "wonderful"));
        }

        [Fact]
        public void Format_OneObjectAsInt()
        {
            Assert.Equal("Hello 22", SR.Format("Hello {0}", 22));
        }


        [Fact]
        public void Format_TwoObjects()
        {
            Assert.Equal("Hello 22 24", SR.Format("Hello {0} {1}", 22, 24));
        }

        [Fact]
        public void Format_ThreeObjects()
        {
            Assert.Equal("YOLO I AM AWESOME", SR.Format("YOLO {0} {1} {2}", "I", "AM", "AWESOME"));
        }

    }
}
