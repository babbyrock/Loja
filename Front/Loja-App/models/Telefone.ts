import { Funcionario } from "./Funcionario";

export interface Telefone {
  id: number;
  nome: string;
  phone: string;
  funcionarioId: number;
  funcionario: Funcionario;
}
