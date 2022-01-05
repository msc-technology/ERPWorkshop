using System;
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
            var generator = new RandomContainerProducer();
            var mock = new MockPersister();
            generator.GenerateAndSave(1000, mock);
            mock.VerifyExpectations();
        }

        public class MockPersister : IContainerPersisterService
        {
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
                throw new NotImplementedException();
            }

            internal void VerifyExpectations()
            {
                if (wrongOrder)
                    throw new Exception("Wrong begin/end order");
                if (beginCalled > 1 || endCalled > 1)
                    throw new Exception("begin or end called too many times");

            }
        }
    }
    }
