using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorPadi.Core.Service.Interface;

namespace TailorPadi.Core.Service.Concrete;
public class TestService : ITestService
{
    public IEnumerable<TestDto> GetNames()
    {
        var names = new List<TestDto>
        {
            new TestDto{ Id=3,Name="Azeez"},
            new TestDto{ Id=1,Name="Bello"},
            new TestDto{ Id=2,Name="Omotosho"},

        };
        return names;
    }
}

public class TestDto
{
    public int Id { get; internal set; }
    public string? Name { get; internal set; }
}