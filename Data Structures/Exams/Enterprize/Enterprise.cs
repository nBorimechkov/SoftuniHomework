using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enterprise : IEnterprise
{
    private Dictionary<Guid, Employee> byID = new Dictionary<Guid, Employee>();
    private Dictionary<double, List<Employee>> bySalary = new Dictionary<double, List<Employee>>();
    private Dictionary<Position, List<Employee>> byPosititon = new Dictionary<Position, List<Employee>>();

    public int Count
    {
        get
        {
            return this.byID.Count;
        }
    }

    public void Add(Employee employee)
    {
        this.byID.Add(employee.Id, employee);

        if (!this.bySalary.ContainsKey(employee.Salary))
        {
            this.bySalary.Add(employee.Salary, new List<Employee>());
        }
        this.bySalary[employee.Salary].Add(employee);

        if (!this.byPosititon.ContainsKey(employee.Position))
        {
            this.byPosititon.Add(employee.Position, new List<Employee>());
        }
        this.byPosititon[employee.Position].Add(employee);
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (!this.byID.ContainsKey(guid))
        {
            return false;
        }
        Employee changedEmployee = this.Get(guid);
        this.byID[guid] = employee;

        int index = this.bySalary[employee.Salary].IndexOf(changedEmployee);
        this.bySalary[employee.Salary][index] = employee;

        index = this.byPosititon[employee.Position].IndexOf(changedEmployee);
        this.byPosititon[employee.Position][index] = employee;

        return true;
    }

    public bool Contains(Guid guid)
    {
        return this.byID.ContainsKey(guid);
    }

    public bool Contains(Employee employee)
    {
        return this.byID.ContainsKey(employee.Id);
    }

    public bool Fire(Guid guid)
    {
        if (!this.byID.ContainsKey(guid))
        {
            return false;
        }
        Employee toFire = this.Get(guid);
        this.byID.Remove(guid);

        this.bySalary[toFire.Salary].Remove(toFire);

        this.byPosititon[toFire.Position].Remove(toFire);

        return true;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (!this.byID.ContainsKey(guid))
        {
            throw new ArgumentException();
        }
        return this.byID[guid];
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        return this.byPosititon[position];
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        List<Employee> result = new List<Employee>();

        foreach (var key in this.bySalary.Keys.Where(x => x >= minSalary))
        {
            result.AddRange(this.bySalary[key]);
        }

        if (result.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        IEnumerable<Employee> result = this.byID.Values.Where(employee => employee.Salary == salary && employee.Position == position);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }
        return result;
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        IEnumerable<Employee> result = this.byID.Values.Where(employee => employee.Salary >= minSalary && employee.Position == position);

        return result;
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach (var employee in this.byID.Values)
        {
            yield return employee;
        }
    }

    public Position PositionByGuid(Guid guid)
    {
        return this.byID[guid].Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        bool result = false;
        foreach (var employee in this.byID.Values.Where(employee => months <= DateTime.Now.Month - employee.HireDate.Month))
        {
            result = true;
            employee.Salary = ((employee.Salary / 100) * percent) + employee.Salary;
        }
        return result;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return this.byID.Values.Where(x => x.FirstName == firstName);
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        return this.byID.Values.Where(employee => employee.FirstName == firstName && employee.Position == position);
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        List<Employee> result = new List<Employee>();

        foreach (var position in positions)
        {
            result.AddRange(this.byPosititon[position]);
        }
        return result;
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        List<Employee> result = new List<Employee>();

        foreach (var salary in this.bySalary.Keys.Where(salary => salary >= minSalary && salary <= maxSalary))
        {
            result.AddRange(this.bySalary[salary]);
        }
        return result;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private Employee Get(Guid id)
    {
        return this.byID[id];
    }
}

