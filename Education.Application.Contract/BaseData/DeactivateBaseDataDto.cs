using Epc.Application.Command;

namespace Education.Application.Contract.BaseData;

public class DeactivateBaseDataDto(int id):ICommand
{
    public int Id { get; set; } = (id);
}