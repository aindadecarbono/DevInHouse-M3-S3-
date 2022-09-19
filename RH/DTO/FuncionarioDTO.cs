using Enum;
namespace DTO;

public class FuncionarioDTO
{


  public string Nome { get; set; }
  public int Senha { get; set; }
  public Permissoes Permissao { get; set; }
  public double Salario { get; set; }


}
