using Enum;
namespace Models;

public class Funcionario
{

  public int Id { get; set; }
  public string Nome { get; set; }
  public int Senha { get; set; }
  public Permissoes Permissao { get; set; }
  public double Salario { get; set; }


}
