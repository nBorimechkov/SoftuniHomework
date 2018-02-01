using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
class DummyTests
{
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        Axe axe = new Axe(5, 5);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.AreEqual(5, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsException()
    {
        Axe axe = new Axe(5, 5);
        Dummy dummy = new Dummy(0, 10);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }

    [Test]
    public void DeadDummyGivesExperience()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void LivingDummyDoesNotGiveExperience()
    {
        Dummy dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() =>dummy.GiveExperience());
    }
}

