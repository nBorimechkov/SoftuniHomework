using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.AreEqual(9, axe.DurabilityPoints);
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        Axe axe = new Axe(3, 1);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Exception ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.AreEqual("Axe is broken.", ex.Message);
    }
}

