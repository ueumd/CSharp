using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum OperationCode : byte
    {
        Default,
        Login,
        Register,
        CreateRole,

        EnterRoom,
        LeaveRoom,
        SyncPosition,
        GetPosition,
        GetMyPosition
    }

    public enum ReturnCode : short
    {
        Success,
        Failed,
        Data,
    }

    public enum LoginCode : byte
    {
        Username,
        Password,
    }
}
