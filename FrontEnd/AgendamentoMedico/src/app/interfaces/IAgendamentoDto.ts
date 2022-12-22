export interface IAgendamentoDto{
  idAgendamento: number,
  idHospital: number,
  idEspecialidade: number,
  idProfissional: number,
  idBeneficiario: number,
  dataAgendamento: Date,
  beneficiario: string,
  numeroCarteirinha: string,
  hospital: string,
  especialidade: string,
  profissional: string
}
