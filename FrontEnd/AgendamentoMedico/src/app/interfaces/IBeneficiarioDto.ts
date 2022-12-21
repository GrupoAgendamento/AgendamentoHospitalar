export interface IBeneficiarioDto {
    idBeneficiario: number,
    nome: string,
    cpf: string,
    telefone?: string,
    email: string,
    endereco?: string,
    numeroCarteirinha: string,
    senha: string,
}