﻿using NUnit.Framework;
using WellFired.Guacamole.Types;

namespace WellFired.Guacamole.Tests.Layout.CenterAndExpandChildren
{
    [TestFixture]
    public class Given_AnVerticalAdjacentLayout_WithTwoChildren
    {
        [Test]
        public void WithOneChildHCVEAndOneHEVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVE();
            var child1 = LayoutFactory.ChildWithHEVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(20));
        }
        
        [Test]
        public void WithOneChildHEVCAndOneHEVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVC();
            var child1 = LayoutFactory.ChildWithHEVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(80));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(180));
        }
        
        [Test]
        public void WithOneChildHEVEAndOneHCVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVE();
            var child1 = LayoutFactory.ChildWithHCVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(20));
        }
        
        [Test]
        public void WithOneChildHEVEAndOneHEVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVE();
            var child1 = LayoutFactory.ChildWithHEVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(100));
        }
        
        [Test]
        public void WithOneChildHCVCAndOneHEVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVC();
            var child1 = LayoutFactory.ChildWithHEVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(80));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(180));
        }
        
        [Test]
        public void WithOneChildHEVCAndOneHCVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVC();
            var child1 = LayoutFactory.ChildWithHCVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(80));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(180));
        }
        
        [Test]
        public void WithOneChildHEVEAndOneHCVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVE();
            var child1 = LayoutFactory.ChildWithHCVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(100));
        }
        
        [Test]
        public void WithOneChildHCVEAndOneHEVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVE();
            var child1 = LayoutFactory.ChildWithHEVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(100));
        }
        
        [Test]
        public void WithOneChildHCVEAndOneHCVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVE();
            var child1 = LayoutFactory.ChildWithHCVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(0));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(20));
        }
        
        [Test]
        public void WithOneChildHEVCAndOneHEVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVC();
            var child1 = LayoutFactory.ChildWithHEVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(40));
            Assert.That(child1.X, Is.EqualTo(0));
            Assert.That(child1.Y, Is.EqualTo(140));
        }
        
        [Test]
        public void WithOneChildHCVCAndOneHCVE_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVC();
            var child1 = LayoutFactory.ChildWithHCVE();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(80));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(180));
        }
        
        [Test]
        public void WithOneChildHEVCAndOneHCVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHEVC();
            var child1 = LayoutFactory.ChildWithHCVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(0));
            Assert.That(child0.Y, Is.EqualTo(40));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(140));
        }
        
        [Test]
        public void WithOneChildHCVCAndOneHCVC_When_Layout_Then_LayoutIsCorrect()
        {
            var child0 = LayoutFactory.ChildWithHCVC();
            var child1 = LayoutFactory.ChildWithHCVC();
            LayoutFactory.VerticalLayoutWith(child0, child1);
            
            Assert.That(child0.X, Is.EqualTo(20));
            Assert.That(child0.Y, Is.EqualTo(40));
            Assert.That(child1.X, Is.EqualTo(20));
            Assert.That(child1.Y, Is.EqualTo(140));
        }
    }
}