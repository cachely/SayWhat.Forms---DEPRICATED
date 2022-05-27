using NUnit.Framework;
using System.Resources;
using SayWhat.Forms.Utilities;
using System.Reflection;

namespace SayWhat.Forms.Tests
{
    public class DynamicLocalizerTests
    {

        [Test]
        public void GetText_ParamIsFound_ReturnsStringValue()
        {
            //arrange
            var expectedString = "Found";
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResource", assembly));

            //act
            var result = DynamicLocalizer.GetText("FoundTestString");

            //assert
            Assert.IsNotEmpty(result);
            Assert.AreEqual(expectedString, result);
        }

#if RELEASE
        [Test]
        public void GetText_ParamIsNull_ReturnsEmptyString()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResource", assembly));

            //act
            var result = DynamicLocalizer.GetText(null);
            
            //assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetText_ParamIsNotFound_ReturnsEmptyString()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResource", assembly));

            //act
            var result = DynamicLocalizer.GetText("NotFoundTest");

            //assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetText_ParamIsNotFoundAndAlwaysThrowExceptionsIsTrue_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResource", assembly));

            //act 
            Utilities.SayWhat.Settings.AlwaysThrowExceptions = true;

            //assert
            Assert.Throws<MissingManifestResourceException>(() => DynamicLocalizer.GetText("NotFoundTest"));
        }

        [Test]
        public void GetText_ResourceIsNotFoundInReleaseAndAlwaysThrowExceptionsIsTrue_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResourceDoesNotExist", assembly));

            //act 
            Utilities.SayWhat.Settings.AlwaysThrowExceptions = true;

            //assert
            Assert.Throws<MissingManifestResourceException>(() => DynamicLocalizer.GetText("FoundTestString"));
        }
#endif


#if DEBUG
        [Test]
        public void GetText_ParamIsNotFoundInDebug_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResource", assembly));

            //act 
            //assert
            Assert.Throws<MissingManifestResourceException>(() => DynamicLocalizer.GetText("NotFoundTest"));
        }

        [Test]
        public void GetText_ResourceIsNotFoundInDebug_ThrowsException()
        {
            //arrange
            var assembly = Assembly.GetAssembly(typeof(DynamicLocalizer))!;
            Utilities.SayWhat.Settings.Initialize(new ResourceManager("SayWhat.Forms.TestResourceDoesNotExist", assembly));

            //act 
            //assert
            Assert.Throws<MissingManifestResourceException>(() => DynamicLocalizer.GetText("FoundTestString"));
        }
#endif

    }
}