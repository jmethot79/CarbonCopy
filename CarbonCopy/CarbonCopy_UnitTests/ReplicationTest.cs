using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zinc.CarbonCopy.Replication;

namespace CarbonCopy_UnitTests
{
    [TestClass]
    public class ReplicationTest
    {
        [TestMethod]
        public void GetString()
        {
            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = "localVariable",
                Type = "System.String",
                Value = "test",
                IsClass = true
            };

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(replicationObject);

            Assert.AreEqual("Dim localVariable As System.String = \"test\"", result);
        }

        [TestMethod]
        public void GetDecimal()
        {
            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = "localVariable",
                Type = "System.Decimal",
                Value = "12,35"
            };

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(replicationObject);

            Assert.AreEqual("Dim localVariable As System.Decimal = 12.35", result);
        }

        [TestMethod]
        public void GetClass()
        {
            
            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = "a",
                Type = "System.Decimal",
                Value = "12,35"
            };

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(replicationObject);

            Assert.AreEqual("Dim localVariable As System.Decimal = 12.35", result);
        }

        private class A
        {
            public string s = "s1";
            public decimal d = 12.456M;
        }
    }
}
