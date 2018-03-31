using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    private int energy;
    private OrderedBag<Invader> invaders;

    public Computer(int energy)
    {
        if (energy < 0)
        {
            throw new ArgumentException();
        }
        this.energy = energy;
        this.invaders = new OrderedBag<Invader>();
    }

    public int Energy
    {
        get
        {
            if (this.energy > 0)
            {
                return 0;
            }
            return this.energy;
        }
        set
        {
            this.energy = value;
        }
    }

    public void Skip(int turns)
    {
        foreach (var invader in this.invaders)
        {
            invader.Distance -= turns;
        }
        if (this.invaders.Any(i => i.Distance <= 0))
        {
            var arrived = this.invaders.Where(i => i.Distance <= 0);
            foreach (var invader in arrived)
            {
                this.energy -= invader.Damage;
                this.invaders.Remove(invader);
            }
        }
    }

    public void AddInvader(Invader invader)
    {
        this.invaders.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        var toDestroy = this.invaders.OrderBy(i => i.Distance).ThenByDescending(i => i.Damage);
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.invaders.RemoveAll(i => i.Distance <= radius);
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.invaders.ToList();
    }
}
