import { Funcionario } from "./Funcionario";

export interface Loja {
  id: number;
  cnpj: string;
  razaoSocial: string;
  nomeFantasia: string;
  telefone: string;
  funcionarios: Funcionario[];
}
