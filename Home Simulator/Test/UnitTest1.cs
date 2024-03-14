using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Simulator.Models.ProfileModels;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public void TestChildUser()
        {
            var user = new User("child", 1, UserType.Child);
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo("child"));
                Assert.That(user.Age, Is.EqualTo(1));
                Assert.That(user.Type, Is.EqualTo(UserType.Child));
                Assert.That(user.HasAccessToLights, Is.EqualTo(true));
                Assert.That(user.HasAccessToDoors, Is.EqualTo(false));
                Assert.That(user.HasAccessToWindows, Is.EqualTo(false));
            });
        }

        [Test]
        public void TestFatherUser()
        {
            var user = new User("father", 1, UserType.Father);
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo("father"));
                Assert.That(user.Age, Is.EqualTo(1));
                Assert.That(user.Type, Is.EqualTo(UserType.Father));
                Assert.That(user.HasAccessToLights, Is.EqualTo(true));
                Assert.That(user.HasAccessToDoors, Is.EqualTo(true));
                Assert.That(user.HasAccessToWindows, Is.EqualTo(true));
            });
        }

        [Test]
        public void TestMotherUser()
        {
            var user = new User("mother", 1, UserType.Mother);
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo("mother"));
                Assert.That(user.Age, Is.EqualTo(1));
                Assert.That(user.Type, Is.EqualTo(UserType.Mother));
                Assert.That(user.HasAccessToLights, Is.EqualTo(true));
                Assert.That(user.HasAccessToDoors, Is.EqualTo(true));
                Assert.That(user.HasAccessToWindows, Is.EqualTo(true));
            });
        }

        [Test]
        public void TestGuestUser()
        {
            var user = new User("guest", 1, UserType.Guest);
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo("guest"));
                Assert.That(user.Age, Is.EqualTo(1));
                Assert.That(user.Type, Is.EqualTo(UserType.Guest));
                Assert.That(user.HasAccessToLights, Is.EqualTo(true));
                Assert.That(user.HasAccessToDoors, Is.EqualTo(false));
                Assert.That(user.HasAccessToWindows, Is.EqualTo(false));
            });
        }


        [Test]
        public void TestStrangerUSer()
        {
            var user = new User("stranger", 1, UserType.Stranger);
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo("stranger"));
                Assert.That(user.Age, Is.EqualTo(1));
                Assert.That(user.Type, Is.EqualTo(UserType.Stranger));
                Assert.That(user.HasAccessToLights, Is.EqualTo(false));
                Assert.That(user.HasAccessToDoors, Is.EqualTo(false));
                Assert.That(user.HasAccessToWindows, Is.EqualTo(false));
            });
        }




    }


}