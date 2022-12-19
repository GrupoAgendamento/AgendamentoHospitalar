export interface IHospitalDto {
    id: number,
    nome: string,
    cnpj?: string,
    endereco?: string,
    telefone?: string,
    cnes?: string,
    ativo: boolean
}