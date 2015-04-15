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
            Replicate Replicate = new StringReplicate()
            {
                Name = "localVariable",
                Type = "System.String",
                Value = "test",
                IsClass = true
            };

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual("Dim localVariable As System.String = \"test\"", result);
        }

        [TestMethod]
        public void GetDecimal()
        {
            Replicate Replicate = new SimpleReplicate()
            {
                Name = "localVariable",
                Type = "System.Decimal",
                Value = "12,35"
            };

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual("Dim localVariable As System.Decimal = 12.35", result);
        }

        [TestMethod]
        public void GetClass()
        {
            
            Replicate Replicate = new ClassReplicate()
            {
                Name = "aClass",
                Type = "ConsoleApplication1.Program.A",
                Value = "{ConsoleApplication1.Program.A}",
                IsClass = true,
                ConstructorParametersCount = 0
            };

            Replicate.Members = new System.Collections.Generic.List<Replicate>();

            Replicate.Members.Add(new StringReplicate()
            {
                Name = "s",
                Type = "System.String",
                Value = "s1",
                IsClass = true
            });

            Replicate.Members.Add(new SimpleReplicate()
            {
                Name = "d",
                Type = "System.Decimal",
                Value = "12.45M",
                IsClass = false
            });

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual(1941479115, result.GetHashCode());
        }

        [TestMethod]
        public void GetClassWithConstructor()
        {

            Replicate Replicate = new ClassReplicate()
            {
                Name = "aClass",
                Type = "ConsoleApplication1.Program.A",
                Value = "{ConsoleApplication1.Program.A}",
                IsClass = true,
                ConstructorParametersCount = 1
            };

            Replicate.Members = new System.Collections.Generic.List<Replicate>();

            Replicate.Members.Add(new StringReplicate()
            {
                Name = "s",
                Type = "System.String",
                Value = "s1",
                IsClass = true
            });

            Replicate.Members.Add(new SimpleReplicate()
            {
                Name = "d",
                Type = "System.Decimal",
                Value = "12.45M",
                IsClass = false
            });

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual(1714081736, result.GetHashCode());
        }

        [TestMethod]
        public void GetClassWithConstructors()
        {

            Replicate Replicate = new ClassReplicate()
            {
                Name = "aClass",
                Type = "ConsoleApplication1.Program.A",
                Value = "{ConsoleApplication1.Program.A}",
                IsClass = true,
                ConstructorParametersCount = 2
            };

            Replicate.Members = new System.Collections.Generic.List<Replicate>();

            Replicate.Members.Add(new StringReplicate()
            {
                Name = "s",
                Type = "System.String",
                Value = "s1",
                IsClass = true
            });

            Replicate.Members.Add(new SimpleReplicate()
            {
                Name = "d",
                Type = "System.Decimal",
                Value = "12.45M",
                IsClass = false
            });

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual(535008086, result.GetHashCode());
        }

        [TestMethod]
        public void GetArray()
        {

            Replicate Replicate = new ArrayReplicate()
            {
                Name = "anArray",
                Type = "ConsoleApplication1.Program.A()",
                Value = "{ConsoleApplication1.Program.A}",
                IsClass = true,
                ConstructorParametersCount = 2
            };

            Replicate.Members = new System.Collections.Generic.List<Replicate>();

            Replicate.Members.Add(new StringReplicate()
            {
                Name = "s",
                Type = "System.String",
                Value = "s1",
                IsClass = true
            });

            Replicate.Members.Add(new SimpleReplicate()
            {
                Name = "d",
                Type = "System.Decimal",
                Value = "12.45M",
                IsClass = false
            });

            var replicator = new Replicator();

            var result = replicator.GenerateDeclaration(Replicate);

            Assert.AreEqual(535008086, result.GetHashCode());
        }
    }
}
