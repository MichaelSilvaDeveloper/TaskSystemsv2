using System.ComponentModel;

namespace TaskSystemsV2.Enums
{
    public enum StatusTask
    {
        [Description("Pendente")]
        Pending = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluída")]
        Concluded = 3
    }
}