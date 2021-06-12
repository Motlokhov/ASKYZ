using System.Data.Common;

namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IConnection
    {
        DbConnection GetConnection();
    }
}
