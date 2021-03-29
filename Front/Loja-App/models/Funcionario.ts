import { Loja } from "./Loja";
import { Telefone } from "./Telefone";

export interface Funcionario {
  id: number;
  nome: string;
  cpf: string;
  email: string;
  lojaId: number;
  loja: Loja;
  telefones: Telefone;
}
