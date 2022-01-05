using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CreateContainersBatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomProducerTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void random_generator_follow_rules()
        {
            const int howMany = 1000;
            var generator = new RandomContainerProducer();
            var mock = new MockPersister(howMany);
            generator.GenerateAndSave(howMany, mock);
            mock.VerifyExpectations();
        }

        public class MockPersister : IContainerPersisterService
        {
            List<int> hashcodes;
            public MockPersister(int expectedPersistCount)
            {
                this.expectedPersistCount = expectedPersistCount;
            }
            int expectedPersistCount;
            int beginCalled = 0;
            int endCalled = 0;
            bool wrongOrder;
            bool followRules = true;
            public void BeginPersistence()
            {
                if (endCalled > 0)
                    wrongOrder = true;
                beginCalled++;
            }

            public void EndPersistence()
            {
                endCalled++;
            }

            public void Persist(string containerCode, string containerType, DateTime hireDate)
            {

                if (!Regex.IsMatch(containerCode, @"^MS[A-Z]U\d{7}$"))
                    followRules = false;
                hashcodes.Add(containerCode.GetHashCode() ^ containerType.GetHashCode() ^ hireDate.GetHashCode());
                expectedPersistCount--;
                var span = DateTime.Today - hireDate.Date;
                if (span.TotalDays > 120 || span.TotalDays < 0)
                    followRules = false;
                switch (containerType)
                {
                    case "20 DRY VAN":
                    case "40 DRY VAN":
                    case "20 HIGH CUBE":
                    case "40 HIGH CUBE":
                    default:followRules = false;
                        break;
                }
            }

            internal void VerifyExpectations()
            {
                if (wrongOrder)
                    throw new Exception("Wrong begin/end order");
                if (beginCalled > 1 || endCalled > 1)
                    throw new Exception("begin or end called too many times");
                if (beginCalled == 0 || endCalled==0)
                    throw new Exception("begin or end not called");
                if (!followRules)
                    throw new Exception("random generation rules not respected");
                if (expectedPersistCount > 0)
                    throw new Exception("persist not called enough");
                if( expectedPersistCount < 0)
                    throw new Exception("persist called too many times");
                var avg = 0;
                foreach (var k in hashcodes)
                {
                    avg += k;
                }
                avg /= hashcodes.Count;
                double stddev=0;
                foreach (var k in hashcodes)
                {
                    stddev += Math.Pow(k-avg,2);
                }
                stddev = Math.Sqrt(stddev / hashcodes.Count);
                if(stddev<2000000)
                    throw new Exception("data does not seems to be random");

            }
        }
    }
    }
