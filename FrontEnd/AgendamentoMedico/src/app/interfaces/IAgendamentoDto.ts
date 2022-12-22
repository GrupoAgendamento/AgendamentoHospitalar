import { IBeneficiarioDto } from "./IBeneficiarioDto";
import { IEspecialidadeDto } from "./IEspecialidadeDto";
import { IHospitalDto } from "./IHospitalDto";
import { IProfissionalDto } from "./IProfissionalDto";

export interface IAgendamentoDto{
  idHospital: number;
  idEspecialidade: number;
  idProfissional: number;
  idBeneficiario: number;
  DataHoraAgendamento: Date;
  ativo: boolean;
  idBeneficiarioNavigation: IBeneficiarioDto;
  idEspecialidadeNavigation: IEspecialidadeDto;
  idHospitalNavigation: IHospitalDto;
  idProfissionalNavigation: IProfissionalDto;
}
