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
                Name = "aClass",
                Type = "ConsoleApplication1.Program.A",
                Value = "{ConsoleApplication1.Program.A}",
                IsClass = true
            };

            replicationObject.Properties = new System.Collections.Generic.List<ReplicationObject>();

            replicationObject.Properties.Add(new ReplicationObject()
            {
                Name = "s",
                Type = "System.String",
                Value = "s1",
                IsClass = true
            });

            replicationObject.Properties.Add(new ReplicationObject()
            {
                Name = "d",
                Type = "System.Decimal",
                Value = "12.45M",
                IsClass = false
            });

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(replicationObject);

            Assert.AreEqual(1921771820, result.GetHashCode());
        }

        //private class A
        //{
        //    public string s = "s1";
        //    public decimal d = 12.456M;
        //}
    }
}
