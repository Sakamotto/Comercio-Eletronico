export class Endereco {
    constructor(){
    }
    public Id?: number;
    public Cidade?: string;
    public Estado?: string;
    public Bairro?: string;
    public Cep?: string;
}


export class Cliente
{
    public Nome: string;
    public Sobrenome: string;
    public DataNascimento: Date;
    public Cpf: string;
    public Email: string;
    public Senha: string
    public Endereco?: Endereco = new Endereco();
}