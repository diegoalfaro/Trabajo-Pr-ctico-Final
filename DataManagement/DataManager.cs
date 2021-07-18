using DataManagement.Common;
using DataManagement.Context;

namespace DataManagement
{
    public class DataManager: GenericUnitOfWork<DataContext>, IUnitOfWork<DataContext>
    {
        
    }
}
