using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorPadi.Core.Service.Concrete;

namespace TailorPadi.Core.Service.Interface;
public interface ITestService
{
    IEnumerable<TestDto> GetNames();
}
